using AO_HRIS.Data;
using AO_HRIS.Employees.UserControls;
using AO_HRIS.Forms.Organization;
using AO_HRIS.Forms.Leave;
using AO_HRIS.Forms.Documents;
using AO_HRIS.Forms.Policies;
using AO_HRIS.Forms.UserManagement;
using AO_HRIS.Security;
using AO_HRIS.Forms.Compensation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AO_HRIS.Forms.Scheduling;
using AO_HRIS.Forms.Attendance;
using AutoUpdaterDotNET;

namespace AO_HRIS.Forms.Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Shown += MainForm_Shown;
            picCompanyLogo.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            AutoUpdater.ReportErrors = false;

            AutoUpdater.SetOwner(this);

            AutoUpdater.Start(
                "https://YOUR-DOMAIN.com/updates/AO_HRIS.xml");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!UserSession.CompanyId.HasValue)
            {
                MessageBox.Show("No company selected.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            try
            {
                LoadCompanyInformation();
                LoadUserInformation();
                ApplyPermissions();
                if (btnDashboard.Visible)
                    LoadUserControl(new DashboardControl());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompanyInformation()
        {
            const string query = @"SELECT c.CompanyName, cl.LogoData
                FROM dbo.Company c
                LEFT JOIN dbo.CompanyLogo cl ON c.CompanyId = cl.CompanyId
                WHERE c.CompanyId = @CompanyId AND c.IsActive = 1";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblCompanyName.Text = reader["CompanyName"].ToString();
                        if (reader["LogoData"] != DBNull.Value)
                        {
                            byte[] logoData = (byte[])reader["LogoData"];
                            using (MemoryStream ms = new MemoryStream(logoData))
                            using (Image image = Image.FromStream(ms))
                            {
                                Image previous = picCompanyLogo.Image;
                                picCompanyLogo.Image = new Bitmap(image);
                                if (previous != null) previous.Dispose();
                            }
                        }
                    }
                }
            }
        }

        private void LoadUserInformation()
        {
            const string query = @"SELECT ua.Username, er.FirstName, er.LastName
            FROM dbo.UserAccount ua
            LEFT JOIN dbo.EmployeeRecord er ON ua.EmployeeId = er.EmployeeId
            WHERE ua.UserId = @UserId";
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblUsername.Text = reader["Username"].ToString();
                        string firstName = reader["FirstName"] == DBNull.Value ? "" : reader["FirstName"].ToString();
                        string lastName = reader["LastName"] == DBNull.Value ? "" : reader["LastName"].ToString();
                        string fullName = (firstName + " " + lastName).Trim();
                        lblEmployeeName.Text = fullName.Length == 0 ? "System Administrator" : fullName;
                        btnCurrentUser.Text = lblEmployeeName.Text;
                    }
                }
            }
        }

        private void ApplyPermissions()
        {
            HashSet<string> permissions = PermissionService.GetPermissions();

            btnDashboard.Visible =
                permissions.Contains(PermissionCodes.Dashboard);

            btnEmployees.Visible =
                permissions.Contains(PermissionCodes.EmployeeRecords);

            btnEmployeeDirectory.Visible =
                permissions.Contains(PermissionCodes.EmployeeRecords);

            btnEmployeeDocuments.Visible =
                permissions.Contains(PermissionCodes.EmployeeDocuments);

            btnPolicies.Visible =
                permissions.Contains(PermissionCodes.PolicyManagement) ||
                permissions.Contains(PermissionCodes.PolicyAcknowledgement);

            btnOrganization.Visible =
                permissions.Contains(PermissionCodes.Organization);

            btnOrgChart.Visible =
                permissions.Contains(PermissionCodes.OrgChart);

            btnScheduling.Visible =
                permissions.Contains(PermissionCodes.Schedules);

            btnAttendance.Visible =
                permissions.Contains(PermissionCodes.Attendance);

            btnLeaves.Visible =
                permissions.Contains(PermissionCodes.LeaveManagement);

            btnUserAccount.Visible =
                permissions.Contains(PermissionCodes.UserRoleManagement);

            btnRoles.Visible =
                permissions.Contains(PermissionCodes.UserRoleManagement);

            btnCompensation.Visible =
                permissions.Contains(PermissionCodes.CompensationView) ||
                permissions.Contains(PermissionCodes.CompensationManage);
        }

        private bool RequirePermission(string permission)
        {
            if (UserSession.CompanyId.HasValue && PermissionService.HasPermission(permission))
                return true;
            MessageBox.Show("Access denied.", "Permission Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void LoadUserControl(UserControl control)
        {
            pnlContent.SuspendLayout();
            try
            {
                while (pnlContent.Controls.Count > 0)
                {
                    Control existing = pnlContent.Controls[0];
                    pnlContent.Controls.RemoveAt(0);
                    existing.Dispose();
                }
                control.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(control);
                control.BringToFront();
            }
            finally { pnlContent.ResumeLayout(); }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (!RequirePermission(PermissionCodes.Dashboard))
                return;

            LoadUserControl(new DashboardControl());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.EmployeeRecords)) 
                LoadUserControl(new EmployeeListControl());
        }

        private void btnEmployeeDirectory_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.EmployeeRecords))
                LoadUserControl(new AO_HRIS.UserControls.Employees.EmployeeDirectoryControl());
        }
        private void btnEmployeeDocuments_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.EmployeeDocuments))
                LoadUserControl(new EmployeeDocumentManagementControl());
        }

        private void btnPolicies_Click(object sender, EventArgs e)
        {
            bool canManage = PermissionService.HasPermission(PermissionCodes.PolicyManagement);
            bool canAcknowledge = PermissionService.HasPermission(PermissionCodes.PolicyAcknowledgement);
            if (UserSession.CompanyId.HasValue && (canManage || canAcknowledge))
                LoadUserControl(new CompanyPolicyManagementControl());
            else
                MessageBox.Show("Access denied.", "Permission Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnOrganization_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.Organization)) LoadUserControl(new OrganizationManagementControl());
        }
        private void btnScheduling_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.Schedules))
                LoadUserControl(new SchedulingManagementControl());
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.Attendance))
                LoadUserControl(new AttendanceManagementControl());
        }
        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.UserRoleManagement))
                LoadUserControl(new UserAccountManagementControl());
        }
        private void pnlContent_Paint(object sender, PaintEventArgs e) { }
        private void btnClose_Click(object sender, EventArgs e) { Close(); }
        private void btnMinimize_Click(object sender, EventArgs e) { WindowState = FormWindowState.Minimized; }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private void drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 1;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int ResizeBorder = 8;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && m.Result == (IntPtr)HTCLIENT && WindowState == FormWindowState.Normal)
            {
                Point cursor = PointToClient(Cursor.Position);
                bool left = cursor.X <= ResizeBorder;
                bool right = cursor.X >= ClientSize.Width - ResizeBorder;
                bool top = cursor.Y <= ResizeBorder;
                bool bottom = cursor.Y >= ClientSize.Height - ResizeBorder;
                if (left && top) m.Result = (IntPtr)HTTOPLEFT;
                else if (right && top) m.Result = (IntPtr)HTTOPRIGHT;
                else if (left && bottom) m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (right && bottom) m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (left) m.Result = (IntPtr)HTLEFT;
                else if (right) m.Result = (IntPtr)HTRIGHT;
                else if (top) m.Result = (IntPtr)HTTOP;
                else if (bottom) m.Result = (IntPtr)HTBOTTOM;
            }
        }

        private void btnOrgChart_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.OrgChart))
                LoadUserControl(new OrganizationChartControl());
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.UserRoleManagement))
                LoadUserControl(new RoleManagementControl());
        }
        private void btnSample_Click(object sender, EventArgs e)
        {
            //just a random fuckass button
           /* if (!PermissionService.HasPermission(PermissionCodes.IncidentReports*//*PermissionCode*//*))
            {
                MessageBox.Show(
                    "Access Denied.",
                    "Authorization",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }*/
        }

        private void btnCompensation_Click(object sender, EventArgs e)
        {
            try
            {
                bool canView = PermissionService.HasPermission(
                    PermissionCodes.CompensationView);

                bool canManage = PermissionService.HasPermission(
                    PermissionCodes.CompensationManage);

                if (!UserSession.CompanyId.HasValue || (!canView && !canManage))
                {
                    MessageBox.Show(
                        "Access denied.",
                        "Permission Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                LoadUserControl(new CompensationManagementControl());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Compensation Management Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLeaveManagement_Click(object sender, EventArgs e)
        {
            if (RequirePermission(PermissionCodes.LeaveManagement))
                LoadUserControl(new LeaveManagementControl());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            // Clear the current user's session and selected company.
            UserSession.Clear();

            // Close MainForm so CompanySelectionForm can return to LoginForm.
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnLogout.PerformClick();
        }
    }
}
