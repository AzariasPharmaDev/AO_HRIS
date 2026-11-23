using AO_HRIS.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Policies
{
    public partial class CompanyPolicyManagementControl : UserControl
    {
        private readonly CompanyPolicyRepository _repository = new CompanyPolicyRepository();
        private int _companyId;
        private bool _canManage;
        private bool _canAcknowledge;
        private bool _initializing;

        public CompanyPolicyManagementControl()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;
        }

        private void CompanyPolicyManagementControl_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            if (!UserSession.CompanyId.HasValue)
            {
                MessageBox.Show("No company is selected.", "Company Policies", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Enabled = false;
                return;
            }

            _companyId = UserSession.CompanyId.Value;
            try
            {
                _canManage = PermissionService.HasPermissionForCompany(PermissionCodes.PolicyManagement, _companyId);
                _canAcknowledge = PermissionService.HasPermissionForCompany(PermissionCodes.PolicyAcknowledgement, _companyId);

                if (!_canManage)
                {
                    tabMain.TabPages.Remove(tabPolicies);
                    tabMain.TabPages.Remove(tabCompliance);
                }
                if (!_canAcknowledge)
                    tabMain.TabPages.Remove(tabMyPolicies);

                if (tabMain.TabPages.Count == 0)
                {
                    MessageBox.Show("You do not have permission to access Company Policy Management.",
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Enabled = false;
                    return;
                }

                if (_canManage)
                {
                    LoadPolicies();
                    LoadComplianceFilter();
                }
                if (_canAcknowledge)
                    LoadMyPolicies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to initialize Company Policy Management:\n" + ex.Message,
                    "Policy Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            if (tabMain.SelectedTab == tabPolicies && _canManage) LoadPolicies();
            else if (tabMain.SelectedTab == tabMyPolicies && _canAcknowledge) LoadMyPolicies();
            else if (tabMain.SelectedTab == tabCompliance && _canManage) LoadCompliance();
        }

        private void LoadPolicies()
        {
            try
            {
                gridPolicies.DataSource = _repository.GetPolicies(_companyId, txtSearch.Text);
                HideColumn(gridPolicies, "PolicyId");
                HideColumn(gridPolicies, "PolicyRevisionId");
                HideColumn(gridPolicies, "PolicyDescription");
                HideColumn(gridPolicies, "CurrentPublishedRevisionId");
                SetHeader(gridPolicies, "PolicyCode", "Code");
                SetHeader(gridPolicies, "PolicyTitle", "Policy");
                SetHeader(gridPolicies, "CategoryName", "Category");
                SetHeader(gridPolicies, "RevisionLabel", "Latest Revision");
                SetHeader(gridPolicies, "EffectiveDate", "Effective Date");
                SetHeader(gridPolicies, "RevisionStatus", "Revision Status");
                SetHeader(gridPolicies, "AcknowledgedCount", "Acknowledged");
                SetHeader(gridPolicies, "PendingCount", "Pending");
                SetHeader(gridPolicies, "IsActive", "Active");
                if (gridPolicies.Columns.Contains("EffectiveDate"))
                    gridPolicies.Columns["EffectiveDate"].DefaultCellStyle.Format = "d";
                UpdatePolicyButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load policies:\n" + ex.Message,
                    "Policy Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyPolicies()
        {
            if (!UserSession.EmployeeId.HasValue)
            {
                gridMyPolicies.DataSource = null;
                btnAcknowledge.Enabled = false;
                btnDownloadMyPolicy.Enabled = false;
                MessageBox.Show("This user account is not linked to an employee record. Employee self-acknowledgement is unavailable.",
                    "Policy Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                gridMyPolicies.DataSource = _repository.GetMyPolicies(_companyId, UserSession.EmployeeId.Value);
                HideColumn(gridMyPolicies, "PolicyId");
                HideColumn(gridMyPolicies, "PolicyRevisionId");
                HideColumn(gridMyPolicies, "OriginalFileName");
                SetHeader(gridMyPolicies, "PolicyTitle", "Policy");
                SetHeader(gridMyPolicies, "CategoryName", "Category");
                SetHeader(gridMyPolicies, "RevisionLabel", "Revision");
                SetHeader(gridMyPolicies, "EffectiveDate", "Effective Date");
                SetHeader(gridMyPolicies, "AcknowledgementStatus", "Status");
                SetHeader(gridMyPolicies, "AcknowledgedAt", "Acknowledged At");
                if (gridMyPolicies.Columns.Contains("EffectiveDate"))
                    gridMyPolicies.Columns["EffectiveDate"].DefaultCellStyle.Format = "d";
                if (gridMyPolicies.Columns.Contains("AcknowledgedAt"))
                    gridMyPolicies.Columns["AcknowledgedAt"].DefaultCellStyle.Format = "g";
                UpdateMyPolicyButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load your policies:\n" + ex.Message,
                    "Policy Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComplianceFilter()
        {
            try
            {
                DataTable policies = _repository.GetPolicyFilters(_companyId);
                DataRow all = policies.NewRow();
                all["PolicyId"] = 0;
                all["PolicyTitle"] = "All active policies";
                policies.Rows.InsertAt(all, 0);
                _initializing = true;
                cboPolicyFilter.DisplayMember = "PolicyTitle";
                cboPolicyFilter.ValueMember = "PolicyId";
                cboPolicyFilter.DataSource = policies;
                cboPolicyFilter.SelectedValue = 0;
                _initializing = false;
                LoadCompliance();
            }
            catch (Exception ex)
            {
                _initializing = false;
                MessageBox.Show("Unable to load policy filters:\n" + ex.Message,
                    "Policy Compliance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompliance()
        {
            if (!_canManage) return;
            try
            {
                int? policyId = null;
                if (cboPolicyFilter.SelectedValue != null && cboPolicyFilter.SelectedValue != DBNull.Value)
                {
                    int selected = Convert.ToInt32(cboPolicyFilter.SelectedValue);
                    if (selected > 0) policyId = selected;
                }

                gridCompliance.DataSource = _repository.GetCompliance(_companyId, policyId);
                HideColumn(gridCompliance, "PolicyId");
                HideColumn(gridCompliance, "PolicyRevisionId");
                SetHeader(gridCompliance, "PolicyCode", "Code");
                SetHeader(gridCompliance, "PolicyTitle", "Policy");
                SetHeader(gridCompliance, "RevisionLabel", "Revision");
                SetHeader(gridCompliance, "EmployeeNo", "Employee No.");
                SetHeader(gridCompliance, "EmployeeName", "Employee");
                SetHeader(gridCompliance, "DepartmentName", "Department");
                SetHeader(gridCompliance, "AcknowledgementStatus", "Status");
                SetHeader(gridCompliance, "AcknowledgedAt", "Acknowledged At");
                if (gridCompliance.Columns.Contains("AcknowledgedAt"))
                    gridCompliance.Columns["AcknowledgedAt"].DefaultCellStyle.Format = "g";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load acknowledgement tracking:\n" + ex.Message,
                    "Policy Compliance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void HideColumn(DataGridView grid, string columnName)
        {
            if (grid.Columns.Contains(columnName)) grid.Columns[columnName].Visible = false;
        }

        private static void SetHeader(DataGridView grid, string columnName, string header)
        {
            if (grid.Columns.Contains(columnName)) grid.Columns[columnName].HeaderText = header;
        }

        private int? SelectedPolicyId()
        {
            if (gridPolicies.SelectedRows.Count == 0 || !gridPolicies.Columns.Contains("PolicyId")) return null;
            object value = gridPolicies.SelectedRows[0].Cells["PolicyId"].Value;
            return value == null || value == DBNull.Value ? (int?)null : Convert.ToInt32(value);
        }

        private int? SelectedPublishedRevisionId()
        {
            if (gridPolicies.SelectedRows.Count == 0 || !gridPolicies.Columns.Contains("CurrentPublishedRevisionId")) return null;
            object value = gridPolicies.SelectedRows[0].Cells["CurrentPublishedRevisionId"].Value;
            return value == null || value == DBNull.Value ? (int?)null : Convert.ToInt32(value);
        }

        private int? SelectedMyRevisionId()
        {
            if (gridMyPolicies.SelectedRows.Count == 0 || !gridMyPolicies.Columns.Contains("PolicyRevisionId")) return null;
            object value = gridMyPolicies.SelectedRows[0].Cells["PolicyRevisionId"].Value;
            return value == null || value == DBNull.Value ? (int?)null : Convert.ToInt32(value);
        }

        private string SelectedMyStatus()
        {
            if (gridMyPolicies.SelectedRows.Count == 0 || !gridMyPolicies.Columns.Contains("AcknowledgementStatus")) return string.Empty;
            return Convert.ToString(gridMyPolicies.SelectedRows[0].Cells["AcknowledgementStatus"].Value);
        }

        private void UpdatePolicyButtons()
        {
            bool hasPolicy = SelectedPolicyId().HasValue;
            bool isActive = hasPolicy && gridPolicies.SelectedRows.Count > 0 &&
                gridPolicies.Columns.Contains("IsActive") &&
                Convert.ToBoolean(gridPolicies.SelectedRows[0].Cells["IsActive"].Value);
            btnEditPolicy.Enabled = isActive;
            btnNewRevision.Enabled = isActive;
            btnArchive.Enabled = isActive;
            btnPublish.Enabled = isActive && gridPolicies.SelectedRows.Count > 0 &&
                gridPolicies.Columns.Contains("RevisionStatus") &&
                string.Equals(Convert.ToString(gridPolicies.SelectedRows[0].Cells["RevisionStatus"].Value), "Draft", StringComparison.OrdinalIgnoreCase);
            btnDownloadPolicy.Enabled = hasPolicy && SelectedPublishedRevisionId().HasValue;
        }

        private void UpdateMyPolicyButtons()
        {
            bool selected = SelectedMyRevisionId().HasValue;
            btnDownloadMyPolicy.Enabled = selected;
            btnAcknowledge.Enabled = selected && string.Equals(SelectedMyStatus(), "Pending", StringComparison.OrdinalIgnoreCase);
        }

        private void GridPolicies_SelectionChanged(object sender, EventArgs e) { UpdatePolicyButtons(); }
        private void GridMyPolicies_SelectionChanged(object sender, EventArgs e) { UpdateMyPolicyButtons(); }

        private void BtnSearch_Click(object sender, EventArgs e) { LoadPolicies(); }
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadPolicies();
            }
        }

        private void BtnNewPolicy_Click(object sender, EventArgs e)
        {
            OpenDraftDialog(null);
        }

        private void BtnEditPolicy_Click(object sender, EventArgs e)
        {
            int? policyId = SelectedPolicyId();
            if (!policyId.HasValue) return;
            try
            {
                using (PolicyDetailsDialog dialog = new PolicyDetailsDialog(_companyId, policyId.Value))
                {
                    if (dialog.ShowDialog(this) != DialogResult.OK) return;
                    _repository.UpdatePolicyDetails(_companyId, policyId.Value, dialog.PolicyCode,
                        dialog.PolicyTitle, dialog.CategoryId, dialog.Description);
                    LoadPolicies();
                    SelectPolicy(policyId.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update policy details:\n" + ex.Message,
                    "Company Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNewRevision_Click(object sender, EventArgs e)
        {
            int? policyId = SelectedPolicyId();
            if (policyId.HasValue) OpenDraftDialog(policyId.Value);
        }

        private void OpenDraftDialog(int? policyId)
        {
            try
            {
                using (PolicyRevisionDialog dialog = new PolicyRevisionDialog(_companyId, policyId))
                {
                    if (dialog.ShowDialog(this) != DialogResult.OK || dialog.Draft == null) return;
                    PolicyRevisionDraft draft = dialog.Draft;
                    int savedPolicyId = _repository.SaveDraft(_companyId, UserSession.UserId,
                        draft.PolicyId, draft.PolicyCode, draft.PolicyTitle, draft.CategoryId,
                        draft.Description, draft.RevisionLabel, draft.EffectiveDate,
                        draft.OriginalFileName, draft.FileData);
                    LoadPolicies();
                    SelectPolicy(savedPolicyId);
                    MessageBox.Show("Policy revision saved as a draft. Publish it when it is ready for employees.",
                        "Company Policies", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save the policy revision:\n" + ex.Message,
                    "Company Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectPolicy(int policyId)
        {
            foreach (DataGridViewRow row in gridPolicies.Rows)
            {
                if (Convert.ToInt32(row.Cells["PolicyId"].Value) == policyId)
                {
                    row.Selected = true;
                    if (row.Cells.Count > 0) gridPolicies.CurrentCell = row.Cells["PolicyCode"];
                    break;
                }
            }
            UpdatePolicyButtons();
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            int? policyId = SelectedPolicyId();
            if (!policyId.HasValue) return;
            if (MessageBox.Show("Publish the latest draft revision? Active employees in this subsidiary will receive an acknowledgement requirement.",
                "Publish Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _repository.PublishLatestDraft(_companyId, UserSession.UserId, policyId.Value);
                LoadPolicies();
                LoadComplianceFilter();
                SelectPolicy(policyId.Value);
                MessageBox.Show("Policy published and acknowledgement requirements generated.",
                    "Company Policies", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to publish policy:\n" + ex.Message,
                    "Company Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnArchive_Click(object sender, EventArgs e)
        {
            int? policyId = SelectedPolicyId();
            if (!policyId.HasValue) return;
            if (MessageBox.Show("Archive this policy? Existing acknowledgement history will be retained.",
                "Archive Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _repository.ArchivePolicy(_companyId, policyId.Value);
                LoadPolicies();
                LoadComplianceFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to archive policy:\n" + ex.Message,
                    "Company Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDownloadPolicy_Click(object sender, EventArgs e)
        {
            int? revisionId = SelectedPublishedRevisionId();
            if (revisionId.HasValue) DownloadRevision(revisionId.Value);
        }

        private void BtnDownloadMyPolicy_Click(object sender, EventArgs e)
        {
            int? revisionId = SelectedMyRevisionId();
            if (revisionId.HasValue) DownloadRevision(revisionId.Value);
        }

        private void DownloadRevision(int revisionId)
        {
            try
            {
                PolicyFile file = _repository.GetRevisionFile(_companyId, revisionId);
                saveFileDialogPolicy.FileName = file.FileName;
                if (saveFileDialogPolicy.ShowDialog(this) != DialogResult.OK) return;
                System.IO.File.WriteAllBytes(saveFileDialogPolicy.FileName, file.Data);
                MessageBox.Show("Policy PDF downloaded successfully.", "Company Policies",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to download the policy document:\n" + ex.Message,
                    "Company Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAcknowledge_Click(object sender, EventArgs e)
        {
            int? revisionId = SelectedMyRevisionId();
            if (!revisionId.HasValue || !UserSession.EmployeeId.HasValue) return;
            if (MessageBox.Show("Confirm that you have read and understood this policy revision? This acknowledgement will be recorded with your account and timestamp.",
                "Acknowledge Policy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _repository.AcknowledgePolicy(_companyId, UserSession.EmployeeId.Value,
                    revisionId.Value, UserSession.UserId);
                LoadMyPolicies();
                MessageBox.Show("Your acknowledgement has been recorded.", "Policy Acknowledgement",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to record acknowledgement:\n" + ex.Message,
                    "Policy Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefreshMyPolicies_Click(object sender, EventArgs e) { LoadMyPolicies(); }
        private void BtnRefreshCompliance_Click(object sender, EventArgs e) { LoadCompliance(); }
    }
}
