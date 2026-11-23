using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AO_HRIS.Forms.UserManagement
{
    public partial class RoleManagementControl : UserControl
    {
        private readonly RoleManagementRepository repository = new RoleManagementRepository();
        private int? selectedRoleId;
        private bool loading;

        private readonly string[] permissionCodes =
        {
            PermissionCodes.Dashboard,
            PermissionCodes.Organization,
            PermissionCodes.OrgChart,
            PermissionCodes.EmployeeRecords,
            PermissionCodes.EmployeeDocuments,
            PermissionCodes.EmployeeDocumentsConfidential,
            PermissionCodes.PolicyManagement,
            PermissionCodes.PolicyAcknowledgement,
            PermissionCodes.EmployeeAssignments,
            PermissionCodes.Schedules,
            PermissionCodes.LeaveManagement,
            PermissionCodes.Payroll,
            PermissionCodes.UserRoleManagement,
            PermissionCodes.CompensationManage,
            PermissionCodes.CompensationView
        };

        public RoleManagementControl()
        {
            InitializeComponent();
            permissionList.Items.AddRange(permissionCodes.Cast<object>().ToArray());
        }

        private void RoleManagementControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (CanManage()) Reload();
            else DisableEditing();
        }

        private bool CanManage()
        {
            try
            {
                return PermissionService.HasPermission(PermissionCodes.UserRoleManagement);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Permission check failed: " + ex.Message,
                    "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void DisableEditing()
        {
            grid.Enabled = false;
            txtCode.Enabled = false;
            txtName.Enabled = false;
            chkActive.Enabled = false;
            permissionList.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = false;
            MessageBox.Show("You do not have permission to manage roles.",
                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Reload()
        {
            loading = true;
            try
            {
                grid.DataSource = repository.GetRoles();
                if (grid.Columns.Contains("RoleId"))
                    grid.Columns["RoleId"].Visible = false;
                ClearEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load roles:\n" + ex.Message,
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { loading = false; }
        }

        private void ClearEditor()
        {
            loading = true;
            try
            {
                selectedRoleId = null;
                txtCode.Clear();
                txtName.Clear();
                chkActive.Checked = true;
                for (int i = 0; i < permissionList.Items.Count; i++)
                    permissionList.SetItemChecked(i, false);
                grid.ClearSelection();
            }
            finally { loading = false; }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (loading || grid.SelectedRows.Count == 0) return;
            DataGridViewRow row = grid.SelectedRows[0];
            if (!grid.Columns.Contains("RoleId") || row.Cells["RoleId"].Value == null ||
                row.Cells["RoleId"].Value == DBNull.Value) return;

            loading = true;
            try
            {
                selectedRoleId = Convert.ToInt32(row.Cells["RoleId"].Value);
                txtCode.Text = Convert.ToString(row.Cells["RoleCode"].Value);
                txtName.Text = Convert.ToString(row.Cells["RoleName"].Value);
                chkActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);

                var permissions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (DataRow p in repository.GetRolePermissions(selectedRoleId.Value).Rows)
                    permissions.Add(Convert.ToString(p["PermissionCode"]));
                for (int i = 0; i < permissionList.Items.Count; i++)
                    permissionList.SetItemChecked(i,
                        permissions.Contains(permissionList.Items[i].ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load role permissions:\n" + ex.Message,
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { loading = false; }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearEditor();
            txtCode.Focus();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!CanManage())
            {
                DisableEditing();
                return;
            }

            string[] selected = permissionList.CheckedItems.Cast<object>()
                .Select(x => x.ToString()).ToArray();
            try
            {
                btnSave.Enabled = false;
                repository.SaveRole(selectedRoleId, txtCode.Text, txtName.Text,
                    chkActive.Checked, selected);
                MessageBox.Show("Role saved successfully.", "Role Management",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save role:\n" + ex.Message,
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { btnSave.Enabled = true; }
        }
    }
}