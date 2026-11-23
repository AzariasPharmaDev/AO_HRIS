
namespace AO_HRIS
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlDashboardHeader;
        private System.Windows.Forms.Panel pnlDashboardBody;

        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDashboardCompany;
        private System.Windows.Forms.Label lblSectionTitle;
        private System.Windows.Forms.Label lblDepartmentTitle;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flwStatistics;
        private System.Windows.Forms.DataGridView dgvDepartmentDistribution;

        private System.Windows.Forms.Panel pnlTotalEmployees;
        private System.Windows.Forms.Panel pnlActiveEmployees;
        private System.Windows.Forms.Panel pnlInactiveEmployees;
        private System.Windows.Forms.Panel pnlDepartments;
        private System.Windows.Forms.Panel pnlAttendance;
        private System.Windows.Forms.Panel pnlPendingLeaves;
        private System.Windows.Forms.Panel pnlApprovedLeaves;

        private System.Windows.Forms.Label lblTotalEmployees;
        private System.Windows.Forms.Label lblActiveEmployees;
        private System.Windows.Forms.Label lblInactiveEmployees;
        private System.Windows.Forms.Label lblTotalDepartments;
        private System.Windows.Forms.Label lblAttendanceEvents;
        private System.Windows.Forms.Label lblPendingLeaves;
        private System.Windows.Forms.Label lblApprovedLeaves;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlDashboardHeader = new System.Windows.Forms.Panel();
            this.pnlDashboardBody = new System.Windows.Forms.Panel();

            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDashboardCompany = new System.Windows.Forms.Label();
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.lblDepartmentTitle = new System.Windows.Forms.Label();

            this.btnRefresh = new System.Windows.Forms.Button();
            this.flwStatistics = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvDepartmentDistribution = new System.Windows.Forms.DataGridView();

            this.pnlTotalEmployees = new System.Windows.Forms.Panel();
            this.pnlActiveEmployees = new System.Windows.Forms.Panel();
            this.pnlInactiveEmployees = new System.Windows.Forms.Panel();
            this.pnlDepartments = new System.Windows.Forms.Panel();
            this.pnlAttendance = new System.Windows.Forms.Panel();
            this.pnlPendingLeaves = new System.Windows.Forms.Panel();
            this.pnlApprovedLeaves = new System.Windows.Forms.Panel();

            this.lblTotalEmployees = new System.Windows.Forms.Label();
            this.lblActiveEmployees = new System.Windows.Forms.Label();
            this.lblInactiveEmployees = new System.Windows.Forms.Label();
            this.lblTotalDepartments = new System.Windows.Forms.Label();
            this.lblAttendanceEvents = new System.Windows.Forms.Label();
            this.lblPendingLeaves = new System.Windows.Forms.Label();
            this.lblApprovedLeaves = new System.Windows.Forms.Label();

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvDepartmentDistribution)).BeginInit();

            this.SuspendLayout();

            // DashboardControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1000, 700);

            this.Controls.Add(this.pnlDashboardBody);
            this.Controls.Add(this.pnlDashboardHeader);

            // Header
            this.pnlDashboardHeader.BackColor = System.Drawing.Color.White;
            this.pnlDashboardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboardHeader.Height = 130;
            this.pnlDashboardHeader.Name = "pnlDashboardHeader";

            this.pnlDashboardHeader.Controls.Add(this.lblPageTitle);
            this.pnlDashboardHeader.Controls.Add(this.lblPageSubtitle);
            this.pnlDashboardHeader.Controls.Add(this.lblDashboardCompany);
            this.pnlDashboardHeader.Controls.Add(this.lblWelcome);
            this.pnlDashboardHeader.Controls.Add(this.btnRefresh);

            // Title
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font(
                "Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor =
                System.Drawing.Color.FromArgb(24, 48, 82);
            this.lblPageTitle.Location = new System.Drawing.Point(28, 15);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Text = "Dashboard";

            // Subtitle
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPageSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(106, 124, 148);
            this.lblPageSubtitle.Location =
                new System.Drawing.Point(30, 61);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Text =
                "HR and workforce overview";

            // Company
            this.lblDashboardCompany.AutoSize = true;
            this.lblDashboardCompany.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDashboardCompany.ForeColor =
                System.Drawing.Color.FromArgb(25, 89, 183);
            this.lblDashboardCompany.Location =
                new System.Drawing.Point(30, 94);
            this.lblDashboardCompany.Name = "lblDashboardCompany";
            this.lblDashboardCompany.Text = "Company: Loading...";

            // Welcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Text = "";
            this.lblWelcome.Visible = false;

            // Refresh button
            this.btnRefresh.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.BackColor =
                System.Drawing.Color.FromArgb(30, 100, 190);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(875, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click +=
                new System.EventHandler(this.BtnRefresh_Click);

            // Body
            this.pnlDashboardBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboardBody.Name = "pnlDashboardBody";
            this.pnlDashboardBody.Padding =
                new System.Windows.Forms.Padding(24, 18, 24, 20);

            this.pnlDashboardBody.Controls.Add(
                this.dgvDepartmentDistribution);
            this.pnlDashboardBody.Controls.Add(
                this.lblDepartmentTitle);
            this.pnlDashboardBody.Controls.Add(
                this.flwStatistics);
            this.pnlDashboardBody.Controls.Add(
                this.lblSectionTitle);

            // Section title
            this.lblSectionTitle.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.lblSectionTitle.Height = 35;
            this.lblSectionTitle.Name = "lblSectionTitle";
            this.lblSectionTitle.Text = "Workforce overview";
            this.lblSectionTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitle.ForeColor =
                System.Drawing.Color.FromArgb(31, 55, 88);

            // Statistics container
            this.flwStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwStatistics.Height = 350;
            this.flwStatistics.AutoScroll = true;
            this.flwStatistics.FlowDirection =
                System.Windows.Forms.FlowDirection.LeftToRight;
            this.flwStatistics.WrapContents = true;
            this.flwStatistics.Name = "flwStatistics";
            this.flwStatistics.BackColor = System.Drawing.Color.Transparent;
            this.flwStatistics.Padding =
                new System.Windows.Forms.Padding(0, 8, 0, 0);

            this.flwStatistics.Controls.Add(this.pnlTotalEmployees);
            this.flwStatistics.Controls.Add(this.pnlActiveEmployees);
            this.flwStatistics.Controls.Add(this.pnlInactiveEmployees);
            this.flwStatistics.Controls.Add(this.pnlDepartments);
            this.flwStatistics.Controls.Add(this.pnlAttendance);
            this.flwStatistics.Controls.Add(this.pnlPendingLeaves);
            this.flwStatistics.Controls.Add(this.pnlApprovedLeaves);

            // Statistic cards
            ConfigureCard(
                this.pnlTotalEmployees,
                this.lblTotalEmployees,
                this.label1,
                "Total Employees",
                System.Drawing.Color.FromArgb(25, 89, 183));

            ConfigureCard(
                this.pnlActiveEmployees,
                this.lblActiveEmployees,
                this.label2,
                "Active Employees",
                System.Drawing.Color.FromArgb(21, 140, 92));

            ConfigureCard(
                this.pnlInactiveEmployees,
                this.lblInactiveEmployees,
                this.label3,
                "Inactive Employees",
                System.Drawing.Color.FromArgb(190, 104, 40));

            ConfigureCard(
                this.pnlDepartments,
                this.lblTotalDepartments,
                this.label4,
                "Total Departments",
                System.Drawing.Color.FromArgb(112, 66, 170));

            ConfigureCard(
                this.pnlAttendance,
                this.lblAttendanceEvents,
                this.label5,
                "Attendance Events Today",
                System.Drawing.Color.FromArgb(30, 130, 150));

            ConfigureCard(
                this.pnlPendingLeaves,
                this.lblPendingLeaves,
                this.label6,
                "Pending Leave Requests",
                System.Drawing.Color.FromArgb(190, 130, 35));

            ConfigureCard(
                this.pnlApprovedLeaves,
                this.lblApprovedLeaves,
                this.label7,
                "Approved Leave Requests",
                System.Drawing.Color.FromArgb(21, 140, 92));

            // Department section title
            this.lblDepartmentTitle.Dock =
                System.Windows.Forms.DockStyle.Top;
            this.lblDepartmentTitle.Height = 38;
            this.lblDepartmentTitle.Name = "lblDepartmentTitle";
            this.lblDepartmentTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDepartmentTitle.ForeColor =
                System.Drawing.Color.FromArgb(31, 55, 88);
            this.lblDepartmentTitle.Text =
                "Employee distribution by department";
            this.lblDepartmentTitle.Padding =
                new System.Windows.Forms.Padding(0, 8, 0, 0);

            // Department table
            this.dgvDepartmentDistribution.Dock =
                System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartmentDistribution.Name =
                "dgvDepartmentDistribution";
            this.dgvDepartmentDistribution.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvDepartmentDistribution.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDepartmentDistribution.AllowUserToAddRows = false;
            this.dgvDepartmentDistribution.AllowUserToDeleteRows = false;
            this.dgvDepartmentDistribution.AllowUserToResizeRows = false;
            this.dgvDepartmentDistribution.ReadOnly = true;
            this.dgvDepartmentDistribution.MultiSelect = false;
            this.dgvDepartmentDistribution.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartmentDistribution.RowHeadersVisible = false;
            this.dgvDepartmentDistribution.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartmentDistribution.EnableHeadersVisualStyles = false;

            this.dgvDepartmentDistribution.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(240, 245, 251);
            this.dgvDepartmentDistribution.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.dgvDepartmentDistribution.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvDepartmentDistribution.ColumnHeadersHeight = 38;

            this.dgvDepartmentDistribution.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDepartmentDistribution.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);
            this.dgvDepartmentDistribution.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(219, 235, 255);
            this.dgvDepartmentDistribution.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(40, 57, 77);

            this.dgvDepartmentDistribution.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(248, 250, 253);
            this.dgvDepartmentDistribution.RowTemplate.Height = 34;

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvDepartmentDistribution)).EndInit();

            this.pnlDashboardBody.ResumeLayout(false);
            this.pnlDashboardHeader.ResumeLayout(false);
            this.pnlDashboardHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        internal void ConfigureCard(
            System.Windows.Forms.Panel panel,
            System.Windows.Forms.Label value,
            System.Windows.Forms.Label caption,
            string title,
            System.Drawing.Color valueColor)
        {
            panel.BackColor = System.Drawing.Color.White;
            panel.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            panel.Margin =
                new System.Windows.Forms.Padding(0, 0, 16, 16);
            panel.Size =
                new System.Drawing.Size(274, 152);

            panel.Controls.Add(value);
            panel.Controls.Add(caption);

            value.AutoSize = true;
            value.Location =
                new System.Drawing.Point(20, 31);
            value.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    25F,
                    System.Drawing.FontStyle.Bold);
            value.ForeColor = valueColor;
            value.Text = "0";

            caption.AutoSize = true;
            caption.Location =
                new System.Drawing.Point(20, 91);
            caption.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            caption.ForeColor =
                System.Drawing.Color.FromArgb(103, 120, 145);
            caption.Text = title;
        }

        #endregion
    }
}
