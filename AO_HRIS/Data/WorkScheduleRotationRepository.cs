
using AO_HRIS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Data
{
    public sealed class WorkScheduleRotationModel
    {
        public int RotationId { get; set; }
        public int WorkScheduleId { get; set; }
        public string RotationName { get; set; }
        public int CycleLengthDays { get; set; }

        public List<WorkScheduleRotationDayModel> Days { get; set; }

        public WorkScheduleRotationModel()
        {
            Days = new List<WorkScheduleRotationDayModel>();
        }
    }

    public sealed class WorkScheduleRotationDayModel
    {
        public int CycleDayNumber { get; set; }
        public int? ShiftId { get; set; }
        public bool IsRestDay { get; set; }
    }

    public sealed class WorkScheduleRotationRepository
    {
        public DataTable GetActiveShifts(int companyId)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(@"
                SELECT
                    ShiftId,
                    ShiftName,
                    CONVERT(varchar(5), StartTime, 108) + ' - ' +
                    CONVERT(varchar(5), EndTime, 108) AS ShiftDisplay
                FROM dbo.WorkShift
                WHERE CompanyId = @CompanyId
                  AND IsActive = 1
                ORDER BY ShiftName;", connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public WorkScheduleRotationModel GetRotation(
            int companyId,
            int workScheduleId)
        {
            WorkScheduleRotationModel rotation = null;

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(@"
                    SELECT
                        R.RotationId,
                        R.WorkScheduleId,
                        R.RotationName,
                        R.CycleLengthDays
                    FROM dbo.WorkScheduleRotation R
                    INNER JOIN dbo.WorkSchedule S
                        ON S.WorkScheduleId = R.WorkScheduleId
                    WHERE S.CompanyId = @CompanyId
                      AND S.WorkScheduleId = @WorkScheduleId
                      AND S.ScheduleType = 'ROTATING';", connection))
                {
                    command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                    command.Parameters.Add("@WorkScheduleId", SqlDbType.Int).Value = workScheduleId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rotation = new WorkScheduleRotationModel
                            {
                                RotationId = Convert.ToInt32(reader["RotationId"]),
                                WorkScheduleId = Convert.ToInt32(reader["WorkScheduleId"]),
                                RotationName = Convert.ToString(reader["RotationName"]),
                                CycleLengthDays = Convert.ToInt32(reader["CycleLengthDays"])
                            };
                        }
                    }
                }

                if (rotation == null)
                    return null;

                using (SqlCommand command = new SqlCommand(@"
                    SELECT
                        CycleDayNumber,
                        ShiftId,
                        IsRestDay
                    FROM dbo.WorkScheduleRotationDay
                    WHERE RotationId = @RotationId
                    ORDER BY CycleDayNumber;", connection))
                {
                    command.Parameters.Add("@RotationId", SqlDbType.Int).Value =
                        rotation.RotationId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rotation.Days.Add(new WorkScheduleRotationDayModel
                            {
                                CycleDayNumber = Convert.ToInt32(reader["CycleDayNumber"]),
                                ShiftId = reader["ShiftId"] == DBNull.Value
                                    ? (int?)null
                                    : Convert.ToInt32(reader["ShiftId"]),
                                IsRestDay = Convert.ToBoolean(reader["IsRestDay"])
                            });
                        }
                    }
                }
            }

            return rotation;
        }

        public void Save(
            int companyId,
            int workScheduleId,
            WorkScheduleRotationModel rotation)
        {
            if (rotation == null)
                throw new ArgumentNullException("rotation");

            if (string.IsNullOrWhiteSpace(rotation.RotationName))
                throw new InvalidOperationException("Enter a rotation name.");

            rotation.RotationName = rotation.RotationName.Trim();

            if (rotation.RotationName.Length > 100)
                throw new InvalidOperationException(
                    "Rotation name cannot exceed 100 characters.");

            if (rotation.CycleLengthDays < 1 ||
                rotation.CycleLengthDays > 366)
            {
                throw new InvalidOperationException(
                    "Cycle length must be between 1 and 366 days.");
            }

            if (rotation.Days == null ||
                rotation.Days.Count != rotation.CycleLengthDays)
            {
                throw new InvalidOperationException(
                    "Configure every day in the rotation cycle.");
            }

            HashSet<int> configuredDays = new HashSet<int>();

            foreach (WorkScheduleRotationDayModel day in rotation.Days)
            {
                if (day.CycleDayNumber < 1 ||
                    day.CycleDayNumber > rotation.CycleLengthDays ||
                    !configuredDays.Add(day.CycleDayNumber))
                {
                    throw new InvalidOperationException(
                        "Cycle days must be unique and consecutive.");
                }

                if (day.IsRestDay && day.ShiftId.HasValue)
                {
                    throw new InvalidOperationException(
                        "Rest days cannot have an assigned shift.");
                }

                if (!day.IsRestDay && !day.ShiftId.HasValue)
                {
                    throw new InvalidOperationException(
                        "Select a shift or mark the day as a rest day.");
                }
            }

            for (int dayNumber = 1;
                 dayNumber <= rotation.CycleLengthDays;
                 dayNumber++)
            {
                if (!configuredDays.Contains(dayNumber))
                {
                    throw new InvalidOperationException(
                        "Missing configuration for cycle day " + dayNumber + ".");
                }
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction =
                    connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        // Confirm that the schedule belongs to this company
                        // and is configured as ROTATING.
                        using (SqlCommand command = new SqlCommand(@"
                            SELECT COUNT(*)
                            FROM dbo.WorkSchedule WITH (UPDLOCK, HOLDLOCK)
                            WHERE WorkScheduleId = @WorkScheduleId
                              AND CompanyId = @CompanyId
                              AND ScheduleType = 'ROTATING';",
                            connection, transaction))
                        {
                            command.Parameters.Add("@WorkScheduleId", SqlDbType.Int)
                                .Value = workScheduleId;
                            command.Parameters.Add("@CompanyId", SqlDbType.Int)
                                .Value = companyId;

                            if (Convert.ToInt32(command.ExecuteScalar()) != 1)
                            {
                                throw new InvalidOperationException(
                                    "The selected work schedule does not exist, " +
                                    "does not belong to this company, or is not ROTATING.");
                            }
                        }

                        // Validate that every selected shift belongs to this company.
                        using (SqlCommand command = new SqlCommand(@"
                            SELECT COUNT(*)
                            FROM dbo.WorkShift
                            WHERE ShiftId = @ShiftId
                              AND CompanyId = @CompanyId
                              AND IsActive = 1;",
                            connection, transaction))
                        {
                            command.Parameters.Add("@ShiftId", SqlDbType.Int);
                            command.Parameters.Add("@CompanyId", SqlDbType.Int)
                                .Value = companyId;

                            foreach (WorkScheduleRotationDayModel day in rotation.Days)
                            {
                                if (day.IsRestDay)
                                    continue;

                                command.Parameters["@ShiftId"].Value = day.ShiftId.Value;

                                if (Convert.ToInt32(command.ExecuteScalar()) != 1)
                                {
                                    throw new InvalidOperationException(
                                        "One of the selected shifts is inactive " +
                                        "or does not belong to this company.");
                                }
                            }
                        }

                        int rotationId;

                        // A schedule can have only one rotation.
                        using (SqlCommand command = new SqlCommand(@"
                            SELECT RotationId
                            FROM dbo.WorkScheduleRotation WITH (UPDLOCK, HOLDLOCK)
                            WHERE WorkScheduleId = @WorkScheduleId;",
                            connection, transaction))
                        {
                            command.Parameters.Add("@WorkScheduleId", SqlDbType.Int)
                                .Value = workScheduleId;

                            object result = command.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                            {
                                using (SqlCommand insert = new SqlCommand(@"
                                    INSERT INTO dbo.WorkScheduleRotation
                                        (WorkScheduleId, RotationName, CycleLengthDays)
                                    VALUES
                                        (@WorkScheduleId, @RotationName, @CycleLengthDays);

                                    SELECT CAST(SCOPE_IDENTITY() AS int);",
                                    connection, transaction))
                                {
                                    AddRotationParameters(
                                        insert,
                                        workScheduleId,
                                        rotation);

                                    rotationId = Convert.ToInt32(insert.ExecuteScalar());
                                }
                            }
                            else
                            {
                                rotationId = Convert.ToInt32(result);

                                using (SqlCommand update = new SqlCommand(@"
                                    UPDATE dbo.WorkScheduleRotation
                                    SET RotationName = @RotationName,
                                        CycleLengthDays = @CycleLengthDays
                                    WHERE RotationId = @RotationId;",
                                    connection, transaction))
                                {
                                    AddRotationParameters(
                                        update,
                                        workScheduleId,
                                        rotation);

                                    update.Parameters.Add("@RotationId", SqlDbType.Int)
                                        .Value = rotationId;

                                    update.ExecuteNonQuery();
                                }

                                using (SqlCommand delete = new SqlCommand(@"
                                    DELETE FROM dbo.WorkScheduleRotationDay
                                    WHERE RotationId = @RotationId;",
                                    connection, transaction))
                                {
                                    delete.Parameters.Add("@RotationId", SqlDbType.Int)
                                        .Value = rotationId;

                                    delete.ExecuteNonQuery();
                                }
                            }
                        }

                        // Insert the complete cycle configuration.
                        using (SqlCommand insertDay = new SqlCommand(@"
                            INSERT INTO dbo.WorkScheduleRotationDay
                                (RotationId, CycleDayNumber, ShiftId, IsRestDay)
                            VALUES
                                (@RotationId, @CycleDayNumber, @ShiftId, @IsRestDay);",
                            connection, transaction))
                        {
                            insertDay.Parameters.Add("@RotationId", SqlDbType.Int)
                                .Value = rotationId;

                            insertDay.Parameters.Add("@CycleDayNumber", SqlDbType.Int);

                            insertDay.Parameters.Add("@ShiftId", SqlDbType.Int);

                            insertDay.Parameters.Add("@IsRestDay", SqlDbType.Bit);

                            foreach (WorkScheduleRotationDayModel day in rotation.Days)
                            {
                                insertDay.Parameters["@CycleDayNumber"].Value =
                                    day.CycleDayNumber;

                                insertDay.Parameters["@ShiftId"].Value =
                                    day.ShiftId.HasValue
                                        ? (object)day.ShiftId.Value
                                        : DBNull.Value;

                                insertDay.Parameters["@IsRestDay"].Value =
                                    day.IsRestDay;

                                insertDay.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        rotation.RotationId = rotationId;
                        rotation.WorkScheduleId = workScheduleId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private static void AddRotationParameters(
            SqlCommand command,
            int workScheduleId,
            WorkScheduleRotationModel rotation)
        {
            command.Parameters.Add("@WorkScheduleId", SqlDbType.Int)
                .Value = workScheduleId;

            command.Parameters.Add("@RotationName", SqlDbType.NVarChar, 100)
                .Value = rotation.RotationName;

            command.Parameters.Add("@CycleLengthDays", SqlDbType.Int)
                .Value = rotation.CycleLengthDays;
        }
    }
}
