/*
    AO_HRIS - Employee Document Management
    Run once against the AO_HRIS database.
    Existing employee and employee-assignment records are not modified.
*/
IF OBJECT_ID(N'dbo.EmployeeDocumentCategory', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.EmployeeDocumentCategory
    (
        CategoryId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_EmployeeDocumentCategory PRIMARY KEY,
        CategoryCode NVARCHAR(50) NOT NULL,
        CategoryName NVARCHAR(100) NOT NULL,
        IsConfidentialDefault BIT NOT NULL CONSTRAINT DF_EmployeeDocumentCategory_Confidential DEFAULT (0),
        SortOrder INT NOT NULL CONSTRAINT DF_EmployeeDocumentCategory_SortOrder DEFAULT (0),
        IsActive BIT NOT NULL CONSTRAINT DF_EmployeeDocumentCategory_IsActive DEFAULT (1),
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_EmployeeDocumentCategory_CreatedAt DEFAULT (SYSDATETIME()),
        CONSTRAINT UQ_EmployeeDocumentCategory_Code UNIQUE (CategoryCode),
        CONSTRAINT UQ_EmployeeDocumentCategory_Name UNIQUE (CategoryName)
    );
END;
GO

IF OBJECT_ID(N'dbo.EmployeeDocument', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.EmployeeDocument
    (
        EmployeeDocumentId BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_EmployeeDocument PRIMARY KEY,
        EmployeeId INT NOT NULL,
        CompanyId INT NOT NULL,
        CategoryId INT NOT NULL,
        DocumentName NVARCHAR(200) NOT NULL,
        OriginalFileName NVARCHAR(260) NOT NULL,
        ContentType NVARCHAR(100) NOT NULL,
        FileExtension NVARCHAR(20) NULL,
        FileSizeBytes BIGINT NOT NULL,
        Sha256Hash CHAR(64) NOT NULL,
        FileData VARBINARY(MAX) NOT NULL,
        IssueDate DATE NULL,
        ExpiryDate DATE NULL,
        IsConfidential BIT NOT NULL CONSTRAINT DF_EmployeeDocument_IsConfidential DEFAULT (0),
        Notes NVARCHAR(1000) NULL,
        UploadedByUserId INT NOT NULL,
        UploadedAt DATETIME2(0) NOT NULL CONSTRAINT DF_EmployeeDocument_UploadedAt DEFAULT (SYSDATETIME()),
        UpdatedByUserId INT NULL,
        UpdatedAt DATETIME2(0) NULL,
        IsActive BIT NOT NULL CONSTRAINT DF_EmployeeDocument_IsActive DEFAULT (1),
        CONSTRAINT FK_EmployeeDocument_EmployeeRecord FOREIGN KEY (EmployeeId) REFERENCES dbo.EmployeeRecord(EmployeeId),
        CONSTRAINT FK_EmployeeDocument_Company FOREIGN KEY (CompanyId) REFERENCES dbo.Company(CompanyId),
        CONSTRAINT FK_EmployeeDocument_Category FOREIGN KEY (CategoryId) REFERENCES dbo.EmployeeDocumentCategory(CategoryId),
        CONSTRAINT FK_EmployeeDocument_UploadedBy FOREIGN KEY (UploadedByUserId) REFERENCES dbo.UserAccount(UserId),
        CONSTRAINT FK_EmployeeDocument_UpdatedBy FOREIGN KEY (UpdatedByUserId) REFERENCES dbo.UserAccount(UserId),
        CONSTRAINT CK_EmployeeDocument_FileSize CHECK (FileSizeBytes > 0 AND FileSizeBytes <= 20971520),
        CONSTRAINT CK_EmployeeDocument_ExpiryDate CHECK (ExpiryDate IS NULL OR IssueDate IS NULL OR ExpiryDate >= IssueDate)
    );

    CREATE INDEX IX_EmployeeDocument_CompanyEmployee_Active
        ON dbo.EmployeeDocument(CompanyId, EmployeeId, IsActive, UploadedAt DESC);
    CREATE INDEX IX_EmployeeDocument_Expiry
        ON dbo.EmployeeDocument(CompanyId, ExpiryDate)
        WHERE IsActive = 1 AND ExpiryDate IS NOT NULL;
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.EmployeeDocumentCategory WHERE CategoryCode = N'GOVERNMENT_ID')
    INSERT dbo.EmployeeDocumentCategory(CategoryCode, CategoryName, IsConfidentialDefault, SortOrder)
    VALUES (N'GOVERNMENT_ID', N'Government ID', 1, 10);
IF NOT EXISTS (SELECT 1 FROM dbo.EmployeeDocumentCategory WHERE CategoryCode = N'EMPLOYMENT_CONTRACT')
    INSERT dbo.EmployeeDocumentCategory(CategoryCode, CategoryName, IsConfidentialDefault, SortOrder)
    VALUES (N'EMPLOYMENT_CONTRACT', N'Employment Contract', 1, 20);
IF NOT EXISTS (SELECT 1 FROM dbo.EmployeeDocumentCategory WHERE CategoryCode = N'CERTIFICATE')
    INSERT dbo.EmployeeDocumentCategory(CategoryCode, CategoryName, IsConfidentialDefault, SortOrder)
    VALUES (N'CERTIFICATE', N'Certificate', 0, 30);
IF NOT EXISTS (SELECT 1 FROM dbo.EmployeeDocumentCategory WHERE CategoryCode = N'EDUCATION')
    INSERT dbo.EmployeeDocumentCategory(CategoryCode, CategoryName, IsConfidentialDefault, SortOrder)
    VALUES (N'EDUCATION', N'Education Record', 0, 40);
IF NOT EXISTS (SELECT 1 FROM dbo.EmployeeDocumentCategory WHERE CategoryCode = N'MEDICAL')
    INSERT dbo.EmployeeDocumentCategory(CategoryCode, CategoryName, IsConfidentialDefault, SortOrder)
    VALUES (N'MEDICAL', N'Medical Document', 1, 50);
IF NOT EXISTS (SELECT 1 FROM dbo.EmployeeDocumentCategory WHERE CategoryCode = N'CLEARANCE')
    INSERT dbo.EmployeeDocumentCategory(CategoryCode, CategoryName, IsConfidentialDefault, SortOrder)
    VALUES (N'CLEARANCE', N'Clearance', 0, 60);
IF NOT EXISTS (SELECT 1 FROM dbo.EmployeeDocumentCategory WHERE CategoryCode = N'OTHER')
    INSERT dbo.EmployeeDocumentCategory(CategoryCode, CategoryName, IsConfidentialDefault, SortOrder)
    VALUES (N'OTHER', N'Other', 0, 100);
GO

/* Grant general document-management access to HR roles.
   Other roles (for example Line Manager) can be granted access in Role Management if approved. */
IF OBJECT_ID(N'dbo.RolePermission', N'U') IS NOT NULL
BEGIN
    INSERT INTO dbo.RolePermission(RoleId, PermissionCode)
    SELECT r.RoleId, N'EMPLOYEE_DOCUMENTS'
    FROM dbo.Role r
    WHERE r.RoleCode IN (N'SYSTEMADMIN', N'HRMANAGER', N'HRUSER')
      AND NOT EXISTS
      (
          SELECT 1 FROM dbo.RolePermission rp
          WHERE rp.RoleId = r.RoleId
            AND rp.PermissionCode = N'EMPLOYEE_DOCUMENTS'
      );

    INSERT INTO dbo.RolePermission(RoleId, PermissionCode)
    SELECT r.RoleId, N'EMPLOYEE_DOCUMENTS_CONFIDENTIAL'
    FROM dbo.Role r
    WHERE r.RoleCode IN (N'SYSTEMADMIN', N'HRMANAGER')
      AND NOT EXISTS
      (
          SELECT 1 FROM dbo.RolePermission rp
          WHERE rp.RoleId = r.RoleId
            AND rp.PermissionCode = N'EMPLOYEE_DOCUMENTS_CONFIDENTIAL'
      );
END;
GO
