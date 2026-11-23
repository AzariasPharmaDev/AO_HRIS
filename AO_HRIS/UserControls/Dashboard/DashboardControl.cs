
using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
            Load += DashboardControl_Load;
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            if (!UserSession.CompanyId.HasValue)
            {
                SetUnavailable();
                lblDashboardCompany.Text = "No company selected";
                return;
            }

            if (!PermissionService.HasPermission(PermissionCodes.Dashboard) ||
                !PermissionService.HasAnyRole(
                    "SYSTEM_ADMIN", "HR_MANAGER", "HR_USER"))
            {
                SetUnavailable();
                lblDashboardCompany.Text = "Access denied";
                return;
            }

            int companyId = UserSession.CompanyId.Value;

            const string query = @"
                SELECT
                    (SELECT COUNT(DISTINCT ea.EmployeeId)
                     FROM dbo.EmployeeAssignment ea
                     INNER JOIN dbo.EmployeeRecord er
                        ON er.EmployeeId = ea.EmployeeId
                     WHERE ea.CompanyId = @CompanyId
                       AND er.IsActive = 1
                    ) AS TotalEmployees,

                    (SELECT COUNT(DISTINCT ea.EmployeeId)
                     FROM dbo.EmployeeAssignment ea
                     INNER JOIN dbo.EmployeeRecord er
                        ON er.EmployeeId = ea.EmployeeId
                     WHERE ea.CompanyId = @CompanyId
                       AND er.IsActive = 1
                       AND ea.EmploymentStatus = 'ACTIVE'
                       AND ea.EffectiveFrom <= CAST(GETDATE() AS DATE)
                       AND (
                           ea.EffectiveTo IS NULL
                           OR ea.EffectiveTo >= CAST(GETDATE() AS DATE)
                       )
                    ) AS ActiveEmployees,

                    (SELECT COUNT(DISTINCT ea.EmployeeId)
                     FROM dbo.EmployeeAssignment ea
                     INNER JOIN dbo.EmployeeRecord er
                        ON er.EmployeeId = ea.EmployeeId
                     WHERE ea.CompanyId = @CompanyId
                       AND er.IsActive = 1
                    )
                    -
                    (SELECT COUNT(DISTINCT ea.EmployeeId)
                     FROM dbo.EmployeeAssignment ea
                     INNER JOIN dbo.EmployeeRecord er
                        ON er.EmployeeId = ea.EmployeeId
                     WHERE ea.CompanyId = @CompanyId
                       AND er.IsActive = 1
                       AND ea.EmploymentStatus = 'ACTIVE'
                       AND ea.EffectiveFrom <= CAST(GETDATE() AS DATE)
                       AND (
                           ea.EffectiveTo IS NULL
                           OR ea.EffectiveTo >= CAST(GETDATE() AS DATE)
                       )
                    ) AS InactiveEmployees,

                    (SELECT COUNT(*)
                     FROM dbo.Department
                     WHERE CompanyId = @CompanyId
                    ) AS TotalDepartments,

                    (SELECT COUNT(*)
                     FROM dbo.AttendanceEvent
                     WHERE CompanyId = @CompanyId
                       AND IsVoided = 0
                       AND EventDateTime >= CAST(GETDATE() AS DATE)
                       AND EventDateTime < DATEADD(
                           DAY, 1, CAST(GETDATE() AS DATE))
                    ) AS AttendanceEventsToday,

                    (SELECT COUNT(*)
                     FROM dbo.LeaveRequest lr
                     INNER JOIN dbo.EmployeeAssignment ea
                        ON ea.AssignmentId = lr.AssignmentId
                     WHERE ea.CompanyId = @CompanyId
                       AND lr.Status = 'PENDING'
                    ) AS PendingLeaveRequests,

                    (SELECT COUNT(*)
                     FROM dbo.LeaveRequest lr
                     INNER JOIN dbo.EmployeeAssignment ea
                        ON ea.AssignmentId = lr.AssignmentId
                     WHERE ea.CompanyId = @CompanyId
                       AND lr.Status = 'APPROVED'
                    ) AS ApprovedLeaveRequests,

                    (SELECT CompanyName
                     FROM dbo.Company
                     WHERE CompanyId = @CompanyId
                       AND IsActive = 1
                    ) AS CompanyName;";

            try
            {
                btnRefresh.Enabled = false;

                using (SqlConnection con = DatabaseConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                        companyId;

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTotalEmployees.Text =
                                Convert.ToString(reader["TotalEmployees"]);

                            lblActiveEmployees.Text =
                                Convert.ToString(reader["ActiveEmployees"]);

                            lblInactiveEmployees.Text =
                                Convert.ToString(reader["InactiveEmployees"]);

                            lblTotalDepartments.Text =
                                Convert.ToString(reader["TotalDepartments"]);

                            lblAttendanceEvents.Text =
                                Convert.ToString(reader["AttendanceEventsToday"]);

                            lblPendingLeaves.Text =
                                Convert.ToString(reader["PendingLeaveRequests"]);

                            lblApprovedLeaves.Text =
                                Convert.ToString(reader["ApprovedLeaveRequests"]);

                            lblDashboardCompany.Text =
                                "Company: " +
                                Convert.ToString(reader["CompanyName"]);
                        }
                    }
                }

                LoadDepartmentDistribution(companyId);
            }
            catch (Exception ex)
            {
                SetUnavailable();

                lblDashboardCompany.Text =
                    "Unable to load company statistics";

                MessageBox.Show(
                    "Unable to load dashboard data.\n\n" + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRefresh.Enabled = true;
            }
        }

        private void LoadDepartmentDistribution(int companyId)
        {
            const string query = @"
                SELECT
                    d.DepartmentName,
                    COUNT(DISTINCT ea.EmployeeId) AS EmployeeCount
                FROM dbo.Department d
                LEFT JOIN dbo.EmployeeAssignment ea
                    ON ea.DepartmentId = d.DepartmentId
                    AND ea.CompanyId = d.CompanyId
                    AND ea.EmploymentStatus = 'ACTIVE'
                    AND ea.EffectiveFrom <= CAST(GETDATE() AS DATE)
                    AND (
                        ea.EffectiveTo IS NULL
                        OR ea.EffectiveTo >= CAST(GETDATE() AS DATE)
                    )
                LEFT JOIN dbo.EmployeeRecord er
                    ON er.EmployeeId = ea.EmployeeId
                    AND er.IsActive = 1
                WHERE d.CompanyId = @CompanyId
                GROUP BY d.DepartmentId, d.DepartmentName
                ORDER BY d.DepartmentName;";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    companyId;

                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvDepartmentDistribution.DataSource = table;

                if (dgvDepartmentDistribution.Columns.Contains("DepartmentName"))
                {
                    dgvDepartmentDistribution.Columns["DepartmentName"].HeaderText =
                        "Department";
                }

                if (dgvDepartmentDistribution.Columns.Contains("EmployeeCount"))
                {
                    dgvDepartmentDistribution.Columns["EmployeeCount"].HeaderText =
                        "Active Employees";
                }
            }
        }

        private void SetUnavailable()
        {
            lblTotalEmployees.Text = "—";
            lblActiveEmployees.Text = "—";
            lblInactiveEmployees.Text = "—";
            lblTotalDepartments.Text = "—";
            lblAttendanceEvents.Text = "—";
            lblPendingLeaves.Text = "—";
            lblApprovedLeaves.Text = "—";

            dgvDepartmentDistribution.DataSource = null;
        }
    }
}
