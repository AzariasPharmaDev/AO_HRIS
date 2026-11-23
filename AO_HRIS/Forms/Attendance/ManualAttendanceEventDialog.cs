using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Attendance
{
    public partial class ManualAttendanceEventDialog : Form
    {
        private readonly AttendanceRepository _repository;
        private readonly int _companyId;
        public int AssignmentId { get { return Convert.ToInt32(cboEmployee.SelectedValue); } }
        public string EventType { get { return Convert.ToString(cboEventType.SelectedItem); } }
        public DateTime EventDateTime { get { return dtpEventDate.Value; } }
        public string Notes { get { return txtNotes.Text.Trim(); } }

        public ManualAttendanceEventDialog(AttendanceRepository repository, int companyId)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _companyId = companyId;
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            DataTable employees = _repository.GetAssignmentOptions(_companyId);
            cboEmployee.DisplayMember = "EmployeeLabel";
            cboEmployee.ValueMember = "AssignmentId";
            cboEmployee.DataSource = employees;
            if (employees.Rows.Count == 0)
            {
                btnSave.Enabled = false;
                lblNoEmployees.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboEmployee.SelectedValue == null || !(cboEmployee.SelectedValue is int))
            {
                MessageBox.Show("Select an employee assignment.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEventType.SelectedIndex < 0)
            {
                MessageBox.Show("Select an event type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    public sealed class VoidAttendanceEventDialog : Form
    {
        private TextBox txtReason;
        private Button btnSave;
        private Button btnCancel;
        public string Reason { get { return txtReason.Text.Trim(); } }

        public VoidAttendanceEventDialog(string employeeName)
        {
            Text = "Void Attendance Event"; StartPosition = FormStartPosition.CenterParent; FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false; ClientSize = new Size(470, 205);
            BackColor = Color.White; Font = new Font("Segoe UI", 9F);
            var lbl = new Label { AutoSize = true, Text = "Voiding event for: " + (employeeName ?? "Unmatched event"), Location = new Point(20, 18), ForeColor = Color.FromArgb(28, 55, 91), Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold) };
            var hint = new Label { AutoSize = true, Text = "Enter the reason. The original event will be retained for audit purposes.", Location = new Point(20, 48), ForeColor = Color.FromArgb(107, 124, 144) };
            txtReason = new TextBox { Location = new Point(20, 78), Size = new Size(430, 58), Multiline = true, MaxLength = 500, Font = new Font("Segoe UI", 9F), BorderStyle = BorderStyle.FixedSingle };
            btnSave = new Button { Text = "Void event", Location = new Point(270, 151), Size = new Size(90, 32), BackColor = Color.FromArgb(190, 55, 55), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnCancel = new Button { Text = "Cancel", Location = new Point(365, 151), Size = new Size(85, 32), DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };
            btnSave.Click += (s, e) => { if (string.IsNullOrWhiteSpace(txtReason.Text)) { MessageBox.Show("Enter a reason.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } DialogResult = DialogResult.OK; Close(); };
            Controls.AddRange(new Control[] { lbl, hint, txtReason, btnSave, btnCancel }); AcceptButton = btnSave; CancelButton = btnCancel;
        }
    }
}
