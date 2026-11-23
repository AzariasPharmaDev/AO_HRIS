using AO_HRIS.Security;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Documents
{
    public partial class EmployeeDocumentManagementControl : UserControl
    {
        private readonly EmployeeDocumentRepository repository = new EmployeeDocumentRepository();
        private DataTable categories;
        private bool canViewConfidential;

        public EmployeeDocumentManagementControl()
        {
            InitializeComponent();
            UpdateButtons();
        }

        private void Control_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                if (!UserSession.CompanyId.HasValue)
                    throw new InvalidOperationException("No company is selected for this session.");

                if (!PermissionService.HasPermissionForCompany(
                    PermissionCodes.EmployeeDocuments, UserSession.CompanyId.Value))
                    throw new UnauthorizedAccessException("You do not have permission to access employee documents.");

                canViewConfidential = PermissionService.HasPermissionForCompany(
                    PermissionCodes.EmployeeDocumentsConfidential, UserSession.CompanyId.Value);

                categories = repository.GetCategories();
                LoadEmployees();

                lblStatus.Text = canViewConfidential
                    ? "Confidential documents are visible to your account."
                    : "Confidential documents are hidden. Contact an administrator if access is required.";
            }
            catch (Exception ex)
            {
                ShowError("Unable to load employee documents", ex);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                int previousEmployeeId = 0;
                if (cboEmployee.SelectedValue != null && !(cboEmployee.SelectedValue is DataRowView))
                    previousEmployeeId = Convert.ToInt32(cboEmployee.SelectedValue);

                DataTable employees = repository.GetEmployees(txtSearch.Text);

                cboEmployee.SelectedIndexChanged -= CboEmployee_SelectedIndexChanged;
                cboEmployee.DataSource = employees;
                cboEmployee.DisplayMember = "EmployeeName";
                cboEmployee.ValueMember = "EmployeeId";

                if (previousEmployeeId > 0)
                {
                    foreach (DataRow employee in employees.Rows)
                    {
                        if (Convert.ToInt32(employee["EmployeeId"]) == previousEmployeeId)
                        {
                            cboEmployee.SelectedValue = previousEmployeeId;
                            break;
                        }
                    }
                }

                cboEmployee.SelectedIndexChanged += CboEmployee_SelectedIndexChanged;
                LoadDocuments();
            }
            catch (Exception ex)
            {
                ShowError("Unable to load employees", ex);
            }
        }

        private void CboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            LoadEmployees();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void LoadDocuments()
        {
            if (cboEmployee.SelectedValue == null || cboEmployee.SelectedValue is DataRowView)
            {
                grid.DataSource = null;
                UpdateButtons();
                return;
            }

            try
            {
                int employeeId = Convert.ToInt32(cboEmployee.SelectedValue);
                grid.DataSource = repository.GetDocuments(employeeId, canViewConfidential);

                if (grid.Columns.Contains("EmployeeDocumentId"))
                    grid.Columns["EmployeeDocumentId"].Visible = false;

                if (grid.Columns.Contains("IsConfidential"))
                    grid.Columns["IsConfidential"].HeaderText = "Confidential";

                if (grid.Columns.Contains("ExpiryStatus"))
                    grid.Columns["ExpiryStatus"].HeaderText = "Expiry status";

                if (grid.Columns.Contains("FileSizeBytes"))
                {
                    grid.Columns["FileSizeBytes"].HeaderText = "Size (bytes)";
                    grid.Columns["FileSizeBytes"].FillWeight = 65;
                }

                foreach (string hiddenColumn in new[] { "OriginalFileName", "Notes" })
                {
                    if (grid.Columns.Contains(hiddenColumn))
                        grid.Columns[hiddenColumn].Visible = false;
                }

                lblStatus.Text = grid.Rows.Count + " document(s) found.";
            }
            catch (Exception ex)
            {
                ShowError("Unable to load documents", ex);
            }

            UpdateButtons();
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (cboEmployee.SelectedValue == null || cboEmployee.SelectedValue is DataRowView)
            {
                MessageBox.Show("Select an employee first.");
                return;
            }

            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Title = "Select employee document";
                file.Filter = "Supported documents|*.pdf;*.jpg;*.jpeg;*.png;*.doc;*.docx;*.xls;*.xlsx;*.txt|All files|*.*";

                if (file.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    FileInfo info = new FileInfo(file.FileName);
                    if (info.Length > 20 * 1024 * 1024)
                        throw new InvalidOperationException("The maximum document size is 20 MB.");

                    using (DocumentUploadDialog dialog = new DocumentUploadDialog(categories, canViewConfidential))
                    {
                        if (dialog.ShowDialog(this) != DialogResult.OK)
                            return;

                        byte[] data = File.ReadAllBytes(file.FileName);
                        repository.AddDocument(
                            Convert.ToInt32(cboEmployee.SelectedValue),
                            dialog.CategoryId,
                            string.IsNullOrWhiteSpace(dialog.DocumentName)
                                ? Path.GetFileNameWithoutExtension(file.FileName)
                                : dialog.DocumentName,
                            Path.GetFileName(file.FileName),
                            data,
                            dialog.IssueDate,
                            dialog.ExpiryDate,
                            dialog.IsConfidential,
                            dialog.Notes);
                    }

                    LoadDocuments();
                    MessageBox.Show("Document uploaded successfully.", "Employee Documents",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowError("Unable to upload document", ex);
                }
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDocument(out long documentId, out bool confidential))
                return;

            try
            {
                DocumentFile document = repository.GetDocument(documentId, confidential);
                using (SaveFileDialog save = new SaveFileDialog())
                {
                    save.FileName = document.FileName;
                    save.Filter = "All files|*.*";
                    save.Title = "Save employee document";

                    if (save.ShowDialog(this) != DialogResult.OK)
                        return;

                    File.WriteAllBytes(save.FileName, document.Data);
                    lblStatus.Text = "Saved " + Path.GetFileName(save.FileName);
                }
            }
            catch (Exception ex)
            {
                ShowError("Unable to download document", ex);
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDocument(out long documentId, out bool confidential))
                return;

            try
            {
                DocumentFile document = repository.GetDocument(documentId, confidential);
                string folder = Path.Combine(Path.GetTempPath(), "AO_HRIS_DocumentPreview");
                Directory.CreateDirectory(folder);

                string safeName = Guid.NewGuid().ToString("N") + Path.GetExtension(document.FileName);
                string temporaryFile = Path.Combine(folder, safeName);
                File.WriteAllBytes(temporaryFile, document.Data);

                Process.Start(new ProcessStartInfo
                {
                    FileName = temporaryFile,
                    UseShellExecute = true
                });

                lblStatus.Text = "Opened document. A temporary copy was placed in " + folder;
            }
            catch (Exception ex)
            {
                ShowError("Unable to open document", ex);
            }
        }

        private void BtnReplace_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDocument(out long documentId, out bool confidential))
                return;

            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Title = "Select replacement document";
                file.Filter = "Supported documents|*.pdf;*.jpg;*.jpeg;*.png;*.doc;*.docx;*.xls;*.xlsx;*.txt|All files|*.*";

                if (file.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    FileInfo info = new FileInfo(file.FileName);
                    if (info.Length > 20 * 1024 * 1024)
                        throw new InvalidOperationException("The maximum document size is 20 MB.");

                    DialogResult confirmation = MessageBox.Show(
                        "Replace the stored file with the selected file? The document metadata will be retained.",
                        "Confirm replacement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmation != DialogResult.Yes)
                        return;

                    repository.ReplaceDocument(documentId, confidential,
                        Path.GetFileName(file.FileName), File.ReadAllBytes(file.FileName));

                    LoadDocuments();
                    MessageBox.Show("Document replaced successfully.", "Employee Documents",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowError("Unable to replace document", ex);
                }
            }
        }

        private void BtnArchive_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDocument(out long documentId, out bool confidential))
                return;

            DialogResult confirmation = MessageBox.Show(
                "Archive this document? It will no longer appear in the active document list.",
                "Confirm archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            try
            {
                repository.ArchiveDocument(documentId, confidential);
                LoadDocuments();
            }
            catch (Exception ex)
            {
                ShowError("Unable to archive document", ex);
            }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private bool TryGetSelectedDocument(out long documentId, out bool confidential)
        {
            documentId = 0;
            confidential = false;

            if (grid.SelectedRows.Count == 0)
                return false;

            DataGridViewRow row = grid.SelectedRows[0];
            documentId = Convert.ToInt64(row.Cells["EmployeeDocumentId"].Value);
            confidential = Convert.ToBoolean(row.Cells["IsConfidential"].Value);
            return true;
        }

        private void UpdateButtons()
        {
            bool selected = grid.SelectedRows.Count > 0;
            btnDownload.Enabled = selected;
            btnOpen.Enabled = selected;
            btnReplace.Enabled = selected;
            btnArchive.Enabled = selected;
            btnUpload.Enabled = cboEmployee.SelectedValue != null && !(cboEmployee.SelectedValue is DataRowView);
        }

        private static void ShowError(string title, Exception exception)
        {
            MessageBox.Show(exception.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
