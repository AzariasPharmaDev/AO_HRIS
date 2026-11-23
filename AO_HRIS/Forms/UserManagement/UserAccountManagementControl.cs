using System;
using System.Data;
using System.Windows.Forms;
using AO_HRIS.Data;
using AO_HRIS.Security;

namespace AO_HRIS.Forms.UserManagement
{
    public partial class UserAccountManagementControl : UserControl
    {
        private readonly UserAccessRepository repository = new UserAccessRepository();
        private int? selectedUserId;
        private bool selectedActive, selectedLocked, loading;

        public UserAccountManagementControl()
        {
            InitializeComponent();
            Load += Control_Load;
            cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;
        }

        private bool Authorized()
        {
            return UserSession.CompanyId.HasValue &&
                PermissionService.HasPermissionForCompany(PermissionCodes.UserRoleManagement, UserSession.CompanyId.Value);
        }

        private int CompanyId { get { return UserSession.CompanyId.Value; } }

        private void Control_Load(object sender, EventArgs e)
        {
            if (!Authorized()) { Enabled = false; MessageBox.Show("Access denied."); return; }
            try
            {
                loading = true;
                cboEmployee.DisplayMember = "DisplayName";
                cboEmployee.ValueMember = "EmployeeId";
                cboEmployee.DataSource = repository.GetEmployees(CompanyId);
                cboRole.DisplayMember = "RoleName";
                cboRole.ValueMember = "RoleId";
                cboRole.DataSource = repository.GetRoles(CompanyId);
                loading = false;
                RefreshAccounts();
                ClearEditor();
            }
            catch (Exception ex) { loading = false; Error(ex); }
        }

        private void RefreshAccounts()
        {
            loading = true;
            try
            {
                dgvAccounts.DataSource = repository.GetAccounts(CompanyId, txtSearch.Text);
                if (dgvAccounts.Columns.Contains("UserId")) dgvAccounts.Columns["UserId"].Visible = false;
                if (dgvAccounts.Columns.Contains("EmployeeId")) dgvAccounts.Columns["EmployeeId"].Visible = false;
                dgvAccounts.ClearSelection();
                dgvAccounts.CurrentCell = null;
            }
            finally { loading = false; }
        }

        private void ClearEditor()
        {
            bool previousLoading = loading;
            loading = true;
            try
            {
                cboEmployee.SelectedIndex = -1;
                ClearAccountFields();
            }
            finally { loading = previousLoading; }
        }

        private void ClearAccountFields()
        {
            selectedUserId = null;
            txtUsername.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPassword.Enabled = true;
            btnSave.Enabled = true;
            txtUsername.Clear(); 
            txtEmail.Clear(); 
            txtPassword.Clear();
            cboRole.SelectedIndex = -1;
            dgvUserRoles.DataSource = null;
            lblSelection.Text = "New Account";
            selectedActive = true; 
            selectedLocked = false;
            btnAssignRole.Enabled = false; 
            btnRevokeRole.Enabled = false;
            btnResetPassword.Enabled = false; 
            btnToggleActive.Enabled = false; 
            btnToggleLock.Enabled = false;
            btnSave.Text = "Create Account";
        }

        private void LoadAccount(DataRow row)
        {
            selectedUserId = Convert.ToInt32(row["UserId"]);
            txtUsername.Text = Convert.ToString(row["Username"]);
            txtEmail.Text = row["Email"] == DBNull.Value ? "" : Convert.ToString(row["Email"]);
            txtPassword.Clear();
            selectedActive = Convert.ToBoolean(row["IsActive"]);
            selectedLocked = Convert.ToBoolean(row["IsLocked"]);
            lblSelection.Text = "Editing Account #" + selectedUserId.Value;
            btnSave.Text = "Save Details";
            bool canManageGlobal = repository.CanManageGlobalAccount(CompanyId);
            txtUsername.ReadOnly = !canManageGlobal;
            txtEmail.ReadOnly = !canManageGlobal;
            txtPassword.Enabled = canManageGlobal;
            btnSave.Enabled = canManageGlobal;
            btnSave.Text = canManageGlobal ? "Save Details" : "Managed by System Admin";
            btnAssignRole.Enabled = true;
            btnResetPassword.Enabled = canManageGlobal;
            btnToggleActive.Enabled = canManageGlobal;
            btnToggleLock.Enabled = canManageGlobal;
            btnToggleActive.Text = selectedActive ? "Deactivate" : "Activate";
            btnToggleLock.Text = selectedLocked ? "Unlock" : "Lock";
            RefreshRoles();
        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading || !Authorized() || !(cboEmployee.SelectedValue is int)) return;
            try
            {
                int employeeId = (int)cboEmployee.SelectedValue;
                DataTable accounts = repository.GetAccountByEmployee(employeeId, CompanyId);
                if (accounts.Rows.Count > 1)
                    throw new InvalidOperationException("Multiple accounts are linked to this employee. Resolve duplicates before editing.");
                bool previousLoading = loading;
                loading = true;
                try
                {
                    // Selection from the employee dropdown is independent of the account grid.
                    dgvAccounts.ClearSelection();
                    dgvAccounts.CurrentCell = null;
                    ClearAccountFields();
                    if (accounts.Rows.Count == 1) LoadAccount(accounts.Rows[0]);
                }
                finally { loading = previousLoading; }
            }
            catch (Exception ex) { Error(ex); }
        }

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            if (loading || dgvAccounts.CurrentRow == null) return;
            var row = dgvAccounts.CurrentRow.DataBoundItem as DataRowView;
            if (row == null) return;
            bool previousLoading = loading;
            loading = true;
            try
            {
                cboEmployee.SelectedValue = row["EmployeeId"];
                LoadAccount(row.Row);
            }
            catch (Exception ex) { Error(ex); }
            finally { loading = previousLoading; }
        }

        private void RefreshRoles()
        {
            dgvUserRoles.DataSource = selectedUserId.HasValue ? repository.GetUserRoles(selectedUserId.Value, CompanyId) : null;
            if (dgvUserRoles.Columns.Contains("UserRoleId")) dgvUserRoles.Columns["UserRoleId"].Visible = false;
            dgvUserRoles.ClearSelection();
            btnRevokeRole.Enabled = false;
        }

        private void dgvUserRoles_SelectionChanged(object sender, EventArgs e)
        {
            btnRevokeRole.Enabled = selectedUserId.HasValue && dgvUserRoles.SelectedRows.Count > 0;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvAccounts.ClearSelection(); dgvAccounts.CurrentCell = null; ClearEditor();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Authorized()) return;
            try
            {
                if (!(cboEmployee.SelectedValue is int)) throw new ArgumentException("Select an employee.");
                int id = repository.SaveAccount(selectedUserId, (int)cboEmployee.SelectedValue,
                    txtUsername.Text, txtEmail.Text, selectedUserId.HasValue ? null : txtPassword.Text, CompanyId);
                MessageBox.Show("Account #" + id + " saved. Select the account and assign its company role.");
                RefreshAccounts(); ClearEditor();
            }
            catch (Exception ex) { Error(ex); }
        }

        private void btnAssignRole_Click(object sender, EventArgs e)
        {
            if (!Authorized() || !selectedUserId.HasValue) return;
            if (!(cboRole.SelectedValue is int)) { MessageBox.Show("Select a role."); return; }
            try
            {
                repository.AssignRole(selectedUserId.Value, (int)cboRole.SelectedValue, CompanyId);
                RefreshRoles();
                MessageBox.Show("Role assigned.");
            }
            catch (Exception ex) { Error(ex); }
        }

        private void btnRevokeRole_Click(object sender, EventArgs e)
        {
            if (!Authorized() || !selectedUserId.HasValue || dgvUserRoles.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Revoke selected role?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                int id = Convert.ToInt32(dgvUserRoles.SelectedRows[0].Cells["UserRoleId"].Value);
                repository.RevokeRole(selectedUserId.Value, id, CompanyId);
                RefreshRoles(); MessageBox.Show("Role revoked.");
            }
            catch (Exception ex) { Error(ex); }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (!Authorized() || !selectedUserId.HasValue) return;
            if (MessageBox.Show("Reset this account's password?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                repository.ResetPassword(selectedUserId.Value, CompanyId, txtPassword.Text);
                txtPassword.Clear(); MessageBox.Show("Password reset.");
            }
            catch (Exception ex) { Error(ex); }
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (!Authorized() || !selectedUserId.HasValue) return;
            if (MessageBox.Show("Change account activation status?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try { repository.SetStatus(selectedUserId.Value, CompanyId, !selectedActive, null); RefreshAccounts(); ClearEditor(); }
            catch (Exception ex) { Error(ex); }
        }

        private void btnToggleLock_Click(object sender, EventArgs e)
        {
            if (!Authorized() || !selectedUserId.HasValue) return;
            if (MessageBox.Show("Change account lock status?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try { repository.SetStatus(selectedUserId.Value, CompanyId, null, !selectedLocked); RefreshAccounts(); ClearEditor(); }
            catch (Exception ex) { Error(ex); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!Authorized()) return;
            try { RefreshAccounts(); ClearEditor(); }
            catch (Exception ex) { Error(ex); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated || loading || !Authorized()) return;
            try { RefreshAccounts(); ClearEditor(); }
            catch (Exception ex) { Error(ex); }
        }

        private static void Error(Exception ex)
        {
            MessageBox.Show(ex.Message, "User & Access Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
