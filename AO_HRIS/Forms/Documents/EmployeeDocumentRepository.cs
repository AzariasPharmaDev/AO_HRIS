using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace AO_HRIS.Forms.Documents
{
    internal sealed class EmployeeDocumentRepository
    {
        private int CurrentCompanyId
        {
            get
            {
                if (!UserSession.CompanyId.HasValue)
                    throw new InvalidOperationException("No company is selected.");
                return UserSession.CompanyId.Value;
            }
        }

        private void EnsureAccess(bool confidential = false)
        {
            string permission = confidential
                ? PermissionCodes.EmployeeDocumentsConfidential
                : PermissionCodes.EmployeeDocuments;

            if (!PermissionService.HasPermissionForCompany(permission, CurrentCompanyId))
                throw new UnauthorizedAccessException("You do not have permission to access these employee documents.");
        }

        public DataTable GetEmployees(string search)
        {
            EnsureAccess();
            const string sql = @"
SELECT DISTINCT er.EmployeeId, er.EmployeeNo,
       LTRIM(RTRIM(CONCAT(er.LastName, ', ', er.FirstName,
           CASE WHEN NULLIF(er.MiddleName, '') IS NULL THEN '' ELSE ' ' + LEFT(er.MiddleName, 1) + '.' END))) AS EmployeeName
FROM dbo.EmployeeRecord er
INNER JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId = er.EmployeeId
WHERE ea.CompanyId = @CompanyId
  AND ea.EffectiveFrom <= CONVERT(date, GETDATE())
  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo >= CONVERT(date, GETDATE()))
  AND (@Search = '' OR er.EmployeeNo LIKE '%' + @Search + '%'
       OR er.FirstName LIKE '%' + @Search + '%' OR er.LastName LIKE '%' + @Search + '%')
ORDER BY EmployeeName;";
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = CurrentCompanyId;
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 150).Value = (search ?? string.Empty).Trim();
                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetCategories()
        {
            EnsureAccess();
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"SELECT CategoryId, CategoryName, IsConfidentialDefault
FROM dbo.EmployeeDocumentCategory WHERE IsActive = 1 ORDER BY SortOrder, CategoryName;", con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) adapter.Fill(table);
            return table;
        }

        public DataTable GetDocuments(int employeeId, bool canViewConfidential)
        {
            EnsureAccess();
            // Do not trust a UI-supplied flag for confidential access.
            canViewConfidential = PermissionService.HasPermissionForCompany(
                PermissionCodes.EmployeeDocumentsConfidential, CurrentCompanyId);
            const string sql = @"
SELECT d.EmployeeDocumentId, c.CategoryName, d.DocumentName, d.OriginalFileName,
       d.IssueDate, d.ExpiryDate, d.IsConfidential, d.FileSizeBytes,
       d.UploadedAt, ua.Username AS UploadedBy, d.Notes,
       CASE WHEN d.ExpiryDate IS NULL THEN 'No expiry'
            WHEN d.ExpiryDate < CONVERT(date, GETDATE()) THEN 'Expired'
            WHEN d.ExpiryDate <= DATEADD(day, 30, CONVERT(date, GETDATE())) THEN 'Expiring soon'
            ELSE 'Valid' END AS ExpiryStatus
FROM dbo.EmployeeDocument d
INNER JOIN dbo.EmployeeDocumentCategory c ON c.CategoryId = d.CategoryId
LEFT JOIN dbo.UserAccount ua ON ua.UserId = d.UploadedByUserId
WHERE d.EmployeeId = @EmployeeId AND d.CompanyId = @CompanyId AND d.IsActive = 1
  AND (@CanViewConfidential = 1 OR d.IsConfidential = 0)
ORDER BY d.UploadedAt DESC;";
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = CurrentCompanyId;
                cmd.Parameters.Add("@CanViewConfidential", SqlDbType.Bit).Value = canViewConfidential;
                adapter.Fill(table);
            }
            return table;
        }

        public void AddDocument(int employeeId, int categoryId, string documentName,
            string originalFileName, byte[] fileData, DateTime? issueDate,
            DateTime? expiryDate, bool confidential, string notes)
        {
            EnsureAccess(confidential);
            if (employeeId <= 0 || categoryId <= 0) throw new ArgumentException("Select an employee and document category.");
            if (fileData == null || fileData.Length == 0) throw new ArgumentException("The selected file is empty.");
            if (fileData.Length > 20 * 1024 * 1024) throw new ArgumentException("The maximum document size is 20 MB.");
            if (string.IsNullOrWhiteSpace(documentName)) throw new ArgumentException("Enter a document name.");
            if (issueDate.HasValue && expiryDate.HasValue && expiryDate.Value.Date < issueDate.Value.Date)
                throw new ArgumentException("The expiration date cannot be earlier than the issue date.");

            byte[] hash;
            using (SHA256 sha = SHA256.Create()) hash = sha.ComputeHash(fileData);

            const string sql = @"
IF NOT EXISTS (
    SELECT 1 FROM dbo.EmployeeAssignment
    WHERE EmployeeId = @EmployeeId AND CompanyId = @CompanyId
      AND EffectiveFrom <= CONVERT(date, GETDATE())
      AND (EffectiveTo IS NULL OR EffectiveTo >= CONVERT(date, GETDATE()))
)
    THROW 50001, 'The selected employee does not have a current assignment in this company.', 1;

INSERT INTO dbo.EmployeeDocument
(EmployeeId, CompanyId, CategoryId, DocumentName, OriginalFileName,
 ContentType, FileExtension, FileSizeBytes, Sha256Hash, FileData,
 IssueDate, ExpiryDate, IsConfidential, Notes, UploadedByUserId)
VALUES
(@EmployeeId, @CompanyId, @CategoryId, @DocumentName, @OriginalFileName,
 @ContentType, @FileExtension, @FileSizeBytes, @Sha256Hash, @FileData,
 @IssueDate, @ExpiryDate, @IsConfidential, @Notes, @UploadedByUserId);";
            string extension = System.IO.Path.GetExtension(originalFileName ?? string.Empty);
            string[] allowedExtensions = { ".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".txt" };
            if (Array.IndexOf(allowedExtensions, (extension ?? string.Empty).ToLowerInvariant()) < 0)
                throw new ArgumentException("This file type is not supported. Use PDF, JPG, PNG, DOC, DOCX, XLS, XLSX, or TXT.");
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = CurrentCompanyId;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@DocumentName", SqlDbType.NVarChar, 200).Value = documentName.Trim();
                cmd.Parameters.Add("@OriginalFileName", SqlDbType.NVarChar, 260).Value = System.IO.Path.GetFileName(originalFileName);
                cmd.Parameters.Add("@ContentType", SqlDbType.NVarChar, 100).Value = GetContentType(extension);
                cmd.Parameters.Add("@FileExtension", SqlDbType.NVarChar, 20).Value = extension;
                cmd.Parameters.Add("@FileSizeBytes", SqlDbType.BigInt).Value = fileData.LongLength;
                cmd.Parameters.Add("@Sha256Hash", SqlDbType.Char, 64).Value = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
                cmd.Parameters.Add("@FileData", SqlDbType.VarBinary, -1).Value = fileData;
                cmd.Parameters.Add("@IssueDate", SqlDbType.Date).Value = (object)issueDate ?? DBNull.Value;
                cmd.Parameters.Add("@ExpiryDate", SqlDbType.Date).Value = (object)expiryDate ?? DBNull.Value;
                cmd.Parameters.Add("@IsConfidential", SqlDbType.Bit).Value = confidential;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000).Value = string.IsNullOrWhiteSpace(notes) ? (object)DBNull.Value : notes.Trim();
                cmd.Parameters.Add("@UploadedByUserId", SqlDbType.Int).Value = UserSession.UserId;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DocumentFile GetDocument(long documentId, bool confidential)
        {
            EnsureAccess(confidential);
            const string sql = @"SELECT OriginalFileName, ContentType, FileData
FROM dbo.EmployeeDocument
WHERE EmployeeDocumentId=@Id AND CompanyId=@CompanyId AND IsActive=1
  AND (@CanViewConfidential=1 OR IsConfidential=0);";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = documentId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = CurrentCompanyId;
                cmd.Parameters.Add("@CanViewConfidential", SqlDbType.Bit).Value = PermissionService.HasPermissionForCompany(PermissionCodes.EmployeeDocumentsConfidential, CurrentCompanyId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    if (!reader.Read()) throw new InvalidOperationException("The document was not found or you do not have access to it.");
                    return new DocumentFile { FileName = Convert.ToString(reader["OriginalFileName"]), ContentType = Convert.ToString(reader["ContentType"]), Data = (byte[])reader["FileData"] };
                }
            }
        }

        public void ReplaceDocument(long documentId, bool confidential, string originalFileName, byte[] fileData)
        {
            EnsureAccess(confidential);
            if (fileData == null || fileData.Length == 0) throw new ArgumentException("The selected file is empty.");
            if (fileData.Length > 20 * 1024 * 1024) throw new ArgumentException("The maximum document size is 20 MB.");
            string extension = System.IO.Path.GetExtension(originalFileName ?? string.Empty);
            string[] allowedExtensions = { ".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".txt" };
            if (Array.IndexOf(allowedExtensions, (extension ?? string.Empty).ToLowerInvariant()) < 0)
                throw new ArgumentException("This file type is not supported.");
            byte[] hash;
            using (SHA256 sha = SHA256.Create()) hash = sha.ComputeHash(fileData);
            const string sql = @"UPDATE dbo.EmployeeDocument
SET OriginalFileName=@OriginalFileName, ContentType=@ContentType, FileExtension=@FileExtension,
    FileSizeBytes=@FileSizeBytes, Sha256Hash=@Sha256Hash, FileData=@FileData,
    UpdatedByUserId=@UserId, UpdatedAt=SYSDATETIME()
WHERE EmployeeDocumentId=@Id AND CompanyId=@CompanyId AND IsActive=1
  AND (@CanReplaceConfidential=1 OR IsConfidential=0);";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@OriginalFileName", SqlDbType.NVarChar, 260).Value = System.IO.Path.GetFileName(originalFileName);
                cmd.Parameters.Add("@ContentType", SqlDbType.NVarChar, 100).Value = GetContentType(extension);
                cmd.Parameters.Add("@FileExtension", SqlDbType.NVarChar, 20).Value = extension;
                cmd.Parameters.Add("@FileSizeBytes", SqlDbType.BigInt).Value = fileData.LongLength;
                cmd.Parameters.Add("@Sha256Hash", SqlDbType.Char, 64).Value = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
                cmd.Parameters.Add("@FileData", SqlDbType.VarBinary, -1).Value = fileData;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = documentId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = CurrentCompanyId;
                cmd.Parameters.Add("@CanReplaceConfidential", SqlDbType.Bit).Value = PermissionService.HasPermissionForCompany(PermissionCodes.EmployeeDocumentsConfidential, CurrentCompanyId);
                con.Open();
                if (cmd.ExecuteNonQuery() == 0) throw new InvalidOperationException("The document could not be replaced.");
            }
        }

        public void ArchiveDocument(long documentId, bool confidential)
        {
            EnsureAccess(confidential);
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"UPDATE dbo.EmployeeDocument SET IsActive=0, UpdatedAt=SYSDATETIME(), UpdatedByUserId=@UserId
WHERE EmployeeDocumentId=@Id AND CompanyId=@CompanyId AND IsActive=1
  AND (@CanArchiveConfidential=1 OR IsConfidential=0);", con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = documentId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = CurrentCompanyId;
                cmd.Parameters.Add("@CanArchiveConfidential", SqlDbType.Bit).Value = PermissionService.HasPermissionForCompany(PermissionCodes.EmployeeDocumentsConfidential, CurrentCompanyId);
                con.Open();
                if (cmd.ExecuteNonQuery() == 0) throw new InvalidOperationException("The document could not be archived.");
            }
        }

        private static string GetContentType(string extension)
        {
            switch ((extension ?? string.Empty).ToLowerInvariant())
            {
                case ".pdf": return "application/pdf";
                case ".jpg": case ".jpeg": return "image/jpeg";
                case ".png": return "image/png";
                case ".doc": return "application/msword";
                case ".docx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".xls": return "application/vnd.ms-excel";
                case ".xlsx": return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case ".txt": return "text/plain";
                default: return "application/octet-stream";
            }
        }
    }

    internal sealed class DocumentFile
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
