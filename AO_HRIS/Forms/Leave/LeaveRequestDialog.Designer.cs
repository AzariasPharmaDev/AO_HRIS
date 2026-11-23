using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Leave
{
    partial class LeaveRequestDialog
    {
        private IContainer components = null;
        private ComboBox cmbEmployee;
        private ComboBox leaveType;
        private DateTimePicker from;
        private DateTimePicker to;
        private NumericUpDown days;
        private TextBox reason;
        private Button btnSave;
        private Button btnCancel;
        private Label lblEmployee;
        private Label lblLeaveType;
        private Label lblDateFrom;
        private Label lblDateTo;
        private Label lblDays;
        private Label lblReason;
        private Label lblSharedBalance;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.leaveType = new System.Windows.Forms.ComboBox();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.days = new System.Windows.Forms.NumericUpDown();
            this.reason = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblLeaveType = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblSharedBalance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.days)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Location = new System.Drawing.Point(155, 16);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(325, 23);
            this.cmbEmployee.TabIndex = 1;
            // 
            // leaveType
            // 
            this.leaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leaveType.Location = new System.Drawing.Point(155, 64);
            this.leaveType.Name = "leaveType";
            this.leaveType.Size = new System.Drawing.Size(325, 23);
            this.leaveType.TabIndex = 3;
            // 
            // from
            // 
            this.from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from.Location = new System.Drawing.Point(155, 112);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(150, 23);
            this.from.TabIndex = 5;
            // 
            // to
            // 
            this.to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to.Location = new System.Drawing.Point(155, 160);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(150, 23);
            this.to.TabIndex = 7;
            // 
            // days
            // 
            this.days.DecimalPlaces = 2;
            this.days.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.days.Location = new System.Drawing.Point(155, 208);
            this.days.Maximum = new decimal(new int[] {
            366,
            0,
            0,
            0});
            this.days.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.days.Name = "days";
            this.days.Size = new System.Drawing.Size(100, 23);
            this.days.TabIndex = 9;
            this.days.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // reason
            // 
            this.reason.Location = new System.Drawing.Point(155, 256);
            this.reason.MaxLength = 1000;
            this.reason.Multiline = true;
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(325, 70);
            this.reason.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(275, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 34);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Submit Request";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(405, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            // 
            // lblEmployee
            // 
            this.lblEmployee.Location = new System.Drawing.Point(18, 20);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(125, 24);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employee";
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.Location = new System.Drawing.Point(18, 68);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(125, 24);
            this.lblLeaveType.TabIndex = 2;
            this.lblLeaveType.Text = "Leave Type";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Location = new System.Drawing.Point(18, 116);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(125, 24);
            this.lblDateFrom.TabIndex = 4;
            this.lblDateFrom.Text = "Date From";
            // 
            // lblDateTo
            // 
            this.lblDateTo.Location = new System.Drawing.Point(18, 164);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(125, 24);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "Date To";
            // 
            // lblDays
            // 
            this.lblDays.Location = new System.Drawing.Point(18, 212);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(125, 24);
            this.lblDays.TabIndex = 8;
            this.lblDays.Text = "Days Requested";
            // 
            // lblReason
            // 
            this.lblReason.Location = new System.Drawing.Point(18, 260);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(125, 24);
            this.lblReason.TabIndex = 10;
            this.lblReason.Text = "Reason";
            // 
            // lblSharedBalance
            // 
            this.lblSharedBalance.AutoSize = true;
            this.lblSharedBalance.ForeColor = System.Drawing.Color.FromArgb(107, 124, 144);
            this.lblSharedBalance.Location = new System.Drawing.Point(18, 338);
            this.lblSharedBalance.Name = "lblSharedBalance";
            this.lblSharedBalance.Size = new System.Drawing.Size(460, 17);
            this.lblSharedBalance.TabIndex = 14;
            this.lblSharedBalance.Text = "Annual leave balance is shared across all leave types and subsidiary assignments.";
            // 
            // LeaveRequestDialog
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(504, 430);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblLeaveType);
            this.Controls.Add(this.leaveType);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.from);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.to);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.days);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblSharedBalance);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LeaveRequestDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Leave Request";
            ((System.ComponentModel.ISupportInitialize)(this.days)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
