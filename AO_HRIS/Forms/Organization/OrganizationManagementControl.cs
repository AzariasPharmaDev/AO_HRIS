using System;
using System.Data;
using System.Windows.Forms;
using AO_HRIS.Security;

namespace AO_HRIS.Forms.Organization
{
    public partial class OrganizationManagementControl : UserControl
    {
        private readonly OrganizationRepository _repository = new OrganizationRepository();
        private bool _loading;

        public OrganizationManagementControl()
        {
            InitializeComponent();
            ConfigureGrids();
            foreach (DataGridView grid in new[] { dgvCompanies, dgvCompanyLogos, dgvDepartments, dgvPositions })
                grid.SelectionChanged += Grid_SelectionChanged;
            Load += OrganizationManagementControl_Load;
            UpdateToolbar();
        }

        private void OrganizationManagementControl_Load(object sender, EventArgs e)
        {
            if (!CanManageOrganization())
            {
                Enabled = false;
                MessageBox.Show("You do not have access to Organization Management.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RefreshCurrent();
        }

        private DataGridView CurrentGrid()
        {
            switch (tabManagement.SelectedIndex)
            {
                case 0: return dgvCompanies;
                case 1: return dgvCompanyLogos;
                case 2: return dgvDepartments;
                case 3: return dgvPositions;
                default: return null;
            }
        }

        private static void ConfigureGrid(DataGridView grid)
        {
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoGenerateColumns = true;
        }

        private void ConfigureGrids()
        {
            ConfigureGrid(dgvCompanies);
            ConfigureGrid(dgvCompanyLogos);
            ConfigureGrid(dgvDepartments);
            ConfigureGrid(dgvPositions);
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (!_loading && ReferenceEquals(sender, CurrentGrid())) UpdateToolbar();
        }

        private bool HasSelection()
        {
            DataGridView grid = CurrentGrid();
            return grid != null && grid.SelectedRows.Count > 0 &&
                !grid.SelectedRows[0].IsNewRow;
        }

        private int? SelectedId(string column)
        {
            DataGridView grid = CurrentGrid();
            if (!HasSelection() || !grid.Columns.Contains(column)) return null;
            object value = grid.SelectedRows[0].Cells[column].Value;
            return value == null || value == DBNull.Value ? (int?)null : Convert.ToInt32(value);
        }
        private void UpdateToolbar()
        {
            bool logo = tabManagement.SelectedIndex == 1;
            bool allowed = CanManageOrganization();
            btnAdd.Text = logo ? "Add Logo" : "Add New";
            btnEdit.Text = logo ? "Edit Logo" : "Edit";
            btnDelete.Text = logo ? "Remove Logo" : "Deactivate";
            btnAdd.Enabled = allowed;
            btnEdit.Enabled = allowed && HasSelection();
            btnDelete.Enabled = allowed && HasSelection();
        }

        private void RefreshCurrent()
        {
            if (_loading) return;
            try
            {
                _loading = true;
                switch (tabManagement.SelectedIndex)
                {
                    case 0: LoadCompanies(); break;
                    case 1: LoadCompanyLogos(); break;
                    case 2: LoadDepartments(); break;
                    case 3: LoadPositions(); break;
                }
                ApplySearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Organization Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _loading = false;
                UpdateToolbar();
            }
        }

        private static void HideColumns(DataGridView grid, params string[] names)
        {
            foreach (string name in names)
                if (grid.Columns.Contains(name)) grid.Columns[name].Visible = false;
        }

        private static void FinishGrid(DataGridView grid)
        {
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Name == "IsActive")
                    col.HeaderText = "Active";

                if (col.Name == "EmployeeCount")
                {
                    col.HeaderText = "Employees";
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                    col.DefaultCellStyle.Format = "N0";
                    col.Width = 95;
                    col.MinimumWidth = 85;
                    col.ReadOnly = true;
                }

                if (col.Name == "FileSize")
                    col.HeaderText = "Size (bytes)";

                if (col.ValueType == typeof(DateTime))
                    col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }

            grid.ClearSelection();
            grid.CurrentCell = null;
        }
        private void LoadCompanies()
        {
            dgvCompanies.DataSource = _repository.GetCompanies();
            HideColumns(dgvCompanies, "CompanyId");
            FinishGrid(dgvCompanies);
        }

        private void LoadCompanyLogos()
        {
            dgvCompanyLogos.DataSource = _repository.GetCompanyLogos();
            HideColumns(dgvCompanyLogos, "CompanyLogoId", "CompanyId", "LogoData");
            FinishGrid(dgvCompanyLogos);
        }

        private void LoadDepartments()
        {
            dgvDepartments.DataSource = _repository.GetDepartments();
            HideColumns(dgvDepartments, "DepartmentId", "CompanyId", "ParentDepartmentId");
            FinishGrid(dgvDepartments);
        }

        private void LoadPositions()
        {
            dgvPositions.DataSource = _repository.GetPositions();
            HideColumns(dgvPositions, "PositionId", "DepartmentId", "CompanyId");
            FinishGrid(dgvPositions);
        }

        private void ApplySearch()
        {
            DataGridView grid = CurrentGrid();
            DataTable table = grid == null ? null : grid.DataSource as DataTable;
            if (table == null) return;
            string search = txtSearch.Text.Trim();
            if (search.Length == 0) { table.DefaultView.RowFilter = ""; return; }
            search = search.Replace("'", "''").Replace("[", "[[]")
                .Replace("]", "[]]").Replace("%", "[%]").Replace("*", "[*]");
            string[] columns;
            switch (tabManagement.SelectedIndex)
            {
                case 0: columns = new[] { "CompanyCode", "CompanyName" }; break;
                case 1: columns = new[] { "CompanyCode", "CompanyName", "FileName" }; break;
                case 2: columns = new[] { "DepartmentCode", "DepartmentName", "CompanyName" }; break;
                case 3: columns = new[] { "PositionCode", "PositionName", "DepartmentName", "CompanyName" }; break;
                default: return;
            }
            var filters = new System.Collections.Generic.List<string>();
            foreach (string column in columns)
                if (table.Columns.Contains(column)) filters.Add("[" + column + "] LIKE '%" + search + "%' ");
            table.DefaultView.RowFilter = string.Join(" OR ", filters.ToArray());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try { ApplySearch(); UpdateToolbar(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Search", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void tabManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshCurrent();
        }

        private void btnRefresh_Click(object sender, EventArgs e) { RefreshCurrent(); }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CanManageOrganization()) return;
            switch (tabManagement.SelectedIndex)
            {
                case 0:
                    using (var form = new CompanyForm())
                        if (form.ShowDialog(this) == DialogResult.OK) RefreshCurrent();
                    break;
                case 1:
                    using (var form = new CompanyLogoManagementForm()) form.ShowDialog(this);
                    RefreshCurrent();
                    break;
                case 2:
                    using (var form = new DepartmentForm())
                        if (form.ShowDialog(this) == DialogResult.OK) RefreshCurrent();
                    break;
                case 3:
                    using (var form = new PositionForm())
                        if (form.ShowDialog(this) == DialogResult.OK) RefreshCurrent();
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!CanManageOrganization()) return;
            string key = tabManagement.SelectedIndex == 0 || tabManagement.SelectedIndex == 1
                ? "CompanyId" : tabManagement.SelectedIndex == 2 ? "DepartmentId" : "PositionId";
            int? id = SelectedId(key);
            if (!id.HasValue) { MessageBox.Show("Please select a record first."); return; }
            switch (tabManagement.SelectedIndex)
            {
                case 0:
                    using (var form = new CompanyForm(id.Value))
                        if (form.ShowDialog(this) == DialogResult.OK) RefreshCurrent();
                    break;
                case 1:
                    using (var form = new CompanyLogoManagementForm(id.Value)) form.ShowDialog(this);
                    RefreshCurrent();
                    break;
                case 2:
                    using (var form = new DepartmentForm(id.Value))
                        if (form.ShowDialog(this) == DialogResult.OK) RefreshCurrent();
                    break;
                case 3:
                    using (var form = new PositionForm(id.Value))
                        if (form.ShowDialog(this) == DialogResult.OK) RefreshCurrent();
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CanManageOrganization()) return;
            int tab = tabManagement.SelectedIndex;
            string key = tab <= 1 ? "CompanyId" : tab == 2 ? "DepartmentId" : "PositionId";
            int? id = SelectedId(key);
            if (!id.HasValue) { MessageBox.Show("Please select a record first."); return; }
            string entity = tab == 0 ? "company" : tab == 1 ? "company logo" : tab == 2 ? "department" : "position";
            string prompt = tab == 1 ? "Remove this company logo?" :
                "Deactivate this " + entity + "?\n\nExisting employee records will not be deleted.";
            if (MessageBox.Show(prompt, "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                switch (tab)
                {
                    case 0: _repository.DeactivateCompany(id.Value); break;
                    case 1: _repository.DeleteCompanyLogo(id.Value); break;
                    case 2: _repository.DeactivateDepartment(id.Value); break;
                    case 3: _repository.DeactivatePosition(id.Value); break;
                }
                RefreshCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Organization Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CanManageOrganization()
        {
            return UserSession.CompanyId.HasValue &&
                UserSession.CompanyId.Value > 0 &&
                PermissionService.HasPermissionForCompany(
                    PermissionCodes.Organization,
                    UserSession.CompanyId.Value);
        }
    }
}
