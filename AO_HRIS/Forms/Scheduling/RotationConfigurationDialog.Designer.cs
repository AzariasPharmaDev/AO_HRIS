
namespace AO_HRIS.Forms.Scheduling
{
    partial class RotationConfigurationDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlSchedule = new System.Windows.Forms.Panel();
            this.lblScheduleCaption = new System.Windows.Forms.Label();
            this.lblScheduleName = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.lblRotationName = new System.Windows.Forms.Label();
            this.txtRotationName = new System.Windows.Forms.TextBox();
            this.lblCycleLength = new System.Windows.Forms.Label();
            this.numCycleLength = new System.Windows.Forms.NumericUpDown();
            this.btnGenerateDays = new System.Windows.Forms.Button();
            this.dgvDays = new System.Windows.Forms.DataGridView();
            this.colCycleDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShift = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRestDay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlSchedule.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCycleLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDays)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(760, 78);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(229, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Rotation Configuration";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(215, 226, 241);
            this.lblSubtitle.Location = new System.Drawing.Point(25, 45);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(326, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Configure the repeating cycle of working days and rest days.";
            // 
            // pnlSchedule
            // 
            this.pnlSchedule.BackColor = System.Drawing.Color.White;
            this.pnlSchedule.Controls.Add(this.lblScheduleName);
            this.pnlSchedule.Controls.Add(this.lblScheduleCaption);
            this.pnlSchedule.Location = new System.Drawing.Point(22, 92);
            this.pnlSchedule.Name = "pnlSchedule";
            this.pnlSchedule.Size = new System.Drawing.Size(716, 53);
            this.pnlSchedule.TabIndex = 1;
            // 
            // lblScheduleCaption
            // 
            this.lblScheduleCaption.AutoSize = true;
            this.lblScheduleCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblScheduleCaption.ForeColor = System.Drawing.Color.FromArgb(107, 124, 144);
            this.lblScheduleCaption.Location = new System.Drawing.Point(12, 7);
            this.lblScheduleCaption.Name = "lblScheduleCaption";
            this.lblScheduleCaption.Size = new System.Drawing.Size(91, 15);
            this.lblScheduleCaption.TabIndex = 0;
            this.lblScheduleCaption.Text = "WORK SCHEDULE";
            // 
            // lblScheduleName
            // 
            this.lblScheduleName.AutoSize = true;
            this.lblScheduleName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblScheduleName.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.lblScheduleName.Location = new System.Drawing.Point(12, 25);
            this.lblScheduleName.Name = "lblScheduleName";
            this.lblScheduleName.Size = new System.Drawing.Size(113, 19);
            this.lblScheduleName.TabIndex = 1;
            this.lblScheduleName.Text = "Schedule Name";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.White;
            this.pnlSettings.Controls.Add(this.btnGenerateDays);
            this.pnlSettings.Controls.Add(this.numCycleLength);
            this.pnlSettings.Controls.Add(this.lblCycleLength);
            this.pnlSettings.Controls.Add(this.txtRotationName);
            this.pnlSettings.Controls.Add(this.lblRotationName);
            this.pnlSettings.Location = new System.Drawing.Point(22, 155);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(716, 84);
            this.pnlSettings.TabIndex = 2;
            // 
            // lblRotationName
            // 
            this.lblRotationName.AutoSize = true;
            this.lblRotationName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRotationName.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.lblRotationName.Location = new System.Drawing.Point(13, 10);
            this.lblRotationName.Name = "lblRotationName";
            this.lblRotationName.Size = new System.Drawing.Size(89, 15);
            this.lblRotationName.TabIndex = 0;
            this.lblRotationName.Text = "Rotation Name";
            // 
            // txtRotationName
            // 
            this.txtRotationName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRotationName.Location = new System.Drawing.Point(16, 31);
            this.txtRotationName.MaxLength = 100;
            this.txtRotationName.Name = "txtRotationName";
            this.txtRotationName.Size = new System.Drawing.Size(310, 24);
            this.txtRotationName.TabIndex = 1;
            // 
            // lblCycleLength
            // 
            this.lblCycleLength.AutoSize = true;
            this.lblCycleLength.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCycleLength.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.lblCycleLength.Location = new System.Drawing.Point(348, 10);
            this.lblCycleLength.Name = "lblCycleLength";
            this.lblCycleLength.Size = new System.Drawing.Size(76, 15);
            this.lblCycleLength.TabIndex = 2;
            this.lblCycleLength.Text = "Cycle Length";
            // 
            // numCycleLength
            // 
            this.numCycleLength.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numCycleLength.Location = new System.Drawing.Point(351, 31);
            this.numCycleLength.Maximum = new decimal(new int[] { 366, 0, 0, 0 });
            this.numCycleLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCycleLength.Name = "numCycleLength";
            this.numCycleLength.Size = new System.Drawing.Size(105, 24);
            this.numCycleLength.TabIndex = 3;
            this.numCycleLength.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // btnGenerateDays
            // 
            this.btnGenerateDays.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnGenerateDays.FlatAppearance.BorderSize = 0;
            this.btnGenerateDays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateDays.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerateDays.ForeColor = System.Drawing.Color.White;
            this.btnGenerateDays.Location = new System.Drawing.Point(474, 29);
            this.btnGenerateDays.Name = "btnGenerateDays";
            this.btnGenerateDays.Size = new System.Drawing.Size(220, 29);
            this.btnGenerateDays.TabIndex = 4;
            this.btnGenerateDays.Text = "Generate Cycle Days";
            this.btnGenerateDays.UseVisualStyleBackColor = false;
            this.btnGenerateDays.Click += new System.EventHandler(this.btnGenerateDays_Click);
            // 
            // dgvDays
            // 
            this.dgvDays.AllowUserToAddRows = false;
            this.dgvDays.AllowUserToDeleteRows = false;
            this.dgvDays.BackgroundColor = System.Drawing.Color.White;
            this.dgvDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDays.ColumnHeadersHeight = 38;
            this.dgvDays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCycleDay,
            this.colShift,
            this.colRestDay});
            this.dgvDays.Location = new System.Drawing.Point(22, 251);
            this.dgvDays.Name = "dgvDays";
            this.dgvDays.RowHeadersVisible = false;
            this.dgvDays.RowTemplate.Height = 34;
            this.dgvDays.Size = new System.Drawing.Size(716, 340);
            this.dgvDays.TabIndex = 3;
            // 
            // colCycleDay
            // 
            this.colCycleDay.HeaderText = "Cycle Day";
            this.colCycleDay.Name = "colCycleDay";
            this.colCycleDay.ReadOnly = true;
            this.colCycleDay.Width = 180;
            // 
            // colShift
            // 
            this.colShift.HeaderText = "Assigned Shift";
            this.colShift.Name = "colShift";
            this.colShift.Width = 410;
            // 
            // colRestDay
            // 
            this.colRestDay.HeaderText = "Rest Day";
            this.colRestDay.Name = "colRestDay";
            this.colRestDay.Width = 110;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 610);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(760, 62);
            this.pnlFooter.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 228, 238);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnCancel.Location = new System.Drawing.Point(514, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(626, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Rotation";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // RotationConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.ClientSize = new System.Drawing.Size(760, 672);
            this.Controls.Add(this.dgvDays);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlSchedule);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotationConfigurationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rotation Configuration";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSchedule.ResumeLayout(false);
            this.pnlSchedule.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCycleLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDays)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlSchedule;
        private System.Windows.Forms.Label lblScheduleCaption;
        private System.Windows.Forms.Label lblScheduleName;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblRotationName;
        private System.Windows.Forms.TextBox txtRotationName;
        private System.Windows.Forms.Label lblCycleLength;
        private System.Windows.Forms.NumericUpDown numCycleLength;
        private System.Windows.Forms.Button btnGenerateDays;
        private System.Windows.Forms.DataGridView dgvDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCycleDay;
        private System.Windows.Forms.DataGridViewComboBoxColumn colShift;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRestDay;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
