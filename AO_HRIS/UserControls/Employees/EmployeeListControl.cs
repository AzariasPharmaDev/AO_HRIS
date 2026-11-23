using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using AO_HRIS.Data;
using AO_HRIS.Forms.Employees;
using AO_HRIS.Security;

namespace AO_HRIS.Employees.UserControls
{
    public partial class EmployeeListControl : UserControl
    {
        private bool loadingFilters;
        private int? loadedCompanyId;

        public EmployeeListControl()
        {
            InitializeComponent();
            btnAddEmployee.Click += btnAddEmployee_Click;
            txtSearch.KeyDown += txtSearch_KeyDown;
            dgvEmployees.CellDoubleClick += dgvEmployees_CellDoubleClick;
            cmbDepartment.SelectedIndexChanged += FilterChanged;
            cmbPosition.SelectedIndexChanged += FilterChanged;
            cmbStatus.SelectedIndexChanged += FilterChanged;
            Load += (s, e) => { if (!DesignMode) ReloadData(); };
        }

        private static void EnsureEmployeeListAccess(int companyId)
        {
            if (companyId <= 0)
                throw new UnauthorizedAccessException(
                    "No valid company is selected.");

            if (!PermissionService.HasPermissionForCompany(
                PermissionCodes.EmployeeRecords, companyId))
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to view employee records for this company.");
            }

            if (!PermissionService.HasPermissionForCompany(
                PermissionCodes.EmployeeAssignments, companyId))
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to view employee assignments for this company.");
            }
        }
        private static int SelectedId(ComboBox combo)
        {
            return combo.SelectedValue == null || combo.SelectedValue is DataRowView
                ? 0 : Convert.ToInt32(combo.SelectedValue);
        }

        private static string SelectedStatus(ComboBox combo)
        {
            return combo.SelectedValue == null || combo.SelectedValue is DataRowView
                ? "" : Convert.ToString(combo.SelectedValue);
        }

        private static void RestoreSelection(ComboBox combo, object value)
        {
            combo.SelectedValue = value;
            if (combo.SelectedIndex < 0 && combo.Items.Count > 0) combo.SelectedIndex = 0;
        }

        private void ReloadData()
        {
            if (!UserSession.CompanyId.HasValue)
            {
                dgvEmployees.DataSource = null;
                cmbDepartment.DataSource = null;
                cmbPosition.DataSource = null;
                cmbStatus.DataSource = null;
                loadedCompanyId = null;
                lblFooter.Text = "No company selected.";
                lblDepartmentCounts.Text = "";
                return;
            }
            if (LoadFilters()) LoadEmployees();
        }

        private bool LoadFilters()
        {
            int companyId = UserSession.CompanyId.Value;
            EnsureEmployeeListAccess(companyId);
            bool sameCompany = loadedCompanyId == companyId;
            int oldDepartment = sameCompany ? SelectedId(cmbDepartment) : 0;
            int oldPosition = sameCompany ? SelectedId(cmbPosition) : 0;
            string oldStatus = sameCompany ? SelectedStatus(cmbStatus) : "";

            // Indent child departments; preserve their actual DepartmentId for filtering.
            const string deptSql = @"
            ;WITH DepartmentTree AS
            (
                SELECT d.DepartmentId, d.DepartmentName, d.ParentDepartmentId,
                       CAST(d.DepartmentName AS nvarchar(2000)) AS DisplayName,
                       CAST(RIGHT('0000000000' + CAST(d.DepartmentId AS varchar(10)),10) AS varchar(4000)) AS SortPath,
                       CAST('/' + CAST(d.DepartmentId AS varchar(11)) + '/' AS varchar(4000)) AS Visited
                FROM dbo.Department d
                WHERE d.CompanyId=@CompanyId AND d.ParentDepartmentId IS NULL
                UNION ALL
                SELECT child.DepartmentId, child.DepartmentName, child.ParentDepartmentId,
                       CAST(REPLICATE(N'    ', CASE WHEN LEN(parent.Visited)-LEN(REPLACE(parent.Visited,'/','')) > 8 THEN 8
                                                 ELSE LEN(parent.Visited)-LEN(REPLACE(parent.Visited,'/','')) END)
                            + N'↳ ' + child.DepartmentName AS nvarchar(2000)),
                       CAST(parent.SortPath + '/' + RIGHT('0000000000' + CAST(child.DepartmentId AS varchar(10)),10) AS varchar(4000)),
                       CAST(parent.Visited + CAST(child.DepartmentId AS varchar(11)) + '/' AS varchar(4000))
                FROM dbo.Department child
                INNER JOIN DepartmentTree parent ON parent.DepartmentId=child.ParentDepartmentId
                WHERE child.CompanyId=@CompanyId
                  AND CHARINDEX('/' + CAST(child.DepartmentId AS varchar(11)) + '/',parent.Visited)=0
            )
            SELECT DepartmentId, DisplayName AS DepartmentName FROM
            (
                SELECT 0 AS DepartmentId, CAST(N'All Departments' AS nvarchar(2000)) AS DisplayName,
                       CAST('' AS varchar(4000)) AS SortPath
                UNION ALL
                SELECT DepartmentId, DisplayName, SortPath FROM DepartmentTree
            ) x ORDER BY SortPath OPTION (MAXRECURSION 100);";

                        const string positionSql = @"
            SELECT PositionId, PositionName FROM
            (SELECT 0 AS PositionId, CAST(N'All Positions' AS nvarchar(200)) AS PositionName
             UNION ALL SELECT p.PositionId, p.PositionName FROM dbo.Position p
             WHERE EXISTS(SELECT 1 FROM dbo.EmployeeAssignment ea
                          WHERE ea.CompanyId=@CompanyId AND ea.PositionId=p.PositionId)) x
            ORDER BY CASE WHEN PositionId=0 THEN 0 ELSE 1 END, PositionName;";

                        const string statusSql = @"
            SELECT StatusValue, StatusLabel FROM
            (SELECT CAST(N'' AS nvarchar(50)) AS StatusValue,
                    CAST(N'All Statuses' AS nvarchar(100)) AS StatusLabel
             UNION ALL SELECT DISTINCT ea.EmploymentStatus, CAST(ea.EmploymentStatus AS nvarchar(100))
             FROM dbo.EmployeeAssignment ea WHERE ea.CompanyId=@CompanyId) x
            ORDER BY CASE WHEN StatusValue=N'' THEN 0 ELSE 1 END, StatusLabel;";

            loadingFilters = true;
            try
            {
                DataTable departments = new DataTable(), positions = new DataTable(), statuses = new DataTable();
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    FillFilter(conn, deptSql, companyId, departments);
                    FillFilter(conn, positionSql, companyId, positions);
                    FillFilter(conn, statusSql, companyId, statuses);
                }
                cmbDepartment.DataSource = null;
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.ValueMember = "DepartmentId";
                cmbDepartment.DataSource = departments;
                RestoreSelection(cmbDepartment, oldDepartment);
                cmbPosition.DataSource = null;
                cmbPosition.DisplayMember = "PositionName";
                cmbPosition.ValueMember = "PositionId";
                cmbPosition.DataSource = positions;
                RestoreSelection(cmbPosition, oldPosition);
                cmbStatus.DataSource = null;
                cmbStatus.DisplayMember = "StatusLabel";
                cmbStatus.ValueMember = "StatusValue";
                cmbStatus.DataSource = statuses;
                RestoreSelection(cmbStatus, oldStatus);
                loadedCompanyId = companyId;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load filters:\n" + ex.Message, "Employee List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { loadingFilters = false; }
        }

        private static void FillFilter(SqlConnection conn, string sql, int companyId, DataTable table)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(table);
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            if (!loadingFilters && UserSession.CompanyId.HasValue) LoadEmployees();
        }

        private void LoadEmployees()
        {
            if (!UserSession.CompanyId.HasValue) return;
            // Recursive descendant selection supports Production and all its child departments.
            const string sql = @"
            ;WITH SelectedDepartments AS
            (
                SELECT d.DepartmentId,
                       CAST('/' + CAST(d.DepartmentId AS varchar(11)) + '/' AS varchar(4000)) AS Visited
                FROM dbo.Department d
                WHERE d.CompanyId=@CompanyId AND d.DepartmentId=@DepartmentId
                UNION ALL
                SELECT child.DepartmentId,
                       CAST(sd.Visited + CAST(child.DepartmentId AS varchar(11)) + '/' AS varchar(4000))
                FROM dbo.Department child
                JOIN SelectedDepartments sd ON child.ParentDepartmentId=sd.DepartmentId
                WHERE child.CompanyId=@CompanyId
                  AND CHARINDEX('/' + CAST(child.DepartmentId AS varchar(11)) + '/',sd.Visited)=0
            )
            SELECT ea.AssignmentId, er.EmployeeId, er.EmployeeNo,
                   LTRIM(RTRIM(CONCAT(er.FirstName, ' ', er.MiddleName, ' ', er.LastName))) AS EmployeeName,
                   COALESCE(parent.DepartmentName,d.DepartmentName,N'(Unassigned)') AS Department,
                   CASE WHEN parent.DepartmentId IS NOT NULL THEN d.DepartmentName ELSE N'' END AS Subdepartment,
                   COALESCE(p.PositionName,N'') AS Position,
                   ea.EmploymentStatus AS [Employment Status], ea.DateHired AS [Date Hired]
            FROM dbo.EmployeeAssignment ea
            JOIN dbo.EmployeeRecord er ON er.EmployeeId=ea.EmployeeId
            LEFT JOIN dbo.Department d ON d.DepartmentId=ea.DepartmentId AND d.CompanyId=ea.CompanyId
            LEFT JOIN dbo.Department parent ON parent.DepartmentId=d.ParentDepartmentId AND parent.CompanyId=ea.CompanyId
            LEFT JOIN dbo.Position p ON p.PositionId=ea.PositionId
            WHERE ea.CompanyId=@CompanyId
              AND (@DepartmentId=0 OR ea.DepartmentId IN (SELECT DepartmentId FROM SelectedDepartments))
              AND (@PositionId=0 OR ea.PositionId=@PositionId)
              AND (@Status=N'' OR ea.EmploymentStatus=@Status)
              AND (@Search=N'' OR er.EmployeeNo LIKE @Pattern OR er.FirstName LIKE @Pattern
                   OR er.MiddleName LIKE @Pattern OR er.LastName LIKE @Pattern
                   OR CONCAT(er.FirstName, ' ', er.MiddleName, ' ', er.LastName) LIKE @Pattern)
            ORDER BY er.LastName, er.FirstName, ea.AssignmentId
            OPTION (MAXRECURSION 100);";
            try
            {
                EnsureEmployeeListAccess(UserSession.CompanyId.Value);

                DataTable table = new DataTable();
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    string search = txtSearch.Text.Trim();
                    string pattern = "%" + search.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") + "%";
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                    cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = SelectedId(cmbDepartment);
                    cmd.Parameters.Add("@PositionId", SqlDbType.Int).Value = SelectedId(cmbPosition);
                    cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = SelectedStatus(cmbStatus);
                    cmd.Parameters.Add("@Search", SqlDbType.NVarChar, 200).Value = search;
                    cmd.Parameters.Add("@Pattern", SqlDbType.NVarChar, -1).Value = pattern;
                    conn.Open();
                    adapter.Fill(table);
                }
                dgvEmployees.DataSource = null;
                dgvEmployees.Columns.Clear();
                dgvEmployees.DataSource = table;
                dgvEmployees.Columns["EmployeeId"].Visible = false;
                dgvEmployees.Columns["AssignmentId"].Visible = false;
                dgvEmployees.Columns["EmployeeNo"].HeaderText = "Employee No.";
                dgvEmployees.Columns["EmployeeName"].HeaderText = "Employee Name";
                dgvEmployees.Columns["Date Hired"].DefaultCellStyle.Format = "MMM dd, yyyy";
                lblFooter.Text = table.Rows.Count + " assignment(s) found  |  Double-click to edit";
                LoadDepartmentCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load employees:\n" + ex.Message, "Employee List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartmentCounts()
        {
            // Group direct assignments under the top-level department, including subdepartments.
            const string sql = @"
            ;WITH DepartmentRoots AS
            (
                SELECT d.DepartmentId, d.DepartmentId AS RootId, d.DepartmentName AS RootName,
                       CAST('/' + CAST(d.DepartmentId AS varchar(11)) + '/' AS varchar(4000)) AS Visited
                FROM dbo.Department d
                WHERE d.CompanyId=@CompanyId AND d.ParentDepartmentId IS NULL
                UNION ALL
                SELECT child.DepartmentId, root.RootId, root.RootName,
                       CAST(root.Visited + CAST(child.DepartmentId AS varchar(11)) + '/' AS varchar(4000))
                FROM dbo.Department child
                JOIN DepartmentRoots root ON child.ParentDepartmentId=root.DepartmentId
                WHERE child.CompanyId=@CompanyId
                  AND CHARINDEX('/' + CAST(child.DepartmentId AS varchar(11)) + '/',root.Visited)=0
            )
            SELECT COALESCE(dr.RootName,N'(Unassigned)') AS DepartmentName,
                   COUNT(*) AS AssignmentCount
            FROM dbo.EmployeeAssignment ea
            LEFT JOIN DepartmentRoots dr ON dr.DepartmentId=ea.DepartmentId
            WHERE ea.CompanyId=@CompanyId
            GROUP BY dr.RootName
            ORDER BY DepartmentName
            OPTION (MAXRECURSION 100);";
            try
            {
                EnsureEmployeeListAccess(UserSession.CompanyId.Value);

                DataTable table = new DataTable();
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                    conn.Open(); adapter.Fill(table);
                }
                lblDepartmentCounts.Text = "Assignments by main department: " +
                    (table.Rows.Count == 0 ? "None" : string.Join("  |  ", table.AsEnumerable()
                    .Select(r => Convert.ToString(r["DepartmentName"]) + ": " + Convert.ToString(r["AssignmentCount"]))));
            }
            catch (Exception ex) { lblDepartmentCounts.Text = "Department counts unavailable: " + ex.Message; }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureEmployeeListAccess(UserSession.CompanyId ?? 0);

                // Keep the existing code below.
                EmployeeForm form = new EmployeeForm();
                form.FormClosed += (s, args) => ReloadData();   
                form.Show(this);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
            if (row.IsNewRow) return;
            int employeeId = Convert.ToInt32(row.Cells["EmployeeId"].Value);
            int assignmentId = Convert.ToInt32(row.Cells["AssignmentId"].Value);
            try
            {
                EnsureEmployeeListAccess(UserSession.CompanyId ?? 0);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (EmployeeForm form = new EmployeeForm(employeeId, assignmentId))
                if (form.ShowDialog(this) == DialogResult.OK) ReloadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e) { ReloadData(); }
        private void btnSearch_Click(object sender, EventArgs e) { LoadEmployees(); }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; LoadEmployees(); }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UserSession.CompanyId.HasValue ||
                    UserSession.CompanyId.Value <= 0)
                {
                    MessageBox.Show(
                        "No company is currently selected.",
                        "Export Employee List",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                EnsureEmployeeListAccess(UserSession.CompanyId.Value);
                if (dgvEmployees.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "There are no employee records to export.",
                        "Export Employee List",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                    dialog.Title = "Export Employee List";
                    dialog.FileName = "Employee_List_" +
                        DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;

                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Employee List");

                        DataTable exportTable =
                            ((DataTable)dgvEmployees.DataSource).Copy();

                        // Remove internal identifier columns.
                        exportTable.Columns.Remove("EmployeeId");
                        exportTable.Columns.Remove("AssignmentId");
                        worksheet.Cell(1, 1).InsertTable(exportTable, "EmployeeList", true);
                        var header = worksheet.Range(1, 1, 1, exportTable.Columns.Count);
                        header.Style.Font.Bold = true;
                        header.Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                        header.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromHtml("#236AD5");
                        header.Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                        worksheet.SheetView.FreezeRows(1);
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(dialog.FileName);
                    }
                }

                MessageBox.Show(
                    "Employee list exported successfully.",
                    "Export Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to export employee list.\n\n" + ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
