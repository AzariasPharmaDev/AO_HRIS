
namespace AO_HRIS.Forms.Scheduling
{
    partial class SchedulingManagementControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlContent = new System.Windows.Forms.Panel();
            this.tabScheduling = new System.Windows.Forms.TabControl();
            this.tabWorkShifts = new System.Windows.Forms.TabPage();
            this.tabWorkSchedules = new System.Windows.Forms.TabPage();
            this.tabEmployeeScheduleAssignments = new System.Windows.Forms.TabPage();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnToggleActive = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();

            this.dgvShifts = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tabScheduling.SuspendLayout();
            this.tabWorkShifts.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(28, 18, 28, 16);
            this.pnlHeader.Size = new System.Drawing.Size(1000, 112);
            this.pnlHeader.TabIndex = 0;

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 124, 144);
            this.lblSubtitle.Location = new System.Drawing.Point(31, 65);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(391, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage work shifts and employee work schedules.";

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.lblTitle.Location = new System.Drawing.Point(27, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(151, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Scheduling";

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.pnlContent.Controls.Add(this.tabScheduling);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 112);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(24, 16, 24, 24);
            this.pnlContent.Size = new System.Drawing.Size(1000, 640);
            this.pnlContent.TabIndex = 1;

            // tabScheduling
            this.tabScheduling.Controls.Add(this.tabWorkShifts);
            this.tabScheduling.Controls.Add(this.tabWorkSchedules);
            this.tabScheduling.Controls.Add(this.tabEmployeeScheduleAssignments);
            this.tabScheduling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabScheduling.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabScheduling.Location = new System.Drawing.Point(24, 16);
            this.tabScheduling.Name = "tabScheduling";
            this.tabScheduling.SelectedIndex = 0;
            this.tabScheduling.Size = new System.Drawing.Size(952, 600);
            this.tabScheduling.TabIndex = 0;

            // tabWorkShifts
            this.tabWorkShifts.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.tabWorkShifts.Controls.Add(this.dgvShifts);
            this.tabWorkShifts.Controls.Add(this.pnlToolbar);
            this.tabWorkShifts.Location = new System.Drawing.Point(4, 24);
            this.tabWorkShifts.Name = "tabWorkShifts";
            this.tabWorkShifts.Padding = new System.Windows.Forms.Padding(16);
            this.tabWorkShifts.Size = new System.Drawing.Size(944, 572);
            this.tabWorkShifts.TabIndex = 0;
            this.tabWorkShifts.Text = "Work Shifts";
            this.tabWorkShifts.UseVisualStyleBackColor = false;

            // tabWorkSchedules
            this.tabWorkSchedules.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.tabWorkSchedules.Location = new System.Drawing.Point(4, 24);
            this.tabWorkSchedules.Name = "tabWorkSchedules";
            this.tabWorkSchedules.Padding = new System.Windows.Forms.Padding(0);
            this.tabWorkSchedules.Size = new System.Drawing.Size(944, 572);
            this.tabWorkSchedules.TabIndex = 1;
            this.tabWorkSchedules.Text = "Work Schedules";
            this.tabWorkSchedules.UseVisualStyleBackColor = false;
            // tabEmployeeScheduleAssignments
            this.tabEmployeeScheduleAssignments.BackColor =
                System.Drawing.Color.FromArgb(247, 250, 254);
            this.tabEmployeeScheduleAssignments.Location =
                new System.Drawing.Point(4, 24);
            this.tabEmployeeScheduleAssignments.Name =
                "tabEmployeeScheduleAssignments";
            this.tabEmployeeScheduleAssignments.Padding =
                new System.Windows.Forms.Padding(0);
            this.tabEmployeeScheduleAssignments.Size =
                new System.Drawing.Size(944, 572);
            this.tabEmployeeScheduleAssignments.TabIndex = 2;
            this.tabEmployeeScheduleAssignments.Text =
                "Employee Schedule Assignments";
            this.tabEmployeeScheduleAssignments.UseVisualStyleBackColor = false;

            // pnlToolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.lblCount);
            this.pnlToolbar.Controls.Add(this.chkIncludeInactive);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.btnToggleActive);
            this.pnlToolbar.Controls.Add(this.btnEdit);
            this.pnlToolbar.Controls.Add(this.btnAdd);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(16, 16);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size = new System.Drawing.Size(912, 62);
            this.pnlToolbar.TabIndex = 0;

            // lblCount
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(107, 124, 144);
            this.lblCount.Location = new System.Drawing.Point(19, 23);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(90, 15);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "0 work shift(s)";

            // chkIncludeInactive
            this.chkIncludeInactive.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkIncludeInactive.ForeColor = System.Drawing.Color.FromArgb(61, 78, 100);
            this.chkIncludeInactive.Location = new System.Drawing.Point(417, 22);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.Size = new System.Drawing.Size(110, 19);
            this.chkIncludeInactive.TabIndex = 4;
            this.chkIncludeInactive.Text = "Show inactive";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            this.chkIncludeInactive.CheckedChanged +=
                new System.EventHandler(this.chkIncludeInactive_CheckedChanged);

            // btnRefresh
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(194, 210, 228);
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(234, 242, 252);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnRefresh.Location = new System.Drawing.Point(539, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(82, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click +=
                new System.EventHandler(this.btnRefresh_Click);

            // btnToggleActive
            this.btnToggleActive.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnToggleActive.BackColor = System.Drawing.Color.White;
            this.btnToggleActive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(194, 210, 228);
            this.btnToggleActive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(234, 242, 252);
            this.btnToggleActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleActive.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleActive.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnToggleActive.Location = new System.Drawing.Point(627, 13);
            this.btnToggleActive.Name = "btnToggleActive";
            this.btnToggleActive.Size = new System.Drawing.Size(100, 36);
            this.btnToggleActive.TabIndex = 2;
            this.btnToggleActive.Text = "Activate";
            this.btnToggleActive.UseVisualStyleBackColor = false;
            this.btnToggleActive.Click +=
                new System.EventHandler(this.btnToggleActive_Click);

            // btnEdit
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(194, 210, 228);
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(234, 242, 252);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnEdit.Location = new System.Drawing.Point(733, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click +=
                new System.EventHandler(this.btnEdit_Click);

            // btnAdd
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(27, 87, 180);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(809, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+ Add Shift";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click +=
                new System.EventHandler(this.btnAdd_Click);

            // dgvShifts
            this.dgvShifts.AllowUserToAddRows = false;
            this.dgvShifts.AllowUserToDeleteRows = false;
            this.dgvShifts.AllowUserToResizeRows = false;
            this.dgvShifts.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvShifts.BackgroundColor = System.Drawing.Color.White;
            this.dgvShifts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShifts.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvShifts.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvShifts.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(234, 242, 252);
            this.dgvShifts.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dgvShifts.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.dgvShifts.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(234, 242, 252);
            this.dgvShifts.ColumnHeadersHeight = 44;
            this.dgvShifts.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvShifts.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvShifts.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.dgvShifts.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.dgvShifts.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(219, 235, 255);
            this.dgvShifts.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(28, 55, 91);
            this.dgvShifts.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(248, 251, 255);
            this.dgvShifts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShifts.EnableHeadersVisualStyles = false;
            this.dgvShifts.GridColor = System.Drawing.Color.FromArgb(228, 235, 243);
            this.dgvShifts.Location = new System.Drawing.Point(16, 78);
            this.dgvShifts.MultiSelect = false;
            this.dgvShifts.Name = "dgvShifts";
            this.dgvShifts.ReadOnly = true;
            this.dgvShifts.RowHeadersVisible = false;
            this.dgvShifts.RowTemplate.Height = 40;
            this.dgvShifts.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShifts.TabIndex = 1;
            this.dgvShifts.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShifts_CellDoubleClick);

            // SchedulingManagementControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SchedulingManagementControl";
            this.Size = new System.Drawing.Size(1000, 752);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.tabScheduling.ResumeLayout(false);
            this.tabWorkShifts.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TabControl tabScheduling;
        private System.Windows.Forms.TabPage tabWorkShifts;
        private System.Windows.Forms.TabPage tabWorkSchedules;
        private System.Windows.Forms.TabPage tabEmployeeScheduleAssignments;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckBox chkIncludeInactive;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnToggleActive;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;

        private System.Windows.Forms.DataGridView dgvShifts;
    }
}
