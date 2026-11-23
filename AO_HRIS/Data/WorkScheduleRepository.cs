
using System;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Data
{
    public sealed class WorkScheduleModel
    {
        public int WorkScheduleId { get; set; }
        public int CompanyId { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public sealed class WorkScheduleDayModel
    {
        public int DayOfWeek { get; set; }
        public int? ShiftId { get; set; }
        public bool IsRestDay { get; set; }
    }

    internal sealed class WorkScheduleRepository
    {
        public DataTable GetSchedules(int companyId, bool includeInactive)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT
                    ws.WorkScheduleId,
                    ws.ScheduleName,
                    ws.ScheduleType,
                    ws.Description,
                    ws.IsActive,
                    ws.CreatedAt,
                    COUNT(wsd.ScheduleDayId) AS ConfiguredDays
                FROM dbo.WorkSchedule ws
                LEFT JOIN dbo.WorkScheduleDay wsd
                    ON wsd.WorkScheduleId = ws.WorkScheduleId
                WHERE ws.CompanyId = @CompanyId
                  AND (@IncludeInactive = 1 OR ws.IsActive = 1)
                GROUP BY
                    ws.WorkScheduleId,
                    ws.ScheduleName,
                    ws.ScheduleType,
                    ws.Description,
                    ws.IsActive,
                    ws.CreatedAt
                ORDER BY ws.ScheduleName;", conn))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeInactive", SqlDbType.Bit).Value =
                    includeInactive;

                DataTable table = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(table);

                return table;
            }
        }

        public DataTable GetActiveShifts(int companyId)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT
                    ShiftId,
                    ShiftName,
                    CONVERT(varchar(5), StartTime, 108) AS StartTimeText,
                    CONVERT(varchar(5), EndTime, 108) AS EndTimeText
                FROM dbo.WorkShift
                WHERE CompanyId = @CompanyId
                  AND IsActive = 1
                ORDER BY ShiftName;", conn))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;

                DataTable table = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(table);

                return table;
            }
        }

        public DataTable GetScheduleDays(int companyId, int workScheduleId)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT
                    d.DayOfWeek,
                    d.ShiftId,
                    d.IsRestDay,
                    s.ShiftName
                FROM dbo.WorkSchedule ws
                CROSS JOIN
                (
                    SELECT 1 AS DayOfWeek
                    UNION ALL SELECT 2
                    UNION ALL SELECT 3
                    UNION ALL SELECT 4
                    UNION ALL SELECT 5
                    UNION ALL SELECT 6
                    UNION ALL SELECT 7
                ) days
                LEFT JOIN dbo.WorkScheduleDay d
                    ON d.WorkScheduleId = ws.WorkScheduleId
                   AND d.DayOfWeek = days.DayOfWeek
                LEFT JOIN dbo.WorkShift s
                    ON s.ShiftId = d.ShiftId
                   AND s.CompanyId = ws.CompanyId
                WHERE ws.WorkScheduleId = @WorkScheduleId
                  AND ws.CompanyId = @CompanyId
                ORDER BY days.DayOfWeek;", conn))
            {
                cmd.Parameters.Add("@WorkScheduleId", SqlDbType.Int).Value =
                    workScheduleId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;

                DataTable table = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(table);

                return table;
            }
        }

        public void Insert(
            WorkScheduleModel schedule,
            WorkScheduleDayModel[] days)
        {
            if (schedule == null)
                throw new ArgumentNullException("schedule");

            if (schedule.WorkScheduleId > 0)
                throw new ArgumentException(
                    "A new schedule cannot already have an ID.");

            Save(schedule, days);
        }

        public void Update(
            WorkScheduleModel schedule,
            WorkScheduleDayModel[] days)
        {
            if (schedule == null)
                throw new ArgumentNullException("schedule");

            if (schedule.WorkScheduleId <= 0)
                throw new ArgumentException(
                    "A valid schedule ID is required for an update.");

            Save(schedule, days);
        }

        private void Save(
            WorkScheduleModel schedule,
            WorkScheduleDayModel[] days)
        {
            if (string.IsNullOrWhiteSpace(schedule.ScheduleName))
                throw new ArgumentException("Schedule name is required.");

            if (schedule.ScheduleName.Trim().Length > 100)
                throw new ArgumentException(
                    "Schedule name cannot exceed 100 characters.");

            if (schedule.ScheduleType != "FIXED" &&
                schedule.ScheduleType != "ROTATING")
                throw new ArgumentException("Invalid schedule type.");

            ValidateDays(days);

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (schedule.WorkScheduleId == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO dbo.WorkSchedule
                                (
                                    CompanyId,
                                    ScheduleName,
                                    ScheduleType,
                                    Description,
                                    IsActive
                                )
                                VALUES
                                (
                                    @CompanyId,
                                    @ScheduleName,
                                    @ScheduleType,
                                    @Description,
                                    @IsActive
                                );

                                SELECT CAST(SCOPE_IDENTITY() AS int);",
                                conn, transaction))
                            {
                                AddScheduleParameters(cmd, schedule);

                                schedule.WorkScheduleId =
                                    Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE dbo.WorkSchedule
                                SET
                                    ScheduleName = @ScheduleName,
                                    ScheduleType = @ScheduleType,
                                    Description = @Description,
                                    IsActive = @IsActive
                                WHERE WorkScheduleId = @WorkScheduleId
                                  AND CompanyId = @CompanyId;",
                                conn, transaction))
                            {
                                AddScheduleParameters(cmd, schedule);

                                cmd.Parameters.Add("@WorkScheduleId",
                                    SqlDbType.Int).Value =
                                    schedule.WorkScheduleId;

                                if (cmd.ExecuteNonQuery() == 0)
                                    throw new InvalidOperationException(
                                        "The schedule was not found in the selected company.");
                            }
                        }

                        ValidateShiftOwnership(
                            conn,
                            transaction,
                            schedule.CompanyId,
                            days);

                        using (SqlCommand cmd = new SqlCommand(@"
                            DELETE FROM dbo.WorkScheduleDay
                            WHERE WorkScheduleId = @WorkScheduleId
                              AND EXISTS
                              (
                                  SELECT 1
                                  FROM dbo.WorkSchedule
                                  WHERE WorkScheduleId = @WorkScheduleId
                                    AND CompanyId = @CompanyId
                              );",
                            conn, transaction))
                        {
                            cmd.Parameters.Add("@WorkScheduleId",
                                SqlDbType.Int).Value = schedule.WorkScheduleId;
                            cmd.Parameters.Add("@CompanyId",
                                SqlDbType.Int).Value = schedule.CompanyId;

                            cmd.ExecuteNonQuery();
                        }

                        foreach (WorkScheduleDayModel day in days)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO dbo.WorkScheduleDay
                                (
                                    WorkScheduleId,
                                    DayOfWeek,
                                    ShiftId,
                                    IsRestDay
                                )
                                VALUES
                                (
                                    @WorkScheduleId,
                                    @DayOfWeek,
                                    @ShiftId,
                                    @IsRestDay
                                );",
                                conn, transaction))
                            {
                                cmd.Parameters.Add("@WorkScheduleId",
                                    SqlDbType.Int).Value = schedule.WorkScheduleId;
                                cmd.Parameters.Add("@DayOfWeek",
                                    SqlDbType.TinyInt).Value = day.DayOfWeek;
                                cmd.Parameters.Add("@ShiftId",
                                    SqlDbType.Int).Value =
                                    day.ShiftId.HasValue
                                        ? (object)day.ShiftId.Value
                                        : DBNull.Value;
                                cmd.Parameters.Add("@IsRestDay",
                                    SqlDbType.Bit).Value = day.IsRestDay;

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void SetActive(
            int companyId,
            int workScheduleId,
            bool isActive)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.WorkSchedule
                SET IsActive = @IsActive
                WHERE WorkScheduleId = @WorkScheduleId
                  AND CompanyId = @CompanyId;", conn))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@WorkScheduleId", SqlDbType.Int).Value =
                    workScheduleId;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;

                conn.Open();

                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException(
                        "The schedule was not found in the selected company.");
            }
        }

        private static void AddScheduleParameters(
            SqlCommand cmd,
            WorkScheduleModel schedule)
        {
            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                schedule.CompanyId;
            cmd.Parameters.Add("@ScheduleName", SqlDbType.NVarChar, 100).Value =
                schedule.ScheduleName.Trim();
            cmd.Parameters.Add("@ScheduleType", SqlDbType.VarChar, 20).Value =
                schedule.ScheduleType;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value =
                string.IsNullOrWhiteSpace(schedule.Description)
                    ? (object)DBNull.Value
                    : schedule.Description.Trim();
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                schedule.IsActive;
        }

        private static void ValidateDays(WorkScheduleDayModel[] days)
        {
            if (days == null || days.Length != 7)
                throw new ArgumentException(
                    "A schedule must contain exactly seven day configurations.");

            bool[] found = new bool[8];

            foreach (WorkScheduleDayModel day in days)
            {
                if (day == null || day.DayOfWeek < 1 || day.DayOfWeek > 7)
                    throw new ArgumentException("Invalid day configuration.");

                if (found[day.DayOfWeek])
                    throw new ArgumentException("Duplicate day configuration.");

                found[day.DayOfWeek] = true;

                if (day.IsRestDay && day.ShiftId.HasValue)
                    throw new ArgumentException(
                        "A rest day cannot have an assigned shift.");

                if (!day.IsRestDay && !day.ShiftId.HasValue)
                    throw new ArgumentException(
                        "Every working day must have an assigned shift.");
            }

            for (int i = 1; i <= 7; i++)
            {
                if (!found[i])
                    throw new ArgumentException(
                        "A day configuration is missing.");
            }
        }

        private static void ValidateShiftOwnership(
            SqlConnection conn,
            SqlTransaction transaction,
            int companyId,
            WorkScheduleDayModel[] days)
        {
            foreach (WorkScheduleDayModel day in days)
            {
                if (day.IsRestDay)
                    continue;

                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(1)
                    FROM dbo.WorkShift
                    WHERE ShiftId = @ShiftId
                      AND CompanyId = @CompanyId
                      AND IsActive = 1;",
                    conn, transaction))
                {
                    cmd.Parameters.Add("@ShiftId", SqlDbType.Int).Value =
                        day.ShiftId.Value;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                        companyId;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) != 1)
                        throw new InvalidOperationException(
                            "A selected shift is inactive or belongs to another company.");
                }
            }
        }
    }
}
