using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Scheduling
{
    public partial class SchedulingManagementControl : UserControl
    {
        private readonly WorkShiftRepository _repository =
            new WorkShiftRepository();

        private int CompanyId
        {
            get { return UserSession.CompanyId.Value; }
        }

        public SchedulingManagementControl()
        {
            InitializeComponent();
            WorkScheduleManagementControl scheduleControl = new WorkScheduleManagementControl();
            EmployeeScheduleAssignmentControl assignmentControl = new EmployeeScheduleAssignmentControl();

            assignmentControl.Dock = DockStyle.Fill;
            tabEmployeeScheduleAssignments.Controls.Add(assignmentControl);
            scheduleControl.Dock = System.Windows.Forms.DockStyle.Fill;

            tabWorkSchedules.Controls.Add(scheduleControl);
            Load += SchedulingManagementControl_Load;
        }

        private void SchedulingManagementControl_Load(
            object sender,
            EventArgs e)
        {
            LoadShifts();
        }

        private void LoadShifts()
        {
            EnsureSchedulingAccess();
            try
            {
                dgvShifts.DataSource = _repository.GetWorkShifts(
                    CompanyId,
                    chkIncludeInactive.Checked
                );

                ConfigureGrid();

                lblCount.Text =
                    dgvShifts.Rows.Count + " work shift(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load work shifts.\n\n" + ex.Message,
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigureGrid()
        {
            if (dgvShifts.Columns.Count == 0)
                return;

            dgvShifts.Columns["ShiftId"].Visible = false;

            dgvShifts.Columns["ShiftName"].HeaderText = "SHIFT NAME";
            dgvShifts.Columns["StartTime"].HeaderText = "START";
            dgvShifts.Columns["EndTime"].HeaderText = "END";
            dgvShifts.Columns["BreakMinutes"].HeaderText = "BREAK (MIN)";
            dgvShifts.Columns["GracePeriodMinutes"].HeaderText = "GRACE (MIN)";
            dgvShifts.Columns["IsActive"].HeaderText = "ACTIVE";
            dgvShifts.Columns["NetMinutes"].HeaderText = "NET WORK (MIN)";

            dgvShifts.Columns["ShiftName"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvShifts.Columns["StartTime"].DefaultCellStyle.Format =
                @"hh\:mm";

            dgvShifts.Columns["EndTime"].DefaultCellStyle.Format =
                @"hh\:mm";

            dgvShifts.Columns["IsActive"].Width = 75;
            dgvShifts.Columns["BreakMinutes"].Width = 105;
            dgvShifts.Columns["GracePeriodMinutes"].Width = 110;
            dgvShifts.Columns["NetMinutes"].Width = 120;
        }

        private WorkShiftModel SelectedShift()
        {
            if (dgvShifts.CurrentRow == null)
                return null;

            DataRowView row =
                dgvShifts.CurrentRow.DataBoundItem as DataRowView;

            if (row == null)
                return null;

            return new WorkShiftModel
            {
                ShiftId = Convert.ToInt32(row["ShiftId"]),
                CompanyId = CompanyId,
                ShiftName = Convert.ToString(row["ShiftName"]),
                StartTime = (TimeSpan)row["StartTime"],
                EndTime = (TimeSpan)row["EndTime"],
                BreakMinutes = Convert.ToInt32(row["BreakMinutes"]),
                GracePeriodMinutes =
                    Convert.ToInt32(row["GracePeriodMinutes"]),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnsureSchedulingAccess();
            using (WorkShiftDialog dialog = new WorkShiftDialog())
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                    return;

                try
                {
                    WorkShiftModel shift = dialog.WorkShift;
                    shift.CompanyId = CompanyId;

                    _repository.Insert(shift);

                    LoadShifts();
                }
                catch (SqlException ex)
                {
                    ShowSaveError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Save Work Shift",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnsureSchedulingAccess();
            WorkShiftModel selected = SelectedShift();

            if (selected == null)
            {
                MessageBox.Show(
                    "Select a work shift first.",
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            using (WorkShiftDialog dialog =
                new WorkShiftDialog(selected))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                    return;

                try
                {
                    WorkShiftModel shift = dialog.WorkShift;

                    shift.CompanyId = CompanyId;
                    shift.ShiftId = selected.ShiftId;

                    _repository.Update(shift);

                    LoadShifts();
                }
                catch (SqlException ex)
                {
                    ShowSaveError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Update Work Shift",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            EnsureSchedulingAccess();
            WorkShiftModel selected = SelectedShift();

            if (selected == null)
            {
                MessageBox.Show(
                    "Select a work shift first.",
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            string action = selected.IsActive
                ? "deactivate"
                : "activate";

            DialogResult result = MessageBox.Show(
                "Are you sure you want to " + action +
                " '" + selected.ShiftName + "'?",
                "Confirm Work Shift",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                _repository.SetActive(
                    CompanyId,
                    selected.ShiftId,
                    !selected.IsActive
                );

                LoadShifts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Work Shift",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadShifts();
        }

        private void chkIncludeInactive_CheckedChanged(
            object sender,
            EventArgs e)
        {
            LoadShifts();
        }

        private void dgvShifts_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEdit_Click(sender, EventArgs.Empty);
        }

        private static void ShowSaveError(SqlException ex)
        {
            if (ex.Number == 2601 || ex.Number == 2627)
            {
                MessageBox.Show(
                    "A work shift with this name already exists " +
                    "for the selected company.",
                    "Duplicate Work Shift",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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
                PermissionCodes.Schedules, UserSession.CompanyId.Value))
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