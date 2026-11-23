
using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Scheduling
{
    public partial class WorkScheduleManagementControl : UserControl
    {
        private readonly WorkScheduleRepository _repository = new WorkScheduleRepository();
        private readonly WorkScheduleRotationRepository _rotationRepository = new WorkScheduleRotationRepository();
        private int CompanyId
        {
            get { return UserSession.CompanyId.Value; }
        }

        public WorkScheduleManagementControl()
        {
            InitializeComponent();
            Load += WorkScheduleManagementControl_Load;
        }

        private void WorkScheduleManagementControl_Load(object sender, EventArgs e)
        {
            LoadSchedules();
        }

        private void LoadSchedules()
        {
            if (!EnsureSchedulingAccess())
                return;
            try
            {
                dgvSchedules.DataSource = _repository.GetSchedules(
                    CompanyId,
                    chkIncludeInactive.Checked);

                ConfigureGrid();

                lblCount.Text = dgvSchedules.Rows.Count + " schedule(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load work schedules.\n\n" + ex.Message,
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            if (dgvSchedules.Columns.Count == 0)
                return;

            dgvSchedules.Columns["WorkScheduleId"].Visible = false;

            dgvSchedules.Columns["ScheduleName"].HeaderText = "SCHEDULE NAME";
            dgvSchedules.Columns["ScheduleType"].HeaderText = "TYPE";
            dgvSchedules.Columns["Description"].HeaderText = "DESCRIPTION";
            dgvSchedules.Columns["IsActive"].HeaderText = "ACTIVE";
            dgvSchedules.Columns["ConfiguredDays"].HeaderText = "DAYS CONFIGURED";
            dgvSchedules.Columns["CreatedAt"].HeaderText = "CREATED";

            dgvSchedules.Columns["ScheduleName"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvSchedules.Columns["Description"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvSchedules.Columns["IsActive"].Width = 75;
            dgvSchedules.Columns["ScheduleType"].Width = 100;
            dgvSchedules.Columns["ConfiguredDays"].Width = 120;
            dgvSchedules.Columns["CreatedAt"].Width = 145;

            dgvSchedules.Columns["CreatedAt"].DefaultCellStyle.Format =
                "MMM dd, yyyy";
        }

        private WorkScheduleModel GetSelectedSchedule()
        {
            if (dgvSchedules.CurrentRow == null)
                return null;

            DataRowView row =
                dgvSchedules.CurrentRow.DataBoundItem as DataRowView;

            if (row == null)
                return null;

            return new WorkScheduleModel
            {
                WorkScheduleId = Convert.ToInt32(row["WorkScheduleId"]),
                CompanyId = CompanyId,
                ScheduleName = Convert.ToString(row["ScheduleName"]),
                ScheduleType = Convert.ToString(row["ScheduleType"]),
                Description = row["Description"] == DBNull.Value
                    ? string.Empty
                    : Convert.ToString(row["Description"]),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (WorkScheduleDialog dialog =
                new WorkScheduleDialog(CompanyId))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                    return;

                try
                {
                    WorkScheduleModel schedule = dialog.WorkSchedule;
                    schedule.CompanyId = CompanyId;

                    _repository.Insert(schedule, dialog.ScheduleDays);
                    LoadSchedules();
                }
                catch (SqlException ex)
                {
                    ShowSaveError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Save Schedule",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            WorkScheduleModel selected = GetSelectedSchedule();

            if (selected == null)
            {
                MessageBox.Show("Select a work schedule first.",
                    "Scheduling", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                var days = _repository.GetScheduleDays(
                    CompanyId,
                    selected.WorkScheduleId);

                using (WorkScheduleDialog dialog =
                    new WorkScheduleDialog(CompanyId, selected, days))
                {
                    if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                        return;

                    WorkScheduleModel updated = dialog.WorkSchedule;
                    updated.CompanyId = CompanyId;
                    updated.WorkScheduleId = selected.WorkScheduleId;

                    _repository.Update(updated, dialog.ScheduleDays);
                    LoadSchedules();
                }
            }
            catch (SqlException ex)
            {
                ShowSaveError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Schedule",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            WorkScheduleModel selected = GetSelectedSchedule();

            if (selected == null)
            {
                MessageBox.Show("Select a work schedule first.",
                    "Scheduling", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string action = selected.IsActive ? "deactivate" : "activate";

            if (MessageBox.Show(
                "Are you sure you want to " + action +
                " '" + selected.ScheduleName + "'?",
                "Confirm Schedule",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _repository.SetActive(
                    CompanyId,
                    selected.WorkScheduleId,
                    !selected.IsActive);

                LoadSchedules();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Schedule",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSchedules();
        }

        private void chkIncludeInactive_CheckedChanged(
            object sender,
            EventArgs e)
        {
            LoadSchedules();
        }

        private void dgvSchedules_CellDoubleClick(
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
                    "A schedule with this name already exists for this company.",
                    "Duplicate Schedule",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfigureRotation_Click(object sender, EventArgs e)
        {
            WorkScheduleModel selected = GetSelectedSchedule();

            if (selected == null)
            {
                MessageBox.Show(
                    "Select a work schedule first.",
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!string.Equals(
                selected.ScheduleType,
                "ROTATING",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Rotation configuration is only available for ROTATING schedules.",
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                WorkScheduleRotationModel rotation =
                    _rotationRepository.GetRotation(
                        CompanyId,
                        selected.WorkScheduleId);

                using (RotationConfigurationDialog dialog =
                    new RotationConfigurationDialog(
                        CompanyId,
                        selected.WorkScheduleId,
                        selected.ScheduleName,
                        rotation))
                {
                    dialog.ShowDialog(FindForm());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open rotation configuration.\n\n" + ex.Message,
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
