
using AO_HRIS.Forms.Employees;
using AO_HRIS.Security;
using ClosedXML.Excel;
using System;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.UserControls.Employees
{
    public partial class EmployeeDirectoryControl : UserControl
    {
        private readonly int _companyId;
        private readonly EmployeeDirectoryRepository _repository =
            new EmployeeDirectoryRepository();

        private DataTable _employees;

        public EmployeeDirectoryControl()
            : this(GetSelectedCompanyId())
        {
        }

        public EmployeeDirectoryControl(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentOutOfRangeException("companyId");

            _companyId = companyId;

            // Initialize all controls FIRST.
            InitializeComponent();

            ConfigureGrid();

            // Register events AFTER InitializeComponent.
            this.Load += EmployeeDirectoryControl_Load;

            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            txtSearch.KeyDown += txtSearch_KeyDown;

            gridEmployees.SelectionChanged +=
                gridEmployees_SelectionChanged;

            gridEmployees.CellDoubleClick +=
                gridEmployees_CellDoubleClick;
        }

        private static int GetSelectedCompanyId()
        {
            if (!UserSession.CompanyId.HasValue ||
                UserSession.CompanyId.Value <= 0)
            {
                throw new InvalidOperationException(
                    "Select a company before opening the Employee Directory.");
            }

            return UserSession.CompanyId.Value;
        }

        private void EmployeeDirectoryControl_Load(
            object sender, EventArgs e)
        {
            LoadDirectory();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDirectory();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDirectory();
        }

        private void txtSearch_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadDirectory();
            }
        }
        private void ConfigureGrid()
        {
            gridEmployees.AutoGenerateColumns = false;
            gridEmployees.Columns.Clear();

            AddColumn("EmployeeNo", "Employee No.", 105);
            AddColumn("EmployeeName", "Employee Name", 190);
            AddColumn("DepartmentName", "Department", 145);
            AddColumn("PositionName", "Position", 145);
            AddColumn("Email", "Email", 190);
            AddColumn("MobileNumber", "Mobile", 125);
            AddColumn("EmploymentStatus", "Status", 100);
        }

        private void AddColumn(
            string property, string header, int width)
        {
            var column = new DataGridViewTextBoxColumn();

            column.DataPropertyName = property;
            column.Name = property;
            column.HeaderText = header;
            column.Width = width;
            column.MinimumWidth = 80;

            gridEmployees.Columns.Add(column);
        }

        private void LoadDirectory()
        {
            try
            {
                _employees = _repository.GetDirectory(
                    _companyId, txtSearch.Text);

                gridEmployees.DataSource = _employees;

                lblCount.Text =
                    _employees.Rows.Count + " assignment(s) found";

                if (gridEmployees.Rows.Count > 0)
                {
                    gridEmployees.ClearSelection();

                    gridEmployees.CurrentCell =
                        gridEmployees.Rows[0].Cells[0];

                    gridEmployees.Rows[0].Selected = true;

                    ShowSelectedEmployee();
                }
                else
                {
                    ClearDetails();
                }
            }
            catch (Exception ex)
            {
                gridEmployees.DataSource = null;

                ClearDetails();

                lblCount.Text = "Unable to load directory";

                MessageBox.Show(
                    "Could not load Employee Directory:\n" + ex.Message,
                    "Directory Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void gridEmployees_SelectionChanged(
            object sender, EventArgs e)
        {
            ShowSelectedEmployee();
        }

        // DOUBLE-CLICK EMPLOYEE TO OPEN EMPLOYEE FORM
        private void gridEmployees_CellDoubleClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow selectedRow =
                gridEmployees.Rows[e.RowIndex];

            DataRowView rowView =
                selectedRow.DataBoundItem as DataRowView;

            if (rowView == null)
                return;

            int employeeId =
                Convert.ToInt32(rowView["EmployeeId"]);

            int assignmentId =
                Convert.ToInt32(rowView["AssignmentId"]);

            OpenEmployeeRecord(employeeId, assignmentId);
        }

        private void OpenEmployeeRecord(
            int employeeId, int assignmentId)
        {
            using (var form = new EmployeeForm(
                employeeId, assignmentId))
            {
                form.ShowDialog(this);
            }

            // Reload records after closing EmployeeForm.
            LoadDirectory();
        }

        private void ShowSelectedEmployee()
        {
            if (gridEmployees.CurrentRow == null)
            {
                ClearDetails();
                return;
            }

            DataRowView rowView =
                gridEmployees.CurrentRow.DataBoundItem as DataRowView;

            if (rowView == null)
            {
                ClearDetails();
                return;
            }

            DataRow row = rowView.Row;

            lblSelectedName.Text =
                Value(row, "EmployeeName");

            lblEmployeeNoValue.Text =
                Value(row, "EmployeeNo");

            lblEmailValue.Text =

                Value(row, "Email");

            lblMobileValue.Text =
                Value(row, "MobileNumber");

            lblTelephoneValue.Text =
                Value(row, "TelephoneNumber");

            lblAddressValue.Text =
                Value(row, "FullAddress");

            lblCompanyValue.Text =
                Value(row, "CompanyName");

            lblDepartmentValue.Text =
                Value(row, "DepartmentName");

            lblPositionValue.Text =
                Value(row, "PositionName");
                        lblHireDateValue.Text =
                row.IsNull("DateHired")
                    ? "—"
                    : Convert.ToDateTime(
                        row["DateHired"]).ToString("MMM dd, yyyy");
        }

        private static string Value(
            DataRow row, string column)
        {
            if (row.IsNull(column))
                return "—";

            string value =
                Convert.ToString(row[column]).Trim();

            return value.Length == 0 ? "—" : value;
        }

        private void ClearDetails()
        {
            lblSelectedName.Text = "Select an employee";
            lblEmployeeNoValue.Text = "—";
            lblEmailValue.Text = "—";
            lblMobileValue.Text = "—";
            lblTelephoneValue.Text = "—";
            lblAddressValue.Text = "—";
            lblCompanyValue.Text = "—";
            lblDepartmentValue.Text = "—";
            lblPositionValue.Text = "—";
            lblHireDateValue.Text = "—";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UserSession.CompanyId.HasValue || UserSession.CompanyId.Value <= 0)
                {
                    MessageBox.Show(
                        "No company is currently selected.",
                        "Export Directory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                int companyId = UserSession.CompanyId.Value;

                string search = txtSearch.Text.Trim();

                DataTable directory = _repository.GetDirectory(companyId, search);

                if (directory.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No employee records found to export.",
                        "Employee Directory",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                    dialog.Title = "Export Employee Directory";
                    dialog.FileName = "Employee_Directory_" +
                                      DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;

                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Employee Directory");

                        worksheet.Cell(1, 1).InsertTable(directory, "EmployeeDirectory");

                        var header = worksheet.Range(
                            1, 1, 1, directory.Columns.Count);

                        header.Style.Font.Bold = true;
                        header.Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                        header.Style.Fill.BackgroundColor =
                            ClosedXML.Excel.XLColor.FromHtml("#236AD5");

                        worksheet.SheetView.FreezeRows(1);
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(dialog.FileName);
                    }
                }

                MessageBox.Show(
                    "Employee directory exported successfully.",
                    "Export Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to export employee directory.\n\n" + ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
