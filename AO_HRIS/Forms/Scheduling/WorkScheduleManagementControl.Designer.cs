
namespace AO_HRIS.Forms.Scheduling
{
    partial class WorkScheduleManagementControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnConfigureRotation;
        private System.Windows.Forms.Button btnToggleActive;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkIncludeInactive;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvSchedules;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnToggleActive = new System.Windows.Forms.Button();
            this.btnConfigureRotation = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 18, 24, 12);
            this.pnlHeader.Size = new System.Drawing.Size(1100, 88);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 18F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.lblTitle.Location = new System.Drawing.Point(24, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Work Schedule Management";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 124, 144);
            this.lblSubtitle.Location = new System.Drawing.Point(27, 49);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(400, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text =
                "Create and manage weekly work schedules for this company.";

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.dgvSchedules);
            this.pnlContent.Controls.Add(this.pnlToolbar);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 88);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(1100, 612);
            this.pnlContent.TabIndex = 1;

            // pnlToolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.lblCount);
            this.pnlToolbar.Controls.Add(this.chkIncludeInactive);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.btnToggleActive);
            this.pnlToolbar.Controls.Add(this.btnConfigureRotation);
            this.pnlToolbar.Controls.Add(this.btnEdit);
            this.pnlToolbar.Controls.Add(this.btnAdd);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(20, 20);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1060, 54);
            this.pnlToolbar.TabIndex = 0;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(0, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+  Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(194, 210, 228);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnEdit.Location = new System.Drawing.Point(113, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnConfigureRotation
            this.btnConfigureRotation.BackColor = System.Drawing.Color.White;
            this.btnConfigureRotation.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(194, 210, 228);
            this.btnConfigureRotation.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigureRotation.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnConfigureRotation.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnConfigureRotation.Location =
                new System.Drawing.Point(211, 5);
            this.btnConfigureRotation.Name = "btnConfigureRotation";
            this.btnConfigureRotation.Size =
                new System.Drawing.Size(145, 36);
            this.btnConfigureRotation.TabIndex = 2;
            this.btnConfigureRotation.Text = "Configure Rotation";
            this.btnConfigureRotation.UseVisualStyleBackColor = false;
            this.btnConfigureRotation.Click +=
                new System.EventHandler(this.btnConfigureRotation_Click);

            // btnToggleActive
            this.btnToggleActive.BackColor = System.Drawing.Color.White;
            this.btnToggleActive.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(194, 210, 228);
            this.btnToggleActive.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleActive.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnToggleActive.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnToggleActive.Location =
                new System.Drawing.Point(364, 5);
            this.btnToggleActive.Name = "btnToggleActive";
            this.btnToggleActive.Size =
                new System.Drawing.Size(135, 36);
            this.btnToggleActive.TabIndex = 3;
            this.btnToggleActive.Text = "Activate / Disable";
            this.btnToggleActive.UseVisualStyleBackColor = false;
            this.btnToggleActive.Click +=
                new System.EventHandler(this.btnToggleActive_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(194, 210, 228);
            this.btnRefresh.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 9F,
                System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnRefresh.Location =
                new System.Drawing.Point(507, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size =
                new System.Drawing.Size(90, 36);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click +=
                new System.EventHandler(this.btnRefresh_Click);

            // chkIncludeInactive
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkIncludeInactive.ForeColor =
                System.Drawing.Color.FromArgb(61, 78, 100);
            this.chkIncludeInactive.Location =
                new System.Drawing.Point(619, 14);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.Size =
                new System.Drawing.Size(111, 19);
            this.chkIncludeInactive.TabIndex = 5;
            this.chkIncludeInactive.Text = "Include inactive";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            this.chkIncludeInactive.CheckedChanged +=
                new System.EventHandler(this.chkIncludeInactive_CheckedChanged);

            // lblCount
            this.lblCount.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor =
                System.Drawing.Color.FromArgb(107, 124, 144);
            this.lblCount.Location =
                new System.Drawing.Point(825, 14);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(235, 20);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "0 schedule(s)";
            this.lblCount.TextAlign =
                System.Drawing.ContentAlignment.MiddleRight;

            // dgvSchedules
            this.dgvSchedules.AllowUserToAddRows = false;
            this.dgvSchedules.AllowUserToDeleteRows = false;
            this.dgvSchedules.AllowUserToResizeRows = false;
            this.dgvSchedules.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvSchedules.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSchedules.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSchedules.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSchedules.ColumnHeadersHeight = 42;
            this.dgvSchedules.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedules.EnableHeadersVisualStyles = false;
            this.dgvSchedules.GridColor =
                System.Drawing.Color.FromArgb(228, 235, 243);
            this.dgvSchedules.Location = new System.Drawing.Point(20, 74);
            this.dgvSchedules.MultiSelect = false;
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.ReadOnly = true;
            this.dgvSchedules.RowHeadersVisible = false;
            this.dgvSchedules.RowTemplate.Height = 38;
            this.dgvSchedules.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedules.Size = new System.Drawing.Size(1060, 518);
            this.dgvSchedules.TabIndex = 1;

            this.dgvSchedules.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(247, 250, 254);
            this.dgvSchedules.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(61, 78, 100);
            this.dgvSchedules.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI Semibold", 9F,
                    System.Drawing.FontStyle.Bold);
            this.dgvSchedules.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(247, 250, 254);
            this.dgvSchedules.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(61, 78, 100);

            this.dgvSchedules.DefaultCellStyle.BackColor =
                System.Drawing.Color.White;
            this.dgvSchedules.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.dgvSchedules.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.dgvSchedules.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(219, 235, 255);
            this.dgvSchedules.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(28, 55, 91);
            this.dgvSchedules.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(250, 252, 255);

            this.dgvSchedules.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvSchedules_CellDoubleClick);

            // WorkScheduleManagementControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "WorkScheduleManagementControl";
            this.Size = new System.Drawing.Size(1100, 700);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
