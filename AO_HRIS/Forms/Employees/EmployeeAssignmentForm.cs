using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Employees
{
    public partial class EmployeeAssignmentForm : Form
    {
        private readonly int _employeeId;
        private readonly int _assignmentId;
        private readonly EmployeeRepository _repository = new EmployeeRepository();
        private bool _loading;
        public int CreatedAssignmentId { get; private set; }
        private bool Editing { get { return _assignmentId > 0; } }

        public EmployeeAssignmentForm(int employeeId) : this(employeeId, 0) { }

        public EmployeeAssignmentForm(int employeeId, int assignmentId)
        {
            if (employeeId <= 0) throw new ArgumentException("Select an existing employee.", "employeeId");
            _employeeId = employeeId;
            _assignmentId = assignmentId;
            InitializeComponent();
            Load += Form_Load;
            cmbCompany.SelectedIndexChanged += CompanyChanged;
            cmbDepartment.SelectedIndexChanged += DepartmentChanged;
            chkHasEffectiveTo.CheckedChanged += (s, e) => dtpEffectiveTo.Enabled = chkHasEffectiveTo.Checked;
            btnSave.Click += SaveClicked;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnEnd.Click += EndClicked;
        }

        private DataTable Table(string sql, params SqlParameter[] args)
        {
            using (var cn = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (args != null) cmd.Parameters.AddRange(args);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        private static SqlParameter P(string name, object value) { return new SqlParameter(name, value ?? DBNull.Value); }
        private static int Id(ComboBox combo)
        {
            int value;
            return combo.SelectedValue != null && int.TryParse(combo.SelectedValue.ToString(), out value) ? value : 0;
        }
        private static void Bind(ComboBox combo, DataTable data, string display, string value)
        {
            combo.DataSource = null;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DataSource = data;
            combo.SelectedIndex = -1;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                _loading = true;
                Text = Editing ? "Edit Employee Assignment" : "Add Employee Assignment";
                lblTitle.Text = Text;
                cmbEmploymentType.Items.AddRange(new object[] { "Regular", "Probationary", "Contractual", "Project-Based" });
                cmbEmploymentStatus.Items.AddRange(new object[] { "ACTIVE", "INACTIVE" });
                cmbEmploymentStatus.SelectedItem = "ACTIVE";
                dtpDateHired.Value = DateTime.Today;
                dtpEffectiveFrom.Value = DateTime.Today;
                dtpEffectiveTo.Value = DateTime.Today;
                chkHasEffectiveTo.Checked = false;
                dtpEffectiveTo.Enabled = false;
                var employee = Table("SELECT EmployeeNo, FirstName, MiddleName, LastName FROM dbo.EmployeeRecord WHERE EmployeeId=@Id", P("@Id", _employeeId));
                if (employee.Rows.Count != 1) throw new InvalidOperationException("Employee record not found.");
                var er = employee.Rows[0];
                lblEmployee.Text = Convert.ToString(er["EmployeeNo"]) + "  |  " + Convert.ToString(er["FirstName"]) + " " + Convert.ToString(er["MiddleName"]) + " " + Convert.ToString(er["LastName"]);
                Bind(cmbCompany, PermissionService.GetAuthorizedAssignmentCompanies(), "CompanyName", "CompanyId");
                btnEnd.Visible = Editing;
                if (Editing) LoadAssignment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load assignment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }
            finally { _loading = false; }
        }

        private void CompanyChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            LoadDepartments(Id(cmbCompany));
        }

        private void DepartmentChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            LoadPositions(Id(cmbDepartment));
        }

        private void LoadDepartments(int companyId)
        {
            Bind(cmbDepartment, Table("SELECT DepartmentId, DepartmentName FROM dbo.Department WHERE CompanyId=@CompanyId AND IsActive=1 ORDER BY DepartmentName", P("@CompanyId", companyId)), "DepartmentName", "DepartmentId");
            Bind(cmbPosition, new DataTable(), "PositionName", "PositionId");
        }

        private void LoadPositions(int departmentId)
        {
            Bind(cmbPosition, Table("SELECT PositionId, PositionName FROM dbo.Position WHERE DepartmentId=@DepartmentId AND IsActive=1 ORDER BY PositionName", P("@DepartmentId", departmentId)), "PositionName", "PositionId");
        }

        private void LoadAssignment()
        {
            var dt = Table(@"SELECT ea.*, d.CompanyId AS DepartmentCompanyId FROM dbo.EmployeeAssignment ea
            JOIN dbo.Department d ON d.DepartmentId=ea.DepartmentId
            WHERE ea.AssignmentId=@AssignmentId AND ea.EmployeeId=@EmployeeId",
                P("@AssignmentId", _assignmentId), P("@EmployeeId", _employeeId));
            if (dt.Rows.Count != 1) throw new InvalidOperationException("Assignment not found for this employee.");
            DataRow r = dt.Rows[0];
            int company = Convert.ToInt32(r["CompanyId"]), department = Convert.ToInt32(r["DepartmentId"]), position = Convert.ToInt32(r["PositionId"]);
            if (Convert.ToInt32(r["DepartmentCompanyId"]) != company) throw new InvalidOperationException("Assignment has an inconsistent department/company.");
            cmbCompany.SelectedValue = company;
            LoadDepartments(company);
            cmbDepartment.SelectedValue = department;
            LoadPositions(department);
            cmbPosition.SelectedValue = position;
            if (Id(cmbCompany) != company || Id(cmbDepartment) != department || Id(cmbPosition) != position)
                throw new InvalidOperationException("Assigned company, department, or position is unavailable or outside your authorized scope.");
            cmbCompany.Enabled = false;
            txtCompanyEmployeeNo.Text = Convert.ToString(r["CompanyEmployeeNo"]);
            cmbEmploymentType.Text = Convert.ToString(r["EmploymentType"]);
            cmbEmploymentStatus.Text = Convert.ToString(r["EmploymentStatus"]).ToUpperInvariant();
            dtpDateHired.Value = Convert.ToDateTime(r["DateHired"]);
            dtpDateHired.Enabled = false;
            dtpEffectiveFrom.Value = Convert.ToDateTime(r["EffectiveFrom"]);
            dtpEffectiveFrom.Enabled = false;
            chkHasEffectiveTo.Checked = r["EffectiveTo"] != DBNull.Value;
            if (chkHasEffectiveTo.Checked) dtpEffectiveTo.Value = Convert.ToDateTime(r["EffectiveTo"]);
            dtpEffectiveTo.Enabled = chkHasEffectiveTo.Checked;
            chkIsPrimary.Checked = Convert.ToBoolean(r["IsPrimary"]);
        }

        private bool ValidateInput()
        {
            if (Id(cmbCompany) <= 0 || Id(cmbDepartment) <= 0 || Id(cmbPosition) <= 0)
            { MessageBox.Show("Select a company, department and position."); return false; }
            if (string.IsNullOrWhiteSpace(cmbEmploymentType.Text) || string.IsNullOrWhiteSpace(cmbEmploymentStatus.Text))
            { MessageBox.Show("Select employment type and status."); return false; }
            if (chkHasEffectiveTo.Checked && dtpEffectiveTo.Value.Date < dtpEffectiveFrom.Value.Date)
            { MessageBox.Show("End date cannot precede effective date."); return false; }
            if (!PermissionService.HasPermissionForCompany(PermissionCodes.EmployeeAssignments, Id(cmbCompany)))
            { MessageBox.Show("You do not have assignment permission for this company."); return false; }
            return true;
        }
        private void SaveClicked(object sender, EventArgs e)
        {

            try
            {
                if (!ValidateInput()) return;
                btnSave.Enabled = false;
                var values = new EmployeeRegistration
                {
                    CompanyId = Id(cmbCompany), DepartmentId = Id(cmbDepartment), PositionId = Id(cmbPosition),
                    CompanyEmployeeNo = txtCompanyEmployeeNo.Text.Trim(),
                    EmploymentType = cmbEmploymentType.Text.Trim(), EmploymentStatus = cmbEmploymentStatus.Text.Trim().ToUpperInvariant(),
                    DateHired = dtpDateHired.Value.Date, EffectiveFrom = dtpEffectiveFrom.Value.Date,
                    EffectiveTo = chkHasEffectiveTo.Checked ? (DateTime?)dtpEffectiveTo.Value.Date : null,
                    IsPrimary = chkIsPrimary.Checked
                };
                if (!Editing) CreatedAssignmentId = _repository.AddCompanyAssignment(_employeeId, values);
                else UpdateAssignment(values, false);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { btnSave.Enabled = true; }
        }

        private void EndClicked(object sender, EventArgs e)
        {
            if (!Editing) return;
            if (MessageBox.Show("End this assignment today?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                if (!PermissionService.HasPermissionForCompany(PermissionCodes.EmployeeAssignments, Id(cmbCompany)))
                    throw new UnauthorizedAccessException("Assignment permission denied.");
                var dt = Table("SELECT EffectiveFrom FROM dbo.EmployeeAssignment WHERE AssignmentId=@Id AND EmployeeId=@EmployeeId", P("@Id", _assignmentId), P("@EmployeeId", _employeeId));
                if (dt.Rows.Count != 1 || Convert.ToDateTime(dt.Rows[0][0]).Date > DateTime.Today)
                    throw new InvalidOperationException("This assignment cannot end before its effective date.");
                var values = new EmployeeRegistration
                {
                    CompanyId = Id(cmbCompany), DepartmentId = Id(cmbDepartment), PositionId = Id(cmbPosition),
                    CompanyEmployeeNo = txtCompanyEmployeeNo.Text.Trim(), EmploymentType = cmbEmploymentType.Text,
                    EmploymentStatus = "INACTIVE", DateHired = dtpDateHired.Value.Date,
                    EffectiveFrom = dtpEffectiveFrom.Value.Date, EffectiveTo = DateTime.Today, IsPrimary = false
                };
                UpdateAssignment(values, true);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Unable to end assignment", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void UpdateAssignment(EmployeeRegistration v, bool ending)
        {
            using (var cn = DatabaseConnection.GetConnection())
            {
                cn.Open();
                using (var tx = cn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        var old = new DataTable();
                        using (var cmd = new SqlCommand("SELECT * FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK) WHERE AssignmentId=@Id AND EmployeeId=@EmployeeId", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Id", _assignmentId);
                            cmd.Parameters.AddWithValue("@EmployeeId", _employeeId);
                            using (var da = new SqlDataAdapter(cmd)) da.Fill(old);
                        }
                        if (old.Rows.Count != 1) throw new InvalidOperationException("Assignment no longer exists.");
                        DataRow o = old.Rows[0];
                        if (Convert.ToInt32(o["CompanyId"]) != v.CompanyId) throw new InvalidOperationException("Company cannot be changed.");
                        if (Convert.ToDateTime(o["EffectiveFrom"]).Date != v.EffectiveFrom.Date) throw new InvalidOperationException("Effective From cannot be changed.");
                        using (var check = new SqlCommand(@"SELECT COUNT(*) FROM dbo.Position p
                            JOIN dbo.Department d ON d.DepartmentId=@DepartmentId
                            WHERE p.PositionId=@PositionId AND (p.DepartmentId IS NULL OR p.DepartmentId=@DepartmentId)
                            AND d.CompanyId=@CompanyId AND p.IsActive=1 AND d.IsActive=1", cn, tx))
                        {
                            check.Parameters.AddWithValue("@PositionId", v.PositionId);
                            check.Parameters.AddWithValue("@DepartmentId", v.DepartmentId);
                            check.Parameters.AddWithValue("@CompanyId", v.CompanyId);
                            if (Convert.ToInt32(check.ExecuteScalar()) != 1) throw new InvalidOperationException("Position does not belong to the selected active department/company.");
                        }
                        if (v.IsPrimary)
                        {
                            using (var check = new SqlCommand(@"SELECT COUNT(*) FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK)
                            WHERE EmployeeId=@EmployeeId AND AssignmentId<>@Id AND IsPrimary=1 AND EmploymentStatus='ACTIVE'
                            AND EffectiveFrom<=COALESCE(@To,CONVERT(date,'99991231')) AND (EffectiveTo IS NULL OR EffectiveTo>=@From)", cn, tx))
                            {
                                check.Parameters.AddWithValue("@EmployeeId", _employeeId);
                                check.Parameters.AddWithValue("@Id", _assignmentId);
                                check.Parameters.AddWithValue("@From", v.EffectiveFrom);
                                check.Parameters.AddWithValue("@To", (object)v.EffectiveTo ?? DBNull.Value);
                                if (Convert.ToInt32(check.ExecuteScalar()) > 0) throw new InvalidOperationException("Another overlapping primary assignment exists.");
                            }
                        }
                        using (var cmd = new SqlCommand(@"UPDATE dbo.EmployeeAssignment SET DepartmentId=@DepartmentId, PositionId=@PositionId,
                            CompanyEmployeeNo=@CompanyEmployeeNo, EmploymentType=@EmploymentType, EmploymentStatus=@EmploymentStatus,
                            EffectiveTo=@EffectiveTo, IsPrimary=@IsPrimary, UpdatedAt=SYSUTCDATETIME()
                            WHERE AssignmentId=@Id AND EmployeeId=@EmployeeId", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Id", _assignmentId);
                            cmd.Parameters.AddWithValue("@EmployeeId", _employeeId);
                            cmd.Parameters.AddWithValue("@DepartmentId", v.DepartmentId);
                            cmd.Parameters.AddWithValue("@PositionId", v.PositionId);
                            cmd.Parameters.AddWithValue("@CompanyEmployeeNo", (object)v.CompanyEmployeeNo ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@EmploymentType", (object)v.EmploymentType ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@EmploymentStatus", v.EmploymentStatus);
                            cmd.Parameters.AddWithValue("@EffectiveTo", (object)v.EffectiveTo ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@IsPrimary", v.IsPrimary);
                            if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Update failed.");
                        }
                        // Record movement in the existing history table.
                        using (var cmd = new SqlCommand(@"INSERT INTO dbo.EmployeeAssignmentHistory
                            (AssignmentId, EmployeeId, MovementType, EffectiveDate, PreviousCompanyId, PreviousDepartmentId, PreviousPositionId,
                            NewCompanyId, NewDepartmentId, NewPositionId, PreviousEmploymentType, NewEmploymentType,
                            PreviousEmploymentStatus, NewEmploymentStatus, Reason)
                            VALUES (@Id,@EmployeeId,@MovementType,@EffectiveDate,@CompanyId,@OldDepartment,@OldPosition,
                            @CompanyId,@NewDepartment,@NewPosition,@OldType,@NewType,@OldStatus,@NewStatus,@Reason)", cn, tx))
                        {
                            string movement = ending ? "SEPARATION" :
                                Convert.ToInt32(o["DepartmentId"]) != v.DepartmentId ? "DEPARTMENT_TRANSFER" :
                                Convert.ToInt32(o["PositionId"]) != v.PositionId ? "POSITION_CHANGE" :
                                Convert.ToString(o["EmploymentStatus"]) != v.EmploymentStatus ? "EMPLOYMENT_STATUS_CHANGE" :
                                Convert.ToString(o["EmploymentType"]) != v.EmploymentType ? "EMPLOYMENT_TYPE_CHANGE" : "OTHER";
                            cmd.Parameters.AddWithValue("@Id", _assignmentId);
                            cmd.Parameters.AddWithValue("@EmployeeId", _employeeId);
                            cmd.Parameters.AddWithValue("@MovementType", movement);
                            cmd.Parameters.AddWithValue("@EffectiveDate", ending ? DateTime.Today : DateTime.Today);
                            cmd.Parameters.AddWithValue("@CompanyId", v.CompanyId);
                            cmd.Parameters.AddWithValue("@OldDepartment", o["DepartmentId"]);
                            cmd.Parameters.AddWithValue("@OldPosition", o["PositionId"]);
                            cmd.Parameters.AddWithValue("@NewDepartment", v.DepartmentId);
                            cmd.Parameters.AddWithValue("@NewPosition", v.PositionId);
                            cmd.Parameters.AddWithValue("@OldType", o["EmploymentType"]);
                            cmd.Parameters.AddWithValue("@NewType", (object)v.EmploymentType ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@OldStatus", o["EmploymentStatus"]);
                            cmd.Parameters.AddWithValue("@NewStatus", v.EmploymentStatus);
                            cmd.Parameters.AddWithValue("@Reason", ending ? "Assignment ended through Employee Assignment Form" : "Assignment edited through Employee Assignment Form");
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch { tx.Rollback(); throw; }
                }
            }
        }
    }
}
