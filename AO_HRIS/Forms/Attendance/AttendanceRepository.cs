using AO_HRIS.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Forms.Attendance
{
    public sealed class AttendanceRepository
    {

        public DataTable GetAssignmentOptions(int companyId)
        {
            const string sql = @"
            SELECT ea.AssignmentId,
                   er.EmployeeNo,
                   LTRIM(RTRIM(
                       COALESCE(NULLIF(er.LastName, ''), '') +
                       CASE WHEN COALESCE(NULLIF(er.PreferredName, ''), NULLIF(er.FirstName, '')) IS NOT NULL
                            THEN ', ' + COALESCE(NULLIF(er.PreferredName, ''), er.FirstName) ELSE '' END +
                       CASE WHEN NULLIF(er.MiddleName, '') IS NOT NULL THEN ' ' + er.MiddleName ELSE '' END +
                       CASE WHEN NULLIF(er.Suffix, '') IS NOT NULL THEN ' ' + er.Suffix ELSE '' END
                   )) AS EmployeeName,
                   d.DepartmentName,
                   p.PositionName,
                   ea.EffectiveFrom,
                   ea.EffectiveTo,
                   ea.EmploymentStatus,
                   er.EmployeeNo + ' - ' + LTRIM(RTRIM(
                       COALESCE(NULLIF(er.LastName, ''), '') +
                       CASE WHEN COALESCE(NULLIF(er.PreferredName, ''), NULLIF(er.FirstName, '')) IS NOT NULL
                            THEN ', ' + COALESCE(NULLIF(er.PreferredName, ''), er.FirstName) ELSE '' END +
                       CASE WHEN NULLIF(er.MiddleName, '') IS NOT NULL THEN ' ' + er.MiddleName ELSE '' END +
                       CASE WHEN NULLIF(er.Suffix, '') IS NOT NULL THEN ' ' + er.Suffix ELSE '' END
                   )) AS EmployeeLabel
            FROM dbo.EmployeeAssignment ea
            INNER JOIN dbo.EmployeeRecord er ON er.EmployeeId = ea.EmployeeId
            LEFT JOIN dbo.Department d ON d.DepartmentId = ea.DepartmentId
            LEFT JOIN dbo.Position p ON p.PositionId = ea.PositionId
            WHERE ea.CompanyId = @CompanyId
              AND er.IsActive = 1
            ORDER BY er.LastName, er.FirstName, ea.EffectiveFrom DESC;";
            var table = new DataTable();
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetEvents(int companyId, DateTime fromDate, DateTime toDate,
            string employeeSearch, string eventType, string sourceType, bool includeVoided)
        {
            const string sql = @"
SELECT ae.AttendanceEventId,
       ae.EventDateTime,
       er.EmployeeNo,
       CASE WHEN er.EmployeeId IS NULL THEN COALESCE(ae.DeviceEmployeeCode, '(Unmatched)')
            ELSE LTRIM(RTRIM(
                COALESCE(NULLIF(er.LastName, ''), '') +
                CASE WHEN COALESCE(NULLIF(er.PreferredName, ''), NULLIF(er.FirstName, '')) IS NOT NULL
                     THEN ', ' + COALESCE(NULLIF(er.PreferredName, ''), er.FirstName) ELSE '' END +
                CASE WHEN NULLIF(er.MiddleName, '') IS NOT NULL THEN ' ' + er.MiddleName ELSE '' END +
                CASE WHEN NULLIF(er.Suffix, '') IS NOT NULL THEN ' ' + er.Suffix ELSE '' END
            )) END AS EmployeeName,
       d.DepartmentName,
       p.PositionName,
       ae.EventType,
       ae.SourceType,
       ae.DeviceEmployeeCode,
       ad.DeviceName,
       ae.IsVoided,
       ae.VoidReason,
       ua.Username AS RecordedBy,
       ae.Notes
FROM dbo.AttendanceEvent ae
LEFT JOIN dbo.EmployeeAssignment ea
       ON ea.AssignmentId = ae.AssignmentId AND ea.CompanyId = ae.CompanyId
LEFT JOIN dbo.EmployeeRecord er ON er.EmployeeId = ea.EmployeeId
LEFT JOIN dbo.Department d ON d.DepartmentId = ea.DepartmentId
LEFT JOIN dbo.Position p ON p.PositionId = ea.PositionId
LEFT JOIN dbo.AttendanceDevice ad ON ad.DeviceId = ae.DeviceId
LEFT JOIN dbo.UserAccount ua ON ua.UserId = ae.RecordedByUserId
WHERE ae.CompanyId = @CompanyId
  AND ae.EventDateTime >= @FromDate
  AND ae.EventDateTime < DATEADD(day, 1, @ToDate)
  AND (@EventType = '' OR ae.EventType = @EventType)
  AND (@SourceType = '' OR ae.SourceType = @SourceType)
  AND (@IncludeVoided = 1 OR ae.IsVoided = 0)
  AND (@Search = '' OR er.EmployeeNo LIKE @SearchLike
       OR er.FirstName LIKE @SearchLike OR er.LastName LIKE @SearchLike
       OR er.PreferredName LIKE @SearchLike OR ae.DeviceEmployeeCode LIKE @SearchLike)
ORDER BY ae.EventDateTime DESC, ae.AttendanceEventId DESC;";
            var table = new DataTable();
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate.Date;
                cmd.Parameters.Add("@EventType", SqlDbType.VarChar, 20).Value = eventType ?? string.Empty;
                cmd.Parameters.Add("@SourceType", SqlDbType.VarChar, 30).Value = sourceType ?? string.Empty;
                cmd.Parameters.Add("@IncludeVoided", SqlDbType.Bit).Value = includeVoided;
                string search = (employeeSearch ?? string.Empty).Trim();
                cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 200).Value = search;
                cmd.Parameters.Add("@SearchLike", SqlDbType.NVarChar, 202).Value = "%" + search + "%";
                adapter.Fill(table);
            }
            return table;
        }

        public void AddManualEvent(int companyId, int assignmentId, string eventType,
            DateTime eventDateTime, int recordedByUserId, string notes)
        {
            if (companyId <= 0 || assignmentId <= 0 || recordedByUserId <= 0)
                throw new ArgumentException("A valid company, employee assignment, and user session are required.");
            if (eventType != "IN" && eventType != "OUT" && eventType != "BREAK_IN" && eventType != "BREAK_OUT")
                throw new ArgumentException("Select a valid attendance event type.");

            const string sql = @"
IF NOT EXISTS (
    SELECT 1 FROM dbo.EmployeeAssignment
    WHERE AssignmentId = @AssignmentId AND CompanyId = @CompanyId
      AND EffectiveFrom <= CONVERT(date, @EventDateTime)
      AND (EffectiveTo IS NULL OR EffectiveTo >= CONVERT(date, @EventDateTime))
)
BEGIN
    THROW 50001, 'The selected employee assignment is not effective for the attendance date or does not belong to this company.', 1;
END;

INSERT INTO dbo.AttendanceEvent
    (CompanyId, AssignmentId, EventType, EventDateTime, SourceType,
     RecordedByUserId, IsVoided, Notes, CreatedAt)
VALUES
    (@CompanyId, @AssignmentId, @EventType, @EventDateTime, 'MANUAL',
     @RecordedByUserId, 0, @Notes, SYSDATETIME());";
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@AssignmentId", SqlDbType.Int).Value = assignmentId;
                cmd.Parameters.Add("@EventType", SqlDbType.VarChar, 20).Value = eventType;
                cmd.Parameters.Add("@EventDateTime", SqlDbType.DateTime2).Value = eventDateTime;
                cmd.Parameters.Add("@RecordedByUserId", SqlDbType.Int).Value = recordedByUserId;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000).Value = string.IsNullOrWhiteSpace(notes) ? (object)DBNull.Value : notes.Trim();
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void VoidEvent(int companyId, int attendanceEventId, int userId, string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Enter a reason for voiding this attendance event.");
            const string sql = @"
UPDATE dbo.AttendanceEvent
SET IsVoided = 1,
    VoidedByUserId = @UserId,
    VoidedAt = SYSDATETIME(),
    VoidReason = @Reason
WHERE AttendanceEventId = @EventId
  AND CompanyId = @CompanyId
  AND IsVoided = 0;
IF @@ROWCOUNT = 0
    THROW 50002, 'The attendance event was not found or has already been voided.', 1;";
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 500).Value = reason.Trim();
                cmd.Parameters.Add("@EventId", SqlDbType.Int).Value = attendanceEventId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
