namespace AO_HRIS.Forms.Scheduling
{
    partial class EmployeeScheduleAssignmentControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvAssignments;

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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 82;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(22, 14, 22, 10);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.lblTitle.Location = new System.Drawing.Point(22, 12);
            this.lblTitle.Text = "Employee Schedule Assignments";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font(
                "Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 124, 144);
            this.lblSubtitle.Location = new System.Drawing.Point(25, 48);
            this.lblSubtitle.Text =
                "Manage work schedules assigned to employee assignments.";

            // pnlToolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.pnlToolbar.Controls.Add(this.lblCount);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.btnEdit);
            this.pnlToolbar.Controls.Add(this.btnAdd);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 58;
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(20, 10, 20, 8);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(22, 10);
            this.btnAdd.Size = new System.Drawing.Size(105, 36);
            this.btnAdd.Text = "+ Assign";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(220, 229, 240);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnEdit.Location = new System.Drawing.Point(137, 10);
            this.btnEdit.Size = new System.Drawing.Size(95, 36);
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(220, 229, 240);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(40, 57, 77);
            this.btnRefresh.Location = new System.Drawing.Point(242, 10);
            this.btnRefresh.Size = new System.Drawing.Size(95, 36);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // lblCount
            this.lblCount.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(107, 124, 144);
            this.lblCount.Location = new System.Drawing.Point(650, 20);
            this.lblCount.Text = "0 schedule assignment(s)";

            // dgvAssignments
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            this.dgvAssignments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAssignments.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvAssignments.ColumnHeadersHeight = 42;
            this.dgvAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssignments.EnableHeadersVisualStyles = false;
            this.dgvAssignments.GridColor =
                System.Drawing.Color.FromArgb(228, 235, 243);
            this.dgvAssignments.RowHeadersVisible = false;
            this.dgvAssignments.RowTemplate.Height = 36;
            this.dgvAssignments.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvAssignments_CellDoubleClick);

            this.dgvAssignments.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(247, 250, 254);
            this.dgvAssignments.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.dgvAssignments.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);
            this.dgvAssignments.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.dgvAssignments.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.dgvAssignments.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(219, 235, 255);
            this.dgvAssignments.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(28, 55, 91);

            // EmployeeScheduleAssignmentControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.Controls.Add(this.dgvAssignments);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "EmployeeScheduleAssignmentControl";
            this.Size = new System.Drawing.Size(900, 550);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.ResumeLayout(false);
        }
    }
}