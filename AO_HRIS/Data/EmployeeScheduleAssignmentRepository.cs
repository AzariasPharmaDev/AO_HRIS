using System;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Data
{
    public class EmployeeScheduleAssignmentModel
    {
        public int ScheduleAssignmentId { get; set; }
        public int AssignmentId { get; set; }

        public string AssignmentMode { get; set; }

        public int? WorkScheduleId { get; set; }
        public DateTime? RotationStartDate { get; set; }

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public int CompanyId { get; set; }
    }

    public sealed class EmployeeScheduleAssignmentRepository
    {
        public DataTable GetEmployeeAssignments(int companyId)
        {
            const string sql = @"
                SELECT
                    ea.AssignmentId,
                    er.EmployeeId,
                    er.EmployeeNo,
                    --LTRIM(RTRIM(
                    --    COALESCE(
                    --        NULLIF(er.PreferredName, ''),
                    --        er.FirstName
                    --    ) +
                    --    CASE
                    --        WHEN NULLIF(er.MiddleName, '') IS NOT NULL
                    --        THEN ' ' + er.MiddleName
                    --        ELSE ''
                    --    END +
                    --    ' ' + er.LastName +
                    --    CASE
                    --        WHEN NULLIF(er.Suffix, '') IS NOT NULL
                    --        THEN ' ' + er.Suffix
                    --        ELSE ''
                    --    END
                    --)) AS EmployeeName,
                    LTRIM(RTRIM(
                        COALESCE(NULLIF(er.LastName, ''), '') +
                        CASE
                            WHEN COALESCE(NULLIF(er.PreferredName, ''), NULLIF(er.FirstName, '')) IS NOT NULL
                            THEN ', ' + COALESCE(NULLIF(er.PreferredName, ''), er.FirstName)
                            ELSE ''
                        END +
                        CASE
                            WHEN NULLIF(er.MiddleName, '') IS NOT NULL
                            THEN ' ' + er.MiddleName
                            ELSE ''
                        END +
                        CASE
                            WHEN NULLIF(er.Suffix, '') IS NOT NULL
                            THEN ' ' + er.Suffix
                            ELSE ''
                        END
                    )) AS EmployeeName,
                    d.DepartmentName,
                    p.PositionName,
                    ea.EmploymentStatus,
                    ea.EffectiveFrom AS EmploymentEffectiveFrom,
                    ea.EffectiveTo AS EmploymentEffectiveTo
                FROM dbo.EmployeeAssignment ea
                INNER JOIN dbo.EmployeeRecord er
                    ON er.EmployeeId = ea.EmployeeId
                LEFT JOIN dbo.Department d
                    ON d.DepartmentId = ea.DepartmentId
                LEFT JOIN dbo.Position p
                    ON p.PositionId = ea.PositionId
                WHERE ea.CompanyId = @CompanyId
                  AND er.IsActive = 1
                  AND (
                        ea.EffectiveTo IS NULL
                        OR ea.EffectiveTo >= CONVERT(date, GETDATE())
                      )
                ORDER BY er.LastName, er.FirstName;";

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable GetScheduleAssignments(int companyId)
        {
            const string sql = @"
                SELECT
                    esa.ScheduleAssignmentId,
                    esa.AssignmentId,
                    er.EmployeeNo,
                    LTRIM(RTRIM(
                        COALESCE(
                            NULLIF(er.PreferredName, ''),
                            er.FirstName
                        ) +
                        CASE
                            WHEN NULLIF(er.MiddleName, '') IS NOT NULL
                            THEN ' ' + er.MiddleName
                            ELSE ''
                        END +
                        ' ' + er.LastName +
                        CASE
                            WHEN NULLIF(er.Suffix, '') IS NOT NULL
                            THEN ' ' + er.Suffix
                            ELSE ''
                        END
                    )) AS EmployeeName,
                    d.DepartmentName,
                    p.PositionName,
                    esa.AssignmentMode,
                    ws.ScheduleName,
                    esa.RotationStartDate,
                    esa.EffectiveFrom,
                    esa.EffectiveTo
                FROM dbo.EmployeeScheduleAssignment esa
                INNER JOIN dbo.EmployeeAssignment ea
                    ON ea.AssignmentId = esa.AssignmentId
                INNER JOIN dbo.EmployeeRecord er
                    ON er.EmployeeId = ea.EmployeeId
                LEFT JOIN dbo.Department d
                    ON d.DepartmentId = ea.DepartmentId
                LEFT JOIN dbo.Position p
                    ON p.PositionId = ea.PositionId
               LEFT JOIN dbo.WorkSchedule ws
                ON ws.WorkScheduleId = esa.WorkScheduleId
               AND ws.CompanyId = ea.CompanyId
                WHERE ea.CompanyId = @CompanyId
                ORDER BY er.LastName, er.FirstName,
                         esa.EffectiveFrom DESC;";

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable GetAvailableSchedules(
            int companyId,
            string scheduleType)
        {
            const string sql = @"
                SELECT
                    ws.WorkScheduleId,
                    ws.ScheduleName,
                    ws.ScheduleType
                FROM dbo.WorkSchedule ws
                WHERE ws.CompanyId = @CompanyId
                  AND ws.IsActive = 1
                  AND ws.ScheduleType = @ScheduleType
                ORDER BY ws.ScheduleName;";

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId;

                command.Parameters.Add("@ScheduleType", SqlDbType.VarChar, 20)
                    .Value = scheduleType;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public EmployeeScheduleAssignmentModel GetById(
            int companyId,
            int scheduleAssignmentId)
        {
            const string sql = @"
                SELECT
                    esa.ScheduleAssignmentId,
                    esa.AssignmentId,
                    esa.AssignmentMode,
                    esa.WorkScheduleId,
                    esa.RotationStartDate,
                    esa.EffectiveFrom,
                    esa.EffectiveTo
                FROM dbo.EmployeeScheduleAssignment esa
                INNER JOIN dbo.EmployeeAssignment ea
                    ON ea.AssignmentId = esa.AssignmentId
                WHERE esa.ScheduleAssignmentId = @ScheduleAssignmentId
                  AND ea.CompanyId = @CompanyId;";

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@ScheduleAssignmentId", SqlDbType.Int)
                    .Value = scheduleAssignmentId;

                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new EmployeeScheduleAssignmentModel
                    {
                        ScheduleAssignmentId =
                            Convert.ToInt32(reader["ScheduleAssignmentId"]),

                        AssignmentId =
                            Convert.ToInt32(reader["AssignmentId"]),

                        AssignmentMode =
                            Convert.ToString(reader["AssignmentMode"]),

                        WorkScheduleId = reader["WorkScheduleId"] == DBNull.Value
                            ? (int?)null
                            : Convert.ToInt32(reader["WorkScheduleId"]),

                        RotationStartDate =
                            reader["RotationStartDate"] == DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(reader["RotationStartDate"]),

                        EffectiveFrom =
                            Convert.ToDateTime(reader["EffectiveFrom"]),

                        EffectiveTo = reader["EffectiveTo"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(reader["EffectiveTo"])
                    };
                }
            }
        }

        public void Insert(
            int companyId,
            EmployeeScheduleAssignmentModel model)
        {
            Save(companyId, model, false);
        }

        public void Update(
            int companyId,
            EmployeeScheduleAssignmentModel model)
        {
            Save(companyId, model, true);
        }

        private void Save(
            int companyId,
            EmployeeScheduleAssignmentModel model,
            bool isUpdate)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            ValidateModel(model);

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction =
                    connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        ValidateEmployeeAssignment(
                            connection, transaction, companyId, model);

                        ValidateSchedule(
                            connection, transaction, companyId, model);

                        ValidateNoOverlap(
                            connection, transaction, model, isUpdate);

                        if (isUpdate)
                            UpdateRecord(connection, transaction, companyId, model);
                        else
                            InsertRecord(connection, transaction, model);

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

         private static void ValidateModel(
            EmployeeScheduleAssignmentModel model)
        {
            string mode = (model.AssignmentMode ?? string.Empty)
                .Trim().ToUpperInvariant();

            if (mode != "FIXED" &&
                mode != "ROTATING" &&
                mode != "INDIVIDUAL")
            {
                throw new InvalidOperationException(
                    "Select a valid schedule assignment mode.");
            }

            model.AssignmentMode = mode;

            if (model.EffectiveTo.HasValue &&
                model.EffectiveTo.Value.Date < model.EffectiveFrom.Date)
            {
                throw new InvalidOperationException(
                    "The effective end date cannot be earlier than the start date.");
            }

            if (mode == "INDIVIDUAL")
            {
                if (model.WorkScheduleId.HasValue ||
                    model.RotationStartDate.HasValue)
                {
                    throw new InvalidOperationException(
                        "Individual schedules cannot have a work schedule or rotation start date.");
                }
            }
            else if (!model.WorkScheduleId.HasValue)
            {
                throw new InvalidOperationException(
                    "Select a work schedule.");
            }

            if (mode == "FIXED" && model.RotationStartDate.HasValue)
            {
                throw new InvalidOperationException(
                    "Fixed schedules cannot have a rotation start date.");
            }

            if (mode == "ROTATING")
            {
                if (!model.RotationStartDate.HasValue)
                {
                    throw new InvalidOperationException(
                        "A rotation start date is required.");
                }

                if (model.RotationStartDate.Value.Date <
                    model.EffectiveFrom.Date)
                {
                    throw new InvalidOperationException(
                        "The rotation start date cannot be earlier than the assignment start date.");
                }

                if (model.EffectiveTo.HasValue &&
                    model.RotationStartDate.Value.Date >
                    model.EffectiveTo.Value.Date)
                {
                    throw new InvalidOperationException(
                        "The rotation start date cannot be later than the assignment end date.");
                }
            }
        }

        private static void ValidateEmployeeAssignment(
            SqlConnection connection,
            SqlTransaction transaction,
            int companyId,
            EmployeeScheduleAssignmentModel model)
            {
                const string sql = @"
            SELECT COUNT(1)
            FROM dbo.EmployeeAssignment ea WITH (UPDLOCK, HOLDLOCK)
            INNER JOIN dbo.EmployeeRecord er
                ON er.EmployeeId = ea.EmployeeId
            WHERE ea.AssignmentId = @AssignmentId
              AND ea.CompanyId = @CompanyId
              AND er.IsActive = 1
              AND ea.EffectiveFrom <= @EffectiveFrom
              AND
              (
                  (
                      @EffectiveTo IS NOT NULL
                      AND
                      (
                          ea.EffectiveTo IS NULL
                          OR ea.EffectiveTo >= @EffectiveTo
                      )
                  )
                  OR
                  (
                      @EffectiveTo IS NULL
                      AND ea.EffectiveTo IS NULL
                  )
              );";

            using (SqlCommand command =
                new SqlCommand(sql, connection, transaction))
            {
                command.Parameters.Add("@AssignmentId", SqlDbType.Int)
                    .Value = model.AssignmentId;

                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId;

                command.Parameters.Add("@EffectiveFrom", SqlDbType.Date)
                    .Value = model.EffectiveFrom.Date;

                command.Parameters.Add("@EffectiveTo", SqlDbType.Date)
                    .Value = model.EffectiveTo.HasValue
                        ? (object)model.EffectiveTo.Value.Date
                        : DBNull.Value;

                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    throw new InvalidOperationException(
                        "The selected employee assignment is invalid, inactive, " +
                        "or does not cover the schedule assignment dates.");
                }
            }
        }

        private static void ValidateSchedule(
            SqlConnection connection,
            SqlTransaction transaction,
            int companyId,
            EmployeeScheduleAssignmentModel model)
        {
            if (model.AssignmentMode == "INDIVIDUAL")
                return;

            const string sql = @"
                SELECT COUNT(1)
                FROM dbo.WorkSchedule ws WITH (UPDLOCK, HOLDLOCK)
                WHERE ws.WorkScheduleId = @WorkScheduleId
                  AND ws.CompanyId = @CompanyId
                  AND ws.IsActive = 1
                  AND ws.ScheduleType = @ScheduleType;";

            using (SqlCommand command =
                new SqlCommand(sql, connection, transaction))
            {
                command.Parameters.Add("@WorkScheduleId", SqlDbType.Int)
                    .Value = model.WorkScheduleId.Value;

                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId;

                command.Parameters.Add("@ScheduleType", SqlDbType.VarChar, 20)
                    .Value = model.AssignmentMode;

                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    throw new InvalidOperationException(
                        "The selected schedule is inactive, unavailable, " +
                        "or does not match the assignment mode.");
                }
            }

            if (model.AssignmentMode == "ROTATING")
            {
                const string rotationSql = @"
                SELECT COUNT(1)
                FROM dbo.WorkScheduleRotation wr
                INNER JOIN dbo.WorkSchedule ws
                    ON ws.WorkScheduleId = wr.WorkScheduleId
                WHERE wr.WorkScheduleId = @WorkScheduleId
                    AND ws.CompanyId = @CompanyId;";

                using (SqlCommand command =
                    new SqlCommand(rotationSql, connection, transaction))
                {
                    command.Parameters.Add("@WorkScheduleId", SqlDbType.Int).Value = model.WorkScheduleId.Value;
                    command.Parameters.Add("@WorkScheduleId", SqlDbType.Int).Value = model.WorkScheduleId.Value;
                    command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;

                    if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                    {
                        throw new InvalidOperationException(
                            "Configure the rotation cycle before assigning this schedule.");
                    }
                }
            }
        }

        private static void ValidateNoOverlap(SqlConnection connection, SqlTransaction transaction, EmployeeScheduleAssignmentModel model, bool isUpdate) {
            string sql = @"
                SELECT COUNT(1)
                FROM dbo.EmployeeScheduleAssignment WITH (UPDLOCK, HOLDLOCK)
                WHERE AssignmentId = @AssignmentId
                  AND (
                        EffectiveTo IS NULL
                        OR EffectiveTo >= @EffectiveFrom
                      )
                  AND (
                        @EffectiveTo IS NULL
                        OR EffectiveFrom <= @EffectiveTo
                      )";

            if (isUpdate)
                sql += " AND ScheduleAssignmentId <> @ScheduleAssignmentId";

            using (SqlCommand command =
                new SqlCommand(sql, connection, transaction))
            {
                command.Parameters.Add("@AssignmentId", SqlDbType.Int)
                    .Value = model.AssignmentId;

                command.Parameters.Add("@EffectiveFrom", SqlDbType.Date)
                    .Value = model.EffectiveFrom.Date;

                command.Parameters.Add("@EffectiveTo", SqlDbType.Date)
                    .Value = model.EffectiveTo.HasValue
                        ? (object)model.EffectiveTo.Value.Date
                        : DBNull.Value;

                if (isUpdate)
                {
                    command.Parameters.Add(
                        "@ScheduleAssignmentId", SqlDbType.Int)
                        .Value = model.ScheduleAssignmentId;
                }

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                {
                    throw new InvalidOperationException(
                        "This employee already has a schedule assignment " +
                        "that overlaps the selected effective dates.");
                }
            }
        }

        private static void InsertRecord(
            SqlConnection connection,
            SqlTransaction transaction,
            EmployeeScheduleAssignmentModel model)
        {
            const string sql = @"
                INSERT INTO dbo.EmployeeScheduleAssignment
                (
                    AssignmentId,
                    AssignmentMode,
                    WorkScheduleId,
                    RotationStartDate,
                    EffectiveFrom,
                    EffectiveTo,
                    CreatedAt
                )
                VALUES
                (
                    @AssignmentId,
                    @AssignmentMode,
                    @WorkScheduleId,
                    @RotationStartDate,
                    @EffectiveFrom,
                    @EffectiveTo,
                    SYSDATETIME()
                );";

            using (SqlCommand command =
                new SqlCommand(sql, connection, transaction))
            {
                AddSaveParameters(command, model);
                command.ExecuteNonQuery();
            }
        }

        private static void UpdateRecord(SqlConnection connection, SqlTransaction transaction, int companyId, EmployeeScheduleAssignmentModel model)
        {
            const string sql = @"
                UPDATE dbo.EmployeeScheduleAssignment
                SET
                    AssignmentId = @AssignmentId,
                    AssignmentMode = @AssignmentMode,
                    WorkScheduleId = @WorkScheduleId,
                    RotationStartDate = @RotationStartDate,
                    EffectiveFrom = @EffectiveFrom,
                    EffectiveTo = @EffectiveTo
                WHERE ScheduleAssignmentId = @ScheduleAssignmentId
                  AND EXISTS
                  (
                      SELECT 1
                      FROM dbo.EmployeeAssignment ea
                      WHERE ea.AssignmentId =
                            EmployeeScheduleAssignment.AssignmentId
                        AND ea.CompanyId = @CompanyId
                  );

                IF @@ROWCOUNT = 0
                    THROW 50001, 'Schedule assignment was not found.', 1;";

            using (SqlCommand command =
                new SqlCommand(sql, connection, transaction))
            {
                AddSaveParameters(command, model);

                command.Parameters.Add(
                    "@ScheduleAssignmentId", SqlDbType.Int)
                    .Value = model.ScheduleAssignmentId;

                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                .Value = companyId;

                command.ExecuteNonQuery();
            }
        }

        private static void AddSaveParameters(
            SqlCommand command,
            EmployeeScheduleAssignmentModel model)
        {
            command.Parameters.Add("@AssignmentId", SqlDbType.Int)
                .Value = model.AssignmentId;

            command.Parameters.Add("@AssignmentMode", SqlDbType.VarChar, 20)
                .Value = model.AssignmentMode;

            command.Parameters.Add("@WorkScheduleId", SqlDbType.Int)
                .Value = model.WorkScheduleId.HasValue
                    ? (object)model.WorkScheduleId.Value
                    : DBNull.Value;

            command.Parameters.Add("@RotationStartDate", SqlDbType.Date)
                .Value = model.RotationStartDate.HasValue
                    ? (object)model.RotationStartDate.Value.Date
                    : DBNull.Value;

            command.Parameters.Add("@EffectiveFrom", SqlDbType.Date)
                .Value = model.EffectiveFrom.Date;

            command.Parameters.Add("@EffectiveTo", SqlDbType.Date)
                .Value = model.EffectiveTo.HasValue
                    ? (object)model.EffectiveTo.Value.Date
                    : DBNull.Value;
        }
    }
}