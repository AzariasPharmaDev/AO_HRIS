using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Scheduling
{
    public partial class EmployeeScheduleAssignmentControl : UserControl
    {
        private readonly EmployeeScheduleAssignmentRepository _repository =
            new EmployeeScheduleAssignmentRepository();

        private int CompanyId
        {
            get { return UserSession.CompanyId.Value; }
        }
        public EmployeeScheduleAssignmentControl()
        {
            InitializeComponent();
            ConfigureGrid();
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            if (!EnsureSchedulingAccess())
                return;
            try
            {
                DataTable table =
                    _repository.GetScheduleAssignments(CompanyId);

                dgvAssignments.DataSource = table;

                lblCount.Text = table.Rows.Count + " schedule assignment(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load employee schedule assignments.\n\n" +
                    ex.Message,
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            dgvAssignments.AutoGenerateColumns = true;
            dgvAssignments.ReadOnly = true;
            dgvAssignments.AllowUserToAddRows = false;
            dgvAssignments.AllowUserToDeleteRows = false;
            dgvAssignments.MultiSelect = false;
            dgvAssignments.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvAssignments.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssignments.RowHeadersVisible = false;
        }

        private int? GetSelectedScheduleAssignmentId()
        {
            if (dgvAssignments.CurrentRow == null)
                return null;

            object value =
                dgvAssignments.CurrentRow.Cells["ScheduleAssignmentId"].Value;

            if (value == null || value == DBNull.Value)
                return null;

            return Convert.ToInt32(value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!EnsureSchedulingAccess())
                return;
            using (EmployeeScheduleAssignmentDialog dialog =
                new EmployeeScheduleAssignmentDialog(CompanyId))
            {
                if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                    LoadAssignments();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!EnsureSchedulingAccess())
                return;
            int? id = GetSelectedScheduleAssignmentId();

            if (!id.HasValue)
            {
                MessageBox.Show(
                    "Select an employee schedule assignment first.",
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (EmployeeScheduleAssignmentDialog dialog =
                new EmployeeScheduleAssignmentDialog(CompanyId, id.Value))
            {
                if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                    LoadAssignments();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAssignments();
        }

        private void dgvAssignments_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit_Click(sender, EventArgs.Empty);
        }

        private bool EnsureSchedulingAccess()
        {
            if (!UserSession.CompanyId.HasValue ||
                UserSession.CompanyId.Value <= 0)
            {
                MessageBox.Show(
                    "No company is currently selected.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!PermissionService.HasPermissionForCompany(
                PermissionCodes.Schedules,
                UserSession.CompanyId.Value))
            {
                MessageBox.Show(
                    "You do not have permission to manage schedules for this company.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
    }
}