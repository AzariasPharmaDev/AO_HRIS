using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Attendance
{
    partial class ManualAttendanceEventDialog
    {
        private IContainer components = null;
        private Label lblTitle;
        private Label lblEmployee;
        private Label lblEventType;
        private Label lblDateTime;
        private Label lblNotes;
        private ComboBox cboEmployee;
        private ComboBox cboEventType;
        private DateTimePicker dtpEventDate;
        private TextBox txtNotes;
        private Label lblNoEmployees;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label(); this.lblEmployee = new Label(); this.lblEventType = new Label(); this.lblDateTime = new Label(); this.lblNotes = new Label();
            this.cboEmployee = new ComboBox(); this.cboEventType = new ComboBox(); this.dtpEventDate = new DateTimePicker(); this.txtNotes = new TextBox();
            this.lblNoEmployees = new Label(); this.btnSave = new Button(); this.btnCancel = new Button(); this.SuspendLayout();
            this.BackColor = Color.White; this.ClientSize = new Size(570, 430); this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog; this.MaximizeBox = false; this.MinimizeBox = false; this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Manual Attendance Entry";
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold); this.lblTitle.ForeColor = Color.FromArgb(28, 55, 91); this.lblTitle.Location = new Point(24, 20); this.lblTitle.Text = "Encode attendance event";
            this.lblEmployee.AutoSize = true; this.lblEmployee.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblEmployee.ForeColor = Color.FromArgb(107, 124, 144); this.lblEmployee.Location = new Point(28, 78); this.lblEmployee.Text = "EMPLOYEE ASSIGNMENT";
            this.lblEventType.AutoSize = true; this.lblEventType.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblEventType.ForeColor = Color.FromArgb(107, 124, 144); this.lblEventType.Location = new Point(28, 158); this.lblEventType.Text = "EVENT TYPE";
            this.lblDateTime.AutoSize = true; this.lblDateTime.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblDateTime.ForeColor = Color.FromArgb(107, 124, 144); this.lblDateTime.Location = new Point(298, 158); this.lblDateTime.Text = "DATE AND TIME";
            this.lblNotes.AutoSize = true; this.lblNotes.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblNotes.ForeColor = Color.FromArgb(107, 124, 144); this.lblNotes.Location = new Point(28, 238); this.lblNotes.Text = "NOTES (OPTIONAL)";
            this.cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList; this.cboEmployee.Font = new Font("Segoe UI", 9.5F); this.cboEmployee.Location = new Point(28, 101); this.cboEmployee.Size = new Size(514, 29);
            this.cboEventType.DropDownStyle = ComboBoxStyle.DropDownList; this.cboEventType.Font = new Font("Segoe UI", 9.5F); this.cboEventType.Location = new Point(28, 181); this.cboEventType.Size = new Size(245, 29);
            this.cboEventType.Items.AddRange(new object[] { "IN", "OUT", "BREAK_IN", "BREAK_OUT" }); this.cboEventType.SelectedIndex = 0;
            this.dtpEventDate.Font = new Font("Segoe UI", 9.5F); this.dtpEventDate.Format = DateTimePickerFormat.Custom; this.dtpEventDate.CustomFormat = "MMM dd, yyyy  hh:mm tt"; this.dtpEventDate.Location = new Point(298, 181); this.dtpEventDate.Size = new Size(244, 29);
            this.txtNotes.Location = new Point(28, 261); this.txtNotes.Size = new Size(514, 70); this.txtNotes.Multiline = true; this.txtNotes.MaxLength = 1000; this.txtNotes.BorderStyle = BorderStyle.FixedSingle; this.txtNotes.Font = new Font("Segoe UI", 9F);
            this.lblNoEmployees.AutoSize = true; this.lblNoEmployees.Location = new Point(28, 335); this.lblNoEmployees.ForeColor = Color.FromArgb(190, 55, 55); this.lblNoEmployees.Text = "No employee assignments are available for this company."; this.lblNoEmployees.Visible = false;
            this.btnSave.Text = "Save event"; this.btnSave.Location = new Point(352, 375); this.btnSave.Size = new Size(90, 32); this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0; this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(220, 229, 239); this.btnSave.BackColor = Color.FromArgb(35, 106, 213); this.btnSave.ForeColor = Color.White;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Text = "Cancel"; this.btnCancel.Location = new Point(447, 375); this.btnCancel.Size = new Size(90, 32); this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 1; this.btnCancel.FlatAppearance.BorderColor = Color.FromArgb(220, 229, 239); this.btnCancel.BackColor = Color.White; this.btnCancel.ForeColor = Color.FromArgb(40, 57, 77); this.btnCancel.DialogResult = DialogResult.Cancel;
            this.Controls.AddRange(new Control[] { this.lblTitle, this.lblEmployee, this.lblEventType, this.lblDateTime, this.lblNotes, this.cboEmployee, this.cboEventType, this.dtpEventDate, this.txtNotes, this.lblNoEmployees, this.btnSave, this.btnCancel });
            this.AcceptButton = this.btnSave; this.CancelButton = this.btnCancel; this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
