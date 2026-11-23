
using System;
using System.Data;
using System.Data.SqlClient;
//using System.Data.IsolationLevel;
using AO_HRIS.Data;
using AO_HRIS.Security;

namespace AO_HRIS.Forms.Compensation
{
    public class CompensationRepository
    {
        private int RequireCompanyId()
        {
            if (!UserSession.CompanyId.HasValue)
                throw new InvalidOperationException(
                    "No company is currently selected.");

            return UserSession.CompanyId.Value;
        }

        private void EnsureViewPermission(int companyId)
        {
            if (!PermissionService.HasPermissionForCompany(
                PermissionCodes.CompensationView, companyId))
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to view employee compensation.");
            }
        }

        private void EnsureManagePermission(int companyId)
        {
            if (!PermissionService.HasPermissionForCompany(
                PermissionCodes.CompensationManage, companyId))
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to manage employee compensation.");
            }
        }

        private DataTable ExecuteTable(
            string sql,
            int companyId,
            int? assignmentId = null,
            DateTime? effectiveDate = null)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    companyId;

                if (assignmentId.HasValue)
                {
                    command.Parameters.Add("@AssignmentId", SqlDbType.Int).Value =
                        assignmentId.Value;
                }

                if (effectiveDate.HasValue)
                {
                    command.Parameters.Add("@EffectiveDate", SqlDbType.Date).Value =
                        effectiveDate.Value.Date;
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        private void EnsureAssignmentBelongsToCompany(
            SqlConnection connection,
            SqlTransaction transaction,
            int assignmentId,
            int companyId,
            out DateTime assignmentStart,
            out DateTime? assignmentEnd)
        {
            const string sql = @"
                SELECT EffectiveFrom, EffectiveTo
                FROM dbo.EmployeeAssignment
                WHERE AssignmentId = @AssignmentId
                  AND CompanyId = @CompanyId;";

            using (SqlCommand command =
                new SqlCommand(sql, connection, transaction))
            {
                command.Parameters.Add("@AssignmentId", SqlDbType.Int).Value =
                    assignmentId;

                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    companyId;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new InvalidOperationException(
                            "The selected employee assignment does not exist " +
                            "in the current company.");
                    }

                    assignmentStart = reader.GetDateTime(0).Date;

                    assignmentEnd = reader.IsDBNull(1)
                        ? (DateTime?)null
                        : reader.GetDateTime(1).Date;
                }
            }
        }

        // Returns all employee assignments belonging to the selected company.
        public DataTable GetAssignments()
        {
            int companyId = RequireCompanyId();
            EnsureViewPermission(companyId);

            const string sql = @"
                SELECT
                    ea.AssignmentId,
                    ea.EmployeeId,
                    er.EmployeeNo,
                    LTRIM(RTRIM(
                        COALESCE(
                            NULLIF(LTRIM(RTRIM(er.PreferredName)), ''),
                            er.FirstName
                        )
                        + CASE
                            WHEN NULLIF(LTRIM(RTRIM(er.MiddleName)), '') IS NULL
                            THEN ''
                            ELSE ' ' + LTRIM(RTRIM(er.MiddleName))
                          END
                        + ' ' + LTRIM(RTRIM(er.LastName))
                        + CASE
                            WHEN NULLIF(LTRIM(RTRIM(er.Suffix)), '') IS NULL
                            THEN ''
                            ELSE ' ' + LTRIM(RTRIM(er.Suffix))
                          END
                    )) AS EmployeeName,
                    ea.EmploymentStatus,
                    ea.EffectiveFrom,
                    ea.EffectiveTo,
                    ea.IsPrimary
                FROM dbo.EmployeeAssignment ea
                INNER JOIN dbo.EmployeeRecord er
                    ON er.EmployeeId = ea.EmployeeId
                WHERE ea.CompanyId = @CompanyId
                ORDER BY er.LastName, er.FirstName, ea.AssignmentId;";

            return ExecuteTable(sql, companyId);
        }

        // Returns the complete salary history for one assignment.
        public DataTable GetCompensationHistory(int assignmentId)
        {
            int companyId = RequireCompanyId();
            EnsureViewPermission(companyId);

            const string sql = @"
                SELECT
                    ec.CompensationId,
                    ec.AssignmentId,
                    ec.BasicSalary,
                    ec.CurrencyCode,
                    ec.EffectiveFrom,
                    ec.EffectiveTo,
                    ec.Remarks,
                    ec.CreatedByUserId,
                    ec.CreatedAt
                FROM dbo.EmployeeCompensation ec
                INNER JOIN dbo.EmployeeAssignment ea
                    ON ea.AssignmentId = ec.AssignmentId
                WHERE ea.CompanyId = @CompanyId
                  AND ec.AssignmentId = @AssignmentId
                ORDER BY ec.EffectiveFrom DESC, ec.CompensationId DESC;";

            DataTable table = ExecuteTable(
                sql, companyId, assignmentId);

            return table;
        }

        // Returns the salary applicable on a specified date.
        public DataTable GetCurrentCompensation(
            int assignmentId,
            DateTime asOfDate)
        {
            int companyId = RequireCompanyId();
            EnsureViewPermission(companyId);

            const string sql = @"
                SELECT
                    ec.CompensationId,
                    ec.AssignmentId,
                    ec.BasicSalary,
                    ec.CurrencyCode,
                    ec.EffectiveFrom,
                    ec.EffectiveTo,
                    ec.Remarks
                FROM dbo.EmployeeCompensation ec
                INNER JOIN dbo.EmployeeAssignment ea
                    ON ea.AssignmentId = ec.AssignmentId
                WHERE ea.CompanyId = @CompanyId
                  AND ec.AssignmentId = @AssignmentId
                  AND ec.EffectiveFrom <= @EffectiveDate
                  AND (
                        ec.EffectiveTo IS NULL
                        OR ec.EffectiveTo >= @EffectiveDate
                  )
                ORDER BY ec.EffectiveFrom DESC;";

            DataTable table = ExecuteTable(
                sql, companyId, assignmentId, asOfDate);

            if (table.Rows.Count > 1)
            {
                throw new InvalidOperationException(
                    "Overlapping compensation records were found. " +
                    "Please review the salary history.");
            }

            return table;
        }

        // Creates a new salary record and preserves previous salary history.
        public int AddCompensation(
            int assignmentId,
            decimal basicSalary,
            string currencyCode,
            DateTime effectiveFrom,
            string remarks)
        {
            int companyId = RequireCompanyId();
            EnsureManagePermission(companyId);

            if (assignmentId <= 0)
                throw new ArgumentException("Invalid employee assignment.");

            if (basicSalary < 0)
                throw new ArgumentException(
                    "Basic salary cannot be negative.");

            currencyCode = (currencyCode ?? "").Trim().ToUpperInvariant();

            if (currencyCode.Length != 3)
                throw new ArgumentException(
                    "Currency code must contain exactly three characters.");

            foreach (char character in currencyCode)
            {
                if (character < 'A' || character > 'Z')
                {
                    throw new ArgumentException(
                        "Currency code must contain letters only.");
                }
            }

            remarks = string.IsNullOrWhiteSpace(remarks)
                ? null
                : remarks.Trim();

            if (remarks != null && remarks.Length > 500)
                throw new ArgumentException(
                    "Remarks cannot exceed 500 characters.");

            effectiveFrom = effectiveFrom.Date;

            int createdByUserId = Convert.ToInt32(UserSession.UserId);

            using (SqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction =
                    connection.BeginTransaction(
                        System.Data.IsolationLevel.Serializable))
                {
                    try
                    {
                        DateTime assignmentStart;
                        DateTime? assignmentEnd;

                        EnsureAssignmentBelongsToCompany(
                            connection,
                            transaction,
                            assignmentId,
                            companyId,
                            out assignmentStart,
                            out assignmentEnd);

                        if (effectiveFrom < assignmentStart)
                        {
                            throw new InvalidOperationException(
                                "The salary effective date cannot be earlier " +
                                "than the assignment start date.");
                        }

                        if (assignmentEnd.HasValue &&
                            effectiveFrom > assignmentEnd.Value)
                        {
                            throw new InvalidOperationException(
                                "The salary effective date cannot be later " +
                                "than the assignment end date.");
                        }

                        DataTable existing = new DataTable();

                        const string historySql = @"
                            SELECT
                                CompensationId,
                                EffectiveFrom,
                                EffectiveTo
                            FROM dbo.EmployeeCompensation
                                WITH (UPDLOCK, HOLDLOCK)
                            WHERE AssignmentId = @AssignmentId
                            ORDER BY EffectiveFrom;";

                        using (SqlCommand historyCommand =
                            new SqlCommand(
                                historySql, connection, transaction))
                        {
                            historyCommand.Parameters.Add(
                                "@AssignmentId", SqlDbType.Int).Value =
                                assignmentId;

                            using (SqlDataAdapter adapter =
                                new SqlDataAdapter(historyCommand))
                            {
                                adapter.Fill(existing);
                            }
                        }

                        int overlappingRecords = 0;
                        int previousCompensationId = 0;

                        foreach (DataRow row in existing.Rows)
                        {
                            DateTime existingStart =
                                Convert.ToDateTime(row["EffectiveFrom"]).Date;

                            DateTime? existingEnd =
                                row["EffectiveTo"] == DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(
                                        row["EffectiveTo"]).Date;

                            // A new open-ended record would overlap
                            // an already scheduled future record.
                            if (existingStart > effectiveFrom)
                            {
                                throw new InvalidOperationException(
                                    "A future salary record already exists. " +
                                    "The new record cannot be inserted before it.");
                            }

                            if (existingStart == effectiveFrom)
                            {
                                throw new InvalidOperationException(
                                    "A salary record already exists for this " +
                                    "effective date.");
                            }

                            if (!existingEnd.HasValue ||
                                existingEnd.Value >= effectiveFrom)
                            {
                                overlappingRecords++;
                                previousCompensationId =
                                    Convert.ToInt32(row["CompensationId"]);
                            }
                        }

                        if (overlappingRecords > 1)
                        {
                            throw new InvalidOperationException(
                                "Multiple overlapping salary records exist. " +
                                "Please review the compensation history.");
                        }

                        // Close the previous open/overlapping salary
                        // one day before the new salary takes effect.
                        if (overlappingRecords == 1)
                        {
                            DateTime previousEnd =
                                effectiveFrom.AddDays(-1);

                            const string closeSql = @"
                                UPDATE dbo.EmployeeCompensation
                                SET EffectiveTo = @EffectiveTo
                                WHERE CompensationId = @CompensationId
                                  AND AssignmentId = @AssignmentId;";

                            using (SqlCommand closeCommand =
                                new SqlCommand(
                                    closeSql, connection, transaction))
                            {
                                closeCommand.Parameters.Add(
                                    "@EffectiveTo", SqlDbType.Date).Value =
                                    previousEnd;

                                closeCommand.Parameters.Add(
                                    "@CompensationId", SqlDbType.Int).Value =
                                    previousCompensationId;

                                closeCommand.Parameters.Add(
                                    "@AssignmentId", SqlDbType.Int).Value =
                                    assignmentId;

                                if (closeCommand.ExecuteNonQuery() != 1)
                                {
                                    throw new InvalidOperationException(
                                        "Unable to close the previous salary record.");
                                }
                            }
                        }

                        const string insertSql = @"
                            INSERT INTO dbo.EmployeeCompensation
                            (
                                AssignmentId,
                                BasicSalary,
                                CurrencyCode,
                                EffectiveFrom,
                                EffectiveTo,
                                Remarks,
                                CreatedByUserId
                            )
                            VALUES
                            (
                                @AssignmentId,
                                @BasicSalary,
                                @CurrencyCode,
                                @EffectiveFrom,
                                @EffectiveTo,
                                @Remarks,
                                @CreatedByUserId
                            );

                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int compensationId;

                        using (SqlCommand insertCommand =
                            new SqlCommand(
                                insertSql, connection, transaction))
                        {
                            insertCommand.Parameters.Add(
                                "@AssignmentId", SqlDbType.Int).Value =
                                assignmentId;

                            SqlParameter salaryParameter =
                                insertCommand.Parameters.Add(
                                    "@BasicSalary", SqlDbType.Decimal);

                            salaryParameter.Precision = 18;
                            salaryParameter.Scale = 2;
                            salaryParameter.Value = basicSalary;

                            insertCommand.Parameters.Add(
                                "@CurrencyCode", SqlDbType.Char, 3).Value =
                                currencyCode;

                            insertCommand.Parameters.Add(
                                "@EffectiveFrom", SqlDbType.Date).Value =
                                effectiveFrom;

                            insertCommand.Parameters.Add(
                                "@EffectiveTo", SqlDbType.Date).Value =
                                assignmentEnd.HasValue
                                    ? (object)assignmentEnd.Value
                                    : DBNull.Value;

                            insertCommand.Parameters.Add(
                                "@Remarks", SqlDbType.NVarChar, 500).Value =
                                remarks == null
                                    ? (object)DBNull.Value
                                    : remarks;

                            insertCommand.Parameters.Add(
                                "@CreatedByUserId", SqlDbType.Int).Value =
                                createdByUserId;

                            compensationId = Convert.ToInt32(
                                insertCommand.ExecuteScalar());
                        }

                        transaction.Commit();

                        return compensationId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
