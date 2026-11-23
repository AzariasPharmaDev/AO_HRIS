using AO_HRIS.Data;
using DocumentFormat.OpenXml.Math;
using System;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Scheduling
{
    public partial class WorkShiftDialog : Form
    {
        public WorkShiftModel WorkShift { get; private set; }

        public WorkShiftDialog()
        {
            InitializeComponent();

            Text = "Add Work Shift";
            chkActive.Checked = true;
        }

        public WorkShiftDialog(WorkShiftModel shift) : this()
        {
            if (shift == null)
                throw new ArgumentNullException("shift");

            Text = "Edit Work Shift";

            txtShiftName.Text = shift.ShiftName;

            dtpStart.Value = DateTime.Today.Add(shift.StartTime);
            dtpEnd.Value = DateTime.Today.Add(shift.EndTime);

            nudBreak.Value = shift.BreakMinutes;
            nudGrace.Value = shift.GracePeriodMinutes;

            chkActive.Checked = shift.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtShiftName.Text.Trim();

            // Validate shift name
            if (name.Length == 0)
            {
                MessageBox.Show(
                    "Enter a work shift name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtShiftName.Focus();
                return;
            }

            TimeSpan start = dtpStart.Value.TimeOfDay;
            TimeSpan end = dtpEnd.Value.TimeOfDay;

            // Start and end cannot be identical
            if (start == end)
            {
                MessageBox.Show(
                    "Start time and end time cannot be the same.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int breakMinutes = Decimal.ToInt32(nudBreak.Value);
            int graceMinutes = Decimal.ToInt32(nudGrace.Value);

            // Supports overnight shifts
            int durationMinutes = end > start
                ? (int)(end - start).TotalMinutes
                : (int)(
                    TimeSpan.FromDays(1) - start + end
                  ).TotalMinutes;

            // Break must be shorter than the shift duration
            if (breakMinutes >= durationMinutes)
            {
                MessageBox.Show(
                    "Break duration must be shorter than the total shift duration.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                nudBreak.Focus();
                return;
            }

            WorkShift = new WorkShiftModel
            {
                ShiftName = name,
                StartTime = start,
                EndTime = end,
                BreakMinutes = breakMinutes,
                GracePeriodMinutes = graceMinutes,
                IsActive = chkActive.Checked
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}