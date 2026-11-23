using AO_HRIS.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using AO_HRIS.Security;

namespace AO_HRIS.Data
{
    public sealed class RoleManagementRepository
    {
        public DataTable GetRoles()
        {
            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(@"
                SELECT RoleId, RoleCode, RoleName, IsActive
                FROM dbo.Role ORDER BY RoleName", connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                var result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }

        public DataTable GetRolePermissions(int roleId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(@"
                SELECT PermissionCode FROM dbo.RolePermission
                WHERE RoleId = @RoleId", connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                command.Parameters.Add("@RoleId", SqlDbType.Int).Value = roleId;
                var result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }

        public int SaveRole(int? roleId, string roleCode, string roleName, bool isActive, string[] permissions)
        {
            roleCode = (roleCode ?? "").Trim().ToUpperInvariant();
            roleName = (roleName ?? "").Trim();
            if (roleCode.Length == 0 || roleName.Length == 0)
                throw new ArgumentException("Role code and name are required.");
            if (roleCode.Length > 50 || roleName.Length > 100)
                throw new ArgumentException("Role code or name is too long.");
            if (permissions == null) permissions = new string[0];

            if (!UserSession.CompanyId.HasValue || UserSession.UserId <= 0)
                throw new UnauthorizedAccessException("A signed-in administrator and active company are required.");

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var authorize = new SqlCommand(@"SELECT COUNT(*) FROM dbo.UserRole ur
                            JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                            JOIN dbo.UserAccount ua ON ua.UserId=ur.UserId
                            JOIN dbo.EmployeeRecord er ON er.EmployeeId=ua.EmployeeId
                            JOIN dbo.Company c ON c.CompanyId=@CompanyId
                            WHERE ur.UserId=@UserId AND ur.CompanyId IS NULL
                              AND ur.IsActive=1 AND r.IsActive=1 AND ua.IsActive=1 AND ua.IsLocked=0 AND er.IsActive=1 AND c.IsActive=1
                              AND UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(r.RoleCode,''),r.RoleName),'_',''),'-',''),' ',''))='SYSTEMADMIN'
                              AND EXISTS(SELECT 1 FROM dbo.EmployeeAssignment ea WHERE ea.EmployeeId=er.EmployeeId
                                AND ea.EmploymentStatus='ACTIVE' AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                                AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date)))", connection, transaction))
                        {
                            authorize.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                            authorize.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                            if (Convert.ToInt32(authorize.ExecuteScalar()) == 0)
                                throw new UnauthorizedAccessException("Only a global System Administrator can modify role definitions and permissions.");
                        }
                        int id;
                        using (var command = new SqlCommand(roleId.HasValue ? @"
                            UPDATE dbo.Role SET RoleCode=@Code, RoleName=@Name, IsActive=@Active
                            WHERE RoleId=@Id;
                            SELECT @@ROWCOUNT;" : @"
                            INSERT INTO dbo.Role (RoleCode, RoleName, IsActive)
                            VALUES (@Code, @Name, @Active);
                            SELECT CAST(SCOPE_IDENTITY() AS int);", connection, transaction))
                        {
                            command.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = roleCode;
                            command.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = roleName;
                            command.Parameters.Add("@Active", SqlDbType.Bit).Value = isActive;
                            if (roleId.HasValue) command.Parameters.Add("@Id", SqlDbType.Int).Value = roleId.Value;
                            int result = Convert.ToInt32(command.ExecuteScalar());
                            if (roleId.HasValue && result != 1)
                                throw new InvalidOperationException("Role no longer exists.");
                            id = roleId ?? result;
                        }
                        using (var command = new SqlCommand("DELETE FROM dbo.RolePermission WHERE RoleId=@Id", connection, transaction))
                        {
                            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            command.ExecuteNonQuery();
                        }
                        foreach (string permission in permissions)
                        {
                            using (var command = new SqlCommand(@"
                                INSERT INTO dbo.RolePermission (RoleId, PermissionCode)
                                VALUES (@Id, @Permission)", connection, transaction))
                            {
                                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                                command.Parameters.Add("@Permission", SqlDbType.NVarChar, 100).Value = permission;
                                command.ExecuteNonQuery();
                            }
                        }
                        using (var audit = new SqlCommand(@"INSERT INTO dbo.AuditLog(UserId,ActionType,TableName,RecordId,Description,CreatedAt)
                            VALUES(@UserId,@Action,'Role',@Record,@Description,SYSUTCDATETIME())", connection, transaction))
                        {
                            audit.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                            audit.Parameters.Add("@Action", SqlDbType.NVarChar, 50).Value = roleId.HasValue ? "ROLE_DEFINITION_UPDATED" : "ROLE_DEFINITION_CREATED";
                            audit.Parameters.Add("@Record", SqlDbType.NVarChar, 100).Value = id.ToString();
                            audit.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = "Role definition and permission list saved.";
                            audit.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return id;
                    }
                    catch { transaction.Rollback(); throw; }
                }
            }
        }
    }
}
