
using AO_HRIS.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Compensation
{
    public partial class CompensationManagementControl : UserControl
    {
        private readonly CompensationRepository _repository =
            new CompensationRepository();

        private bool canManage;

        public CompensationManagementControl()
        {
            InitializeComponent();

            this.Load += CompensationManagementControl_Load;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            try
            {
                if (!UserSession.CompanyId.HasValue)
                    throw new InvalidOperationException(
                        "Select a company before opening Compensation Management.");

                canManage = PermissionService.HasPermissionForCompany(
                    PermissionCodes.CompensationManage,
                    UserSession.CompanyId.Value);

                btnRecordSalary.Visible = canManage;
                pnlEntry.Visible = canManage;

                ConfigureGrids();
                WireEvents();
                LoadAssignments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Compensation Management could not load.\r\n\r\n" + ex.Message,
                    "Compensation Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void WireEvents()
        {
            btnRefresh.Click += (s, e) => RunSafe(LoadAssignments);

            btnRecordSalary.Click += (s, e) =>
                RunSafe(RecordSalary);

            dgvEmployees.SelectionChanged += (s, e) =>
                RunSafe(LoadSelectedEmployee);

            txtSearch.TextChanged += (s, e) =>
                ApplyEmployeeFilter();
        }

        private void ConfigureGrids()
        {
            ConfigureGrid(dgvEmployees);
            ConfigureGrid(dgvHistory);
        }

        private static void ConfigureGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
        }

        private void RunSafe(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Compensation Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadAssignments()
        {
            dgvEmployees.DataSource = _repository.GetAssignments();

            HideColumn(dgvEmployees, "AssignmentId");
            HideColumn(dgvEmployees, "EmployeeId");
            HideColumn(dgvEmployees, "EffectiveFrom");
            HideColumn(dgvEmployees, "EffectiveTo");
            HideColumn(dgvEmployees, "IsPrimary");

            SetHeader(dgvEmployees, "EmployeeNo", "Employee No.");
            SetHeader(dgvEmployees, "EmployeeName", "Employee");
            SetHeader(dgvEmployees, "EmploymentStatus", "Status");

            if (dgvEmployees.Columns.Contains("EmployeeName"))
                dgvEmployees.Columns["EmployeeName"].FillWeight = 170;

            ApplyEmployeeFilter();

            if (dgvEmployees.Rows.Count > 0)
            {
                dgvEmployees.Rows[0].Selected = true;
                LoadSelectedEmployee();
            }
            else
            {
                ClearSelectedEmployee();
            }
        }

        private void ApplyEmployeeFilter()
        {
            if (!(dgvEmployees.DataSource is DataTable dt))
                return;

            string search = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(search))
            {
                dt.DefaultView.RowFilter = "";
            }
            else
            {
                dt.DefaultView.RowFilter =
                    string.Format(
                        "Convert(EmployeeNo, 'System.String') LIKE '%{0}%' OR " +
                        "EmployeeName LIKE '%{0}%'",
                        search);
            }
        }

        private void LoadSelectedEmployee()
        {
            if (dgvEmployees.CurrentRow == null ||
                !dgvEmployees.Columns.Contains("AssignmentId"))
            {
                ClearSelectedEmployee();
                return;
            }

            int assignmentId = Convert.ToInt32(
                dgvEmployees.CurrentRow.Cells["AssignmentId"].Value);

            string employeeNo = Convert.ToString(
                dgvEmployees.CurrentRow.Cells["EmployeeNo"].Value);

            string employeeName = Convert.ToString(
                dgvEmployees.CurrentRow.Cells["EmployeeName"].Value);

            lblSelectedEmployee.Text =
                employeeName + "  |  " + employeeNo;

            LoadCurrentCompensation(assignmentId);
            LoadHistory(assignmentId);
        }

        private void LoadCurrentCompensation(int assignmentId)
        {
            DataTable dt = _repository.GetCurrentCompensation(
                assignmentId,
                DateTime.Today);

            if (dt == null || dt.Rows.Count == 0)
            {
                lblCurrentSalary.Text = "No current salary recorded";
                lblCurrentCurrency.Text = "";
                lblCurrentEffective.Text = "";
                return;
            }

            DataRow row = dt.Rows[0];

            decimal salary = Convert.ToDecimal(row["BasicSalary"]);
            string currency = Convert.ToString(row["CurrencyCode"]);
            DateTime effectiveFrom = Convert.ToDateTime(row["EffectiveFrom"]);

            lblCurrentSalary.Text = salary.ToString("N2");
            lblCurrentCurrency.Text = currency;
            lblCurrentEffective.Text =
                "Effective since " + effectiveFrom.ToString("MMMM dd, yyyy");
        }

        private void LoadHistory(int assignmentId)
        {
            dgvHistory.DataSource =
                _repository.GetCompensationHistory(assignmentId);

            HideColumn(dgvHistory, "CompensationId");
            HideColumn(dgvHistory, "AssignmentId");
            HideColumn(dgvHistory, "CreatedByUserId");
            HideColumn(dgvHistory, "CreatedAt");

            SetHeader(dgvHistory, "BasicSalary", "Basic Salary");
            SetHeader(dgvHistory, "CurrencyCode", "Currency");
            SetHeader(dgvHistory, "EffectiveFrom", "Effective From");
            SetHeader(dgvHistory, "EffectiveTo", "Effective To");

            if (dgvHistory.Columns.Contains("BasicSalary"))
            {
                dgvHistory.Columns["BasicSalary"].DefaultCellStyle.Format = "N2";
                dgvHistory.Columns["BasicSalary"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvHistory.Columns.Contains("EffectiveFrom"))
                dgvHistory.Columns["EffectiveFrom"].DefaultCellStyle.Format = "MMM dd, yyyy";

            if (dgvHistory.Columns.Contains("EffectiveTo"))
                dgvHistory.Columns["EffectiveTo"].DefaultCellStyle.Format = "MMM dd, yyyy";

            if (dgvHistory.Columns.Contains("Remarks"))
                dgvHistory.Columns["Remarks"].FillWeight = 180;
        }

        private void RecordSalary()
        {
            if (!canManage)
                throw new UnauthorizedAccessException(
                    "You do not have permission to manage employee compensation.");

            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Select an employee first.");
                return;
            }

            int assignmentId = Convert.ToInt32(
                dgvEmployees.CurrentRow.Cells["AssignmentId"].Value);

            decimal salary = nudBasicSalary.Value;
            string currency = txtCurrency.Text.Trim().ToUpperInvariant();
            DateTime effectiveFrom = dtpEffectiveFrom.Value.Date;
            string remarks = txtRemarks.Text.Trim();

            if (salary < 0)
            {
                MessageBox.Show("Basic salary cannot be negative.");
                return;
            }

            if (currency.Length != 3)
            {
                MessageBox.Show(
                    "Enter a valid three-letter currency code, such as PHP.",
                    "Invalid Currency",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCurrency.Focus();
                return;
            }

            if (remarks.Length > 500)
            {
                MessageBox.Show("Remarks cannot exceed 500 characters.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Record a basic salary of " + currency + " " +
                salary.ToString("N2") + " effective " +
                effectiveFrom.ToString("MMMM dd, yyyy") + "?\r\n\r\n" +
                "The previous salary record will be closed when applicable.",
                "Confirm Salary Record",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            _repository.AddCompensation(
                assignmentId,
                salary,
                currency,
                effectiveFrom,
                remarks);

            LoadCurrentCompensation(assignmentId);
            LoadHistory(assignmentId);

            nudBasicSalary.Value = 0;
            txtCurrency.Text = "PHP";
            dtpEffectiveFrom.Value = DateTime.Today;
            txtRemarks.Clear();

            MessageBox.Show(
                "Employee compensation recorded successfully.",
                "Compensation Management",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ClearSelectedEmployee()
        {
            lblSelectedEmployee.Text = "No employee selected";
            lblCurrentSalary.Text = "—";
            lblCurrentCurrency.Text = "";
            lblCurrentEffective.Text = "";
            dgvHistory.DataSource = null;
        }

        private static void HideColumn(DataGridView grid, string name)
        {
            if (grid.Columns.Contains(name))
                grid.Columns[name].Visible = false;
        }

        private static void SetHeader(
            DataGridView grid,
            string columnName,
            string header)
        {
            if (grid.Columns.Contains(columnName))
                grid.Columns[columnName].HeaderText = header;
        }

        private void CompensationManagementControl_Load(object sender, EventArgs e)
        {
            ConfigureSplitContainer();
        }

        private void ConfigureSplitContainer()
        {
            int width = splitMain.ClientSize.Width;

            if (width <= 0)
                return;

            // Start with no restrictive minimum sizes.
            splitMain.Panel1MinSize = 0;
            splitMain.Panel2MinSize = 0;

            int panel1Minimum = 220;
            int panel2Minimum = 350;
            int splitterWidth = splitMain.SplitterWidth;

            // Use the preferred panel sizes when the available width permits.
            if (width >= panel1Minimum + panel2Minimum + splitterWidth)
            {
                int maximumDistance =
                    width - panel2Minimum - splitterWidth;

                int distance = Math.Min(390, maximumDistance);
                distance = Math.Max(panel1Minimum, distance);

                splitMain.SplitterDistance = distance;

                splitMain.Panel1MinSize = panel1Minimum;
                splitMain.Panel2MinSize = panel2Minimum;
            }
            else
            {
                // Smaller application windows: use flexible panel sizing.
                splitMain.SplitterDistance = Math.Max(
                    0,
                    Math.Min(width / 2, width - splitterWidth));
            }
        }
    }
}
