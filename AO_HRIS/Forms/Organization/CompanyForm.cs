
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Organization
{
    public partial class CompanyForm : Form
    {
        private readonly OrganizationRepository _repository =
            new OrganizationRepository();

        private readonly int? _companyId;

        public CompanyForm()
        {
            InitializeComponent();
        }

        public CompanyForm(int companyId) : this()
        {
            _companyId = companyId;
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            if (_companyId.HasValue)
            {
                Text = "Edit Company";
                btnSave.Text = "Save Changes";
                LoadCompany();
            }
            else
            {
                Text = "Add Company";
                btnSave.Text = "Save Company";
                chkIsActive.Checked = true;
            }
        }

        private void LoadCompany()
        {
            DataTable table =
                _repository.GetCompany(_companyId.Value);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Company not found.",
                    "Organization Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            DataRow row = table.Rows[0];

            txtCompanyCode.Text =
                Convert.ToString(row["CompanyCode"]);

            txtCompanyName.Text =
                Convert.ToString(row["CompanyName"]);

            txtLegalName.Text =
                Convert.ToString(row["LegalName"]);

            txtAddress.Text =
                Convert.ToString(row["Address"]);

            txtContactNumber.Text =
                Convert.ToString(row["ContactNumber"]);

            txtEmail.Text =
                Convert.ToString(row["Email"]);

            chkIsActive.Checked =
                Convert.ToBoolean(row["IsActive"]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCompanyCode.Text.Trim();
            string name = txtCompanyName.Text.Trim();

            if (string.IsNullOrWhiteSpace(code) ||
                string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Company Code and Company Name are required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnSave.Enabled = false;

                if (_companyId.HasValue)
                {
                    _repository.UpdateCompany(
                        _companyId.Value,
                        code,
                        name,
                        txtLegalName.Text,
                        txtAddress.Text,
                        txtContactNumber.Text,
                        txtEmail.Text,
                        chkIsActive.Checked);
                }
                else
                {
                    _repository.AddCompany(
                        code,
                        name,
                        txtLegalName.Text,
                        txtAddress.Text,
                        txtContactNumber.Text,
                        txtEmail.Text,
                        chkIsActive.Checked);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Number == 2601 || ex.Number == 2627
                        ? "Company Code already exists."
                        : "Database error: " + ex.Message,
                    "Save Company",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Save Company",
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
