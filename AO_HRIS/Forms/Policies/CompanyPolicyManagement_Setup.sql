USE [AO_HRIS];
GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

/* Policy categories are company-scoped so each subsidiary can maintain its own list. */
IF OBJECT_ID(N'dbo.PolicyCategory', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PolicyCategory
    (
        CategoryId INT IDENTITY(1,1) NOT NULL,
        CompanyId INT NOT NULL,
        CategoryCode NVARCHAR(30) NOT NULL,
        CategoryName NVARCHAR(100) NOT NULL,
        IsActive BIT NOT NULL CONSTRAINT DF_PolicyCategory_IsActive DEFAULT (1),
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_PolicyCategory_CreatedAt DEFAULT (SYSDATETIME()),
        UpdatedAt DATETIME2(0) NULL,
        CONSTRAINT PK_PolicyCategory PRIMARY KEY CLUSTERED (CategoryId),
        CONSTRAINT UQ_PolicyCategory_Company_Code UNIQUE (CompanyId, CategoryCode),
        CONSTRAINT UQ_PolicyCategory_Category_Company UNIQUE (CategoryId, CompanyId),
        CONSTRAINT FK_PolicyCategory_Company FOREIGN KEY (CompanyId)
            REFERENCES dbo.Company(CompanyId)
    );
END;
GO

IF OBJECT_ID(N'dbo.CompanyPolicy', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CompanyPolicy
    (
        PolicyId INT IDENTITY(1,1) NOT NULL,
        CompanyId INT NOT NULL,
        CategoryId INT NOT NULL,
        PolicyCode NVARCHAR(30) NOT NULL,
        PolicyTitle NVARCHAR(200) NOT NULL,
        PolicyDescription NVARCHAR(2000) NULL,
        IsActive BIT NOT NULL CONSTRAINT DF_CompanyPolicy_IsActive DEFAULT (1),
        CreatedByUserId INT NOT NULL,
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_CompanyPolicy_CreatedAt DEFAULT (SYSDATETIME()),
        UpdatedAt DATETIME2(0) NULL,
        CONSTRAINT PK_CompanyPolicy PRIMARY KEY CLUSTERED (PolicyId),
        CONSTRAINT UQ_CompanyPolicy_Company_Code UNIQUE (CompanyId, PolicyCode),
        CONSTRAINT UQ_CompanyPolicy_Policy_Company UNIQUE (PolicyId, CompanyId),
        CONSTRAINT FK_CompanyPolicy_Company FOREIGN KEY (CompanyId)
            REFERENCES dbo.Company(CompanyId),
        CONSTRAINT FK_CompanyPolicy_Category_Company FOREIGN KEY (CategoryId, CompanyId)
            REFERENCES dbo.PolicyCategory(CategoryId, CompanyId),
        CONSTRAINT FK_CompanyPolicy_CreatedBy FOREIGN KEY (CreatedByUserId)
            REFERENCES dbo.UserAccount(UserId)
    );
END;
GO

IF OBJECT_ID(N'dbo.PolicyRevision', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PolicyRevision
    (
        PolicyRevisionId INT IDENTITY(1,1) NOT NULL,
        PolicyId INT NOT NULL,
        RevisionNumber INT NOT NULL,
        RevisionLabel NVARCHAR(30) NOT NULL,
        OriginalFileName NVARCHAR(260) NOT NULL,
        ContentType NVARCHAR(100) NOT NULL,
        FileSizeBytes BIGINT NOT NULL,
        FileData VARBINARY(MAX) NOT NULL,
        EffectiveDate DATE NOT NULL,
        IsPublished BIT NOT NULL CONSTRAINT DF_PolicyRevision_IsPublished DEFAULT (0),
        IsSuperseded BIT NOT NULL CONSTRAINT DF_PolicyRevision_IsSuperseded DEFAULT (0),
        PublishedAt DATETIME2(0) NULL,
        PublishedByUserId INT NULL,
        CreatedByUserId INT NOT NULL,
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_PolicyRevision_CreatedAt DEFAULT (SYSDATETIME()),
        CONSTRAINT PK_PolicyRevision PRIMARY KEY CLUSTERED (PolicyRevisionId),
        CONSTRAINT UQ_PolicyRevision_Policy_Revision UNIQUE (PolicyId, RevisionNumber),
        CONSTRAINT FK_PolicyRevision_Policy FOREIGN KEY (PolicyId)
            REFERENCES dbo.CompanyPolicy(PolicyId),
        CONSTRAINT FK_PolicyRevision_PublishedBy FOREIGN KEY (PublishedByUserId)
            REFERENCES dbo.UserAccount(UserId),
        CONSTRAINT FK_PolicyRevision_CreatedBy FOREIGN KEY (CreatedByUserId)
            REFERENCES dbo.UserAccount(UserId),
        CONSTRAINT CK_PolicyRevision_Number CHECK (RevisionNumber > 0),
        CONSTRAINT CK_PolicyRevision_FileSize CHECK (FileSizeBytes > 0 AND FileSizeBytes <= 20971520),
        CONSTRAINT CK_PolicyRevision_PublishState CHECK
        (
            (IsPublished = 0 AND PublishedAt IS NULL AND PublishedByUserId IS NULL)
            OR
            (IsPublished = 1 AND PublishedAt IS NOT NULL AND PublishedByUserId IS NOT NULL)
        )
    );
END;
GO

IF OBJECT_ID(N'dbo.PolicyAcknowledgement', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PolicyAcknowledgement
    (
        AcknowledgementId BIGINT IDENTITY(1,1) NOT NULL,
        PolicyRevisionId INT NOT NULL,
        AssignmentId INT NOT NULL,
        EmployeeId INT NOT NULL,
        CompanyId INT NOT NULL,
        AcknowledgedByUserId INT NULL,
        AcknowledgedAt DATETIME2(0) NULL,
        AcknowledgementNote NVARCHAR(1000) NULL,
        CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_PolicyAcknowledgement_CreatedAt DEFAULT (SYSDATETIME()),
        CONSTRAINT PK_PolicyAcknowledgement PRIMARY KEY CLUSTERED (AcknowledgementId),
        CONSTRAINT UQ_PolicyAcknowledgement_Revision_Assignment UNIQUE (PolicyRevisionId, AssignmentId),
        CONSTRAINT FK_PolicyAcknowledgement_Revision FOREIGN KEY (PolicyRevisionId)
            REFERENCES dbo.PolicyRevision(PolicyRevisionId),
        CONSTRAINT FK_PolicyAcknowledgement_Assignment_Employee FOREIGN KEY (AssignmentId, EmployeeId)
            REFERENCES dbo.EmployeeAssignment(AssignmentId, EmployeeId),
        CONSTRAINT FK_PolicyAcknowledgement_Assignment_Company FOREIGN KEY (AssignmentId, CompanyId)
            REFERENCES dbo.EmployeeAssignment(AssignmentId, CompanyId),
        CONSTRAINT FK_PolicyAcknowledgement_AcknowledgedBy FOREIGN KEY (AcknowledgedByUserId)
            REFERENCES dbo.UserAccount(UserId)
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_CompanyPolicy_Company_Active'
      AND object_id = OBJECT_ID(N'dbo.CompanyPolicy')
)
BEGIN
    CREATE INDEX IX_CompanyPolicy_Company_Active
        ON dbo.CompanyPolicy(CompanyId, IsActive, PolicyTitle);
END;
GO

IF NOT EXISTS
(
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_PolicyRevision_Policy_Published'
      AND object_id = OBJECT_ID(N'dbo.PolicyRevision')
)
BEGIN
    CREATE INDEX IX_PolicyRevision_Policy_Published
        ON dbo.PolicyRevision(PolicyId, IsPublished, IsSuperseded, RevisionNumber DESC);
END;
GO

IF NOT EXISTS
(
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_PolicyAcknowledgement_Company_Employee'
      AND object_id = OBJECT_ID(N'dbo.PolicyAcknowledgement')
)
BEGIN
    CREATE INDEX IX_PolicyAcknowledgement_Company_Employee
        ON dbo.PolicyAcknowledgement(CompanyId, EmployeeId, AcknowledgedAt);
END;
GO

/* Seed standard categories for every existing company; safe to run repeatedly. */
INSERT INTO dbo.PolicyCategory (CompanyId, CategoryCode, CategoryName)
SELECT c.CompanyId, v.CategoryCode, v.CategoryName
FROM dbo.Company c
CROSS JOIN
(
    VALUES
        (N'GENERAL', N'General Policies'),
        (N'EMPLOYMENT', N'Employment'),
        (N'CODE_CONDUCT', N'Code of Conduct'),
        (N'HEALTH_SAFETY', N'Health and Safety'),
        (N'DATA_PRIVACY', N'Data Privacy'),
        (N'IT_SECURITY', N'IT and Information Security'),
        (N'BENEFITS', N'Benefits and Compensation'),
        (N'LEAVE_ATTENDANCE', N'Leave and Attendance'),
        (N'WORKPLACE', N'Workplace Guidelines')
) v(CategoryCode, CategoryName)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.PolicyCategory pc
    WHERE pc.CompanyId = c.CompanyId
      AND pc.CategoryCode = v.CategoryCode
);
GO

SELECT N'PolicyCategory' AS TableName, COUNT(*) AS RecordCount FROM dbo.PolicyCategory
UNION ALL
SELECT N'CompanyPolicy', COUNT(*) FROM dbo.CompanyPolicy
UNION ALL
SELECT N'PolicyRevision', COUNT(*) FROM dbo.PolicyRevision
UNION ALL
SELECT N'PolicyAcknowledgement', COUNT(*) FROM dbo.PolicyAcknowledgement;
GO
