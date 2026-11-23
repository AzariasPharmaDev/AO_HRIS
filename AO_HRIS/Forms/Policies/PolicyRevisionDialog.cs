using AO_HRIS.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Policies
{
    public partial class PolicyRevisionDialog : Form
    {
        private readonly int _companyId;
        private readonly int? _policyId;
        private readonly CompanyPolicyRepository _repository = new CompanyPolicyRepository();

        public PolicyRevisionDraft Draft { get; private set; }

        public PolicyRevisionDialog()
        {
            InitializeComponent();
        }

        public PolicyRevisionDialog(int companyId, int? policyId) : this()
        {
            _companyId = companyId;
            _policyId = policyId;
            LoadCategories();

            if (policyId.HasValue)
                LoadExistingPolicy(policyId.Value);
            else
                txtRevisionLabel.Text = "1.0";
        }

        private void LoadCategories()
        {
            DataTable categories = _repository.GetCategories(_companyId);
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
            cboCategory.DataSource = categories;
            if (categories.Rows.Count == 0)
            {
                btnSaveDraft.Enabled = false;
                MessageBox.Show("No active policy categories were found. Run the Company Policy Management SQL setup first.",
                    "Policy Categories", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadExistingPolicy(int policyId)
        {
            DataTable result = _repository.GetPolicyHeader(_companyId, policyId);
            DataRow row = result.Rows[0];
            txtPolicyCode.Text = Convert.ToString(row["PolicyCode"]);
            txtPolicyTitle.Text = Convert.ToString(row["PolicyTitle"]);
            txtDescription.Text = row["PolicyDescription"] == DBNull.Value ? string.Empty : Convert.ToString(row["PolicyDescription"]);
            if (cboCategory.DataSource != null)
                cboCategory.SelectedValue = Convert.ToInt32(row["CategoryId"]);

            txtPolicyCode.Enabled = false;
            txtPolicyTitle.Enabled = false;
            txtDescription.Enabled = false;
            cboCategory.Enabled = false;
            txtRevisionLabel.Text = "Revision " + Convert.ToString(row["NextRevisionNumber"]);
            Text = "Create Policy Revision";
            lblDialogTitle.Text = "Create a new policy revision";
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialogPolicy.ShowDialog(this) == DialogResult.OK)
                txtFilePath.Text = openFileDialogPolicy.FileName;
        }

        private void BtnSaveDraft_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_policyId.HasValue)
                {
                    if (string.IsNullOrWhiteSpace(txtPolicyCode.Text))
                        throw new ArgumentException("Enter a policy code.");
                    if (string.IsNullOrWhiteSpace(txtPolicyTitle.Text))
                        throw new ArgumentException("Enter a policy title.");
                    if (cboCategory.SelectedValue == null)
                        throw new ArgumentException("Select a policy category.");
                }

                if (string.IsNullOrWhiteSpace(txtRevisionLabel.Text))
                    throw new ArgumentException("Enter a revision label.");
                if (string.IsNullOrWhiteSpace(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
                    throw new ArgumentException("Select a PDF policy document.");
                if (!string.Equals(Path.GetExtension(txtFilePath.Text), ".pdf", StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("Policy documents must be PDF files.");

                byte[] data = File.ReadAllBytes(txtFilePath.Text);
                if (data.Length == 0) throw new ArgumentException("The selected PDF is empty.");
                if (data.LongLength > 20L * 1024L * 1024L)
                    throw new ArgumentException("The maximum policy document size is 20 MB.");

                Draft = new PolicyRevisionDraft
                {
                    PolicyId = _policyId,
                    PolicyCode = txtPolicyCode.Text.Trim(),
                    PolicyTitle = txtPolicyTitle.Text.Trim(),
                    CategoryId = _policyId.HasValue ? 0 : Convert.ToInt32(cboCategory.SelectedValue),
                    Description = txtDescription.Text.Trim(),
                    RevisionLabel = txtRevisionLabel.Text.Trim(),
                    EffectiveDate = dtpEffectiveDate.Value.Date,
                    OriginalFileName = Path.GetFileName(txtFilePath.Text),
                    FileData = data
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Policy Revision", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
