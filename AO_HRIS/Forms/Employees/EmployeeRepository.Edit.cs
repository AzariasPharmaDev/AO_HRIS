using System;
using System.Data;
using System.Data.SqlClient;
using AO_HRIS.Data;
using AO_HRIS.Security;

namespace AO_HRIS.Forms.Employees
{
    public sealed partial class EmployeeRepository
    {
        public DataRow GetForEdit(int employeeId, int assignmentId, int companyId)
        {
            EnsureCompanyPermission(PermissionCodes.EmployeeRecords, companyId);
            EnsureCompanyPermission(PermissionCodes.EmployeeAssignments, companyId);

            const string sql = @"
             SELECT er.*, ea.AssignmentId, ea.CompanyId, ea.DepartmentId, ea.PositionId,
                   ea.CompanyEmployeeNo, ea.ManagerAssignmentId, ea.EmploymentType,
                   ea.EmploymentStatus, ea.DateHired, ea.RegularizationDate,
                   ea.ContractEndDate, ea.EffectiveFrom, ea.EffectiveTo,
                   ea.WorkLocation, ea.CostCenter, ea.IsPrimary
            FROM dbo.EmployeeRecord er
            JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId = er.EmployeeId
            WHERE er.EmployeeId = @EmployeeId AND ea.AssignmentId = @AssignmentId
              AND ea.CompanyId = @CompanyId;";
            using (SqlConnection cn = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@AssignmentId", SqlDbType.Int).Value = assignmentId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                DataTable dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                if (dt.Rows.Count != 1)
                    throw new InvalidOperationException("Employee assignment not found in the current company.");
                return dt.Rows[0];
            }
        }

        public void Update(int employeeId, int assignmentId, int companyId, EmployeeRegistration e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (e.CompanyId != companyId)
                throw new ArgumentException("Cannot change the company of an existing assignment.");

            ValidateEmployeeRegistration(e);
            ValidateAssignmentDates(e);
            EnsureCompanyPermission(PermissionCodes.EmployeeRecords, companyId);
            EnsureCompanyPermission(PermissionCodes.EmployeeAssignments, companyId);
            using (SqlConnection cn = DatabaseConnection.GetConnection())
            {
                cn.Open();
                using (SqlTransaction tx = cn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {

                        ResolvePositionId(cn, tx, e);
                        ValidateCompanyDepartmentPosition(cn, tx, e);
                        ValidateManagerAssignment(cn, tx, e, employeeId);
                        ValidateAssignmentOverlap(cn, tx, employeeId, e, assignmentId);
                        // Preserve assignment ownership verification.
                        using (SqlCommand check = new SqlCommand(@"
                        SELECT COUNT(*)
                        FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK)
                        WHERE AssignmentId = @AssignmentId
                          AND EmployeeId = @EmployeeId
                          AND CompanyId = @CompanyId;", cn, tx))
                        {
                            Add(check, "@AssignmentId", SqlDbType.Int, assignmentId);
                            Add(check, "@EmployeeId", SqlDbType.Int, employeeId);
                            Add(check, "@CompanyId", SqlDbType.Int, companyId);
                            if (Convert.ToInt32(check.ExecuteScalar()) != 1)
                                throw new InvalidOperationException(
                                    "Assignment does not belong to this employee/company.");
                        }
                        DataTable previousAssignment = new DataTable();
                        using (SqlCommand snapshot = new SqlCommand(@"
                        SELECT CompanyId, DepartmentId, PositionId, ManagerAssignmentId,
                            EmploymentType, EmploymentStatus, CompanyEmployeeNo
                        FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK)
                        WHERE AssignmentId=@AssignmentId AND EmployeeId=@EmployeeId AND CompanyId=@CompanyId;", cn, tx))
                        {
                            Add(snapshot, "@AssignmentId", SqlDbType.Int, assignmentId);
                            Add(snapshot, "@EmployeeId", SqlDbType.Int, employeeId);
                            Add(snapshot, "@CompanyId", SqlDbType.Int, companyId);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(snapshot)) adapter.Fill(previousAssignment);
                        }
                        if (previousAssignment.Rows.Count != 1)
                            throw new InvalidOperationException("Assignment not found while preparing history.");
                        DataRow previous = previousAssignment.Rows[0];
                        // Preserve the existing company employee number.
                        // Generate one only if the database value is missing.
                        string companyEmployeeNo =
                            previous["CompanyEmployeeNo"] == DBNull.Value
                                ? null
                                : Convert.ToString(previous["CompanyEmployeeNo"]);

                        if (string.IsNullOrWhiteSpace(companyEmployeeNo))
                        {
                            companyEmployeeNo = GenerateCompanyEmployeeNo(cn, tx, companyId, employeeId);
                        }
                        using (SqlCommand cmd = new SqlCommand(@"
                        UPDATE dbo.EmployeeRecord SET
                         FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName,
                         Suffix=@Suffix, PreferredName=@PreferredName, BirthDate=@BirthDate,
                         Gender=@Gender, CivilStatus=@CivilStatus, Email=@Email,
                         MobileNumber=@MobileNumber, TelephoneNumber=@TelephoneNumber,
                         AddressLine1=@AddressLine1, AddressLine2=@AddressLine2,
                         Barangay=@Barangay, City=@City, Province=@Province,
                         PostalCode=@PostalCode, Country=@Country,
                         EmergencyContactName=@EmergencyContactName,
                         EmergencyContactRelationship=@EmergencyContactRelationship,
                         EmergencyContactNumber=@EmergencyContactNumber, IsActive=@IsActive,
                         UpdatedAt=GETDATE()
                        WHERE EmployeeId=@EmployeeId;", cn, tx))
                        {
                            Add(cmd, "@EmployeeId", SqlDbType.Int, employeeId);
                            AddPersonalParameters(cmd, e);
                            if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Employee not found.");
                        }
                        using (SqlCommand cmd = new SqlCommand(@"
                        UPDATE dbo.EmployeeAssignment SET
                         DepartmentId=@DepartmentId, PositionId=@PositionId,
                         CompanyEmployeeNo=@CompanyEmployeeNo, ManagerAssignmentId=@ManagerAssignmentId,
                         EmploymentType=@EmploymentType, EmploymentStatus=@EmploymentStatus,
                         DateHired=@DateHired, RegularizationDate=@RegularizationDate,
                         ContractEndDate=@ContractEndDate, EffectiveFrom=@EffectiveFrom,
                         EffectiveTo=@EffectiveTo, WorkLocation=@WorkLocation,
                         CostCenter=@CostCenter, IsPrimary=@IsPrimary, UpdatedAt=GETDATE()
                        WHERE AssignmentId=@AssignmentId AND EmployeeId=@EmployeeId AND CompanyId=@CompanyId;", cn, tx))
                        {
                            Add(cmd, "@AssignmentId", SqlDbType.Int, assignmentId);
                            Add(cmd, "@EmployeeId", SqlDbType.Int, employeeId);
                            Add(cmd, "@CompanyId", SqlDbType.Int, companyId);
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
                            if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Assignment not found.");
                        }

                        bool departmentChanged = Convert.ToInt32(previous["DepartmentId"]) != e.DepartmentId;
                        bool positionChanged = Convert.ToInt32(previous["PositionId"]) != e.PositionId;
                        bool managerChanged = !SameNullableInt(previous["ManagerAssignmentId"], e.ManagerAssignmentId);
                        bool statusChanged = !String.Equals(Convert.ToString(previous["EmploymentStatus"]), e.EmploymentStatus, StringComparison.OrdinalIgnoreCase);
                        bool typeChanged = !String.Equals(Convert.ToString(previous["EmploymentType"]), e.EmploymentType, StringComparison.OrdinalIgnoreCase);

                        if (departmentChanged || positionChanged || managerChanged || statusChanged || typeChanged)
                        {
                            string movementType = departmentChanged ? "DEPARTMENT_TRANSFER" :
                                positionChanged ? "POSITION_CHANGE" :
                                managerChanged ? "MANAGER_CHANGE" :
                                statusChanged ? "EMPLOYMENT_STATUS_CHANGE" : "EMPLOYMENT_TYPE_CHANGE";

                            using (SqlCommand history = new SqlCommand(@"
                            INSERT INTO dbo.EmployeeAssignmentHistory
                            (AssignmentId, EmployeeId, MovementType, EffectiveDate,
                             PreviousCompanyId, PreviousDepartmentId, PreviousPositionId, PreviousManagerAssignmentId,
                             NewCompanyId, NewDepartmentId, NewPositionId, NewManagerAssignmentId,
                             PreviousEmploymentType, NewEmploymentType, PreviousEmploymentStatus, NewEmploymentStatus,
                             Reason)
                            VALUES
                            (@AssignmentId, @EmployeeId, @MovementType, @EffectiveDate,
                             @CompanyId, @PreviousDepartmentId, @PreviousPositionId, @PreviousManagerAssignmentId,
                             @CompanyId, @NewDepartmentId, @NewPositionId, @NewManagerAssignmentId,
                             @PreviousEmploymentType, @NewEmploymentType, @PreviousEmploymentStatus, @NewEmploymentStatus,
                             @Reason);", cn, tx))
                            {
                                Add(history, "@AssignmentId", SqlDbType.Int, assignmentId);
                                Add(history, "@EmployeeId", SqlDbType.Int, employeeId);
                                Add(history, "@MovementType", SqlDbType.NVarChar, movementType, 50);
                                Add(history, "@EffectiveDate", SqlDbType.Date, e.EffectiveFrom.Date);
                                Add(history, "@CompanyId", SqlDbType.Int, companyId);
                                Add(history, "@PreviousDepartmentId", SqlDbType.Int, Convert.ToInt32(previous["DepartmentId"]));
                                Add(history, "@PreviousPositionId", SqlDbType.Int, Convert.ToInt32(previous["PositionId"]));
                                Add(history, "@PreviousManagerAssignmentId", SqlDbType.Int, previous["ManagerAssignmentId"] == DBNull.Value ? (object)DBNull.Value : previous["ManagerAssignmentId"]);
                                Add(history, "@NewDepartmentId", SqlDbType.Int, e.DepartmentId);
                                Add(history, "@NewPositionId", SqlDbType.Int, e.PositionId);
                                Add(history, "@NewManagerAssignmentId", SqlDbType.Int, Db(e.ManagerAssignmentId));
                                Add(history, "@PreviousEmploymentType", SqlDbType.NVarChar, previous["EmploymentType"] == DBNull.Value ? (object)DBNull.Value : previous["EmploymentType"], 50);
                                Add(history, "@NewEmploymentType", SqlDbType.NVarChar, Db(e.EmploymentType), 50);
                                Add(history, "@PreviousEmploymentStatus", SqlDbType.NVarChar, previous["EmploymentStatus"], 50);
                                Add(history, "@NewEmploymentStatus", SqlDbType.NVarChar, e.EmploymentStatus, 50);
                                Add(history, "@Reason", SqlDbType.NVarChar, "Employment information updated through Employee Form", 1000);
                                history.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                    catch { try { tx.Rollback(); } catch { } throw; }
                }
            }
        }

        private static bool SameNullableInt(object oldValue, int? newValue)
        {
            if (oldValue == null || oldValue == DBNull.Value) return !newValue.HasValue;
            return newValue.HasValue && Convert.ToInt32(oldValue) == newValue.Value;
        }

        private static void AddPersonalParameters(SqlCommand cmd, EmployeeRegistration e)
        {
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
        }
    }
}
