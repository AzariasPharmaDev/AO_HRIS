
using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Employees
{
    public partial class EmployeeForm : Form
    {
        private bool _loadingCompanies = false;

        public EmployeeForm()
        {
            InitializeComponent();
            InitializeDropdowns();
            InitializeDatePickers();
            InitializeForm();
            WireSaveButton();
        }

        private void InitializeDropdowns()
        {
            cmbSuffix.Items.AddRange(new object[]
            {
                "None", "Jr.", "Sr.", "II", "III", "IV"
            });

            cmbGender.Items.AddRange(new object[]
            {
                "Male", "Female", "Other",
                "Prefer not to say"
            });

            cmbCivilStatus.Items.AddRange(new object[]
            {
                "Single", "Married", "Widowed",
                "Separated", "Divorced"
            });

            cmbCountry.Items.Add("Philippines");


            cmbEmergencyRelationship.Items.AddRange(new object[]
            {
                "Parent", "Spouse", "Sibling",
                "Child", "Relative", "Guardian",
                "Friend", "Other"
            });

            cmbEmploymentType.Items.AddRange(new object[]
            {
                "Regular", "Probationary",
                "Contractual", "Project-Based",
                "Part-Time", "Intern"
            });

            cmbEmploymentStatus.Items.AddRange(new object[]
            {
                "Active", "On Leave", "Suspended",
                "Resigned", "Terminated", "Retired"
            });

            cmbSuffix.SelectedIndex = 0;
            cmbCountry.SelectedIndex = 0;
            cmbEmploymentStatus.SelectedIndex = 0;

            cmbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDown/*List*/;
            cmbManager.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitializeDatePickers()
        {
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.ShowCheckBox = true;
            dtpBirthDate.Checked = false;
            dtpRegularizationDate.ShowCheckBox = true;
            dtpRegularizationDate.Checked = false;
            dtpContractEndDate.ShowCheckBox = true;
            dtpContractEndDate.Checked = false;
            dtpDateHired.Value = DateTime.Today;
            dtpEffectiveTo.ShowCheckBox = true;
            dtpEffectiveTo.Checked = false;
            dtpEffectiveFrom.Value = DateTime.Today;
        }

        private void InitializeForm()
        {
            Text = "Add Employee";

            txtEmployeeNo.ReadOnly = true;
            chkIsActive.Checked = true;
            tabEmployee.SelectedTab = tabPersonal;

            cmbCompany.SelectedIndexChanged += cmbCompany_SelectedIndexChanged;
            cmbDepartment.SelectedIndexChanged -= cmbDepartment_SelectedIndexChanged;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;

            btnCancel.Click += btnCancel_Click;
        }

        private DateTime? GetBirthDateForSave()
        {
            if (!dtpBirthDate.Checked)
                return null;

            DateTime birthDate = dtpBirthDate.Value.Date;

            if (birthDate > DateTime.Today)
                throw new InvalidOperationException(
                    "Birth date cannot be in the future.");

            return birthDate;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!RequirePermission(PermissionCodes.EmployeeRecords, "access employee records"))
                {
                    Close();
                    return;
                }
                if (!UserSession.CompanyId.HasValue)
                {
                    MessageBox.Show("No company is currently selected.", "Employee Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                LoadCompanies();
                LoadPositions();
                if (IsEditMode)
                {
                    LoadEmployeeForEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load employee form data:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private DataTable ExecuteTable(string query, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                adapter.Fill(table);
            }

            return table;
        }

        private void LoadCompanies()
        {
            _loadingCompanies = true;

            try
            {
                // Restricted to the selected company until
                // authorized-company access is implemented.
                string query = @"
                    SELECT CompanyId, CompanyName
                    FROM Company
                    WHERE IsActive = 1
                      AND CompanyId = @CompanyId
                    ORDER BY CompanyName";

                DataTable table = ExecuteTable(query, new SqlParameter("@CompanyId", UserSession.CompanyId.Value));

                cmbCompany.DataSource = null;
                cmbCompany.DisplayMember = "CompanyName";
                cmbCompany.ValueMember = "CompanyId";
                cmbCompany.DataSource = table;

                // Do not allow changing companies yet. 
                cmbCompany.Enabled = false;
            }
            finally
            {
                _loadingCompanies = false;
            }

            if (cmbCompany.SelectedValue != null &&
                cmbCompany.SelectedValue is int)
            {
                int companyId =
                    (int)cmbCompany.SelectedValue;

                LoadDepartments(companyId);
                LoadManagers(companyId);
            }
        }

        private void LoadDepartments(int companyId)
        {
            string query = @"
                SELECT DepartmentId, DepartmentName FROM Department
                WHERE CompanyId = @CompanyId AND IsActive = 1
                ORDER BY DepartmentName";

            DataTable table = ExecuteTable(query, new SqlParameter("@CompanyId", companyId));
            cmbDepartment.DataSource = null;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentId";
            cmbDepartment.DataSource = table;
            cmbDepartment.SelectedIndex = -1;
        }

        private void LoadPositions()
        {
            if (!(cmbDepartment.SelectedValue is int))
            {
                cmbPosition.DataSource = null;
                cmbPosition.Items.Clear();
                cmbPosition.Text = "";
                return;
            }

            int departmentId = (int)cmbDepartment.SelectedValue;

            string query = @"
                SELECT
                    PositionId,
                    PositionName
                FROM dbo.Position
                WHERE IsActive = 1
                  AND DepartmentId = @DepartmentId
                ORDER BY PositionName;";

            DataTable table = ExecuteTable(
                query,
                new SqlParameter("@DepartmentId", departmentId));

            cmbPosition.DataSource = null;
            cmbPosition.Items.Clear();

            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "PositionId";
            cmbPosition.DataSource = table;

            // Allow selecting an existing position or typing a new one.
            cmbPosition.SelectedIndex = -1;
            cmbPosition.Text = "";
        }

        private void LoadManagers(int companyId)
        {
            string query = @"
            SELECT
                ea.AssignmentId,
                LTRIM(RTRIM(
                    er.LastName + ', ' +
                    er.FirstName
                )) AS EmployeeName
            FROM EmployeeAssignment ea
            INNER JOIN EmployeeRecord er
                ON ea.EmployeeId = er.EmployeeId
            WHERE ea.CompanyId = @CompanyId
              AND er.IsActive = 1
              AND ea.EmploymentStatus = 'Active'
              AND ea.EffectiveFrom <= @Today
              AND (
                  ea.EffectiveTo IS NULL
                  OR ea.EffectiveTo >= @Today
              )
            ORDER BY er.LastName, er.FirstName";

            DataTable table = ExecuteTable(
                query,
                new SqlParameter("@CompanyId", companyId),
                new SqlParameter(
                    "@Today",
                    DateTime.Today));

            cmbManager.DataSource = null;
            cmbManager.DisplayMember = "EmployeeName";
            cmbManager.ValueMember = "AssignmentId";
            cmbManager.DataSource = table;

            // Manager assignment is optional.
            cmbManager.SelectedIndex = -1;
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingCompanies)
                return;

            if (!(cmbCompany.SelectedValue is int))
                return;

            try
            {
                int companyId =
                    (int)cmbCompany.SelectedValue;

                // Defense in depth: prevent an unauthorized
                // company selection from being loaded.
                if (!UserSession.CompanyId.HasValue ||
                    companyId != UserSession.CompanyId.Value)
                {
                    throw new InvalidOperationException(
                        "Company selection is not authorized.");
                }

                LoadDepartments(companyId);
                LoadManagers(companyId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Company Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Retained because your original Designer
        // references this event handler.

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd, int msg, int wParam, int lParam);

        private void drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
        private void btnAddAssignment_Click(object sender, EventArgs e)
        {
            if (!RequirePermission(PermissionCodes.EmployeeAssignments, "manage employee assignments"))
            {
                return;
            }
            if (!_editEmployeeId.HasValue || _editEmployeeId.Value <= 0)
            {
                MessageBox.Show(
                    "Please save the employee record before adding another company assignment.",
                    "Employee Assignment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int employeeId = _editEmployeeId.Value;

            using (EmployeeAssignmentForm form =
                new EmployeeAssignmentForm(employeeId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show(
                        "The employee's company assignment has been saved.",
                        "Assignment Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Assignment list refresh will be added later.
                }
            }
        }

        private void btnClearManager_Click(object sender, EventArgs e)
        {
            cmbManager.SelectedIndex = -1;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPositions();
        }

        private bool RequirePermission(string permission, string action)
        {
            if (PermissionService.HasPermission(permission))
                return true;

            MessageBox.Show(
                "You do not have permission to " + action + ".",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }
    }
}