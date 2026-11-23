//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace AO_HRIS.UserControls.Security
//{
//    public partial class UserRoleManagementControl : UserControl
//    {
//        public UserRoleManagementControl()
//        {
//            InitializeComponent();
//        }
//    }
//}


using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.UserControls.Security
{
    public partial class UserRoleManagementControl : UserControl
    {
        private int? selectedUserId = null;

        public UserRoleManagementControl()
        {
            InitializeComponent();

            dgvUsers.ReadOnly = true;
            dgvUsers.MultiSelect = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AllowUserToAddRows = false;
            dgvUserRoles.ReadOnly = true;
            dgvUserRoles.MultiSelect = false;
            dgvUserRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUserRoles.AllowUserToAddRows = false;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            btnAssignRole.Enabled = false;
            btnRevokeRole.Enabled = false;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnRefresh.Click += btnRefresh_Click;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            dgvUserRoles.SelectionChanged += dgvUserRoles_SelectionChanged;
            btnAssignRole.Click += btnAssignRole_Click;
            btnRevokeRole.Click += btnRevokeRole_Click;
            Load += UserRoleManagementControl_Load;
        }

        private bool HasAccess()
        {
            return UserSession.CompanyId.HasValue &&
                PermissionService.HasPermission(
                    PermissionCodes.UserRoleManagement);
        }

        private void UserRoleManagementControl_Load(
            object sender, EventArgs e)
        {
            if (!HasAccess())
            {
                MessageBox.Show(
                    "You do not have permission to manage roles.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Enabled = false;
                return;
            }

            lblCompanyScope.Text = "Current Company";

            LoadRoles();
            LoadUsers();
        }

        private void LoadRoles()
        {
            string query = @"
                SELECT RoleId, RoleName
                FROM dbo.Role
                WHERE IsActive = 1
                ORDER BY RoleName";

            using (SqlConnection con =
                DatabaseConnection.GetConnection())
            using (SqlDataAdapter adapter =
                new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbRole.DataSource = dt;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleId";
                cmbRole.SelectedIndex = -1;
            }
        }

        private void LoadUsers()
        {
            selectedUserId = null;
            lblSelectedUser.Text = "No user selected";
            btnAssignRole.Enabled = false;
            btnRevokeRole.Enabled = false;
            dgvUserRoles.DataSource = null;

            string query = @"
                SELECT DISTINCT
                    ua.UserId,
                    ua.Username,
                    LTRIM(RTRIM(
                        ISNULL(er.FirstName, '') + ' ' +
                        ISNULL(er.LastName, '')
                    )) AS EmployeeName
                FROM dbo.UserAccount ua
                INNER JOIN dbo.EmployeeRecord er
                    ON ua.EmployeeId = er.EmployeeId
                INNER JOIN dbo.EmployeeAssignment ea
                    ON er.EmployeeId = ea.EmployeeId
                WHERE ea.CompanyId = @CompanyId
                    AND ua.IsActive = 1
                    AND er.IsActive = 1
                    AND ea.EmploymentStatus = 'ACTIVE'
                    AND ea.EffectiveFrom <=
                        CAST(GETDATE() AS DATE)
                    AND (
                        ea.EffectiveTo IS NULL
                        OR ea.EffectiveTo >=
                            CAST(GETDATE() AS DATE)
                    )
                    AND (
                        ua.Username LIKE @Search
                        OR er.FirstName LIKE @Search
                        OR er.LastName LIKE @Search
                    )
                ORDER BY ua.Username";

            using (SqlConnection con =
                DatabaseConnection.GetConnection())
            using (SqlCommand cmd =
                new SqlCommand(query, con))
            {
                cmd.Parameters.Add(
                    "@CompanyId", SqlDbType.Int
                ).Value = UserSession.CompanyId.Value;

                cmd.Parameters.Add(
                    "@Search", SqlDbType.NVarChar, 200
                ).Value = "%" + txtSearch.Text.Trim() + "%";

                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }

            dgvUsers.ClearSelection();
        }

        private void LoadUserRoles()
        {
            if (!selectedUserId.HasValue)
                return;

            string query = @"
                SELECT
                    ur.UserRoleId,
                    r.RoleName,
                    c.CompanyName,
                    ur.IsActive
                FROM dbo.UserRole ur
                INNER JOIN dbo.Role r
                    ON ur.RoleId = r.RoleId
                INNER JOIN dbo.Company c
                    ON ur.CompanyId = c.CompanyId
                WHERE ur.UserId = @UserId
                    AND ur.CompanyId = @CompanyId
                    AND ur.IsActive = 1
                ORDER BY r.RoleName";

            using (SqlConnection con =
                DatabaseConnection.GetConnection())
            using (SqlCommand cmd =
                new SqlCommand(query, con))
            {
                cmd.Parameters.Add(
                    "@UserId", SqlDbType.Int
                ).Value = selectedUserId.Value;

                cmd.Parameters.Add(
                    "@CompanyId", SqlDbType.Int
                ).Value = UserSession.CompanyId.Value;

                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUserRoles.DataSource = dt;
                }
            }

            dgvUserRoles.ClearSelection();
            btnRevokeRole.Enabled = false;
        }

        private void dgvUsers_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
                return;

            DataGridViewRow row =
                dgvUsers.SelectedRows[0];

            if (row.Cells["UserId"].Value == null)
                return;

            selectedUserId = Convert.ToInt32(
                row.Cells["UserId"].Value);

            lblSelectedUser.Text =
                row.Cells["EmployeeName"].Value.ToString()
                + " (" +
                row.Cells["Username"].Value.ToString()
                + ")";

            btnAssignRole.Enabled = true;

            LoadUserRoles();
        }

        private void dgvUserRoles_SelectionChanged(
            object sender, EventArgs e)
        {
            btnRevokeRole.Enabled =
                dgvUserRoles.SelectedRows.Count > 0;
        }

        private void txtSearch_TextChanged(
            object sender, EventArgs e)
        {
            if (HasAccess())
                LoadUsers();
        }

        private void btnRefresh_Click(
            object sender, EventArgs e)
        {
            if (!HasAccess())
                return;

            LoadRoles();
            LoadUsers();
        }

        private void btnAssignRole_Click(
            object sender, EventArgs e)
        {
            if (!HasAccess())
                return;

            if (!selectedUserId.HasValue ||
                cmbRole.SelectedValue == null ||
                cmbRole.SelectedValue is DataRowView)
            {
                MessageBox.Show(
                    "Select a user and a role.");
                return;
            }

            int userId = selectedUserId.Value;
            int roleId =
                Convert.ToInt32(cmbRole.SelectedValue);

            if (MessageBox.Show(
                "Assign this role to the selected user?",
                "Confirm Assignment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            using (SqlConnection con =
                DatabaseConnection.GetConnection())
            {
                con.Open();

                using (SqlTransaction transaction =
                    con.BeginTransaction(
                        IsolationLevel.Serializable))
                {
                    try
                    {
                        // Recheck the administrator's authority
                        // inside the transaction.
                        EnsureAdministrator(
                            con, transaction);

                        // Confirm target account belongs
                        // to the current company.
                        EnsureTargetUser(
                            con, transaction, userId);

                        // Reactivate an existing assignment
                        // or insert a new one.
                        string query = @"
                            IF EXISTS (
                                SELECT 1
                                FROM dbo.UserRole WITH
                                    (UPDLOCK, HOLDLOCK)
                                WHERE UserId = @UserId
                                  AND RoleId = @RoleId
                                  AND CompanyId = @CompanyId
                            )
                            BEGIN
                                UPDATE dbo.UserRole
                                SET IsActive = 1
                                WHERE UserId = @UserId
                                  AND RoleId = @RoleId
                                  AND CompanyId = @CompanyId
                            END
                            ELSE
                            BEGIN
                                INSERT INTO dbo.UserRole
                                    (UserId, RoleId,
                                     CompanyId, IsActive)
                                VALUES
                                    (@UserId, @RoleId,
                                     @CompanyId, 1)
                            END";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                query, con, transaction))
                        {
                            cmd.Parameters.Add(
                                "@UserId", SqlDbType.Int
                            ).Value = userId;

                            cmd.Parameters.Add(
                                "@RoleId", SqlDbType.Int
                            ).Value = roleId;

                            cmd.Parameters.Add(
                                "@CompanyId", SqlDbType.Int
                            ).Value =
                                UserSession.CompanyId.Value;

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show(
                            "Role assigned successfully.");

                        LoadUserRoles();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        MessageBox.Show(
                            ex.Message,
                            "Assignment Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRevokeRole_Click(
            object sender, EventArgs e)
        {
            if (!HasAccess() ||
                dgvUserRoles.SelectedRows.Count == 0 ||
                !selectedUserId.HasValue)
                return;

            int userRoleId = Convert.ToInt32(
                dgvUserRoles.SelectedRows[0]
                    .Cells["UserRoleId"].Value);

            if (selectedUserId.Value ==
                UserSession.UserId)
            {
                MessageBox.Show(
                    "You cannot revoke your own roles " +
                    "from this screen.");
                return;
            }

            if (MessageBox.Show(
                "Revoke the selected role?",
                "Confirm Revocation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)
                != DialogResult.Yes)
                return;

            using (SqlConnection con =
                DatabaseConnection.GetConnection())
            {
                con.Open();

                using (SqlTransaction transaction =
                    con.BeginTransaction(
                        IsolationLevel.Serializable))
                {
                    try
                    {
                        EnsureAdministrator(
                            con, transaction);

                        string query = @"
                            UPDATE dbo.UserRole
                            SET IsActive = 0
                            WHERE UserRoleId = @UserRoleId
                                AND UserId = @UserId
                                AND CompanyId = @CompanyId
                                AND IsActive = 1";

                        int affected;

                        using (SqlCommand cmd =
                            new SqlCommand(
                                query, con, transaction))
                        {
                            cmd.Parameters.Add(
                                "@UserRoleId", SqlDbType.Int
                            ).Value = userRoleId;

                            cmd.Parameters.Add(
                                "@UserId", SqlDbType.Int
                            ).Value = selectedUserId.Value;

                            cmd.Parameters.Add(
                                "@CompanyId", SqlDbType.Int
                            ).Value =
                                UserSession.CompanyId.Value;

                            affected = cmd.ExecuteNonQuery();
                        }

                        if (affected != 1)
                            throw new InvalidOperationException(
                                "The role assignment is no " +
                                "longer active.");

                        transaction.Commit();

                        MessageBox.Show(
                            "Role revoked successfully.");

                        LoadUserRoles();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        MessageBox.Show(
                            ex.Message,
                            "Revocation Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EnsureAdministrator(
            SqlConnection con,
            SqlTransaction transaction)
        {
            string query = @"
                SELECT COUNT(*)
                FROM dbo.UserRole ur
                INNER JOIN dbo.Role r
                    ON ur.RoleId = r.RoleId
                INNER JOIN dbo.UserAccount ua
                    ON ur.UserId = ua.UserId
                WHERE ur.UserId = @UserId
                    AND (
                        ur.CompanyId = @CompanyId
                        OR ur.CompanyId IS NULL
                    )
                    AND ur.IsActive = 1
                    AND r.IsActive = 1
                    AND ua.IsActive = 1
                    AND (
                        UPPER(REPLACE(REPLACE(
                            r.RoleCode, '_', ''), ' ', ''))
                            = 'SYSTEMADMIN'
                        OR
                        UPPER(REPLACE(REPLACE(
                            r.RoleName, '_', ''), ' ', ''))
                            = 'SYSTEMADMIN'
                    )";

            using (SqlCommand cmd =
                new SqlCommand(query, con, transaction))
            {
                cmd.Parameters.Add(
                    "@UserId", SqlDbType.Int
                ).Value = UserSession.UserId;

                cmd.Parameters.Add(
                    "@CompanyId", SqlDbType.Int
                ).Value = UserSession.CompanyId.Value;

                if (Convert.ToInt32(
                    cmd.ExecuteScalar()) == 0)
                {
                    throw new UnauthorizedAccessException(
                        "Administrator permission is required.");
                }
            }
        }

        private void EnsureTargetUser(
            SqlConnection con,
            SqlTransaction transaction,
            int userId)
        {
            string query = @"
                SELECT COUNT(*)
                FROM dbo.UserAccount ua
                INNER JOIN dbo.EmployeeRecord er
                    ON ua.EmployeeId = er.EmployeeId
                INNER JOIN dbo.EmployeeAssignment ea
                    ON er.EmployeeId = ea.EmployeeId
                INNER JOIN dbo.Company c
                    ON ea.CompanyId = c.CompanyId
                WHERE ua.UserId = @UserId
                    AND ea.CompanyId = @CompanyId
                    AND ua.IsActive = 1
                    AND er.IsActive = 1
                    AND c.IsActive = 1
                    AND ea.EmploymentStatus = 'ACTIVE'
                    AND ea.EffectiveFrom <=
                        CAST(GETDATE() AS DATE)
                    AND (
                        ea.EffectiveTo IS NULL
                        OR ea.EffectiveTo >=
                            CAST(GETDATE() AS DATE)
                    )";

            using (SqlCommand cmd =
                new SqlCommand(query, con, transaction))
            {
                cmd.Parameters.Add(
                    "@UserId", SqlDbType.Int
                ).Value = userId;

                cmd.Parameters.Add(
                    "@CompanyId", SqlDbType.Int
                ).Value = UserSession.CompanyId.Value;

                if (Convert.ToInt32(
                    cmd.ExecuteScalar()) == 0)
                {
                    throw new InvalidOperationException(
                        "This user has no active assignment " +
                        "in the selected company.");
                }
            }
        }
    }
}

