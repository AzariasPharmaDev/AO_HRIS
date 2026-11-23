
using System;
using System.Data;
using System.Data.SqlClient;
using AO_HRIS.Data;
using AO_HRIS.Security;

namespace AO_HRIS.Forms.Employees
{
    public sealed partial class EmployeeRepository
    {
        public int AddCompanyAssignment(
            int employeeId,
            EmployeeRegistration e)
        {
            if (employeeId <= 0)
                throw new ArgumentException("Invalid EmployeeId.");

            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (e.CompanyId <= 0 || e.DepartmentId <= 0)
            {
                throw new ArgumentException(
                    "Company and Department are required.");
            }

            ValidateAssignmentDates(e);
            EnsureCompanyPermission(PermissionCodes.EmployeeAssignments, e.CompanyId);

            using (SqlConnection cn =
                DatabaseConnection.GetConnection())
            {
                cn.Open();

                using (SqlTransaction tx =
                    cn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        ResolvePositionId(cn, tx, e);
                        ValidateCompanyDepartmentPosition(cn, tx, e);
                        ValidateManagerAssignment(cn, tx, e, employeeId);
                        ValidateAssignmentOverlap(cn, tx, employeeId, e);

                        // Automatically generate company-specific employee number.
                        string companyEmployeeNo = GenerateCompanyEmployeeNo(cn, tx, e.CompanyId, employeeId);
                        using (SqlCommand cmd = new SqlCommand(@"
                        IF NOT EXISTS
                        (
                            SELECT 1
                            FROM dbo.EmployeeRecord
                            WHERE EmployeeId = @EmployeeId
                        )
                            THROW 50001, 'Employee does not exist.', 1;


                        INSERT INTO dbo.EmployeeAssignment
                        (
                            EmployeeId,
                            CompanyId,
                            DepartmentId,
                            PositionId,
                            CompanyEmployeeNo,
                            ManagerAssignmentId,
                            EmploymentType,
                            EmploymentStatus,
                            DateHired,
                            RegularizationDate,
                            ContractEndDate,
                            EffectiveFrom,
                            EffectiveTo,
                            WorkLocation,
                            CostCenter,
                            IsPrimary
                        )
                        OUTPUT INSERTED.AssignmentId
                        VALUES
                        (
                            @EmployeeId,
                            @CompanyId,
                            @DepartmentId,
                            @PositionId,
                            @CompanyEmployeeNo,
                            @ManagerAssignmentId,
                            @EmploymentType,
                            @EmploymentStatus,
                            @DateHired,
                            @RegularizationDate,
                            @ContractEndDate,
                            @EffectiveFrom,
                            @EffectiveTo,
                            @WorkLocation,
                            @CostCenter,
                            @IsPrimary
                        );", cn, tx))
                        {
                            cmd.Parameters.Add("@EmployeeId",
                                SqlDbType.Int).Value = employeeId;

                            cmd.Parameters.Add("@CompanyId",
                                SqlDbType.Int).Value = e.CompanyId;

                            cmd.Parameters.Add("@DepartmentId",
                                SqlDbType.Int).Value = e.DepartmentId;

                            cmd.Parameters.Add("@PositionId",
                                SqlDbType.Int).Value = e.PositionId;

                            cmd.Parameters.Add("@CompanyEmployeeNo",
                                SqlDbType.NVarChar, 50).Value =
                                companyEmployeeNo;

                            cmd.Parameters.Add("@ManagerAssignmentId",
                                SqlDbType.Int).Value =
                                Db(e.ManagerAssignmentId);

                            cmd.Parameters.Add("@EmploymentType",
                                SqlDbType.NVarChar, 100).Value =
                                Db(e.EmploymentType);

                            cmd.Parameters.Add("@EmploymentStatus",
                                SqlDbType.NVarChar, 100).Value =
                                Db(e.EmploymentStatus);

                            cmd.Parameters.Add("@DateHired",
                                SqlDbType.Date).Value =
                                e.DateHired.Date;

                            cmd.Parameters.Add("@RegularizationDate",
                                SqlDbType.Date).Value =
                                Db(e.RegularizationDate);

                            cmd.Parameters.Add("@ContractEndDate",
                                SqlDbType.Date).Value =
                                Db(e.ContractEndDate);

                            cmd.Parameters.Add("@EffectiveFrom",
                                SqlDbType.Date).Value =
                                e.EffectiveFrom.Date;

                            cmd.Parameters.Add("@EffectiveTo",
                                SqlDbType.Date).Value =
                                Db(e.EffectiveTo);

                            cmd.Parameters.Add("@WorkLocation",
                                SqlDbType.NVarChar, 200).Value =
                                Db(e.WorkLocation);

                            cmd.Parameters.Add("@CostCenter",
                                SqlDbType.NVarChar, 100).Value =
                                Db(e.CostCenter);

                            cmd.Parameters.Add("@IsPrimary",
                                SqlDbType.Bit).Value =
                                e.IsPrimary;

                            int assignmentId =
                                Convert.ToInt32(cmd.ExecuteScalar());

                            // An additional concurrent company assignment is not a transfer.
                            // Record its creation in the same transaction as the assignment.
                            using (SqlCommand history = new SqlCommand(@"
                            INSERT INTO dbo.EmployeeAssignmentHistory
                            (
                                AssignmentId,
                                EmployeeId,
                                MovementType,
                                EffectiveDate,
                                NewCompanyId,
                                NewDepartmentId,
                                NewPositionId,
                                NewManagerAssignmentId,
                                NewEmploymentType,
                                NewEmploymentStatus,
                                Reason
                            )
                            VALUES
                            (
                                @AssignmentId,
                                @EmployeeId,
                                N'OTHER',
                                @EffectiveDate,
                                @CompanyId,
                                @DepartmentId,
                                @PositionId,
                                @ManagerAssignmentId,
                                @EmploymentType,
                                @EmploymentStatus,
                                @Reason
                            );", cn, tx))
                            {
                                Add(history, "@AssignmentId", SqlDbType.Int, assignmentId);
                                Add(history, "@EmployeeId", SqlDbType.Int, employeeId);
                                Add(history, "@EffectiveDate", SqlDbType.Date, e.EffectiveFrom.Date);
                                Add(history, "@CompanyId", SqlDbType.Int, e.CompanyId);
                                Add(history, "@DepartmentId", SqlDbType.Int, e.DepartmentId);
                                Add(history, "@PositionId", SqlDbType.Int, e.PositionId);
                                Add(history, "@ManagerAssignmentId", SqlDbType.Int, Db(e.ManagerAssignmentId));
                                Add(history, "@EmploymentType", SqlDbType.NVarChar, Db(e.EmploymentType), 50);
                                Add(history, "@EmploymentStatus", SqlDbType.NVarChar, Db(e.EmploymentStatus), 50);
                                Add(history, "@Reason", SqlDbType.NVarChar,
                                    "Additional concurrent company assignment created", 1000);
                                if (history.ExecuteNonQuery() != 1)
                                    throw new InvalidOperationException("Assignment history could not be recorded.");
                            }

                            tx.Commit();

                            return assignmentId;
                        }
                    }
                    catch
                    {
                        try { tx.Rollback(); }
                        catch { }

                        throw;
                    }
                }
            }
        }

        private string GenerateCompanyEmployeeNo(SqlConnection cn,SqlTransaction tx,int companyId,int? employeeId = null)
        {
            string companyCode;
            
            // Lock the company row to serialize number generation.
            using (SqlCommand cmd = new SqlCommand(@"
            SELECT CompanyCode
            FROM dbo.Company WITH (UPDLOCK, HOLDLOCK)
            WHERE CompanyId = @CompanyId;", cn, tx))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    companyId;

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    throw new InvalidOperationException(
                        "Company code could not be found.");

                companyCode = Convert.ToString(result).Trim();
            }

            if (string.IsNullOrWhiteSpace(companyCode))
                throw new InvalidOperationException(
                    "The selected company has no CompanyCode.");

            // Reuse the existing number if this employee
            // already has an assignment in this company.
            if (employeeId.HasValue)
            {
                DataTable existingNumbers = new DataTable();

                using (SqlCommand cmd = new SqlCommand(@"
                SELECT DISTINCT CompanyEmployeeNo
                FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK)
                WHERE EmployeeId = @EmployeeId
                  AND CompanyId = @CompanyId
                  AND CompanyEmployeeNo IS NOT NULL
                  AND LTRIM(RTRIM(CompanyEmployeeNo)) <> '';", cn, tx))
                {
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value =
                        employeeId.Value;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                        companyId;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(existingNumbers);
                }

                if (existingNumbers.Rows.Count > 1)
                {
                    throw new InvalidOperationException(
                        "This employee has multiple CompanyEmployeeNo values " +
                        "within the same company. Resolve the existing numbers " +
                        "before creating another assignment.");
                }

                if (existingNumbers.Rows.Count == 1)
                {
                    return Convert.ToString(
                        existingNumbers.Rows[0]["CompanyEmployeeNo"]).Trim();
                }
            }
            // Generate the next number for this company.
            long nextNumber;

            using (SqlCommand cmd = new SqlCommand(@"
            SELECT ISNULL(
                MAX(
                    TRY_CONVERT(
                        BIGINT,
                        SUBSTRING(
                            CompanyEmployeeNo,
                            LEN(@CompanyCode) + 2,
                            50
                        )
                    )
                ),
                0
            ) + 1
            FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK)
            WHERE CompanyId = @CompanyId
              AND LEFT(
                    CompanyEmployeeNo,
                    LEN(@CompanyCode) + 1
                  ) = @CompanyCode + '-';", cn, tx))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    companyId;

                cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 50).Value =
                    companyCode;

                nextNumber = Convert.ToInt64(cmd.ExecuteScalar());
            }

            if (nextNumber > 99999)
                throw new InvalidOperationException(
                    "The company employee number limit has been reached.");

            return companyCode + "-" +
                nextNumber.ToString(
                    "D5",
                    System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}