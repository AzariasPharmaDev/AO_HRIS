namespace AO_HRIS.Forms.Scheduling
{
    partial class WorkShiftDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblShiftName = new System.Windows.Forms.Label();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblBreak = new System.Windows.Forms.Label();
            this.nudBreak = new System.Windows.Forms.NumericUpDown();
            this.lblGrace = new System.Windows.Forms.Label();
            this.nudGrace = new System.Windows.Forms.NumericUpDown();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGrace)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(28, 55, 91);

            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.pnlHeader.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.pnlHeader.Location =
                new System.Drawing.Point(0, 0);

            this.pnlHeader.Name = "pnlHeader";

            this.pnlHeader.Size =
                new System.Drawing.Size(470, 82);

            this.pnlHeader.TabIndex = 0;

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(218, 229, 244);

            this.lblSubtitle.Location =
                new System.Drawing.Point(22, 49);

            this.lblSubtitle.Name = "lblSubtitle";

            this.lblSubtitle.Size =
                new System.Drawing.Size(261, 15);

            this.lblSubtitle.TabIndex = 1;

            this.lblSubtitle.Text =
                "Set the shift hours and attendance allowances.";

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    15F,
                    System.Drawing.FontStyle.Bold
                );

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(20, 13);

            this.lblTitle.Name = "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(129, 28);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text = "Work Shift";

            // 
            // lblShiftName
            // 
            this.lblShiftName.AutoSize = true;

            this.lblShiftName.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);

            this.lblShiftName.Location =
                new System.Drawing.Point(25, 108);

            this.lblShiftName.Name = "lblShiftName";

            this.lblShiftName.Size =
                new System.Drawing.Size(67, 15);

            this.lblShiftName.TabIndex = 1;

            this.lblShiftName.Text = "Shift name";

            // 
            // txtShiftName
            // 
            this.txtShiftName.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtShiftName.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtShiftName.Location =
                new System.Drawing.Point(28, 130);

            this.txtShiftName.MaxLength = 100;

            this.txtShiftName.Name = "txtShiftName";

            this.txtShiftName.Size =
                new System.Drawing.Size(414, 25);

            this.txtShiftName.TabIndex = 2;

            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;

            this.lblStart.Location =
                new System.Drawing.Point(25, 177);

            this.lblStart.Name = "lblStart";

            this.lblStart.Size =
                new System.Drawing.Size(59, 15);

            this.lblStart.TabIndex = 3;

            this.lblStart.Text = "Start time";

            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "hh:mm tt";

            this.dtpStart.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;

            this.dtpStart.ShowUpDown = true;

            this.dtpStart.Location =
                new System.Drawing.Point(28, 199);

            this.dtpStart.Name = "dtpStart";

            this.dtpStart.Size =
                new System.Drawing.Size(190, 23);

            this.dtpStart.TabIndex = 4;

            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;

            this.lblEnd.Location =
                new System.Drawing.Point(251, 177);

            this.lblEnd.Name = "lblEnd";

            this.lblEnd.Size =
                new System.Drawing.Size(55, 15);

            this.lblEnd.TabIndex = 5;

            this.lblEnd.Text = "End time";

            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "hh:mm tt";

            this.dtpEnd.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;

            this.dtpEnd.ShowUpDown = true;

            this.dtpEnd.Location =
                new System.Drawing.Point(254, 199);

            this.dtpEnd.Name = "dtpEnd";

            this.dtpEnd.Size =
                new System.Drawing.Size(188, 23);

            this.dtpEnd.TabIndex = 6;

            // 
            // lblBreak
            // 
            this.lblBreak.AutoSize = true;

            this.lblBreak.Location =
                new System.Drawing.Point(25, 249);

            this.lblBreak.Name = "lblBreak";

            this.lblBreak.Size =
                new System.Drawing.Size(83, 15);

            this.lblBreak.TabIndex = 7;

            this.lblBreak.Text = "Break (minutes)";

            // 
            // nudBreak
            // 
            this.nudBreak.Location =
                new System.Drawing.Point(28, 271);

            this.nudBreak.Maximum =
                new decimal(new int[] { 1440, 0, 0, 0 });

            this.nudBreak.Name = "nudBreak";

            this.nudBreak.Size =
                new System.Drawing.Size(190, 23);

            this.nudBreak.TabIndex = 8;

            // 
            // lblGrace
            // 
            this.lblGrace.AutoSize = true;

            this.lblGrace.Location =
                new System.Drawing.Point(251, 249);

            this.lblGrace.Name = "lblGrace";

            this.lblGrace.Size =
                new System.Drawing.Size(113, 15);

            this.lblGrace.TabIndex = 9;

            this.lblGrace.Text = "Grace period (minutes)";

            // 
            // nudGrace
            // 
            this.nudGrace.Location =
                new System.Drawing.Point(254, 271);

            this.nudGrace.Maximum =
                new decimal(new int[] { 1440, 0, 0, 0 });

            this.nudGrace.Name = "nudGrace";

            this.nudGrace.Size =
                new System.Drawing.Size(188, 23);

            this.nudGrace.TabIndex = 10;

            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;

            this.chkActive.CheckState =
                System.Windows.Forms.CheckState.Checked;

            this.chkActive.Location =
                new System.Drawing.Point(28, 318);

            this.chkActive.Name = "chkActive";

            this.chkActive.Size =
                new System.Drawing.Size(59, 19);

            this.chkActive.TabIndex = 11;

            this.chkActive.Text = "Active";

            this.chkActive.UseVisualStyleBackColor = true;

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor =
                System.Drawing.Color.FromArgb(247, 250, 254);

            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);

            this.pnlFooter.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            this.pnlFooter.Location =
                new System.Drawing.Point(0, 365);

            this.pnlFooter.Name = "pnlFooter";

            this.pnlFooter.Size =
                new System.Drawing.Size(470, 64);

            this.pnlFooter.TabIndex = 12;

            // 
            // btnCancel
            // 
            this.btnCancel.Anchor =
                System.Windows.Forms.AnchorStyles.Right;

            this.btnCancel.BackColor =
                System.Drawing.Color.White;

            this.btnCancel.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(220, 230, 241);

            this.btnCancel.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCancel.Location =
                new System.Drawing.Point(258, 15);

            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size =
                new System.Drawing.Size(84, 34);

            this.btnCancel.TabIndex = 1;

            this.btnCancel.Text = "Cancel";

            this.btnCancel.UseVisualStyleBackColor = false;

            this.btnCancel.Click +=
                new System.EventHandler(this.btnCancel_Click);

            // 
            // btnSave
            // 
            this.btnSave.Anchor =
                System.Windows.Forms.AnchorStyles.Right;

            this.btnSave.BackColor =
                System.Drawing.Color.FromArgb(35, 106, 213);

            this.btnSave.FlatAppearance.BorderSize = 0;

            this.btnSave.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSave.ForeColor =
                System.Drawing.Color.White;

            this.btnSave.Location =
                new System.Drawing.Point(352, 15);

            this.btnSave.Name = "btnSave";

            this.btnSave.Size =
                new System.Drawing.Size(90, 34);

            this.btnSave.TabIndex = 0;

            this.btnSave.Text = "Save";

            this.btnSave.UseVisualStyleBackColor = false;

            this.btnSave.Click +=
                new System.EventHandler(this.btnSave_Click);

            // 
            // WorkShiftDialog
            // 
            this.AcceptButton = this.btnSave;

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.White;

            this.CancelButton = this.btnCancel;

            this.ClientSize =
                new System.Drawing.Size(470, 429);

            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.nudGrace);
            this.Controls.Add(this.lblGrace);
            this.Controls.Add(this.nudBreak);
            this.Controls.Add(this.lblBreak);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtShiftName);
            this.Controls.Add(this.lblShiftName);
            this.Controls.Add(this.pnlHeader);

            this.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name = "WorkShiftDialog";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Work Shift";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.nudBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGrace)).EndInit();

            this.pnlFooter.ResumeLayout(false);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblShiftName;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblBreak;
        private System.Windows.Forms.NumericUpDown nudBreak;
        private System.Windows.Forms.Label lblGrace;
        private System.Windows.Forms.NumericUpDown nudGrace;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}