using System;
using System.Data;
using System.Data.SqlClient;
using AO_HRIS.Security;

namespace AO_HRIS.Data
{
    public sealed class UserAccessRepository
    {
        private static SqlParameter P(string name, SqlDbType type, object value)
        {
            return new SqlParameter(name, type) { Value = value ?? DBNull.Value };
        }

        private static bool IsGlobalSystemAdmin(SqlConnection con, SqlTransaction tx)
        {
            const string sql = @"SELECT CASE WHEN EXISTS (
                SELECT 1 FROM dbo.UserRole ur
                JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                JOIN dbo.UserAccount ua ON ua.UserId=ur.UserId
                JOIN dbo.EmployeeRecord er ON er.EmployeeId=ua.EmployeeId
                WHERE ur.UserId=@Actor AND ur.CompanyId IS NULL
                  AND ur.IsActive=1 AND r.IsActive=1 AND ua.IsActive=1 AND ua.IsLocked=0 AND er.IsActive=1
                  AND UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(r.RoleCode,''),r.RoleName),'_',''),'-',''),' ',''))='SYSTEMADMIN'
                  AND EXISTS(SELECT 1 FROM dbo.EmployeeAssignment ea WHERE ea.EmployeeId=er.EmployeeId
                    AND ea.EmploymentStatus='ACTIVE' AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                    AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date)))
            ) THEN 1 ELSE 0 END";
            using (var cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.Add(P("@Actor", SqlDbType.Int, UserSession.UserId));
                return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
        }                                                                                                               

        private static void Authorize(SqlConnection con, SqlTransaction tx, int companyId)
        {
            const string sql = @"SELECT CASE WHEN EXISTS (
                SELECT 1 FROM dbo.UserRole ur
                JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                JOIN dbo.RolePermission rp ON rp.RoleId=r.RoleId
                JOIN dbo.UserAccount ua ON ua.UserId=ur.UserId
                JOIN dbo.Company c ON c.CompanyId=@CompanyId
                WHERE ur.UserId=@Actor AND (ur.CompanyId=@CompanyId OR ur.CompanyId IS NULL)
                  AND ur.IsActive=1 AND r.IsActive=1 AND ua.IsActive=1 AND ua.IsLocked=0
                  AND c.IsActive=1 AND rp.PermissionCode=@Permission
                  AND (EXISTS(SELECT 1 FROM dbo.EmployeeRecord er JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                        WHERE er.EmployeeId=ua.EmployeeId AND er.IsActive=1 AND ea.CompanyId=@CompanyId
                          AND ea.EmploymentStatus='ACTIVE' AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                          AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date)))
                    OR (ur.CompanyId IS NULL AND UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(r.RoleCode,''),r.RoleName),'_',''),'-',''),' ',''))='SYSTEMADMIN'
                        AND EXISTS(SELECT 1 FROM dbo.EmployeeRecord er0 JOIN dbo.EmployeeAssignment ea0 ON ea0.EmployeeId=er0.EmployeeId
                          WHERE er0.EmployeeId=ua.EmployeeId AND er0.IsActive=1 AND ea0.EmploymentStatus='ACTIVE'
                            AND ea0.EffectiveFrom<=CAST(GETDATE() AS date) AND (ea0.EffectiveTo IS NULL OR ea0.EffectiveTo>=CAST(GETDATE() AS date)))))
            ) THEN 1 ELSE 0 END";
            using (var cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.Add(P("@Actor", SqlDbType.Int, UserSession.UserId));
                cmd.Parameters.Add(P("@CompanyId", SqlDbType.Int, companyId));
                cmd.Parameters.Add(P("@Permission", SqlDbType.NVarChar, PermissionCodes.UserRoleManagement));
                if (Convert.ToInt32(cmd.ExecuteScalar()) != 1)
                    throw new UnauthorizedAccessException("You do not have User & Access Management permission for this company.");
            }
        }

        private static void EnsureEmployee(SqlConnection con, SqlTransaction tx, int employeeId, int companyId)
        {
            const string sql = @"SELECT COUNT(*) FROM dbo.EmployeeRecord er
                JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                JOIN dbo.Company c ON c.CompanyId=ea.CompanyId
                WHERE er.EmployeeId=@EmployeeId AND er.IsActive=1 AND c.IsActive=1
                  AND ea.CompanyId=@CompanyId AND ea.EmploymentStatus='ACTIVE'
                  AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date))";
            using (var cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.Add(P("@EmployeeId", SqlDbType.Int, employeeId));
                cmd.Parameters.Add(P("@CompanyId", SqlDbType.Int, companyId));
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    throw new InvalidOperationException("The selected employee is not active in the selected company.");
            }
        }

        // Used for management actions that must still work for former employees, e.g. deactivation.
        private static void EnsureUserBelongsToCompany(SqlConnection con, SqlTransaction tx, int userId, int companyId)
        {
            const string sql = @"SELECT COUNT(*) FROM dbo.UserAccount ua
                JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=ua.EmployeeId
                WHERE ua.UserId=@UserId AND ua.EmployeeId IS NOT NULL AND ea.CompanyId=@CompanyId";
            using (var cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.Add(P("@UserId", SqlDbType.Int, userId));
                cmd.Parameters.Add(P("@CompanyId", SqlDbType.Int, companyId));
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    throw new InvalidOperationException("The account is not associated with an employee assignment in this company.");
            }
        }

        private static void EnsureActiveUserAssignment(SqlConnection con, SqlTransaction tx, int userId, int companyId)
        {
            const string sql = @"SELECT COUNT(*) FROM dbo.UserAccount ua
                JOIN dbo.EmployeeRecord er ON er.EmployeeId=ua.EmployeeId
                JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                JOIN dbo.Company c ON c.CompanyId=ea.CompanyId
                WHERE ua.UserId=@UserId AND ua.EmployeeId IS NOT NULL AND er.IsActive=1
                  AND ea.CompanyId=@CompanyId AND c.IsActive=1 AND ea.EmploymentStatus='ACTIVE'
                  AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date))";
            using (var cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.Add(P("@UserId", SqlDbType.Int, userId));
                cmd.Parameters.Add(P("@CompanyId", SqlDbType.Int, companyId));
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    throw new InvalidOperationException("The account does not belong to an active employee assignment in this company.");
            }
        }

        private static void Audit(SqlConnection con, SqlTransaction tx, string action, string table, int? recordId, string description)
        {
            using (var cmd = new SqlCommand(@"INSERT INTO dbo.AuditLog
                (UserId,ActionType,TableName,RecordId,Description,CreatedAt)
                VALUES(@UserId,@Action,@Table,@Record,@Description,SYSUTCDATETIME())", con, tx))
            {
                cmd.Parameters.Add(P("@UserId", SqlDbType.Int, UserSession.UserId > 0 ? (object)UserSession.UserId : null));
                cmd.Parameters.Add(P("@Action", SqlDbType.NVarChar, action));
                cmd.Parameters.Add(P("@Table", SqlDbType.NVarChar, table));
                cmd.Parameters.Add(P("@Record", SqlDbType.NVarChar, recordId.HasValue ? recordId.Value.ToString() : null));
                cmd.Parameters.Add(P("@Description", SqlDbType.NVarChar, description));
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetEmployees(int companyId)
        {
            const string sql = @"SELECT DISTINCT er.EmployeeId,
                LTRIM(RTRIM(COALESCE(er.LastName,'') + ', ' + COALESCE(er.FirstName,'') + ' ' + COALESCE(er.MiddleName,''))) AS DisplayName
                FROM dbo.EmployeeRecord er JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                JOIN dbo.Company c ON c.CompanyId=ea.CompanyId
                WHERE er.IsActive=1 AND c.IsActive=1 AND ea.CompanyId=@CompanyId AND ea.EmploymentStatus='ACTIVE'
                  AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date))
                ORDER BY DisplayName";
            return Query(sql, P("@CompanyId", SqlDbType.Int, companyId));
        }

        public DataTable GetAccountByEmployee(int employeeId, int companyId)
        {
            const string sql = @"SELECT ua.UserId,ua.EmployeeId,ua.Username,ua.Email,ua.IsActive,ua.IsLocked
                FROM dbo.UserAccount ua JOIN dbo.EmployeeRecord er ON er.EmployeeId=ua.EmployeeId
                WHERE ua.EmployeeId=@EmployeeId AND er.IsActive=1
                  AND EXISTS(SELECT 1 FROM dbo.EmployeeAssignment ea WHERE ea.EmployeeId=er.EmployeeId AND ea.CompanyId=@CompanyId)";
            return Query(sql, P("@EmployeeId", SqlDbType.Int, employeeId), P("@CompanyId", SqlDbType.Int, companyId));
        }

        public bool CanManageGlobalAccount(int companyId)
        {
            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open(); return IsGlobalSystemAdmin(con, null);
            }
        }

        public DataTable GetRoles(int companyId)
        {
            bool systemAdmin;
            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open(); systemAdmin = IsGlobalSystemAdmin(con, null);
            }
            const string sql = @"SELECT RoleId,RoleName FROM dbo.[Role]
                WHERE IsActive=1 AND (@SystemAdmin=1 OR UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(RoleCode,''),RoleName),'_',''),'-',''),' ','')) NOT IN ('SYSTEMADMIN','HRMANAGER'))
                ORDER BY RoleName";
            return Query(sql, P("@SystemAdmin", SqlDbType.Bit, systemAdmin));
        }

        public DataTable GetAccounts(int companyId, string search)
        {
            const string sql = @"SELECT ua.UserId,ua.EmployeeId,ua.Username,ua.Email,
                COALESCE(er.EmployeeNo,'') AS EmployeeNo,
                LTRIM(RTRIM(COALESCE(er.FirstName,'')+' '+COALESCE(er.LastName,''))) AS EmployeeName,
                ua.IsActive,ua.IsLocked,ua.LastLoginAt,
                STUFF((SELECT ', '+r.RoleName FROM dbo.UserRole ur JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                    WHERE ur.UserId=ua.UserId AND (ur.CompanyId=@CompanyId OR ur.CompanyId IS NULL) AND ur.IsActive=1 AND r.IsActive=1
                    ORDER BY r.RoleName FOR XML PATH(''),TYPE).value('.','nvarchar(max)'),1,2,'') AS Roles
                FROM dbo.UserAccount ua JOIN dbo.EmployeeRecord er ON er.EmployeeId=ua.EmployeeId
                WHERE EXISTS(SELECT 1 FROM dbo.EmployeeAssignment ea WHERE ea.EmployeeId=er.EmployeeId AND ea.CompanyId=@CompanyId)
                  AND (@Search='' OR ua.Username LIKE '%'+@Search+'%' OR er.EmployeeNo LIKE '%'+@Search+'%'
                    OR er.FirstName LIKE '%'+@Search+'%' OR er.LastName LIKE '%'+@Search+'%')
                ORDER BY ua.Username";
            return Query(sql, P("@CompanyId", SqlDbType.Int, companyId), P("@Search", SqlDbType.NVarChar, (search ?? "").Trim()));
        }

        public DataTable GetUserRoles(int userId, int companyId)
        {
            const string sql = @"SELECT ur.UserRoleId,r.RoleName,ur.AssignedAt FROM dbo.UserRole ur
                JOIN dbo.[Role] r ON r.RoleId=ur.RoleId WHERE ur.UserId=@UserId AND ur.CompanyId=@CompanyId AND ur.IsActive=1 ORDER BY r.RoleName";
            return Query(sql, P("@UserId", SqlDbType.Int, userId), P("@CompanyId", SqlDbType.Int, companyId));
        }

        private static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(parameters);
                var table = new DataTable(); adapter.Fill(table); return table;
            }
        }

        public int SaveAccount(int? userId, int employeeId, string username, string email, string password, int companyId)
        {
            username = (username ?? "").Trim(); email = (email ?? "").Trim();
            if (username.Length < 1 || username.Length > 100) throw new ArgumentException("Username must contain 1–100 characters.");
            if (email.Length > 150) throw new ArgumentException("Email is too long.");
            if (!userId.HasValue && (password ?? "").Length < 12) throw new ArgumentException("New accounts require a password of at least 12 characters.");
            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open(); using (var tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        Authorize(con, tx, companyId);
                        EnsureEmployee(con, tx, employeeId, companyId);
                        if (userId.HasValue)
                        {
                            if (!IsGlobalSystemAdmin(con, tx)) throw new UnauthorizedAccessException("Only a global System Administrator can edit account details shared across subsidiaries.");
                            EnsureUserBelongsToCompany(con, tx, userId.Value, companyId);
                            using (var linkedEmployee = new SqlCommand("SELECT EmployeeId FROM dbo.UserAccount WHERE UserId=@UserId", con, tx))
                            {
                                linkedEmployee.Parameters.Add(P("@UserId", SqlDbType.Int, userId.Value));
                                object linkedId = linkedEmployee.ExecuteScalar();
                                if (linkedId == null || linkedId == DBNull.Value || Convert.ToInt32(linkedId) != employeeId)
                                    throw new InvalidOperationException("An existing login cannot be transferred to another employee. Create a separate employee account instead.");
                            }
                        }
                        using (var check = new SqlCommand(@"SELECT COUNT(*) FROM dbo.UserAccount WITH(UPDLOCK,HOLDLOCK)
                            WHERE (Username=@Username OR EmployeeId=@EmployeeId) AND (@UserId IS NULL OR UserId<>@UserId)", con, tx))
                        {
                            check.Parameters.Add(P("@Username", SqlDbType.NVarChar, username));
                            check.Parameters.Add(P("@EmployeeId", SqlDbType.Int, employeeId));
                            check.Parameters.Add(P("@UserId", SqlDbType.Int, userId));
                            if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                                throw new InvalidOperationException("This username or employee already has an account.");
                        }
                        int id;
                        if (userId.HasValue)
                        {
                            using (var cmd = new SqlCommand(@"UPDATE dbo.UserAccount SET Username=@Username,
                                Email=@Email,UpdatedAt=SYSUTCDATETIME() WHERE UserId=@UserId", con, tx))
                            {
                                cmd.Parameters.Add(P("@Username", SqlDbType.NVarChar, username));
                                cmd.Parameters.Add(P("@Email", SqlDbType.NVarChar, email.Length == 0 ? null : email));
                                cmd.Parameters.Add(P("@UserId", SqlDbType.Int, userId.Value));
                                if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Account not found.");
                            }
                            id = userId.Value;
                            Audit(con, tx, "ACCOUNT_UPDATED", "UserAccount", id, "Updated global login details for employee " + employeeId + ".");
                        }
                        else
                        {
                            using (var cmd = new SqlCommand(@"INSERT INTO dbo.UserAccount
                                (EmployeeId,Username,Email,PasswordHash,IsActive,IsLocked,FailedLoginAttempts,CreatedAt)
                                OUTPUT INSERTED.UserId VALUES(@EmployeeId,@Username,@Email,@Hash,1,0,0,SYSUTCDATETIME())", con, tx))
                            {
                                cmd.Parameters.Add(P("@EmployeeId", SqlDbType.Int, employeeId));
                                cmd.Parameters.Add(P("@Username", SqlDbType.NVarChar, username));
                                cmd.Parameters.Add(P("@Email", SqlDbType.NVarChar, email.Length == 0 ? null : email));
                                cmd.Parameters.Add(P("@Hash", SqlDbType.NVarChar, PasswordHelper.HashPassword(password)));
                                id = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                            Audit(con, tx, "ACCOUNT_CREATED", "UserAccount", id, "Created login account for employee " + employeeId + " in company " + companyId + ".");
                        }
                        tx.Commit(); return id;
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
        }

        public void AssignRole(int userId, int roleId, int companyId)
        {
            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open(); using (var tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        Authorize(con, tx, companyId); EnsureActiveUserAssignment(con, tx, userId, companyId);
                        bool systemAdmin = IsGlobalSystemAdmin(con, tx);
                        string roleCode;
                        using (var role = new SqlCommand("SELECT RoleCode FROM dbo.[Role] WITH(UPDLOCK,HOLDLOCK) WHERE RoleId=@RoleId AND IsActive=1", con, tx))
                        {
                            role.Parameters.Add(P("@RoleId", SqlDbType.Int, roleId));
                            object value = role.ExecuteScalar();
                            if (value == null || value == DBNull.Value) throw new InvalidOperationException("Invalid or inactive role.");
                            roleCode = Convert.ToString(value);
                        }
                        string normalized = (roleCode ?? "").Replace("_", "").Replace("-", "").Replace(" ", "").ToUpperInvariant();
                        if (!systemAdmin && (normalized == "SYSTEMADMIN" || normalized == "HRMANAGER"))
                            throw new UnauthorizedAccessException("Only a System Administrator can assign System Administrator or HR Manager roles.");
                        using (var cmd = new SqlCommand(@"IF EXISTS(SELECT 1 FROM dbo.UserRole WITH(UPDLOCK,HOLDLOCK)
                            WHERE UserId=@UserId AND CompanyId=@CompanyId AND RoleId=@RoleId)
                            UPDATE dbo.UserRole SET IsActive=1,AssignedAt=SYSUTCDATETIME()
                            WHERE UserId=@UserId AND CompanyId=@CompanyId AND RoleId=@RoleId;
                            ELSE INSERT INTO dbo.UserRole(UserId,RoleId,CompanyId,AssignedAt,IsActive)
                            VALUES(@UserId,@RoleId,@CompanyId,SYSUTCDATETIME(),1)", con, tx))
                        {
                            cmd.Parameters.Add(P("@UserId", SqlDbType.Int, userId));
                            cmd.Parameters.Add(P("@RoleId", SqlDbType.Int, roleId));
                            cmd.Parameters.Add(P("@CompanyId", SqlDbType.Int, companyId));
                            cmd.ExecuteNonQuery();
                        }
                        Audit(con, tx, "ROLE_ASSIGNED", "UserRole", userId, "Assigned role " + roleCode + " in company " + companyId + ".");
                        tx.Commit();
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
        }

        public void RevokeRole(int userId, int userRoleId, int companyId)
        {
            if (userId == UserSession.UserId) throw new InvalidOperationException("You cannot revoke your own roles.");
            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open(); using (var tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        Authorize(con, tx, companyId); EnsureUserBelongsToCompany(con, tx, userId, companyId);
                        bool systemAdmin = IsGlobalSystemAdmin(con, tx);
                        string roleCode;
                        using (var find = new SqlCommand(@"SELECT r.RoleCode FROM dbo.UserRole ur JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                            WHERE ur.UserRoleId=@Id AND ur.UserId=@UserId AND (ur.CompanyId=@CompanyId OR ur.CompanyId IS NULL) AND ur.IsActive=1", con, tx))
                        {
                            find.Parameters.Add(P("@Id", SqlDbType.Int, userRoleId)); find.Parameters.Add(P("@UserId", SqlDbType.Int, userId)); find.Parameters.Add(P("@CompanyId", SqlDbType.Int, companyId));
                            object value = find.ExecuteScalar();
                            if (value == null || value == DBNull.Value) throw new InvalidOperationException("Role assignment not found.");
                            roleCode = Convert.ToString(value);
                        }
                        string normalized = (roleCode ?? "").Replace("_", "").Replace("-", "").Replace(" ", "").ToUpperInvariant();
                        if (!systemAdmin && (normalized == "SYSTEMADMIN" || normalized == "HRMANAGER"))
                            throw new UnauthorizedAccessException("Only a System Administrator can revoke privileged roles.");
                        using (var cmd = new SqlCommand(@"UPDATE dbo.UserRole SET IsActive=0
                            WHERE UserRoleId=@Id AND UserId=@UserId AND CompanyId=@CompanyId AND IsActive=1", con, tx))
                        {
                            cmd.Parameters.Add(P("@Id", SqlDbType.Int, userRoleId)); cmd.Parameters.Add(P("@UserId", SqlDbType.Int, userId)); cmd.Parameters.Add(P("@CompanyId", SqlDbType.Int, companyId));
                            if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Only company-specific roles can be revoked here. Global roles require a System Administrator.");
                        }
                        Audit(con, tx, "ROLE_REVOKED", "UserRole", userId, "Revoked role " + roleCode + " in company " + companyId + ".");
                        tx.Commit();
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
        }

        public void SetStatus(int userId, int companyId, bool? active, bool? locked)
        {
            if (userId == UserSession.UserId && (active == false || locked == true))
                throw new InvalidOperationException("You cannot deactivate or lock your own account.");
            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open(); using (var tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        Authorize(con, tx, companyId);
                        if (!IsGlobalSystemAdmin(con, tx)) throw new UnauthorizedAccessException("Only a global System Administrator can change account status shared across subsidiaries.");
                        EnsureUserBelongsToCompany(con, tx, userId, companyId);
                        bool oldActive, oldLocked;
                        using (var get = new SqlCommand("SELECT IsActive,IsLocked FROM dbo.UserAccount WITH(UPDLOCK,HOLDLOCK) WHERE UserId=@Id", con, tx))
                        {
                            get.Parameters.Add(P("@Id", SqlDbType.Int, userId)); using (var reader = get.ExecuteReader())
                            { if (!reader.Read()) throw new InvalidOperationException("Account not found."); oldActive = reader.GetBoolean(0); oldLocked = reader.GetBoolean(1); }
                        }
                        using (var cmd = new SqlCommand(@"UPDATE dbo.UserAccount SET IsActive=COALESCE(@Active,IsActive),
                            IsLocked=COALESCE(@Locked,IsLocked),FailedLoginAttempts=CASE WHEN @Locked=0 THEN 0 ELSE FailedLoginAttempts END,
                            UpdatedAt=SYSUTCDATETIME() WHERE UserId=@UserId", con, tx))
                        {
                            cmd.Parameters.Add(P("@Active", SqlDbType.Bit, active)); cmd.Parameters.Add(P("@Locked", SqlDbType.Bit, locked)); cmd.Parameters.Add(P("@UserId", SqlDbType.Int, userId)); cmd.ExecuteNonQuery();
                        }
                        bool newActive = active.HasValue ? active.Value : oldActive;
                        bool newLocked = locked.HasValue ? locked.Value : oldLocked;
                        if (newActive != oldActive) Audit(con, tx, newActive ? "ACCOUNT_ACTIVATED" : "ACCOUNT_DEACTIVATED", "UserAccount", userId, "Account active status changed in company " + companyId + ".");
                        if (newLocked != oldLocked) Audit(con, tx, newLocked ? "ACCOUNT_LOCKED" : "ACCOUNT_UNLOCKED", "UserAccount", userId, "Account lock status changed in company " + companyId + ".");
                        tx.Commit();
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
        }

        public void ResetPassword(int userId, int companyId, string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 12) throw new ArgumentException("Password must contain at least 12 characters.");
            string hash = PasswordHelper.HashPassword(password);
            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open(); using (var tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        Authorize(con, tx, companyId);
                        if (!IsGlobalSystemAdmin(con, tx)) throw new UnauthorizedAccessException("Only a global System Administrator can reset account passwords shared across subsidiaries.");
                        EnsureUserBelongsToCompany(con, tx, userId, companyId);
                        using (var cmd = new SqlCommand(@"UPDATE dbo.UserAccount SET PasswordHash=@Hash,FailedLoginAttempts=0,
                            IsLocked=0,UpdatedAt=SYSUTCDATETIME() WHERE UserId=@UserId", con, tx))
                        {
                            cmd.Parameters.Add(P("@Hash", SqlDbType.NVarChar, hash)); cmd.Parameters.Add(P("@UserId", SqlDbType.Int, userId));
                            if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Account not found.");
                        }
                        Audit(con, tx, "PASSWORD_RESET", "UserAccount", userId, "Password reset by administrator.");
                        tx.Commit();
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
        }
    }
}
