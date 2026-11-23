using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Data
{
    public sealed class UserAccountRepository
    {
        public DataTable GetAccounts(int companyId, string search)
        {
            const string sql = @"
            SELECT ua.UserId, ua.EmployeeId, ua.Username, ua.Email,
                   ISNULL(er.EmployeeNo, '') AS EmployeeNo,
                   LTRIM(RTRIM(ISNULL(er.FirstName, '') + ' ' + ISNULL(er.LastName, ''))) AS EmployeeName,
                   ua.IsActive, ua.IsLocked, ua.FailedLoginAttempts, ua.LastLoginAt,
                   STUFF((SELECT ', ' + r.RoleName FROM dbo.UserRole ur
                          INNER JOIN dbo.[Role] r ON r.RoleId = ur.RoleId
                          WHERE ur.UserId = ua.UserId AND ur.IsActive = 1 AND r.IsActive = 1
                            AND (ur.CompanyId = @CompanyId OR ur.CompanyId IS NULL)
                          FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '') AS Roles
            FROM dbo.UserAccount ua
            LEFT JOIN dbo.EmployeeRecord er ON er.EmployeeId = ua.EmployeeId
            WHERE (@Search = '' OR ua.Username LIKE '%' + @Search + '%'
                OR er.EmployeeNo LIKE '%' + @Search + '%'
                OR er.FirstName LIKE '%' + @Search + '%'
                OR er.LastName LIKE '%' + @Search + '%')
              AND (EXISTS (SELECT 1 FROM dbo.UserRole ur WHERE ur.UserId = ua.UserId
                             AND (ur.CompanyId = @CompanyId OR ur.CompanyId IS NULL))
                   OR NOT EXISTS (SELECT 1 FROM dbo.UserRole ur WHERE ur.UserId = ua.UserId))
            ORDER BY ua.Username;";
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 100).Value = (search ?? "").Trim();
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable GetEmployees()
        {
            const string sql = @"SELECT er.EmployeeId,
            er.EmployeeNo + ' - ' + er.FirstName + ' ' + er.LastName AS DisplayName
            FROM dbo.EmployeeRecord er WHERE er.IsActive = 1
            ORDER BY er.LastName, er.FirstName";
            return ReadTable(sql);
        }

        public DataTable GetRoles()
        {
            return ReadTable("SELECT RoleId, RoleName FROM dbo.[Role] WHERE IsActive = 1 ORDER BY RoleName");
        }

        private static DataTable ReadTable(string sql)
        {
            using (var con = DatabaseConnection.GetConnection())
            using (var adapter = new SqlDataAdapter(sql, con))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public int? GetCompanyRole(int userId, int companyId)
        {
            const string sql = @"SELECT TOP (1) RoleId FROM dbo.UserRole
 WHERE UserId=@UserId AND CompanyId=@CompanyId AND IsActive=1 ORDER BY UserRoleId DESC";
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                con.Open();
                object result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? (int?)null : Convert.ToInt32(result);
            }
        }

        public int Save(int? userId, int? employeeId, string username, string email,
                        string newPassword, int roleId, int companyId)
        {
            username = (username ?? "").Trim();
            email = (email ?? "").Trim();
            if (username.Length == 0 || username.Length > 100)
                throw new ArgumentException("Username must contain 1 to 100 characters.");
            if (email.Length > 150) throw new ArgumentException("Email is too long.");
            if (roleId <= 0 || companyId <= 0) throw new ArgumentException("Select a valid role and company.");
            if (!userId.HasValue && string.IsNullOrEmpty(newPassword))
                throw new ArgumentException("A password is required for a new account.");
            if (newPassword != null && newPassword.Length > 0 && newPassword.Length < 12)
                throw new ArgumentException("Passwords must be at least 12 characters.");

            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        int id;
                        using (var check = new SqlCommand(@"
SELECT COUNT(*) FROM dbo.UserAccount WITH (UPDLOCK, HOLDLOCK)
WHERE (Username=@Username AND (@UserId IS NULL OR UserId<>@UserId))
   OR (EmployeeId=@EmployeeId AND @EmployeeId IS NOT NULL
       AND (@UserId IS NULL OR UserId<>@UserId));", con, tx))
                        {
                            check.Parameters.Add("@Username", SqlDbType.NVarChar, 100).Value = username;
                            check.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = (object)employeeId ?? DBNull.Value;
                            check.Parameters.Add("@UserId", SqlDbType.Int).Value = (object)userId ?? DBNull.Value;
                            if ((int)check.ExecuteScalar() > 0)
                                throw new InvalidOperationException("Username or employee is already linked to another account.");
                        }
                        if (userId.HasValue)
                        {
                            id = userId.Value;
                            using (var cmd = new SqlCommand(@"
UPDATE dbo.UserAccount SET Username=@Username, Email=@Email,
 EmployeeId=@EmployeeId, UpdatedAt=SYSUTCDATETIME()
WHERE UserId=@UserId;", con, tx))
                            {
                                AddIdentityFields(cmd, id, employeeId, username, email);
                                if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Account not found.");
                            }
                        }
                        else
                        {
                            using (var cmd = new SqlCommand(@"
INSERT INTO dbo.UserAccount (EmployeeId, Username, Email, PasswordHash,
 IsActive, IsLocked, FailedLoginAttempts, CreatedAt)
OUTPUT INSERTED.UserId
VALUES (@EmployeeId, @Username, @Email, @Hash, 1, 0, 0, SYSUTCDATETIME());", con, tx))
                            {
                                AddIdentityFields(cmd, null, employeeId, username, email);
                                cmd.Parameters.Add("@Hash", SqlDbType.NVarChar, 500).Value = PasswordHelper.HashPassword(newPassword);
                                id = (int)cmd.ExecuteScalar();
                            }
                        }
                        using (var cmd = new SqlCommand(@"
UPDATE dbo.UserRole SET IsActive=0 WHERE UserId=@UserId AND CompanyId=@CompanyId AND IsActive=1;
INSERT INTO dbo.UserRole (UserId, RoleId, CompanyId, AssignedAt, IsActive)
VALUES (@UserId, @RoleId, @CompanyId, SYSUTCDATETIME(), 1);", con, tx))
                        {
                            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = id;
                            cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = roleId;
                            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                        return id;
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
        }

        private static void AddIdentityFields(SqlCommand cmd, int? userId, int? employeeId, string username, string email)
        {
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = (object)userId ?? DBNull.Value;
            cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = (object)employeeId ?? DBNull.Value;
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 100).Value = username;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email.Length == 0 ? (object)DBNull.Value : email;
        }

        public void ResetPassword(int userId, string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 12)
                throw new ArgumentException("Password must be at least 12 characters.");
            ExecuteAccountUpdate(userId, "PasswordHash=@Hash, FailedLoginAttempts=0", PasswordHelper.HashPassword(password));
        }

        public void SetStatus(int userId, bool? active, bool? locked)
        {
            if (userId == UserSession.UserId && (active == false || locked == true))
                throw new InvalidOperationException("You cannot disable or lock your own account.");
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(@"UPDATE dbo.UserAccount SET
 IsActive=COALESCE(@Active, IsActive), IsLocked=COALESCE(@Locked, IsLocked),
 FailedLoginAttempts=CASE WHEN @Locked=0 THEN 0 ELSE FailedLoginAttempts END,
 UpdatedAt=SYSUTCDATETIME() WHERE UserId=@UserId", con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = (object)active ?? DBNull.Value;
                cmd.Parameters.Add("@Locked", SqlDbType.Bit).Value = (object)locked ?? DBNull.Value;
                con.Open();
                if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Account not found.");
            }
        }

        private static void ExecuteAccountUpdate(int userId, string setClause, string hash)
        {
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand("UPDATE dbo.UserAccount SET " + setClause + ", UpdatedAt=SYSUTCDATETIME() WHERE UserId=@UserId", con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@Hash", SqlDbType.NVarChar, 500).Value = hash;
                con.Open();
                if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Account not found.");
            }
        }
    }
}
