using System;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Policies
{
    public partial class PolicyDetailsDialog : Form
    {
        private readonly int _companyId;
        private readonly int _policyId;
        private readonly CompanyPolicyRepository _repository = new CompanyPolicyRepository();

        public string PolicyCode { get; private set; }
        public string PolicyTitle { get; private set; }
        public int CategoryId { get; private set; }
        public string Description { get; private set; }

        public PolicyDetailsDialog()
        {
            InitializeComponent();
        }

        public PolicyDetailsDialog(int companyId, int policyId) : this()
        {
            _companyId = companyId;
            _policyId = policyId;
            LoadCategories();
            LoadPolicy();
        }

        private void LoadCategories()
        {
            DataTable categories = _repository.GetCategories(_companyId);
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
            cboCategory.DataSource = categories;
        }

        private void LoadPolicy()
        {
            DataRow row = _repository.GetPolicyHeader(_companyId, _policyId).Rows[0];
            txtPolicyCode.Text = Convert.ToString(row["PolicyCode"]);
            txtPolicyTitle.Text = Convert.ToString(row["PolicyTitle"]);
            txtDescription.Text = row["PolicyDescription"] == DBNull.Value ? string.Empty : Convert.ToString(row["PolicyDescription"]);
            cboCategory.SelectedValue = Convert.ToInt32(row["CategoryId"]);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPolicyCode.Text))
            {
                MessageBox.Show("Enter a policy code.", "Policy Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPolicyCode.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPolicyTitle.Text))
            {
                MessageBox.Show("Enter a policy title.", "Policy Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPolicyTitle.Focus();
                return;
            }
            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Select a policy category.", "Policy Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PolicyCode = txtPolicyCode.Text.Trim();
            PolicyTitle = txtPolicyTitle.Text.Trim();
            CategoryId = Convert.ToInt32(cboCategory.SelectedValue);
            Description = txtDescription.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
