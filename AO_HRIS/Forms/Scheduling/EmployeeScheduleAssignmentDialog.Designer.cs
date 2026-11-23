namespace AO_HRIS.Forms.Scheduling
{
    partial class EmployeeScheduleAssignmentDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlContent;

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cboAssignment;

        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cboMode;

        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.ComboBox cboSchedule;

        private System.Windows.Forms.Label lblRotationStart;
        private System.Windows.Forms.DateTimePicker dtpRotationStart;

        private System.Windows.Forms.Label lblEffectiveFrom;
        private System.Windows.Forms.DateTimePicker dtpEffectiveFrom;

        private System.Windows.Forms.Label lblEffectiveTo;
        private System.Windows.Forms.DateTimePicker dtpEffectiveTo;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cboAssignment = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.cboSchedule = new System.Windows.Forms.ComboBox();
            this.lblRotationStart = new System.Windows.Forms.Label();
            this.dtpRotationStart = new System.Windows.Forms.DateTimePicker();
            this.lblEffectiveFrom = new System.Windows.Forms.Label();
            this.dtpEffectiveFrom = new System.Windows.Forms.DateTimePicker();
            this.lblEffectiveTo = new System.Windows.Forms.Label();
            this.dtpEffectiveTo = new System.Windows.Forms.DateTimePicker();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 14, 24, 10);
            this.pnlHeader.Size = new System.Drawing.Size(560, 85);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSubtitle.Location = new System.Drawing.Point(27, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(218, 15);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "Assign a work schedule to an employee.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(287, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "New Schedule Assignment";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnlContent.Controls.Add(this.lblEmployee);
            this.pnlContent.Controls.Add(this.cboAssignment);
            this.pnlContent.Controls.Add(this.lblMode);
            this.pnlContent.Controls.Add(this.cboMode);
            this.pnlContent.Controls.Add(this.lblSchedule);
            this.pnlContent.Controls.Add(this.cboSchedule);
            this.pnlContent.Controls.Add(this.lblRotationStart);
            this.pnlContent.Controls.Add(this.dtpRotationStart);
            this.pnlContent.Controls.Add(this.lblEffectiveFrom);
            this.pnlContent.Controls.Add(this.dtpEffectiveFrom);
            this.pnlContent.Controls.Add(this.lblEffectiveTo);
            this.pnlContent.Controls.Add(this.dtpEffectiveTo);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 85);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(28, 24, 28, 20);
            this.pnlContent.Size = new System.Drawing.Size(560, 380);
            this.pnlContent.TabIndex = 0;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblEmployee.Location = new System.Drawing.Point(28, 25);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(129, 15);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employee Assignment";
            // 
            // cboAssignment
            // 
            this.cboAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAssignment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboAssignment.Location = new System.Drawing.Point(31, 49);
            this.cboAssignment.Name = "cboAssignment";
            this.cboAssignment.Size = new System.Drawing.Size(498, 23);
            this.cboAssignment.TabIndex = 1;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblMode.Location = new System.Drawing.Point(28, 96);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(107, 15);
            this.lblMode.TabIndex = 2;
            this.lblMode.Text = "Assignment Mode";
            // 
            // cboMode
            // 
            this.cboMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMode.Location = new System.Drawing.Point(31, 120);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(498, 23);
            this.cboMode.TabIndex = 3;
            this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblSchedule.Location = new System.Drawing.Point(28, 168);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(92, 15);
            this.lblSchedule.TabIndex = 4;
            this.lblSchedule.Text = "Work Schedule";
            // 
            // cboSchedule
            // 
            this.cboSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchedule.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSchedule.Location = new System.Drawing.Point(31, 192);
            this.cboSchedule.Name = "cboSchedule";
            this.cboSchedule.Size = new System.Drawing.Size(498, 23);
            this.cboSchedule.TabIndex = 5;
            // 
            // lblRotationStart
            // 
            this.lblRotationStart.AutoSize = true;
            this.lblRotationStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRotationStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblRotationStart.Location = new System.Drawing.Point(28, 240);
            this.lblRotationStart.Name = "lblRotationStart";
            this.lblRotationStart.Size = new System.Drawing.Size(116, 15);
            this.lblRotationStart.TabIndex = 6;
            this.lblRotationStart.Text = "Rotation Start Date";
            // 
            // dtpRotationStart
            // 
            this.dtpRotationStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpRotationStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRotationStart.Location = new System.Drawing.Point(31, 264);
            this.dtpRotationStart.Name = "dtpRotationStart";
            this.dtpRotationStart.Size = new System.Drawing.Size(220, 23);
            this.dtpRotationStart.TabIndex = 7;
            // 
            // lblEffectiveFrom
            // 
            this.lblEffectiveFrom.AutoSize = true;
            this.lblEffectiveFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEffectiveFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblEffectiveFrom.Location = new System.Drawing.Point(28, 320);
            this.lblEffectiveFrom.Name = "lblEffectiveFrom";
            this.lblEffectiveFrom.Size = new System.Drawing.Size(90, 15);
            this.lblEffectiveFrom.TabIndex = 8;
            this.lblEffectiveFrom.Text = "Effective From";
            // 
            // dtpEffectiveFrom
            // 
            this.dtpEffectiveFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEffectiveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveFrom.Location = new System.Drawing.Point(31, 344);
            this.dtpEffectiveFrom.Name = "dtpEffectiveFrom";
            this.dtpEffectiveFrom.Size = new System.Drawing.Size(220, 23);
            this.dtpEffectiveFrom.TabIndex = 9;
            // 
            // lblEffectiveTo
            // 
            this.lblEffectiveTo.AutoSize = true;
            this.lblEffectiveTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEffectiveTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblEffectiveTo.Location = new System.Drawing.Point(285, 320);
            this.lblEffectiveTo.Name = "lblEffectiveTo";
            this.lblEffectiveTo.Size = new System.Drawing.Size(130, 15);
            this.lblEffectiveTo.TabIndex = 10;
            this.lblEffectiveTo.Text = "Effective To (optional)";
            // 
            // dtpEffectiveTo
            // 
            this.dtpEffectiveTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEffectiveTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveTo.Location = new System.Drawing.Point(288, 344);
            this.dtpEffectiveTo.Name = "dtpEffectiveTo";
            this.dtpEffectiveTo.ShowCheckBox = true;
            this.dtpEffectiveTo.Size = new System.Drawing.Size(220, 23);
            this.dtpEffectiveTo.TabIndex = 11;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 465);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(20, 12, 24, 12);
            this.pnlFooter.Size = new System.Drawing.Size(560, 70);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(229)))), ((int)(((byte)(240)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.btnCancel.Location = new System.Drawing.Point(362, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 36);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(458, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EmployeeScheduleAssignmentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(560, 535);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeScheduleAssignmentDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee Schedule Assignment";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}