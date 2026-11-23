using System;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Documents
{
    internal partial class DocumentUploadDialog : Form
    {
        private bool canMarkConfidential;

        public int CategoryId
        {
            get { return Convert.ToInt32(cboCategory.SelectedValue); }
        }

        public string DocumentName
        {
            get { return txtName.Text.Trim(); }
        }

        public DateTime? IssueDate
        {
            get { return chkIssue.Checked ? (DateTime?)dtIssue.Value.Date : null; }
        }

        public DateTime? ExpiryDate
        {
            get { return chkExpiry.Checked ? (DateTime?)dtExpiry.Value.Date : null; }
        }

        public bool IsConfidential
        {
            get { return chkConfidential.Checked; }
        }

        public string Notes
        {
            get { return txtNotes.Text.Trim(); }
        }
        
        public DocumentUploadDialog()
        {
            InitializeComponent();
        }

        public DocumentUploadDialog(DataTable source, bool allowConfidential)
            : this()
        {
            canMarkConfidential = allowConfidential;
            chkConfidential.Enabled = allowConfidential;

            cboCategory.DataSource = source;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";

            UpdateConfidentialDefault();
        }

        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConfidentialDefault();
        }

        private void UpdateConfidentialDefault()
        {
            if (!canMarkConfidential)
            {
                chkConfidential.Checked = false;
                return;
            }

            DataRowView selectedCategory = cboCategory.SelectedItem as DataRowView;
            if (selectedCategory != null && selectedCategory.Row.Table.Columns.Contains("IsConfidentialDefault"))
                chkConfidential.Checked = Convert.ToBoolean(selectedCategory["IsConfidentialDefault"]);
        }

        private void ChkIssue_CheckedChanged(object sender, EventArgs e)
        {
            dtIssue.Enabled = chkIssue.Checked;
        }

        private void ChkExpiry_CheckedChanged(object sender, EventArgs e)
        {
            dtExpiry.Enabled = chkExpiry.Checked;
        }
    }
}
