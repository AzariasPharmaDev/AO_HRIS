
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Organization
{
    public partial class DepartmentForm : Form
    {
        private readonly OrganizationRepository _repository =
            new OrganizationRepository();

        private readonly int? _departmentId;

        public DepartmentForm()
        {
            InitializeComponent();
        }

        public DepartmentForm(int departmentId) : this()
        {
            _departmentId = departmentId;
        }
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCompanies();
                LoadParentDepartments();

                if (_departmentId.HasValue)
                {
                    Text = "Edit Department";
                    lblTitle.Text = "Edit Department";
                    btnSave.Text = "Save Changes";
                    LoadDepartment();
                }
                else
                {
                    Text = "Add Department";
                    lblTitle.Text = "Add Department";
                    btnSave.Text = "Save Department";
                    chkIsActive.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Load Department",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                BeginInvoke(new Action(Close));
            }
        }

        private void LoadParentDepartments()
        {
            if (!UserSession.CompanyId.HasValue)
                throw new InvalidOperationException(
                    "No active company is selected.");

            DataTable departments = _repository.GetParentDepartments(
                UserSession.CompanyId.Value,
                _departmentId);

            DataRow noParent = departments.NewRow();
            noParent["DepartmentId"] = DBNull.Value;
            noParent["DepartmentName"] = "No Parent Department";

            departments.Rows.InsertAt(noParent, 0);

            cmbParentDepartment.DataSource = departments;
            cmbParentDepartment.DisplayMember = "DepartmentName";
            cmbParentDepartment.ValueMember = "DepartmentId";
            cmbParentDepartment.SelectedIndex = 0;
        }
        private void LoadCompanies()
        {
            if (!UserSession.CompanyId.HasValue ||
                UserSession.CompanyId.Value <= 0)
            {
                throw new InvalidOperationException(
                    "No active company is selected.");
            }

            DataTable companies = _repository.GetCompany(
                UserSession.CompanyId.Value);

            DataView view = new DataView(companies);
            view.RowFilter = "IsActive = true";

            if (view.Count == 0)
                throw new InvalidOperationException(
                    "The active company is unavailable or inactive.");

            cmbCompany.DataSource = view.ToTable();
            cmbCompany.DisplayMember = "CompanyName";
            cmbCompany.ValueMember = "CompanyId";
            cmbCompany.SelectedValue = UserSession.CompanyId.Value;

            // Company is determined by the active session.
            cmbCompany.Enabled = false;
        }

        private void LoadDepartment()
        {
            DataTable table =
                _repository.GetDepartment(_departmentId.Value);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Department not found.",
                    "Department Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                BeginInvoke(new Action(Close));
                return;
            }

            DataRow row = table.Rows[0];

            cmbCompany.SelectedValue =
                Convert.ToInt32(row["CompanyId"]);

            txtDepartmentCode.Text =
                Convert.ToString(row["DepartmentCode"]);

            txtDepartmentName.Text =
                Convert.ToString(row["DepartmentName"]);

            txtDescription.Text =
                Convert.ToString(row["Description"]);

            if (row["ParentDepartmentId"] != DBNull.Value)
            {
                cmbParentDepartment.SelectedValue =
                    Convert.ToInt32(row["ParentDepartmentId"]);
            }
            else
            {
                cmbParentDepartment.SelectedIndex = 0;
            }

            chkIsActive.Checked =
                Convert.ToBoolean(row["IsActive"]);

            // Keep the department under its original company.
            // Moving departments requires separate dependency checks.
            cmbCompany.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCompany.SelectedValue == null ||
                !(cmbCompany.SelectedValue is int))
            {
                MessageBox.Show(
                    "Please select a company.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int companyId = (int)cmbCompany.SelectedValue;
            int? parentDepartmentId = null;

            if (cmbParentDepartment.SelectedValue != null &&
                cmbParentDepartment.SelectedValue != DBNull.Value)
            {
                parentDepartmentId =
                    Convert.ToInt32(cmbParentDepartment.SelectedValue);
            }
            string code = txtDepartmentCode.Text.Trim();
            string name = txtDepartmentName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Department Name is required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnSave.Enabled = false;

                // Generate a code if this is a new department
                // and the Department Code field is empty.
                if (!_departmentId.HasValue &&
                    string.IsNullOrWhiteSpace(code))
                {
                    code = _repository.GetNextDepartmentCode(companyId);
                    txtDepartmentCode.Text = code;
                }

                if (_departmentId.HasValue)
                {
                    _repository.UpdateDepartment(
                    _departmentId.Value,
                    code,
                    name,
                    txtDescription.Text,
                    chkIsActive.Checked,
                    parentDepartmentId);
                }
                else
                {
                    _repository.AddDepartment(
                     code,
                     name,
                     txtDescription.Text,
                     chkIsActive.Checked,
                     parentDepartmentId);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                string message =
                    ex.Number == 2601 || ex.Number == 2627
                    ? "This Department Code already exists in the selected company."
                    : "Database error: " + ex.Message;

                MessageBox.Show(
                    message,
                    "Save Department",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Save Department",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
