using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Forms.Policies
{
    public sealed class PolicyFile
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }

    public sealed class CompanyPolicyRepository
    {
        private static void EnsureCompany(int companyId)
        {
            if (!UserSession.CompanyId.HasValue || UserSession.CompanyId.Value != companyId)
                throw new UnauthorizedAccessException("The selected company does not match the current session.");
        }

        private static void EnsureManagePermission(int companyId)
        {
            EnsureCompany(companyId);
            if (!PermissionService.HasPermissionForCompany(PermissionCodes.PolicyManagement, companyId))
                throw new UnauthorizedAccessException("You do not have permission to manage company policies.");
        }

        private static void EnsureAcknowledgementPermission(int companyId)
        {
            EnsureCompany(companyId);
            if (!PermissionService.HasPermissionForCompany(PermissionCodes.PolicyAcknowledgement, companyId))
                throw new UnauthorizedAccessException("You do not have permission to acknowledge company policies.");
        }

        public DataTable GetCategories(int companyId)
        {
            EnsureManagePermission(companyId);
            const string sql = @"SELECT CategoryId, CategoryName
FROM dbo.PolicyCategory
WHERE CompanyId=@CompanyId AND IsActive=1
ORDER BY CategoryName;";
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetPolicies(int companyId, string searchText)
        {
            EnsureManagePermission(companyId);
            const string sql = @"
SELECT p.PolicyId, p.PolicyCode, p.PolicyTitle, c.CategoryName, p.PolicyDescription,
       p.IsActive, latest.PolicyRevisionId, latest.RevisionNumber,
       latest.RevisionLabel, latest.EffectiveDate, published.PolicyRevisionId AS CurrentPublishedRevisionId,
       CASE WHEN latest.PolicyRevisionId IS NULL THEN 'No revision'
            WHEN latest.IsPublished=0 THEN 'Draft'
            WHEN latest.IsSuperseded=1 THEN 'Superseded'
            ELSE 'Published' END AS RevisionStatus,
       ISNULL(counts.AcknowledgedCount,0) AS AcknowledgedCount,
       ISNULL(counts.PendingCount,0) AS PendingCount
FROM dbo.CompanyPolicy p
LEFT JOIN dbo.PolicyCategory c ON c.CategoryId=p.CategoryId AND c.CompanyId=p.CompanyId
OUTER APPLY
(
    SELECT TOP (1) pr.PolicyRevisionId, pr.RevisionNumber, pr.RevisionLabel,
           pr.EffectiveDate, pr.IsPublished, pr.IsSuperseded
    FROM dbo.PolicyRevision pr
    WHERE pr.PolicyId=p.PolicyId
    ORDER BY pr.RevisionNumber DESC
) latest
OUTER APPLY
(
    SELECT TOP (1) pr.PolicyRevisionId
    FROM dbo.PolicyRevision pr
    WHERE pr.PolicyId=p.PolicyId AND pr.IsPublished=1 AND pr.IsSuperseded=0
    ORDER BY pr.RevisionNumber DESC
) published
OUTER APPLY
(
    SELECT COUNT(*) AS TotalCount,
           SUM(CASE WHEN pa.AcknowledgedAt IS NOT NULL THEN 1 ELSE 0 END) AS AcknowledgedCount,
           SUM(CASE WHEN pa.AcknowledgedAt IS NULL THEN 1 ELSE 0 END) AS PendingCount
    FROM dbo.PolicyAcknowledgement pa
    INNER JOIN dbo.PolicyRevision currentRevision ON currentRevision.PolicyRevisionId=pa.PolicyRevisionId
    WHERE currentRevision.PolicyId=p.PolicyId
      AND currentRevision.IsPublished=1 AND currentRevision.IsSuperseded=0
) counts
WHERE p.CompanyId=@CompanyId
  AND (@Search=N'' OR p.PolicyCode LIKE N'%' + @Search + N'%'
       OR p.PolicyTitle LIKE N'%' + @Search + N'%'
       OR c.CategoryName LIKE N'%' + @Search + N'%')
ORDER BY p.IsActive DESC, p.PolicyTitle;";
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 150).Value = (searchText ?? string.Empty).Trim();
                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetPolicyHeader(int companyId, int policyId)
        {
            EnsureManagePermission(companyId);
            const string sql = @"SELECT p.PolicyId, p.PolicyCode, p.PolicyTitle, p.CategoryId,
       p.PolicyDescription,
       ISNULL((SELECT MAX(RevisionNumber) FROM dbo.PolicyRevision WHERE PolicyId=p.PolicyId),0)+1 AS NextRevisionNumber
FROM dbo.CompanyPolicy p
WHERE p.PolicyId=@PolicyId AND p.CompanyId=@CompanyId AND p.IsActive=1;";
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = policyId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(table);
            }
            if (table.Rows.Count == 0)
                throw new InvalidOperationException("The selected policy was not found or is inactive.");
            return table;
        }

        public int SaveDraft(int companyId, int userId, int? policyId, string policyCode,
            string policyTitle, int categoryId, string description, string revisionLabel,
            DateTime effectiveDate, string originalFileName, byte[] fileData)
        {
            EnsureManagePermission(companyId);
            if (userId <= 0 || userId != UserSession.UserId)
                throw new UnauthorizedAccessException("Invalid user session.");
            if (fileData == null || fileData.Length == 0)
                throw new ArgumentException("Select a PDF policy document.");
            if (fileData.LongLength > 20L * 1024L * 1024L)
                throw new ArgumentException("The maximum policy document size is 20 MB.");
            if (string.IsNullOrWhiteSpace(originalFileName) ||
                !string.Equals(System.IO.Path.GetExtension(originalFileName), ".pdf", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Policy documents must be PDF files.");
            if (string.IsNullOrWhiteSpace(revisionLabel))
                throw new ArgumentException("Enter a revision label.");

            using (SqlConnection con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        int savedPolicyId;
                        if (policyId.HasValue)
                        {
                            using (SqlCommand verify = new SqlCommand(@"SELECT COUNT(*) FROM dbo.CompanyPolicy WITH (UPDLOCK,HOLDLOCK)
WHERE PolicyId=@PolicyId AND CompanyId=@CompanyId AND IsActive=1;", con, tx))
                            {
                                verify.Parameters.Add("@PolicyId", SqlDbType.Int).Value = policyId.Value;
                                verify.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                                if (Convert.ToInt32(verify.ExecuteScalar()) != 1)
                                    throw new InvalidOperationException("The selected policy is unavailable.");
                            }
                            savedPolicyId = policyId.Value;
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(policyCode)) throw new ArgumentException("Enter a policy code.");
                            if (string.IsNullOrWhiteSpace(policyTitle)) throw new ArgumentException("Enter a policy title.");

                            using (SqlCommand insertPolicy = new SqlCommand(@"
INSERT INTO dbo.CompanyPolicy
(CompanyId, CategoryId, PolicyCode, PolicyTitle, PolicyDescription, CreatedByUserId)
VALUES
(@CompanyId, @CategoryId, @PolicyCode, @PolicyTitle, @Description, @UserId);
SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tx))
                            {
                                insertPolicy.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                                insertPolicy.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
                                insertPolicy.Parameters.Add("@PolicyCode", SqlDbType.NVarChar, 30).Value = policyCode.Trim();
                                insertPolicy.Parameters.Add("@PolicyTitle", SqlDbType.NVarChar, 200).Value = policyTitle.Trim();
                                insertPolicy.Parameters.Add("@Description", SqlDbType.NVarChar, 2000).Value = string.IsNullOrWhiteSpace(description) ? (object)DBNull.Value : description.Trim();
                                insertPolicy.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                                savedPolicyId = Convert.ToInt32(insertPolicy.ExecuteScalar());
                            }
                        }

                        int revisionNumber;
                        using (SqlCommand next = new SqlCommand(@"SELECT ISNULL(MAX(RevisionNumber),0)+1
FROM dbo.PolicyRevision WITH (UPDLOCK,HOLDLOCK) WHERE PolicyId=@PolicyId;", con, tx))
                        {
                            next.Parameters.Add("@PolicyId", SqlDbType.Int).Value = savedPolicyId;
                            revisionNumber = Convert.ToInt32(next.ExecuteScalar());
                        }

                        using (SqlCommand insertRevision = new SqlCommand(@"
INSERT INTO dbo.PolicyRevision
(PolicyId, RevisionNumber, RevisionLabel, OriginalFileName, ContentType,
 FileSizeBytes, FileData, EffectiveDate, CreatedByUserId)
VALUES
(@PolicyId, @RevisionNumber, @RevisionLabel, @FileName, N'application/pdf',
 @FileSizeBytes, @FileData, @EffectiveDate, @UserId);", con, tx))
                        {
                            insertRevision.Parameters.Add("@PolicyId", SqlDbType.Int).Value = savedPolicyId;
                            insertRevision.Parameters.Add("@RevisionNumber", SqlDbType.Int).Value = revisionNumber;
                            insertRevision.Parameters.Add("@RevisionLabel", SqlDbType.NVarChar, 30).Value = revisionLabel.Trim();
                            insertRevision.Parameters.Add("@FileName", SqlDbType.NVarChar, 260).Value = System.IO.Path.GetFileName(originalFileName);
                            insertRevision.Parameters.Add("@FileSizeBytes", SqlDbType.BigInt).Value = fileData.LongLength;
                            insertRevision.Parameters.Add("@FileData", SqlDbType.VarBinary, -1).Value = fileData;
                            insertRevision.Parameters.Add("@EffectiveDate", SqlDbType.Date).Value = effectiveDate.Date;
                            insertRevision.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                            insertRevision.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return savedPolicyId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public void PublishLatestDraft(int companyId, int userId, int policyId)
        {
            EnsureManagePermission(companyId);
            if (userId <= 0 || userId != UserSession.UserId)
                throw new UnauthorizedAccessException("Invalid user session.");
            using (SqlConnection con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        int revisionId;
                        using (SqlCommand find = new SqlCommand(@"
SELECT TOP (1) pr.PolicyRevisionId
FROM dbo.PolicyRevision pr WITH (UPDLOCK,HOLDLOCK)
INNER JOIN dbo.CompanyPolicy p ON p.PolicyId=pr.PolicyId
WHERE pr.PolicyId=@PolicyId AND p.CompanyId=@CompanyId AND p.IsActive=1
  AND pr.IsPublished=0
ORDER BY pr.RevisionNumber DESC;", con, tx))
                        {
                            find.Parameters.Add("@PolicyId", SqlDbType.Int).Value = policyId;
                            find.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                            object value = find.ExecuteScalar();
                            if (value == null || value == DBNull.Value)
                                throw new InvalidOperationException("There is no draft revision to publish for this policy.");
                            revisionId = Convert.ToInt32(value);
                        }

                        using (SqlCommand supersede = new SqlCommand(@"
UPDATE dbo.PolicyRevision
SET IsSuperseded=1
WHERE PolicyId=@PolicyId AND IsPublished=1 AND IsSuperseded=0;", con, tx))
                        {
                            supersede.Parameters.Add("@PolicyId", SqlDbType.Int).Value = policyId;
                            supersede.ExecuteNonQuery();
                        }

                        using (SqlCommand publish = new SqlCommand(@"
UPDATE dbo.PolicyRevision
SET IsPublished=1, IsSuperseded=0, PublishedAt=SYSDATETIME(), PublishedByUserId=@UserId
WHERE PolicyRevisionId=@RevisionId AND IsPublished=0;", con, tx))
                        {
                            publish.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                            publish.Parameters.Add("@RevisionId", SqlDbType.Int).Value = revisionId;
                            if (publish.ExecuteNonQuery() != 1)
                                throw new InvalidOperationException("The draft revision could not be published.");
                        }

                        InsertAcknowledgementObligations(con, tx, companyId, revisionId);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        private static void InsertAcknowledgementObligations(SqlConnection con, SqlTransaction tx,
            int companyId, int revisionId)
        {
            const string sql = @"
INSERT INTO dbo.PolicyAcknowledgement
(PolicyRevisionId, AssignmentId, EmployeeId, CompanyId)
SELECT @RevisionId, ea.AssignmentId, ea.EmployeeId, ea.CompanyId
FROM dbo.EmployeeAssignment ea
WHERE ea.CompanyId=@CompanyId
  AND ea.EmploymentStatus=N'Active'
  AND ea.EffectiveFrom<=CONVERT(date,GETDATE())
  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CONVERT(date,GETDATE()))
  AND NOT EXISTS
  (
      SELECT 1 FROM dbo.PolicyAcknowledgement pa
      WHERE pa.PolicyRevisionId=@RevisionId AND pa.AssignmentId=ea.AssignmentId
  );";
            using (SqlCommand cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.Add("@RevisionId", SqlDbType.Int).Value = revisionId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePolicyDetails(int companyId, int policyId, string policyCode,
            string policyTitle, int categoryId, string description)
        {
            EnsureManagePermission(companyId);
            if (string.IsNullOrWhiteSpace(policyCode)) throw new ArgumentException("Enter a policy code.");
            if (string.IsNullOrWhiteSpace(policyTitle)) throw new ArgumentException("Enter a policy title.");

            const string sql = @"UPDATE dbo.CompanyPolicy
SET CategoryId=@CategoryId, PolicyCode=@PolicyCode, PolicyTitle=@PolicyTitle,
    PolicyDescription=@Description, UpdatedAt=SYSDATETIME()
WHERE PolicyId=@PolicyId AND CompanyId=@CompanyId AND IsActive=1;";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@PolicyCode", SqlDbType.NVarChar, 30).Value = policyCode.Trim();
                cmd.Parameters.Add("@PolicyTitle", SqlDbType.NVarChar, 200).Value = policyTitle.Trim();
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 2000).Value = string.IsNullOrWhiteSpace(description) ? (object)DBNull.Value : description.Trim();
                cmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = policyId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                con.Open();
                if (cmd.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("The policy was not found or has been archived.");
            }
        }

        public void ArchivePolicy(int companyId, int policyId)
        {
            EnsureManagePermission(companyId);
            const string sql = @"UPDATE dbo.CompanyPolicy
SET IsActive=0, UpdatedAt=SYSDATETIME()
WHERE PolicyId=@PolicyId AND CompanyId=@CompanyId AND IsActive=1;";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = policyId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                con.Open();
                if (cmd.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("The policy was not found or has already been archived.");
            }
        }

        public DataTable GetMyPolicies(int companyId, int employeeId)
        {
            EnsureAcknowledgementPermission(companyId);
            if (!UserSession.EmployeeId.HasValue || UserSession.EmployeeId.Value != employeeId)
                throw new UnauthorizedAccessException("You can only view your own policy acknowledgements.");

            EnsureCurrentEmployeeObligations(companyId, employeeId);
            const string sql = @"
SELECT p.PolicyId, pr.PolicyRevisionId, p.PolicyTitle, c.CategoryName,
       pr.RevisionLabel, pr.EffectiveDate, pr.OriginalFileName,
       pa.AcknowledgedAt,
       CASE WHEN pa.AcknowledgedAt IS NULL THEN 'Pending' ELSE 'Acknowledged' END AS AcknowledgementStatus
FROM dbo.PolicyAcknowledgement pa
INNER JOIN dbo.PolicyRevision pr ON pr.PolicyRevisionId=pa.PolicyRevisionId
INNER JOIN dbo.CompanyPolicy p ON p.PolicyId=pr.PolicyId
INNER JOIN dbo.PolicyCategory c ON c.CategoryId=p.CategoryId AND c.CompanyId=p.CompanyId
INNER JOIN dbo.EmployeeAssignment ea ON ea.AssignmentId=pa.AssignmentId AND ea.EmployeeId=pa.EmployeeId
WHERE pa.CompanyId=@CompanyId AND pa.EmployeeId=@EmployeeId
  AND p.IsActive=1 AND pr.IsPublished=1 AND pr.IsSuperseded=0
  AND ea.EmploymentStatus=N'Active'
  AND ea.EffectiveFrom<=CONVERT(date,GETDATE())
  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CONVERT(date,GETDATE()))
ORDER BY pr.EffectiveDate DESC, p.PolicyTitle;";
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                adapter.Fill(table);
            }
            return table;
        }

        private static void EnsureCurrentEmployeeObligations(int companyId, int employeeId)
        {
            const string sql = @"
INSERT INTO dbo.PolicyAcknowledgement
(PolicyRevisionId, AssignmentId, EmployeeId, CompanyId)
SELECT pr.PolicyRevisionId, ea.AssignmentId, ea.EmployeeId, ea.CompanyId
FROM dbo.PolicyRevision pr
INNER JOIN dbo.CompanyPolicy p ON p.PolicyId=pr.PolicyId
INNER JOIN dbo.EmployeeAssignment ea ON ea.CompanyId=p.CompanyId
WHERE p.CompanyId=@CompanyId AND p.IsActive=1
  AND pr.IsPublished=1 AND pr.IsSuperseded=0
  AND ea.EmployeeId=@EmployeeId AND ea.EmploymentStatus=N'Active'
  AND ea.EffectiveFrom<=CONVERT(date,GETDATE())
  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CONVERT(date,GETDATE()))
  AND NOT EXISTS
  (
      SELECT 1 FROM dbo.PolicyAcknowledgement pa
      WHERE pa.PolicyRevisionId=pr.PolicyRevisionId AND pa.AssignmentId=ea.AssignmentId
  );";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AcknowledgePolicy(int companyId, int employeeId, int revisionId, int userId)
        {
            EnsureAcknowledgementPermission(companyId);
            if (!UserSession.EmployeeId.HasValue || UserSession.EmployeeId.Value != employeeId || userId != UserSession.UserId)
                throw new UnauthorizedAccessException("The current account is not linked to the selected employee.");

            const string sql = @"
UPDATE pa
SET AcknowledgedByUserId=@UserId, AcknowledgedAt=SYSDATETIME()
FROM dbo.PolicyAcknowledgement pa
INNER JOIN dbo.PolicyRevision pr ON pr.PolicyRevisionId=pa.PolicyRevisionId
INNER JOIN dbo.CompanyPolicy p ON p.PolicyId=pr.PolicyId
INNER JOIN dbo.EmployeeAssignment ea ON ea.AssignmentId=pa.AssignmentId AND ea.EmployeeId=pa.EmployeeId
WHERE pa.PolicyRevisionId=@RevisionId AND pa.CompanyId=@CompanyId AND pa.EmployeeId=@EmployeeId
  AND pa.AcknowledgedAt IS NULL
  AND p.IsActive=1 AND pr.IsPublished=1 AND pr.IsSuperseded=0
  AND ea.EmploymentStatus=N'Active'
  AND ea.EffectiveFrom<=CONVERT(date,GETDATE())
  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CONVERT(date,GETDATE()));";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@RevisionId", SqlDbType.Int).Value = revisionId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                con.Open();
                if (cmd.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("This policy is no longer pending or is not assigned to your current company assignment.");
            }
        }

        private static void EnsureCompanyAcknowledgementObligations(int companyId)
        {
            const string sql = @"
INSERT INTO dbo.PolicyAcknowledgement
(PolicyRevisionId, AssignmentId, EmployeeId, CompanyId)
SELECT pr.PolicyRevisionId, ea.AssignmentId, ea.EmployeeId, ea.CompanyId
FROM dbo.PolicyRevision pr
INNER JOIN dbo.CompanyPolicy p ON p.PolicyId=pr.PolicyId
INNER JOIN dbo.EmployeeAssignment ea ON ea.CompanyId=p.CompanyId
WHERE p.CompanyId=@CompanyId AND p.IsActive=1
  AND pr.IsPublished=1 AND pr.IsSuperseded=0
  AND ea.EmploymentStatus=N'Active'
  AND ea.EffectiveFrom<=CONVERT(date,GETDATE())
  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CONVERT(date,GETDATE()))
  AND NOT EXISTS
  (
      SELECT 1 FROM dbo.PolicyAcknowledgement pa
      WHERE pa.PolicyRevisionId=pr.PolicyRevisionId AND pa.AssignmentId=ea.AssignmentId
  );";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetCompliance(int companyId, int? policyId)
        {
            EnsureManagePermission(companyId);
            EnsureCompanyAcknowledgementObligations(companyId);
            const string sql = @"
SELECT p.PolicyId, pr.PolicyRevisionId, p.PolicyCode, p.PolicyTitle,
       pr.RevisionLabel, COALESCE(ea.CompanyEmployeeNo, er.EmployeeNo) AS EmployeeNo,
       LTRIM(RTRIM(COALESCE(er.FirstName,N'') + N' ' + COALESCE(er.LastName,N''))) AS EmployeeName,
       d.DepartmentName,
       CASE WHEN pa.AcknowledgedAt IS NULL THEN 'Pending' ELSE 'Acknowledged' END AS AcknowledgementStatus,
       pa.AcknowledgedAt
FROM dbo.PolicyAcknowledgement pa
INNER JOIN dbo.PolicyRevision pr ON pr.PolicyRevisionId=pa.PolicyRevisionId
INNER JOIN dbo.CompanyPolicy p ON p.PolicyId=pr.PolicyId
INNER JOIN dbo.EmployeeAssignment ea ON ea.AssignmentId=pa.AssignmentId AND ea.EmployeeId=pa.EmployeeId
INNER JOIN dbo.EmployeeRecord er ON er.EmployeeId=pa.EmployeeId
LEFT JOIN dbo.Department d ON d.DepartmentId=ea.DepartmentId AND d.CompanyId=ea.CompanyId
WHERE pa.CompanyId=@CompanyId AND p.IsActive=1
  AND pr.IsPublished=1 AND pr.IsSuperseded=0
  AND (@PolicyId IS NULL OR p.PolicyId=@PolicyId)
ORDER BY p.PolicyTitle, er.LastName, er.FirstName;";
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = (object)policyId ?? DBNull.Value;
                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetPolicyFilters(int companyId)
        {
            EnsureManagePermission(companyId);
            const string sql = @"SELECT PolicyId, PolicyTitle FROM dbo.CompanyPolicy
WHERE CompanyId=@CompanyId AND IsActive=1 ORDER BY PolicyTitle;";
            DataTable table = new DataTable();
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(table);
            }
            return table;
        }

        public PolicyFile GetRevisionFile(int companyId, int revisionId)
        {
            EnsureCompany(companyId);
            bool canManage = PermissionService.HasPermissionForCompany(PermissionCodes.PolicyManagement, companyId);
            bool canAcknowledge = PermissionService.HasPermissionForCompany(PermissionCodes.PolicyAcknowledgement, companyId);
            if (!canManage && !canAcknowledge)
                throw new UnauthorizedAccessException("You do not have permission to view policy documents.");

            const string sql = @"SELECT pr.OriginalFileName, pr.ContentType, pr.FileData
FROM dbo.PolicyRevision pr
INNER JOIN dbo.CompanyPolicy p ON p.PolicyId=pr.PolicyId
WHERE pr.PolicyRevisionId=@RevisionId AND p.CompanyId=@CompanyId
  AND (@CanManage=1 OR EXISTS
      (SELECT 1 FROM dbo.PolicyAcknowledgement pa
       WHERE pa.PolicyRevisionId=pr.PolicyRevisionId
         AND pa.CompanyId=@CompanyId AND pa.EmployeeId=@EmployeeId));";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@RevisionId", SqlDbType.Int).Value = revisionId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@CanManage", SqlDbType.Bit).Value = canManage;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = (object)UserSession.EmployeeId ?? DBNull.Value;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    if (!reader.Read()) throw new InvalidOperationException("The policy document was not found.");
                    return new PolicyFile
                    {
                        FileName = Convert.ToString(reader["OriginalFileName"]),
                        ContentType = Convert.ToString(reader["ContentType"]),
                        Data = (byte[])reader["FileData"]
                    };
                }
            }
        }
    }
}
