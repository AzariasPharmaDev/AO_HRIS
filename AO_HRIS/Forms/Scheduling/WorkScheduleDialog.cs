
using AO_HRIS.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Scheduling
{
    public partial class WorkScheduleDialog : Form
    {
        private readonly int _companyId;
        private readonly WorkScheduleModel _schedule;

        private readonly ComboBox[] _shiftCombos;
        private readonly CheckBox[] _restChecks;

        private readonly string[] _dayNames =
        {
            "Monday", "Tuesday", "Wednesday", "Thursday",
            "Friday", "Saturday", "Sunday"
        };

        public WorkScheduleModel WorkSchedule
        {
            get { return _schedule; }
        }

        public WorkScheduleDayModel[] ScheduleDays { get; private set; }

        public WorkScheduleDialog(int companyId)
            : this(companyId, null, null)
        {
        }

        public WorkScheduleDialog(
            int companyId,
            WorkScheduleModel schedule,
            DataTable scheduleDays)
        {
            InitializeComponent();

            _companyId = companyId;

            _schedule = schedule ?? new WorkScheduleModel
            {
                CompanyId = companyId,
                ScheduleType = "FIXED",
                IsActive = true
            };

            _shiftCombos = new[]
            {
                cboMonday,
                cboTuesday,
                cboWednesday,
                cboThursday,
                cboFriday,
                cboSaturday,
                cboSunday
            };

            _restChecks = new[]
            {
                chkMondayRest,
                chkTuesdayRest,
                chkWednesdayRest,
                chkThursdayRest,
                chkFridayRest,
                chkSaturdayRest,
                chkSundayRest
            };

            InitializeRestDayEvents();
            LoadShiftOptions();
            ConfigureForm();

            if (schedule != null)
                LoadScheduleDays(scheduleDays);
            else
                SetDefaultDays();
        }

        private void ConfigureForm()
        {
            Text = _schedule.WorkScheduleId > 0
                ? "Edit Work Schedule"
                : "New Work Schedule";

            lblTitle.Text = _schedule.WorkScheduleId > 0
                ? "Edit Work Schedule"
                : "Create Work Schedule";

            txtScheduleName.Text = _schedule.ScheduleName ?? string.Empty;
            txtDescription.Text = _schedule.Description ?? string.Empty;

            cboScheduleType.SelectedItem =
                _schedule.ScheduleType == "ROTATING"
                    ? "ROTATING"
                    : "FIXED";

            chkActive.Checked = _schedule.IsActive;
        }

        private void LoadShiftOptions()
        {
            WorkScheduleRepository repository =
                new WorkScheduleRepository();

            DataTable shifts = repository.GetActiveShifts(_companyId);

            foreach (ComboBox combo in _shiftCombos)
            {
                DataTable options = shifts.Copy();

                options.Columns.Add(
                    "ShiftDisplay",
                    typeof(string));

                foreach (DataRow row in options.Rows)
                {
                    row["ShiftDisplay"] =
                        Convert.ToString(row["ShiftName"]) +
                        " (" +
                        Convert.ToString(row["StartTimeText"]) +
                        " - " +
                        Convert.ToString(row["EndTimeText"]) +
                        ")";
                }

                combo.DisplayMember = "ShiftDisplay";
                combo.ValueMember = "ShiftId";
                combo.DataSource = options;
                combo.SelectedIndex = -1;
            }
        }

        private void SetDefaultDays()
        {
            for (int i = 0; i < 7; i++)
            {
                bool isWeekend = i >= 5;

                _restChecks[i].Checked = isWeekend;
                _shiftCombos[i].Enabled = !isWeekend;
                _shiftCombos[i].SelectedIndex = -1;
            }
        }

        private void LoadScheduleDays(DataTable scheduleDays)
        {
            SetDefaultDays();

            if (scheduleDays == null)
                return;

            foreach (DataRow row in scheduleDays.Rows)
            {
                if (row["DayOfWeek"] == DBNull.Value)
                    continue;

                int dayNumber = Convert.ToInt32(row["DayOfWeek"]);
                int index = dayNumber - 1;

                if (index < 0 || index > 6)
                    continue;

                bool isRestDay =
                    row["IsRestDay"] != DBNull.Value &&
                    Convert.ToBoolean(row["IsRestDay"]);

                _restChecks[index].Checked = isRestDay;

                if (!isRestDay && row["ShiftId"] != DBNull.Value)
                {
                    int shiftId = Convert.ToInt32(row["ShiftId"]);

                    _shiftCombos[index].SelectedValue = shiftId;

                    if (_shiftCombos[index].SelectedIndex < 0)
                    {
                        MessageBox.Show(
                            "The previously assigned shift for " +
                            _dayNames[index] +
                            " is no longer active or available in this company. " +
                            "Please select another active shift.",
                            "Unavailable Shift",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }

                _shiftCombos[index].Enabled = !isRestDay;
            }
        }

        private void InitializeRestDayEvents()
        {
            foreach (CheckBox check in _restChecks)
                check.CheckedChanged += RestDayChanged;
        }

        private void RestDayChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                if (sender == _restChecks[i])
                {
                    bool isRestDay = _restChecks[i].Checked;

                    _shiftCombos[i].Enabled = !isRestDay;

                    if (isRestDay)
                        _shiftCombos[i].SelectedIndex = -1;

                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtScheduleName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Enter a schedule name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtScheduleName.Focus();
                return;
            }

            if (cboScheduleType.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Select a schedule type.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cboScheduleType.Focus();
                return;
            }

            WorkScheduleDayModel[] days =
                new WorkScheduleDayModel[7];

            for (int i = 0; i < 7; i++)
            {
                bool isRestDay = _restChecks[i].Checked;
                int? shiftId = null;

                if (!isRestDay)
                {
                    if (_shiftCombos[i].SelectedValue == null ||
                        _shiftCombos[i].SelectedValue == DBNull.Value)
                    {
                        MessageBox.Show(
                            "Select a shift for " + _dayNames[i] +
                            " or mark it as a rest day.",
                            "Incomplete Schedule",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        _shiftCombos[i].Focus();
                        return;
                    }

                    shiftId = Convert.ToInt32(
                        _shiftCombos[i].SelectedValue);
                }

                days[i] = new WorkScheduleDayModel
                {
                    DayOfWeek = i + 1,
                    ShiftId = shiftId,
                    IsRestDay = isRestDay
                };
            }

            _schedule.CompanyId = _companyId;
            _schedule.ScheduleName = name;
            _schedule.ScheduleType =
                Convert.ToString(cboScheduleType.SelectedItem);
            _schedule.Description = txtDescription.Text.Trim();
            _schedule.IsActive = chkActive.Checked;

            ScheduleDays = days;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cboScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboScheduleType.SelectedItem == null)
                return;

            string scheduleType = cboScheduleType.SelectedItem.ToString();

            // Keep the selected schedule type valid.
            if (scheduleType != "FIXED" && scheduleType != "ROTATING")
                return;

            // Both schedule types use the same seven-day configuration UI.
            // ROTATING schedules will use rotation configuration in a later step.
        }
    }
}
