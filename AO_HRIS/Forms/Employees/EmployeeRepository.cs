using System;
using System.Data;
using System.Data.SqlClient;
using AO_HRIS.Data;
using AO_HRIS.Security;

namespace AO_HRIS.Forms.Employees
{
    public sealed class EmployeeRegistration
    {
        public string FirstName, MiddleName, LastName, Suffix, PreferredName;
        public DateTime? BirthDate;
        public string Gender, CivilStatus, Email, MobileNumber, TelephoneNumber;
        public string AddressLine1, AddressLine2, Barangay, City, Province, PostalCode, Country;
        public string EmergencyContactName, EmergencyContactRelationship, EmergencyContactNumber;
        public bool IsActive;
        public int CompanyId, DepartmentId, PositionId;
        public string PositionName;
        public int? ManagerAssignmentId;
        public string CompanyEmployeeNo, EmploymentType, EmploymentStatus, WorkLocation, CostCenter;
        public DateTime DateHired, EffectiveFrom;
        public DateTime? RegularizationDate, ContractEndDate, EffectiveTo;
        public bool IsPrimary;
    }

    public sealed partial class EmployeeRepository
    {
        private static object Db(string value) { return String.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim(); }
        private static object Db(DateTime? value) { return value.HasValue ? (object)value.Value.Date : DBNull.Value; }
        private static object Db(int? value) { return value.HasValue ? (object)value.Value : DBNull.Value; }

        private static void Add(SqlCommand cmd, string name, SqlDbType type, object value, int size = 0)
        {
            SqlParameter p = size > 0 ? cmd.Parameters.Add(name, type, size) : cmd.Parameters.Add(name, type);
            p.Value = value ?? DBNull.Value;
        }
        public string Create(EmployeeRegistration e)
        {
            // Validate employee information.
            ValidateEmployeeRegistration(e);
            EnsureCompanyPermission(PermissionCodes.EmployeeRecords, e.CompanyId);
            EnsureCompanyPermission(PermissionCodes.EmployeeAssignments, e.CompanyId);

            // Validate employment and assignment dates.
            ValidateAssignmentDates(e);

            using (SqlConnection cn = DatabaseConnection.GetConnection())
            {
                cn.Open();
                using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        ResolvePositionId(cn, tx, e);
                        ValidateCompanyDepartmentPosition(cn, tx, e);
                        ValidateManagerAssignment(cn, tx, e);
                        // Generate company-specific employee number.
                        string companyEmployeeNo =
                            GenerateCompanyEmployeeNo(cn, tx, e.CompanyId);
                        // A transaction-scoped SQL Server application lock serializes number allocation.
                        using (SqlCommand lockCmd = new SqlCommand(@"
                        DECLARE @result int;
                        EXEC @result = sys.sp_getapplock
                            @Resource = N'AO_HRIS_EmployeeNo',
                            @LockMode = 'Exclusive',
                            @LockOwner = 'Transaction',
                            @LockTimeout = 15000;
                        SELECT @result;", cn, tx))
                        {
                            int result = Convert.ToInt32(lockCmd.ExecuteScalar());
                            if (result < 0) throw new InvalidOperationException("Could not reserve an employee number.");
                        }
                        // Prevent registering an existing person again.
                        string existingEmployeeNo =
                            FindExistingEmployeeNo(cn, tx, e);

                        if (!String.IsNullOrEmpty(existingEmployeeNo))
                        {
                            throw new InvalidOperationException(
                                "A possible duplicate employee record was found.\n\n" +
                                "Existing Employee Number: " + existingEmployeeNo + "\n\n" +
                                "The employee was not registered.\n" +
                                "Please check the existing Employee Directory. " +
                                "If this person is already employed, use their existing " +
                                "employee record and add an assignment if necessary.");
                        }
                        int next;
                        //GENERATE EMPLOYEE NO.
                        using (SqlCommand numberCmd = new SqlCommand(@"
                        SELECT ISNULL(MAX(TRY_CONVERT(int, SUBSTRING(EmployeeNo, 3, 20))), 0) + 1
                        FROM dbo.EmployeeRecord WITH (UPDLOCK, HOLDLOCK)
                        WHERE EmployeeNo LIKE 'E-%'
                          AND SUBSTRING(EmployeeNo, 3, 20) NOT LIKE '%[^0-9]%'
                          AND LEN(EmployeeNo) > 2;", cn, tx))
                            next = Convert.ToInt32(numberCmd.ExecuteScalar());

                        if (next > 99999) throw new InvalidOperationException("Employee number E-99999 has been reached.");
                        string employeeNo = "E-" + next.ToString("D5");
                        int employeeId;
                        using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO dbo.EmployeeRecord
                        (EmployeeNo, FirstName, MiddleName, LastName, Suffix, PreferredName, BirthDate,
                         Gender, CivilStatus, Email, MobileNumber, TelephoneNumber, AddressLine1, AddressLine2,
                         Barangay, City, Province, PostalCode, Country, EmergencyContactName,
                         EmergencyContactRelationship, EmergencyContactNumber, IsActive)
                        OUTPUT INSERTED.EmployeeId
                        VALUES
                        (@EmployeeNo, @FirstName, @MiddleName, @LastName, @Suffix, @PreferredName, @BirthDate,
                         @Gender, @CivilStatus, @Email, @MobileNumber, @TelephoneNumber, @AddressLine1, @AddressLine2,
                         @Barangay, @City, @Province, @PostalCode, @Country, @EmergencyContactName,
                         @EmergencyContactRelationship, @EmergencyContactNumber, @IsActive);", cn, tx))
                        {
                            Add(cmd, "@EmployeeNo", SqlDbType.NVarChar, employeeNo, 20);
                            Add(cmd, "@FirstName", SqlDbType.NVarChar, Db(e.FirstName), 100);
                            Add(cmd, "@MiddleName", SqlDbType.NVarChar, Db(e.MiddleName), 100);
                            Add(cmd, "@LastName", SqlDbType.NVarChar, Db(e.LastName), 100);
                            Add(cmd, "@Suffix", SqlDbType.NVarChar, Db(e.Suffix == "None" ? null : e.Suffix), 20);
                            Add(cmd, "@PreferredName", SqlDbType.NVarChar, Db(e.PreferredName), 100);
                            Add(cmd, "@BirthDate", SqlDbType.Date, Db(e.BirthDate));
                            Add(cmd, "@Gender", SqlDbType.NVarChar, Db(e.Gender), 20);
                            Add(cmd, "@CivilStatus", SqlDbType.NVarChar, Db(e.CivilStatus), 30);
                            Add(cmd, "@Email", SqlDbType.NVarChar, Db(e.Email), 150);
                            Add(cmd, "@MobileNumber", SqlDbType.NVarChar, Db(e.MobileNumber), 30);
                            Add(cmd, "@TelephoneNumber", SqlDbType.NVarChar, Db(e.TelephoneNumber), 30);
                            Add(cmd, "@AddressLine1", SqlDbType.NVarChar, Db(e.AddressLine1), 250);
                            Add(cmd, "@AddressLine2", SqlDbType.NVarChar, Db(e.AddressLine2), 250);
                            Add(cmd, "@Barangay", SqlDbType.NVarChar, Db(e.Barangay), 100);
                            Add(cmd, "@City", SqlDbType.NVarChar, Db(e.City), 100);
                            Add(cmd, "@Province", SqlDbType.NVarChar, Db(e.Province), 100);
                            Add(cmd, "@PostalCode", SqlDbType.NVarChar, Db(e.PostalCode), 20);
                            Add(cmd, "@Country", SqlDbType.NVarChar, Db(e.Country), 100);
                            Add(cmd, "@EmergencyContactName", SqlDbType.NVarChar, Db(e.EmergencyContactName), 200);
                            Add(cmd, "@EmergencyContactRelationship", SqlDbType.NVarChar, Db(e.EmergencyContactRelationship), 50);
                            Add(cmd, "@EmergencyContactNumber", SqlDbType.NVarChar, Db(e.EmergencyContactNumber), 30);
                            Add(cmd, "@IsActive", SqlDbType.Bit, e.IsActive);
                            employeeId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        int assignmentId;
                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO dbo.EmployeeAssignment
                            (EmployeeId, CompanyId, DepartmentId, PositionId, CompanyEmployeeNo,
                             ManagerAssignmentId, EmploymentType, EmploymentStatus, DateHired,
                             RegularizationDate, ContractEndDate, EffectiveFrom, EffectiveTo,
                             WorkLocation, CostCenter, IsPrimary)
                            OUTPUT INSERTED.AssignmentId
                            VALUES
                            (@EmployeeId, @CompanyId, @DepartmentId, @PositionId, @CompanyEmployeeNo,
                             @ManagerAssignmentId, @EmploymentType, @EmploymentStatus, @DateHired,
                             @RegularizationDate, @ContractEndDate, @EffectiveFrom, @EffectiveTo,
                             @WorkLocation, @CostCenter, @IsPrimary);", cn, tx))
                        {
                            Add(cmd, "@EmployeeId", SqlDbType.Int, employeeId);
                            Add(cmd, "@CompanyId", SqlDbType.Int, e.CompanyId);
                            Add(cmd, "@DepartmentId", SqlDbType.Int, e.DepartmentId);
                            Add(cmd, "@PositionId", SqlDbType.Int, e.PositionId);
                            Add(cmd, "@CompanyEmployeeNo", SqlDbType.NVarChar, companyEmployeeNo, 50);
                            Add(cmd, "@ManagerAssignmentId", SqlDbType.Int, Db(e.ManagerAssignmentId));
                            Add(cmd, "@EmploymentType", SqlDbType.NVarChar, Db(e.EmploymentType), 50);
                            Add(cmd, "@EmploymentStatus", SqlDbType.NVarChar, Db(e.EmploymentStatus), 50);
                            Add(cmd, "@DateHired", SqlDbType.Date, e.DateHired.Date);
                            Add(cmd, "@RegularizationDate", SqlDbType.Date, Db(e.RegularizationDate));
                            Add(cmd, "@ContractEndDate", SqlDbType.Date, Db(e.ContractEndDate));
                            Add(cmd, "@EffectiveFrom", SqlDbType.Date, e.EffectiveFrom.Date);
                            Add(cmd, "@EffectiveTo", SqlDbType.Date, Db(e.EffectiveTo));
                            Add(cmd, "@WorkLocation", SqlDbType.NVarChar, Db(e.WorkLocation), 200);
                            Add(cmd, "@CostCenter", SqlDbType.NVarChar, Db(e.CostCenter), 50);
                            Add(cmd, "@IsPrimary", SqlDbType.Bit, e.IsPrimary);
                            assignmentId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Every employee begins with a NEW_HIRE event in the employment timeline.
                        using (SqlCommand history = new SqlCommand(@"
                        INSERT INTO dbo.EmployeeAssignmentHistory
                        (AssignmentId, EmployeeId, MovementType, EffectiveDate,
                         NewCompanyId, NewDepartmentId, NewPositionId, NewManagerAssignmentId,
                         NewEmploymentType, NewEmploymentStatus, Reason)
                        VALUES
                        (@AssignmentId, @EmployeeId, 'NEW_HIRE', @EffectiveDate,
                         @CompanyId, @DepartmentId, @PositionId, @ManagerAssignmentId,
                         @EmploymentType, @EmploymentStatus, @Reason);", cn, tx))
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
                            Add(history, "@Reason", SqlDbType.NVarChar, "Initial employee registration", 1000);
                            history.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return employeeNo;
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        private static string FindExistingEmployeeNo(SqlConnection cn, SqlTransaction tx, EmployeeRegistration e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (!e.BirthDate.HasValue)
                throw new ArgumentException("Birth date is required before duplicate checking.");

            const string query = @"
            SELECT TOP (1) EmployeeNo
            FROM dbo.EmployeeRecord WITH (UPDLOCK, HOLDLOCK)
            WHERE
                UPPER(LTRIM(RTRIM(FirstName))) = UPPER(LTRIM(RTRIM(@FirstName)))
                AND UPPER(LTRIM(RTRIM(LastName))) = UPPER(LTRIM(RTRIM(@LastName)))
                AND BirthDate = @BirthDate
            ORDER BY EmployeeId;";

            using (SqlCommand cmd = new SqlCommand(query, cn, tx))
            {
                Add(cmd, "@FirstName", SqlDbType.NVarChar,
                    e.FirstName.Trim(), 100);

                Add(cmd, "@LastName", SqlDbType.NVarChar,
                    e.LastName.Trim(), 100);

                Add(cmd, "@BirthDate", SqlDbType.Date,
                    e.BirthDate.Value.Date);

                object result = cmd.ExecuteScalar();

                return result == null || result == DBNull.Value
                    ? null
                    : Convert.ToString(result);
            }
        }
    }
}