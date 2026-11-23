
using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Organization
{
    public partial class PositionForm : Form
    {
        private readonly OrganizationRepository _repository =
            new OrganizationRepository();

        private readonly int? _positionId;

        public PositionForm()
        {
            InitializeComponent();
        }

        public PositionForm(int positionId) : this()
        {
            _positionId = positionId;
        }

        private void PositionForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCompanies();
                LoadPositionLevels();

                if (_positionId.HasValue)
                {
                    Text = "Edit Position";
                    lblTitle.Text = "Edit Position";
                    btnSave.Text = "Save Changes";

                    LoadPosition();
                }
                else
                {
                    Text = "Add Position";
                    lblTitle.Text = "Add Position";
                    btnSave.Text = "Save Position";
                    chkIsActive.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Position Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                BeginInvoke(new Action(Close));
            }
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
            {
                throw new InvalidOperationException(
                    "The active company is unavailable or inactive.");
            }

            cmbCompany.DisplayMember = "CompanyName";
            cmbCompany.ValueMember = "CompanyId";
            cmbCompany.DataSource = view.ToTable();
            cmbCompany.SelectedValue = UserSession.CompanyId.Value;

            cmbCompany.Enabled = false;
        }

        private void LoadPositionLevels()
        {
            DataTable levels = _repository.GetPositionLevels();

            cmbPositionLevel.DataSource = null;
            cmbPositionLevel.DisplayMember = "LevelName";
            cmbPositionLevel.ValueMember = "PositionLevelId";
            cmbPositionLevel.DataSource = levels;
            cmbPositionLevel.SelectedIndex = -1;
        }

        private void cmbCompany_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            cmbDepartment.DataSource = null;

            if (!UserSession.CompanyId.HasValue)
                return;

            DataTable departments = _repository.GetDepartments();

            DataView view = new DataView(departments);
            view.RowFilter = "IsActive = true";

            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentId";
            cmbDepartment.DataSource = view.ToTable();
            cmbDepartment.SelectedIndex = -1;
        }



        private void LoadPosition()
        {
            DataTable table = _repository.GetPosition(_positionId.Value);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Position not found or it does not belong to the active company.",
                    "Position Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                BeginInvoke(new Action(Close));
                return;
            }

            DataRow row = table.Rows[0];

            string positionCode = row["PositionCode"] == DBNull.Value
     ? string.Empty
     : Convert.ToString(row["PositionCode"]);

            txtPositionCode.Text = string.IsNullOrWhiteSpace(positionCode)
                ? _repository.GetNextPositionCode()
                : positionCode;

            txtPositionName.Text =
                Convert.ToString(row["PositionName"]);

            txtDescription.Text =
                row["Description"] == DBNull.Value
                    ? string.Empty
                    : Convert.ToString(row["Description"]);

            chkIsActive.Checked =
                Convert.ToBoolean(row["IsActive"]);

            if (row["DepartmentId"] != DBNull.Value)
            {
                int departmentId =
                    Convert.ToInt32(row["DepartmentId"]);

                DataTable department =
                    _repository.GetDepartment(departmentId);

                if (department.Rows.Count > 0)
                {
                    cmbCompany.SelectedValue =
                        Convert.ToInt32(department.Rows[0]["CompanyId"]);

                    cmbDepartment.SelectedValue = departmentId;
                }
            }

            if (row.Table.Columns.Contains("PositionLevelId") &&
                row["PositionLevelId"] != DBNull.Value)
            {
                int positionLevelId =
                    Convert.ToInt32(row["PositionLevelId"]);

                cmbPositionLevel.SelectedValue = positionLevelId;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtPositionCode.Text.Trim();
            string name = txtPositionName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (/*string.IsNullOrWhiteSpace(code) ||*/
                string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Position Name is required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int departmentId;

            if (cmbDepartment.SelectedValue == null ||
                !int.TryParse(
                    Convert.ToString(cmbDepartment.SelectedValue),
                    out departmentId))
            {
                MessageBox.Show(
                    "Select a company and department.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int positionLevelId;

            if (cmbPositionLevel.SelectedValue == null ||
                !int.TryParse(
                    Convert.ToString(cmbPositionLevel.SelectedValue),
                    out positionLevelId))
            {
                MessageBox.Show(
                    "Select a Position Level.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbPositionLevel.Focus();
                return;
            }

            try
            {
                btnSave.Enabled = false;

                if (_positionId.HasValue)
                {
                    _repository.UpdatePosition(
                        _positionId.Value,
                        departmentId,
                        positionLevelId,
                        code,
                        name,
                        description,
                        chkIsActive.Checked);
                }
                else
                {
                    _repository.AddPosition(
                        departmentId,
                        positionLevelId,
                        code,
                        name,
                        description,
                        chkIsActive.Checked);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                string message =
                    ex.Number == 2601 || ex.Number == 2627
                        ? "Position Code already exists."
                        : "Database error: " + ex.Message;

                MessageBox.Show(
                    message,
                    "Save Position",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Save Position",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        public string GetNextPositionCode()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
            SELECT
                'POS-' +
                RIGHT(
                    '0000' +
                    CAST(
                        ISNULL(
                            MAX(TRY_CONVERT(INT, SUBSTRING(PositionCode, 5, 20))),
                            0
                        ) + 1 AS VARCHAR(10)
                    ),
                    4
                )
            FROM Position
            WHERE PositionCode LIKE 'POS-%'
              AND SUBSTRING(PositionCode, 5, 20) <> ''
              AND SUBSTRING(PositionCode, 5, 20) NOT LIKE '%[^0-9]%';";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return Convert.ToString(command.ExecuteScalar());
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
