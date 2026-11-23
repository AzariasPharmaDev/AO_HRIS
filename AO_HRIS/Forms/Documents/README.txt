AO_HRIS - EMPLOYEE DOCUMENT MANAGEMENT

WHAT IS INCLUDED
- EmployeeDocumentManagementControl.cs: code-built WinForms user control; no Designer file is required.
- EmployeeDocumentRepository.cs: SQL Server data access and company/permission checks.
- DocumentUploadDialog.cs: document metadata dialog.
- EmployeeDocumentManagement.sql: one-time database migration.

INSTALLATION
1. Back up the AO_HRIS database.
2. Open EmployeeDocumentManagement.sql in SQL Server Management Studio.
3. Confirm the database context is AO_HRIS, then execute the script once.
4. Open AO_HRIS.csproj in Visual Studio and build the project.
5. Log in using an account with EMPLOYEE_DOCUMENTS permission. Employee Documents will appear in the sidebar.
6. SYSTEMADMIN, HRMANAGER, and HRUSER receive general EMPLOYEE_DOCUMENTS access if those RoleCode values exist. SYSTEMADMIN and HRMANAGER receive EMPLOYEE_DOCUMENTS_CONFIDENTIAL. Other roles can be granted either permission in Role Management when approved.

BEHAVIOR
- Documents are stored as VARBINARY(MAX) in SQL Server, not in App.config or a local folder.
- Maximum file size: 20 MB per document.
- Supported extensions: PDF, JPG/JPEG, PNG, DOC/DOCX, XLS/XLSX, TXT.
- Documents are scoped to the selected company and the employee must have a current assignment in that company at upload time.
- One EmployeeRecord remains shared across subsidiaries; this feature does not create duplicate employee records.
- The module is available only to users with EMPLOYEE_DOCUMENTS. Confidential documents are hidden unless the current user also has EMPLOYEE_DOCUMENTS_CONFIDENTIAL.
- Archive is a soft archive; it does not physically delete the database row or file bytes.
- Opening a document writes a temporary copy under %TEMP%\AO_HRIS_DocumentPreview. Remove that folder when finished if the document is sensitive.
- Replacing a document updates the file bytes and file metadata while retaining the document's category, dates, notes, and confidentiality flag.

IMPORTANT
The SQL migration has not been run against your live database. Apply it only after taking a backup. The project could not be compiled in this environment because the .NET Framework/MSBuild toolchain is unavailable here; build and test it in Visual Studio before using it with live employee documents.
