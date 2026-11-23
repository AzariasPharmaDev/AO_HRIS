using System;
using System.Data;
using System.Data.SqlClient;
using AO_HRIS.Data;
using AO_HRIS.Security;

namespace AO_HRIS.UserControls.Employees
{
    public sealed class EmployeeDirectoryRepository
    {
        public DataTable GetDirectory(int companyId, string search)
        {
            if (companyId <= 0)
                throw new ArgumentOutOfRangeException("companyId");

            if (!PermissionService.HasPermissionForCompany(
                PermissionCodes.EmployeeRecords, companyId))
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to view employee records for this company.");
            }

            if (!PermissionService.HasPermissionForCompany(
                PermissionCodes.EmployeeAssignments, companyId))
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to view employee assignments for this company.");
            }

            const string sql = @"
        SELECT ea.AssignmentId, er.EmployeeId, er.EmployeeNo,
               LTRIM(RTRIM(CONCAT(er.FirstName, ' ', NULLIF(er.MiddleName, ''), ' ', er.LastName, ' ', NULLIF(er.Suffix, '')))) AS EmployeeName,
               er.PreferredName, er.Email, er.MobileNumber, er.TelephoneNumber,
               LTRIM(RTRIM(CONCAT(
                 COALESCE(NULLIF(er.AddressLine1, ''), ''),
                 CASE WHEN NULLIF(er.AddressLine2, '') IS NOT NULL THEN ', ' + er.AddressLine2 ELSE '' END,
                 CASE WHEN NULLIF(er.Barangay, '') IS NOT NULL THEN ', ' + er.Barangay ELSE '' END,
                 CASE WHEN NULLIF(er.City, '') IS NOT NULL THEN ', ' + er.City ELSE '' END,
                 CASE WHEN NULLIF(er.Province, '') IS NOT NULL THEN ', ' + er.Province ELSE '' END,
                 CASE WHEN NULLIF(er.PostalCode, '') IS NOT NULL THEN ' ' + er.PostalCode ELSE '' END,
                 CASE WHEN NULLIF(er.Country, '') IS NOT NULL THEN ', ' + er.Country ELSE '' END
               ))) AS FullAddress,
               c.CompanyName, d.DepartmentName, p.PositionName,
               ea.DateHired, ea.EmploymentStatus, ea.CompanyEmployeeNo
        FROM EmployeeAssignment ea
        INNER JOIN EmployeeRecord er ON er.EmployeeId = ea.EmployeeId
        INNER JOIN Company c ON c.CompanyId = ea.CompanyId
        LEFT JOIN Department d ON d.DepartmentId = ea.DepartmentId AND d.CompanyId = ea.CompanyId
        LEFT JOIN Position p ON p.PositionId = ea.PositionId
        WHERE ea.CompanyId = @CompanyId
          AND (@Search = '' OR er.EmployeeNo LIKE @LikeSearch
               OR er.FirstName LIKE @LikeSearch OR er.LastName LIKE @LikeSearch
               OR er.PreferredName LIKE @LikeSearch OR er.Email LIKE @LikeSearch
               OR er.MobileNumber LIKE @LikeSearch OR er.TelephoneNumber LIKE @LikeSearch
               OR c.CompanyName LIKE @LikeSearch OR d.DepartmentName LIKE @LikeSearch
               OR p.PositionName LIKE @LikeSearch
               OR CONCAT(er.FirstName, ' ', er.LastName) LIKE @LikeSearch)
        ORDER BY er.LastName, er.FirstName, ea.AssignmentId;";
            var result = new DataTable();
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(sql, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                string term = (search ?? string.Empty).Trim();
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                command.Parameters.Add("@Search", SqlDbType.NVarChar, 200).Value = term;
                command.Parameters.Add("@LikeSearch", SqlDbType.NVarChar, 410).Value = "%" + term.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") + "%";
                adapter.Fill(result);
            }
            return result;
        }
    }
}
