using AO_HRIS.Data;
using AO_HRIS.Forms.Employees;
using AO_HRIS.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Organization
{
    public partial class OrganizationChartControl : UserControl
    {
        private sealed class Assignment
        {
            public int Id;
            public int? ManagerId, DepartmentId, MainDepartmentId;
            public string Name, Number, Department, MainDepartment, Position;
        }
        private readonly OrganizationChartRepository repository = new OrganizationChartRepository();
        private readonly List<Assignment> assignments = new List<Assignment>();
        private readonly HashSet<int> collapsed = new HashSet<int>();
        private bool loading;

        public OrganizationChartControl()
        {
            InitializeComponent();
            Load += OrganizationChartControl_Load;
        }

        private void OrganizationChartControl_Load(object sender, EventArgs e)
        {
            if (!UserSession.CompanyId.HasValue ||
                !PermissionService.HasPermission(PermissionCodes.OrgChart))
            {
                Enabled = false;
                MessageBox.Show("Access denied.", "Organizational Chart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Reload();
        }

        private void Reload()
        {
            if (!UserSession.CompanyId.HasValue) return;
            try
            {
                loading = true;
                assignments.Clear();
                foreach (DataRow row in repository.GetAssignments(UserSession.CompanyId.Value).Rows)
                {
                    assignments.Add(new Assignment {
                        Id = Convert.ToInt32(row["AssignmentId"]),
                        ManagerId = row["ManagerAssignmentId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["ManagerAssignmentId"]),
                        DepartmentId = row["DepartmentId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["DepartmentId"]),
                        MainDepartmentId = row["MainDepartmentId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MainDepartmentId"]),
                        Name = Convert.ToString(row["EmployeeName"]), Number = Convert.ToString(row["EmployeeNo"]),
                        Department = Convert.ToString(row["DepartmentName"]),
                        MainDepartment = Convert.ToString(row["MainDepartmentName"]),
                        Position = Convert.ToString(row["PositionName"])
                    });
                }
                object old = cboDepartment.SelectedValue;
                DataTable departments = new DataTable();
                departments.Columns.Add("Id", typeof(int)); departments.Columns.Add("Name", typeof(string));
                departments.Rows.Add(0, "All departments");
                // The filter lists main departments, not each production unit.
                foreach (var item in assignments.Where(a => a.MainDepartmentId.HasValue)
                    .GroupBy(a => new { a.MainDepartmentId, a.MainDepartment })
                    .OrderBy(g => g.Key.MainDepartment))
                    departments.Rows.Add(item.Key.MainDepartmentId.Value, item.Key.MainDepartment);
                cboDepartment.DisplayMember = "Name"; cboDepartment.ValueMember = "Id";
                cboDepartment.DataSource = departments;
                if (old != null && old != DBNull.Value && departments.Select("Id=" + Convert.ToInt32(old)).Length > 0)
                    cboDepartment.SelectedValue = Convert.ToInt32(old);
                collapsed.RemoveWhere(id => !assignments.Any(a => a.Id == id));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Organizational Chart", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { loading = false; }
            BuildChart();
        }
        private void BuildChart()
        {
            if (loading) return;
            var byId = assignments.ToDictionary(a => a.Id);
            int department = 0;
            if (cboDepartment.SelectedValue != null) int.TryParse(Convert.ToString(cboDepartment.SelectedValue), out department);
            string search = txtSearch.Text.Trim();
            var visible = new HashSet<int>();
            foreach (Assignment a in assignments)
            {
                bool matches = (department == 0 || (a.MainDepartmentId ?? -1) == department) &&
                    (search.Length == 0 || a.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                     a.Number.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                     a.Position.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
                if (!matches) continue;
                Assignment current = a;
                var visited = new HashSet<int>();
                while (current != null && visited.Add(current.Id))
                {
                    visible.Add(current.Id);
                    Assignment parent;
                    current = current.ManagerId.HasValue && byId.TryGetValue(current.ManagerId.Value, out parent) ? parent : null;
                }
            }
            // Break invalid parent links and cycles rather than rendering an infinite graph.
            var cards = new List<ChartCanvas.Card>();
            foreach (Assignment a in assignments.Where(a => visible.Contains(a.Id)))
            {
                int? parentId = a.ManagerId;
                if (!parentId.HasValue || !visible.Contains(parentId.Value)) parentId = null;
                else
                {
                    var visited = new HashSet<int> { a.Id };
                    int? walk = parentId;
                    while (walk.HasValue && visited.Add(walk.Value))
                    {
                        Assignment p;
                        walk = byId.TryGetValue(walk.Value, out p) ? p.ManagerId : null;
                    }
                    if (walk.HasValue) parentId = null;
                }
                cards.Add(new ChartCanvas.Card { Id = a.Id, ParentId = parentId, Name = a.Name,
                    Position = a.Position,
                    Department = a.MainDepartment == a.Department ? a.Department : a.MainDepartment + " / " + a.Department,
                    Number = a.Number });
            }
            canvas.SetCards(cards, collapsed);
            lblCount.Text = cards.Count + " assignment(s)";
        }
        private void FilterChanged(object sender, EventArgs e) { BuildChart(); }
        private void btnRefresh_Click(object sender, EventArgs e) { Reload(); }
        private void btnZoomIn_Click(object sender, EventArgs e) { canvas.ZoomBy(1.2f); }
        private void btnZoomOut_Click(object sender, EventArgs e) { canvas.ZoomBy(1f / 1.2f); }
        private void btnFit_Click(object sender, EventArgs e) { canvas.Fit(); }
        private void btnExpand_Click(object sender, EventArgs e) { collapsed.Clear(); BuildChart(); }
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            collapsed.Clear();
            foreach (var a in assignments) if (assignments.Any(x => x.ManagerId == a.Id)) collapsed.Add(a.Id);
            BuildChart();
        }
        private void Canvas_CardSelected(int id)
        {
            Assignment a = assignments.FirstOrDefault(x => x.Id == id);
            if (a == null) return;

            selectedAssignmentId = id;

            lblDetails.Text = a.Name + "  |  " +
                              a.Position + "  |  " +
                              (a.MainDepartment == a.Department ? a.Department : a.MainDepartment + " / " + a.Department) +
                              "  |  Employee #: " + a.Number;

            btnViewEmployee.Enabled = true;
        }
        private int selectedAssignmentId = 0;

        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            if (selectedAssignmentId <= 0 || !UserSession.CompanyId.HasValue)
                return;

            if (!PermissionService.HasPermission(
                PermissionCodes.EmployeeRecords))
            {
                MessageBox.Show(
                    "You do not have permission to access employee records.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int employeeId = 0;

                using (SqlConnection connection = DatabaseConnection.GetConnection())
                using (SqlCommand command = new SqlCommand(
                @"SELECT EmployeeId FROM dbo.EmployeeAssignment
                WHERE AssignmentId = @AssignmentId
                AND CompanyId = @CompanyId", connection))
                {
                    command.Parameters.Add("@AssignmentId", SqlDbType.Int)
                        .Value = selectedAssignmentId;

                    command.Parameters.Add("@CompanyId", SqlDbType.Int)
                        .Value = UserSession.CompanyId.Value;

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        employeeId = Convert.ToInt32(result);
                }

                if (employeeId <= 0)
                {
                    MessageBox.Show(
                        "Employee record not found.",
                        "Organizational Chart",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                using (EmployeeForm form = new EmployeeForm(
                    employeeId, selectedAssignmentId))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open employee record:\n" + ex.Message,
                    "Organizational Chart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

