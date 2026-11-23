using System;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Data
{
    public sealed class OrganizationChartRepository
    {
        public DataTable GetAssignments(int companyId)
        {
            const string sql = @"
SELECT ea.AssignmentId,
       ea.ManagerAssignmentId,
       er.EmployeeId,
       LTRIM(RTRIM(COALESCE(er.LastName, '') + ', ' + COALESCE(er.FirstName, '') +
           CASE WHEN NULLIF(LTRIM(RTRIM(COALESCE(er.MiddleName, ''))), '') IS NULL
                THEN '' ELSE ' ' + LTRIM(RTRIM(er.MiddleName)) END)) AS EmployeeName,
       COALESCE(er.EmployeeNo, '') AS EmployeeNo,
       COALESCE(d.DepartmentName, 'Unassigned Department') AS DepartmentName,
       COALESCE(pd.DepartmentName, d.DepartmentName, 'Unassigned Department') AS MainDepartmentName,
       COALESCE(p.PositionName, 'Unassigned Position') AS PositionName,
       ea.DepartmentId,
       d.ParentDepartmentId,
       COALESCE(d.ParentDepartmentId, d.DepartmentId) AS MainDepartmentId
FROM dbo.EmployeeAssignment ea
INNER JOIN dbo.EmployeeRecord er ON er.EmployeeId = ea.EmployeeId
LEFT JOIN dbo.Department d ON d.DepartmentId = ea.DepartmentId AND d.CompanyId = ea.CompanyId
LEFT JOIN dbo.Department pd ON pd.DepartmentId = d.ParentDepartmentId AND pd.CompanyId = d.CompanyId
LEFT JOIN dbo.[Position] p ON p.PositionId = ea.PositionId
WHERE ea.CompanyId = @CompanyId
  AND er.IsActive = 1
  AND ea.EmploymentStatus = 'ACTIVE'
  AND ea.EffectiveFrom <= CAST(GETDATE() AS date)
  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo >= CAST(GETDATE() AS date))
ORDER BY er.LastName, er.FirstName, er.MiddleName, ea.AssignmentId;";
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                var result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }
    }
}
