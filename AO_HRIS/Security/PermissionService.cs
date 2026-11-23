using AO_HRIS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Security
{
    public static class PermissionService
    {
        public static HashSet<string> GetPermissions()
        {
            var permissions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (UserSession.UserId <= 0 || !UserSession.CompanyId.HasValue) return permissions;
            const string sql = @"SELECT DISTINCT rp.PermissionCode
                FROM dbo.UserRole ur
                JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                JOIN dbo.RolePermission rp ON rp.RoleId=r.RoleId
                JOIN dbo.UserAccount ua ON ua.UserId=ur.UserId
                JOIN dbo.Company c ON c.CompanyId=@CompanyId
                WHERE ur.UserId=@UserId AND (ur.CompanyId=@CompanyId OR ur.CompanyId IS NULL)
                  AND ur.IsActive=1 AND r.IsActive=1 AND ua.IsActive=1 AND ua.IsLocked=0 AND c.IsActive=1
                  AND (EXISTS(SELECT 1 FROM dbo.EmployeeRecord er JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                        WHERE er.EmployeeId=ua.EmployeeId AND er.IsActive=1 AND ea.CompanyId=@CompanyId
                          AND ea.EmploymentStatus='ACTIVE' AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                          AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date)))
                    OR (UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(r.RoleCode,''),r.RoleName),'_',''),'-',''),' ',''))='SYSTEMADMIN' AND EXISTS(SELECT 1 FROM dbo.EmployeeRecord er0 JOIN dbo.EmployeeAssignment ea0 ON ea0.EmployeeId=er0.EmployeeId WHERE er0.EmployeeId=ua.EmployeeId AND er0.IsActive=1 AND ea0.EmploymentStatus='ACTIVE' AND ea0.EffectiveFrom<=CAST(GETDATE() AS date) AND (ea0.EffectiveTo IS NULL OR ea0.EffectiveTo>=CAST(GETDATE() AS date)))))";
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                con.Open(); using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) permissions.Add(Convert.ToString(reader["PermissionCode"]));
            }
            return permissions;
        }

        public static bool HasPermission(string permissionCode)
        {
            return !string.IsNullOrWhiteSpace(permissionCode) && GetPermissions().Contains(permissionCode);
        }

        public static bool HasPermissionForCompany(string permissionCode, int companyId)
        {
            if (string.IsNullOrWhiteSpace(permissionCode) || companyId <= 0 || UserSession.UserId <= 0) return false;
            const string sql = @"SELECT CASE WHEN EXISTS (
                SELECT 1 FROM dbo.UserRole ur
                JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                JOIN dbo.RolePermission rp ON rp.RoleId=r.RoleId
                JOIN dbo.UserAccount ua ON ua.UserId=ur.UserId
                JOIN dbo.Company c ON c.CompanyId=@CompanyId
                WHERE ur.UserId=@UserId AND (ur.CompanyId=@CompanyId OR ur.CompanyId IS NULL)
                  AND ur.IsActive=1 AND r.IsActive=1 AND ua.IsActive=1 AND ua.IsLocked=0
                  AND c.IsActive=1 AND rp.PermissionCode=@PermissionCode
                  AND (EXISTS(SELECT 1 FROM dbo.EmployeeRecord er JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                        WHERE er.EmployeeId=ua.EmployeeId AND er.IsActive=1 AND ea.CompanyId=@CompanyId
                          AND ea.EmploymentStatus='ACTIVE' AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                          AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date)))
                    OR (UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(r.RoleCode,''),r.RoleName),'_',''),'-',''),' ',''))='SYSTEMADMIN' AND EXISTS(SELECT 1 FROM dbo.EmployeeRecord er0 JOIN dbo.EmployeeAssignment ea0 ON ea0.EmployeeId=er0.EmployeeId WHERE er0.EmployeeId=ua.EmployeeId AND er0.IsActive=1 AND ea0.EmploymentStatus='ACTIVE' AND ea0.EffectiveFrom<=CAST(GETDATE() AS date) AND (ea0.EffectiveTo IS NULL OR ea0.EffectiveTo>=CAST(GETDATE() AS date)))))
            ) THEN 1 ELSE 0 END";
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@PermissionCode", SqlDbType.NVarChar, 100).Value = permissionCode;
                con.Open(); return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
        }

        public static HashSet<string> GetRoleCodes()
        {
            var roleCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (UserSession.UserId <= 0 || !UserSession.CompanyId.HasValue)
                return roleCodes;

            const string sql = @"
        SELECT DISTINCT
            UPPER(REPLACE(REPLACE(REPLACE(
                COALESCE(NULLIF(r.RoleCode, ''), r.RoleName),
                '_', ''), '-', ''), ' ', '')) AS RoleCode
        FROM dbo.UserRole ur
        JOIN dbo.[Role] r ON r.RoleId = ur.RoleId
        JOIN dbo.UserAccount ua ON ua.UserId = ur.UserId
        JOIN dbo.Company c ON c.CompanyId = @CompanyId
        WHERE ur.UserId = @UserId
          AND (ur.CompanyId = @CompanyId OR ur.CompanyId IS NULL)
          AND ur.IsActive = 1
          AND r.IsActive = 1
          AND ua.IsActive = 1
          AND ua.IsLocked = 0
          AND c.IsActive = 1
          AND (
              EXISTS (
                  SELECT 1
                  FROM dbo.EmployeeRecord er
                  JOIN dbo.EmployeeAssignment ea
                      ON ea.EmployeeId = er.EmployeeId
                  WHERE er.EmployeeId = ua.EmployeeId
                    AND er.IsActive = 1
                    AND ea.CompanyId = @CompanyId
                    AND ea.EmploymentStatus = 'ACTIVE'
                    AND ea.EffectiveFrom <= CAST(GETDATE() AS date)
                    AND (
                        ea.EffectiveTo IS NULL
                        OR ea.EffectiveTo >= CAST(GETDATE() AS date)
                    )
              )
              OR (
                  UPPER(REPLACE(REPLACE(REPLACE(
                      COALESCE(NULLIF(r.RoleCode, ''), r.RoleName),
                      '_', ''), '-', ''), ' ', '')) = 'SYSTEMADMIN'
                  AND EXISTS (
                      SELECT 1
                      FROM dbo.EmployeeRecord er0
                      JOIN dbo.EmployeeAssignment ea0
                          ON ea0.EmployeeId = er0.EmployeeId
                      WHERE er0.EmployeeId = ua.EmployeeId
                        AND er0.IsActive = 1
                        AND ea0.EmploymentStatus = 'ACTIVE'
                        AND ea0.EffectiveFrom <= CAST(GETDATE() AS date)
                        AND (
                            ea0.EffectiveTo IS NULL
                            OR ea0.EffectiveTo >= CAST(GETDATE() AS date)
                        )
                  )
              )
          )";

            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    UserSession.CompanyId.Value;

                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            roleCodes.Add(Convert.ToString(reader["RoleCode"]));
                    }
                }
            }

            return roleCodes;
        }

        public static bool HasAnyRole(params string[] roleCodes)
        {
            if (roleCodes == null || roleCodes.Length == 0)
                return false;

            HashSet<string> assignedRoles = GetRoleCodes();

            foreach (string roleCode in roleCodes)
            {
                if (string.IsNullOrWhiteSpace(roleCode))
                    continue;

                string normalized = roleCode
                    .Replace("_", "")
                    .Replace("-", "")
                    .Replace(" ", "");

                if (assignedRoles.Contains(normalized))
                    return true;
            }

            return false;
        }

        public static DataTable GetAuthorizedAssignmentCompanies()
        {
            var table = new DataTable();
            const string sql = @"SELECT DISTINCT c.CompanyId,c.CompanyName
                FROM dbo.Company c
                WHERE c.IsActive=1 AND (
                    EXISTS(SELECT 1 FROM dbo.UserRole ur JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                        WHERE ur.UserId=@UserId AND ur.IsActive=1 AND r.IsActive=1 AND ur.CompanyId IS NULL
                          AND UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(r.RoleCode,''),r.RoleName),'_',''),'-',''),' ',''))='SYSTEMADMIN'
                          AND EXISTS(SELECT 1 FROM dbo.EmployeeRecord er0 JOIN dbo.EmployeeAssignment ea0 ON ea0.EmployeeId=er0.EmployeeId WHERE er0.EmployeeId=@EmployeeId AND er0.IsActive=1 AND ea0.EmploymentStatus='ACTIVE' AND ea0.EffectiveFrom<=CAST(GETDATE() AS date) AND (ea0.EffectiveTo IS NULL OR ea0.EffectiveTo>=CAST(GETDATE() AS date))))
                    OR EXISTS(SELECT 1 FROM dbo.EmployeeRecord er JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                        WHERE er.EmployeeId=@EmployeeId AND er.IsActive=1 AND ea.CompanyId=c.CompanyId
                          AND ea.EmploymentStatus='ACTIVE' AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                          AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date)))
                ) ORDER BY c.CompanyName";
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = UserSession.EmployeeId.HasValue ? (object)UserSession.EmployeeId.Value : DBNull.Value;
                adapter.Fill(table);
            }
            return table;
        }
    }
}
