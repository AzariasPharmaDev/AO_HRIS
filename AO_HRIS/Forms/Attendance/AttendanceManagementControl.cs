using AO_HRIS.Security;
using System;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Attendance
{
    public partial class AttendanceManagementControl : UserControl
    {
        private readonly AttendanceRepository _repository = new AttendanceRepository();
        private int CompanyId { get { return UserSession.CompanyId.GetValueOrDefault(); } }

        public AttendanceManagementControl()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
                return;
            if (!UserSession.CompanyId.HasValue)
                throw new InvalidOperationException("Select a company before opening Attendance Management.");

            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            ConfigureFilters();
            WireEvents();
            LoadEvents();
        }

        private void ConfigureFilters()
        {
            cboEventType.Items.AddRange(new object[] { "All event types", "IN", "OUT", "BREAK_IN", "BREAK_OUT", "PUNCH", "UNKNOWN" });
            cboEventType.SelectedIndex = 0;
            cboSource.Items.AddRange(new object[] { "All sources", "MANUAL", "EMPLOYEE_APP", "BIOMETRIC_IMPORT", "ADMIN_IMPORT" });
            cboSource.SelectedIndex = 0;
        }

        private void WireEvents()
        {
            btnApplyFilters.Click += (s, e) => RunSafe(LoadEvents);
            btnResetFilters.Click += (s, e) =>
            {
                dtpFrom.Value = DateTime.Today;
                dtpTo.Value = DateTime.Today;
                txtSearch.Clear();
                cboEventType.SelectedIndex = 0;
                cboSource.SelectedIndex = 0;
                chkIncludeVoided.Checked = false;
                RunSafe(LoadEvents);
            };
            btnRefresh.Click += (s, e) => RunSafe(LoadEvents);
            btnManualEntry.Click += (s, e) => RunSafe(CreateManualEvent);
            btnVoidEvent.Click += (s, e) => RunSafe(VoidSelectedEvent);
        }

        private void RunSafe(Action action)
        {
            try { action(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attendance Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEvents()
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
                throw new InvalidOperationException("The start date cannot be later than the end date.");

            string eventType = cboEventType.SelectedIndex <= 0 ? string.Empty : Convert.ToString(cboEventType.SelectedItem);
            string source = cboSource.SelectedIndex <= 0 ? string.Empty : Convert.ToString(cboSource.SelectedItem);
            DataTable table = _repository.GetEvents(CompanyId, dtpFrom.Value.Date, dtpTo.Value.Date,
                txtSearch.Text, eventType, source, chkIncludeVoided.Checked);
            dgvEvents.DataSource = table;
            ConfigureGrid();
            lblCount.Text = table.Rows.Count.ToString("N0") + " attendance event(s)";
            btnVoidEvent.Enabled = table.Rows.Count > 0;
        }

        private void ConfigureGrid()
        {
            if (dgvEvents.Columns.Count == 0) return;
            dgvEvents.Columns["AttendanceEventId"].Visible = false;
            dgvEvents.Columns["EventDateTime"].HeaderText = "DATE / TIME";
            dgvEvents.Columns["EventDateTime"].DefaultCellStyle.Format = "MMM dd, yyyy  hh:mm tt";
            dgvEvents.Columns["EmployeeNo"].HeaderText = "EMPLOYEE NO.";
            dgvEvents.Columns["EmployeeName"].HeaderText = "EMPLOYEE";
            dgvEvents.Columns["DepartmentName"].HeaderText = "DEPARTMENT";
            dgvEvents.Columns["PositionName"].HeaderText = "POSITION";
            dgvEvents.Columns["EventType"].HeaderText = "EVENT";
            dgvEvents.Columns["SourceType"].HeaderText = "SOURCE";
            dgvEvents.Columns["DeviceEmployeeCode"].HeaderText = "DEVICE CODE";
            dgvEvents.Columns["DeviceName"].HeaderText = "DEVICE";
            dgvEvents.Columns["IsVoided"].HeaderText = "VOIDED";
            dgvEvents.Columns["VoidReason"].HeaderText = "VOID REASON";
            dgvEvents.Columns["RecordedBy"].HeaderText = "RECORDED BY";
            dgvEvents.Columns["Notes"].HeaderText = "NOTES";
            dgvEvents.Columns["EmployeeName"].MinimumWidth = 170;
            dgvEvents.Columns["EmployeeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEvents.Columns["DepartmentName"].MinimumWidth = 130;
            dgvEvents.Columns["PositionName"].MinimumWidth = 130;
            dgvEvents.Columns["VoidReason"].MinimumWidth = 130;
            dgvEvents.Columns["Notes"].MinimumWidth = 140;
        }

        private void CreateManualEvent()
        {
            using (var dialog = new ManualAttendanceEventDialog(_repository, CompanyId))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK) return;
                _repository.AddManualEvent(CompanyId, dialog.AssignmentId, dialog.EventType,
                    dialog.EventDateTime, UserSession.UserId, dialog.Notes);
            }
            LoadEvents();
        }

        private void VoidSelectedEvent()
        {
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show("Select an attendance event first.", "Attendance Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToBoolean(dgvEvents.CurrentRow.Cells["IsVoided"].Value))
            {
                MessageBox.Show("This event has already been voided.", "Attendance Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int eventId = Convert.ToInt32(dgvEvents.CurrentRow.Cells["AttendanceEventId"].Value);
            string employee = Convert.ToString(dgvEvents.CurrentRow.Cells["EmployeeName"].Value);
            using (var dialog = new VoidAttendanceEventDialog(employee))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK) return;
                _repository.VoidEvent(CompanyId, eventId, UserSession.UserId, dialog.Reason);
            }
            LoadEvents();
        }
    }
}
