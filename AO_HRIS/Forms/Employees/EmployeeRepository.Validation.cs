using System;
using System.Data;
using System.Data.SqlClient;
using AO_HRIS.Security;

namespace AO_HRIS.Forms.Employees
{
    public sealed partial class EmployeeRepository
    {
        private static void ValidateEmployeeRegistration(EmployeeRegistration e)
        {

            if (e == null) throw new ArgumentNullException(nameof(e));

            RequireText(e.FirstName, "First name", 100);
            RequireText(e.LastName, "Last name", 100);
            ValidateOptionalText(e.MiddleName, "Middle name", 100);
            ValidateOptionalText(e.Suffix == "None" ? null : e.Suffix, "Suffix", 20);
            ValidateOptionalText(e.PreferredName, "Preferred name", 100);
            ValidateOptionalText(e.Gender, "Gender", 20);
            ValidateOptionalText(e.CivilStatus, "Civil status", 30);
            ValidateOptionalText(e.Email, "Email", 150);
            ValidateOptionalText(e.MobileNumber, "Mobile number", 30);
            ValidateOptionalText(e.TelephoneNumber, "Telephone number", 30);
            ValidateOptionalText(e.AddressLine1, "Address line 1", 250);
            ValidateOptionalText(e.AddressLine2, "Address line 2", 250);
            ValidateOptionalText(e.Barangay, "Barangay", 100);
            ValidateOptionalText(e.City, "City", 100);
            ValidateOptionalText(e.Province, "Province", 100);
            ValidateOptionalText(e.PostalCode, "Postal code", 20);
            ValidateOptionalText(e.Country, "Country", 100);
            ValidateOptionalText(e.EmergencyContactName, "Emergency contact name", 200);
            ValidateOptionalText(e.EmergencyContactRelationship, "Emergency contact relationship", 50);
            ValidateOptionalText(e.EmergencyContactNumber, "Emergency contact number", 30);

            if (!e.BirthDate.HasValue)
                throw new ArgumentException("Birth date is required.");

            if (e.BirthDate.Value.Date > DateTime.Today)
                throw new ArgumentException("Birth date cannot be in the future.");

            ValidateAssignmentDates(e);
        }

        private static void ValidateAssignmentDates(EmployeeRegistration e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (e.CompanyId <= 0 || e.DepartmentId <= 0)
                throw new ArgumentException("Company and department are required.");
            if (e.DateHired == DateTime.MinValue || e.EffectiveFrom == DateTime.MinValue)
                throw new ArgumentException("Date hired and effective-from date are required.");
            if (e.EffectiveFrom.Date < e.DateHired.Date)
                throw new ArgumentException("Effective-from date cannot be earlier than date hired.");
            if (e.EffectiveTo.HasValue && e.EffectiveTo.Value.Date < e.EffectiveFrom.Date)
                throw new ArgumentException("Effective-to date cannot be earlier than effective-from date.");
            if (e.ContractEndDate.HasValue && e.ContractEndDate.Value.Date < e.EffectiveFrom.Date)
                throw new ArgumentException("Contract end date cannot be earlier than the assignment effective-from date.");
            if (e.RegularizationDate.HasValue && e.RegularizationDate.Value.Date < e.DateHired.Date)
                throw new ArgumentException("Regularization date cannot be earlier than date hired.");

            ValidateOptionalText(e.CompanyEmployeeNo, "Company employee number", 20);
            ValidateOptionalText(e.EmploymentType, "Employment type", 50);
            RequireText(e.EmploymentStatus, "Employment status", 50);
            ValidateOptionalText(e.WorkLocation, "Work location", 200);
            ValidateOptionalText(e.CostCenter, "Cost center", 50);
        }

        private static void RequireText(string value, string fieldName, int maxLength)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(fieldName + " is required.");
            if (value.Trim().Length > maxLength)
                throw new ArgumentException(fieldName + " cannot exceed " + maxLength + " characters.");
        }

        private static void ValidateOptionalText(string value, string fieldName, int maxLength)
        {
            if (!String.IsNullOrWhiteSpace(value) && value.Trim().Length > maxLength)
                throw new ArgumentException(fieldName + " cannot exceed " + maxLength + " characters.");
        }

        private static void ValidateCompanyDepartmentPosition(SqlConnection cn, SqlTransaction tx, EmployeeRegistration e)
        {
            
            using (SqlCommand cmd = new SqlCommand(@"
            IF NOT EXISTS
            (
                SELECT 1 FROM dbo.Company WITH (UPDLOCK, HOLDLOCK)
                WHERE CompanyId = @CompanyId AND IsActive = 1
            )
                THROW 51001, 'Company does not exist or is inactive.', 1;

            IF NOT EXISTS
            (
                SELECT 1 FROM dbo.Department WITH (UPDLOCK, HOLDLOCK)
                WHERE DepartmentId = @DepartmentId AND CompanyId = @CompanyId AND IsActive = 1
            )
                THROW 51002, 'Department does not belong to this company or is inactive.', 1;

            -- A position with DepartmentId NULL is shared/company-wide. Otherwise it must
            -- belong to the selected department.
            IF NOT EXISTS
            (
                SELECT 1 FROM dbo.Position WITH (UPDLOCK, HOLDLOCK)
                WHERE PositionId = @PositionId
                  AND IsActive = 1
                  AND (DepartmentId IS NULL OR DepartmentId = @DepartmentId)
            )
                THROW 51003, 'Position is inactive or does not belong to the selected department.', 1;", cn, tx)
            )
            {
                Add(cmd, "@CompanyId", SqlDbType.Int, e.CompanyId);
                Add(cmd, "@DepartmentId", SqlDbType.Int, e.DepartmentId);
                Add(cmd, "@PositionId", SqlDbType.Int, e.PositionId);
                cmd.ExecuteNonQuery();
            }
        }

        private static void ValidateManagerAssignment(SqlConnection cn, SqlTransaction tx, EmployeeRegistration e, int? employeeId = null)
        {
            if (!e.ManagerAssignmentId.HasValue) return;

            using (SqlCommand cmd = new SqlCommand(@"
IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EmployeeAssignment ma WITH (UPDLOCK, HOLDLOCK)
    INNER JOIN dbo.EmployeeRecord mr WITH (UPDLOCK, HOLDLOCK)
        ON mr.EmployeeId = ma.EmployeeId
    WHERE ma.AssignmentId = @ManagerAssignmentId
      AND ma.CompanyId = @CompanyId
      AND (@EmployeeId IS NULL OR ma.EmployeeId <> @EmployeeId)
      AND UPPER(LTRIM(RTRIM(ma.EmploymentStatus))) = 'ACTIVE'
      AND mr.IsActive = 1
      AND ma.EffectiveFrom <= @EffectiveFrom
      AND (ma.EffectiveTo IS NULL OR ma.EffectiveTo >= ISNULL(@EffectiveTo, CONVERT(date, '99991231', 112)))
)
    THROW 51004, 'Manager must be a different active employee with an assignment covering the selected period in this company.', 1;", cn, tx))
            {
                Add(cmd, "@ManagerAssignmentId", SqlDbType.Int, e.ManagerAssignmentId.Value);
                Add(cmd, "@CompanyId", SqlDbType.Int, e.CompanyId);
                Add(cmd, "@EmployeeId", SqlDbType.Int, Db(employeeId));
                Add(cmd, "@EffectiveFrom", SqlDbType.Date, e.EffectiveFrom.Date);
                Add(cmd, "@EffectiveTo", SqlDbType.Date, Db(e.EffectiveTo));
                cmd.ExecuteNonQuery();
            }

            // Prevent indirect reporting cycles (A reports to B, while B already
            // reports through a chain that eventually reaches A).
            if (employeeId.HasValue)
            {
                using (SqlCommand cmd = new SqlCommand(@"
DECLARE @WouldCreateCycle bit = 0;
;WITH ManagerChain AS
(
    SELECT a.AssignmentId, a.EmployeeId, a.ManagerAssignmentId,
           CAST('/' + CONVERT(varchar(20), a.AssignmentId) + '/' AS varchar(max)) AS VisitPath
    FROM dbo.EmployeeAssignment a WITH (UPDLOCK, HOLDLOCK)
    WHERE a.AssignmentId = @ManagerAssignmentId AND a.CompanyId = @CompanyId

    UNION ALL

    SELECT parent.AssignmentId, parent.EmployeeId, parent.ManagerAssignmentId,
           CAST(mc.VisitPath + CONVERT(varchar(20), parent.AssignmentId) + '/' AS varchar(max))
    FROM ManagerChain mc
    INNER JOIN dbo.EmployeeAssignment parent WITH (UPDLOCK, HOLDLOCK)
        ON parent.AssignmentId = mc.ManagerAssignmentId
       AND parent.CompanyId = @CompanyId
    WHERE mc.ManagerAssignmentId IS NOT NULL
      AND mc.VisitPath NOT LIKE '%/' + CONVERT(varchar(20), parent.AssignmentId) + '/%'
)
SELECT @WouldCreateCycle = CASE WHEN EXISTS
    (SELECT 1 FROM ManagerChain WHERE EmployeeId = @EmployeeId) THEN 1 ELSE 0 END
OPTION (MAXRECURSION 100);
IF @WouldCreateCycle = 1
    THROW 51006, 'This manager selection would create a circular reporting relationship.', 1;", cn, tx))
                {
                    Add(cmd, "@ManagerAssignmentId", SqlDbType.Int, e.ManagerAssignmentId.Value);
                    Add(cmd, "@CompanyId", SqlDbType.Int, e.CompanyId);
                    Add(cmd, "@EmployeeId", SqlDbType.Int, employeeId.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void EnsureCompanyPermission(string permissionCode, int companyId)
        {
            if (companyId <= 0 || !PermissionService.HasPermissionForCompany(permissionCode, companyId))
                throw new UnauthorizedAccessException("You do not have permission to perform this operation for the selected company.");
        }

        private static void ValidateAssignmentOverlap(SqlConnection cn, SqlTransaction tx, int employeeId, EmployeeRegistration e, int? excludeAssignmentId = null)
        {
            using (SqlCommand cmd = new SqlCommand(@"
IF EXISTS
(
    SELECT 1 FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK)
    WHERE EmployeeId = @EmployeeId
      AND CompanyId = @CompanyId
      AND (@ExcludeAssignmentId IS NULL OR AssignmentId <> @ExcludeAssignmentId)
      AND EffectiveFrom <= ISNULL(@EffectiveTo, CONVERT(date, '99991231', 112))
      AND (EffectiveTo IS NULL OR EffectiveTo >= @EffectiveFrom)
)
    THROW 51005, 'Employee already has an overlapping assignment in this company.', 1;", cn, tx))
            {
                Add(cmd, "@EmployeeId", SqlDbType.Int, employeeId);
                Add(cmd, "@CompanyId", SqlDbType.Int, e.CompanyId);
                Add(cmd, "@ExcludeAssignmentId", SqlDbType.Int, Db(excludeAssignmentId));
                Add(cmd, "@EffectiveFrom", SqlDbType.Date, e.EffectiveFrom.Date);
                Add(cmd, "@EffectiveTo", SqlDbType.Date, Db(e.EffectiveTo));
                cmd.ExecuteNonQuery();
            }
        }
        private static int ResolvePositionId(
    SqlConnection cn,
    SqlTransaction tx,
    EmployeeRegistration e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            // An existing selected position must still pass the normal validation.
            if (e.PositionId > 0)
                return e.PositionId;

            string positionName = (e.PositionName ?? "").Trim();

            if (string.IsNullOrWhiteSpace(positionName))
                throw new ArgumentException("Please select or enter a position.");

            if (positionName.Length > 400)
                throw new ArgumentException("Position name cannot exceed 400 characters.");

            // Confirm that the selected department belongs to the active company.
            using (SqlCommand department = new SqlCommand(@"
        SELECT COUNT(*)
        FROM dbo.Department WITH (UPDLOCK, HOLDLOCK)
        WHERE DepartmentId = @DepartmentId
          AND CompanyId = @CompanyId
          AND IsActive = 1;", cn, tx))
            {
                Add(department, "@DepartmentId", SqlDbType.Int, e.DepartmentId);
                Add(department, "@CompanyId", SqlDbType.Int, e.CompanyId);

                if (Convert.ToInt32(department.ExecuteScalar()) != 1)
                    throw new InvalidOperationException(
                        "The selected department does not belong to the active company.");
            }

            // Reuse an existing active position with the same name in this department.
            using (SqlCommand find = new SqlCommand(@"
        SELECT TOP (2) PositionId
        FROM dbo.Position WITH (UPDLOCK, HOLDLOCK)
        WHERE DepartmentId = @DepartmentId
          AND IsActive = 1
          AND UPPER(LTRIM(RTRIM(PositionName))) =
              UPPER(LTRIM(RTRIM(@PositionName)))
        ORDER BY PositionId;", cn, tx))
            {
                Add(find, "@DepartmentId", SqlDbType.Int, e.DepartmentId);
                Add(find, "@PositionName", SqlDbType.NVarChar, positionName, 400);

                using (SqlDataReader reader = find.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int existingId = reader.GetInt32(0);

                        if (reader.Read())
                            throw new InvalidOperationException(
                                "Multiple positions with this name already exist in the selected department. " +
                                "Please select the correct existing position.");

                        e.PositionId = existingId;
                        return existingId;
                    }
                }
            }

            // Serialize POS code generation across concurrent registrations.
            using (SqlCommand lockCmd = new SqlCommand(@"
        DECLARE @result int;
        EXEC @result = sys.sp_getapplock
            @Resource = N'AO_HRIS_PositionCode',
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 15000;
        SELECT @result;", cn, tx))
            {
                int result = Convert.ToInt32(lockCmd.ExecuteScalar());

                if (result < 0)
                    throw new InvalidOperationException(
                        "Could not reserve a position code. Please try again.");
            }

            int nextNumber;

            using (SqlCommand numberCmd = new SqlCommand(@"
        SELECT ISNULL(
            MAX(TRY_CONVERT(INT, SUBSTRING(PositionCode, 5, 20))), 0
        ) + 1
        FROM dbo.Position WITH (UPDLOCK, HOLDLOCK)
        WHERE PositionCode LIKE 'POS-%'
          AND SUBSTRING(PositionCode, 5, 20) <> ''
          AND SUBSTRING(PositionCode, 5, 20) NOT LIKE '%[^0-9]%';", cn, tx))
            {
                nextNumber = Convert.ToInt32(numberCmd.ExecuteScalar());
            }

            string positionCode = "POS-" + nextNumber.ToString("D4");

            // Retrieve the default Position Level.
            int rankAndFileId;

            using (SqlCommand levelCmd = new SqlCommand(@"
        SELECT PositionLevelId
        FROM dbo.PositionLevel
        WHERE LevelCode = N'RANK_FILE'
          AND IsActive = 1;", cn, tx))
            {
                object result = levelCmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    throw new InvalidOperationException(
                        "The active Rank and File position level was not found.");

                rankAndFileId = Convert.ToInt32(result);
            }

            // Insert the new position in the same transaction as the employee operation.
            using (SqlCommand insert = new SqlCommand(@"
        INSERT INTO dbo.Position
        (
            DepartmentId,
            PositionLevelId,
            PositionCode,
            PositionName,
            IsActive
        )
        OUTPUT INSERTED.PositionId
        VALUES
        (
            @DepartmentId,
            @PositionLevelId,
            @PositionCode,
            @PositionName,
            1
        );", cn, tx))
            {
                Add(insert, "@DepartmentId", SqlDbType.Int, e.DepartmentId);
                Add(insert, "@PositionLevelId", SqlDbType.Int, rankAndFileId);
                Add(insert, "@PositionCode", SqlDbType.NVarChar, positionCode, 40);
                Add(insert, "@PositionName", SqlDbType.NVarChar, positionName, 400);

                int newPositionId = Convert.ToInt32(insert.ExecuteScalar());

                e.PositionId = newPositionId;
                return newPositionId;
            }
        }
    }
}
