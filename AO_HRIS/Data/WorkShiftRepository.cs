using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Data
{
    public sealed class WorkShiftModel
    {
        public int ShiftId { get; set; }
        public int CompanyId { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BreakMinutes { get; set; }
        public int GracePeriodMinutes { get; set; }
        public bool IsActive { get; set; }
    }

    internal class WorkShiftRepository
    {
        public DataTable GetWorkShifts(int companyId, bool includeInactive)
        {
            const string sql = @"
            SELECT
                ShiftId,
                ShiftName,
                StartTime,
                EndTime,
                BreakMinutes,
                GracePeriodMinutes,
                IsActive,
                CASE
                    WHEN EndTime > StartTime
                        THEN DATEDIFF(MINUTE, StartTime, EndTime)
                    ELSE DATEDIFF(
                        MINUTE,
                        StartTime,
                        DATEADD(DAY, 1, CAST(EndTime AS datetime))
                    )
                END - BreakMinutes AS NetMinutes
            FROM dbo.WorkShift
            WHERE CompanyId = @CompanyId
              AND (@IncludeInactive = 1 OR IsActive = 1)
            ORDER BY IsActive DESC, ShiftName;";

            DataTable table = new DataTable();

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeInactive", SqlDbType.Bit).Value = includeInactive;

                adapter.Fill(table);
            }

            return table;
        }

        public void Insert(WorkShiftModel shift)
        {
            const string sql = @"
            INSERT INTO dbo.WorkShift
            (
                CompanyId,
                ShiftName,
                StartTime,
                EndTime,
                BreakMinutes,
                GracePeriodMinutes,
                IsActive
            )
            VALUES
            (
                @CompanyId,
                @ShiftName,
                @StartTime,
                @EndTime,
                @BreakMinutes,
                @GracePeriodMinutes,
                @IsActive
            );";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                AddParameters(cmd, shift);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(WorkShiftModel shift)
        {
            const string sql = @"
            UPDATE dbo.WorkShift
            SET
                ShiftName = @ShiftName,
                StartTime = @StartTime,
                EndTime = @EndTime,
                BreakMinutes = @BreakMinutes,
                GracePeriodMinutes = @GracePeriodMinutes,
                IsActive = @IsActive
            WHERE ShiftId = @ShiftId
              AND CompanyId = @CompanyId;";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                AddParameters(cmd, shift);

                cmd.Parameters.Add("@ShiftId", SqlDbType.Int).Value = shift.ShiftId;

                con.Open();

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new InvalidOperationException(
                        "The selected work shift no longer exists in the current company.");
                }
            }
        }

        public void SetActive(int companyId, int shiftId, bool isActive)
        {
            const string sql = @"
            UPDATE dbo.WorkShift
            SET IsActive = @IsActive
            WHERE CompanyId = @CompanyId
              AND ShiftId = @ShiftId;";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@ShiftId", SqlDbType.Int).Value = shiftId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;

                con.Open();

                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw new InvalidOperationException(
                        "The selected work shift could not be found.");
                }
            }
        }

        private static void AddParameters(SqlCommand cmd, WorkShiftModel shift)
        {
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = shift.CompanyId;
            cmd.Parameters.Add("@ShiftName", SqlDbType.NVarChar, 100).Value = shift.ShiftName.Trim();
            cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = shift.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = shift.EndTime;
            cmd.Parameters.Add("@BreakMinutes", SqlDbType.Int).Value = shift.BreakMinutes;
            cmd.Parameters.Add("@GracePeriodMinutes", SqlDbType.Int).Value = shift.GracePeriodMinutes;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = shift.IsActive;
        }
    }
}