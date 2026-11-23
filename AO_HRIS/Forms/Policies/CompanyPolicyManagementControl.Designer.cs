namespace AO_HRIS.Forms.Policies
{
    partial class CompanyPolicyManagementControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPolicies;
        private System.Windows.Forms.TabPage tabMyPolicies;
        private System.Windows.Forms.TabPage tabCompliance;
        private System.Windows.Forms.Panel pnlPoliciesToolbar;
        private System.Windows.Forms.Label lblPoliciesTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNewPolicy;
        private System.Windows.Forms.Button btnEditPolicy;
        private System.Windows.Forms.Button btnNewRevision;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnDownloadPolicy;
        private System.Windows.Forms.DataGridView gridPolicies;
        private System.Windows.Forms.Panel pnlMyPoliciesToolbar;
        private System.Windows.Forms.Label lblMyPoliciesTitle;
        private System.Windows.Forms.Button btnRefreshMyPolicies;
        private System.Windows.Forms.Button btnAcknowledge;
        private System.Windows.Forms.Button btnDownloadMyPolicy;
        private System.Windows.Forms.DataGridView gridMyPolicies;
        private System.Windows.Forms.Panel pnlComplianceToolbar;
        private System.Windows.Forms.Label lblComplianceTitle;
        private System.Windows.Forms.ComboBox cboPolicyFilter;
        private System.Windows.Forms.Button btnRefreshCompliance;
        private System.Windows.Forms.DataGridView gridCompliance;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPolicy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPolicies = new System.Windows.Forms.TabPage();
            this.gridPolicies = new System.Windows.Forms.DataGridView();
            this.pnlPoliciesToolbar = new System.Windows.Forms.Panel();
            this.btnDownloadPolicy = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnNewRevision = new System.Windows.Forms.Button();
            this.btnNewPolicy = new System.Windows.Forms.Button();
            this.btnEditPolicy = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblPoliciesTitle = new System.Windows.Forms.Label();
            this.tabMyPolicies = new System.Windows.Forms.TabPage();
            this.gridMyPolicies = new System.Windows.Forms.DataGridView();
            this.pnlMyPoliciesToolbar = new System.Windows.Forms.Panel();
            this.btnDownloadMyPolicy = new System.Windows.Forms.Button();
            this.btnAcknowledge = new System.Windows.Forms.Button();
            this.btnRefreshMyPolicies = new System.Windows.Forms.Button();
            this.lblMyPoliciesTitle = new System.Windows.Forms.Label();
            this.tabCompliance = new System.Windows.Forms.TabPage();
            this.gridCompliance = new System.Windows.Forms.DataGridView();
            this.pnlComplianceToolbar = new System.Windows.Forms.Panel();
            this.btnRefreshCompliance = new System.Windows.Forms.Button();
            this.cboPolicyFilter = new System.Windows.Forms.ComboBox();
            this.lblComplianceTitle = new System.Windows.Forms.Label();
            this.saveFileDialogPolicy = new System.Windows.Forms.SaveFileDialog();
            this.tabMain.SuspendLayout();
            this.tabPolicies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPolicies)).BeginInit();
            this.pnlPoliciesToolbar.SuspendLayout();
            this.tabMyPolicies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMyPolicies)).BeginInit();
            this.pnlMyPoliciesToolbar.SuspendLayout();
            this.tabCompliance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompliance)).BeginInit();
            this.pnlComplianceToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPolicies);
            this.tabMain.Controls.Add(this.tabMyPolicies);
            this.tabMain.Controls.Add(this.tabCompliance);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1100, 700);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.TabMain_SelectedIndexChanged);
            // 
            // tabPolicies
            // 
            this.tabPolicies.Controls.Add(this.gridPolicies);
            this.tabPolicies.Controls.Add(this.pnlPoliciesToolbar);
            this.tabPolicies.Location = new System.Drawing.Point(4, 24);
            this.tabPolicies.Name = "tabPolicies";
            this.tabPolicies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPolicies.Size = new System.Drawing.Size(1092, 672);
            this.tabPolicies.TabIndex = 0;
            this.tabPolicies.Text = "Policy Management";
            this.tabPolicies.UseVisualStyleBackColor = true;
            // 
            // gridPolicies
            // 
            this.gridPolicies.AllowUserToAddRows = false;
            this.gridPolicies.AllowUserToDeleteRows = false;
            this.gridPolicies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPolicies.BackgroundColor = System.Drawing.Color.White;
            this.gridPolicies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPolicies.ColumnHeadersHeight = 38;
            this.gridPolicies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPolicies.Location = new System.Drawing.Point(3, 75);
            this.gridPolicies.MultiSelect = false;
            this.gridPolicies.Name = "gridPolicies";
            this.gridPolicies.ReadOnly = true;
            this.gridPolicies.RowHeadersVisible = false;
            this.gridPolicies.RowTemplate.Height = 34;
            this.gridPolicies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPolicies.Size = new System.Drawing.Size(1086, 594);
            this.gridPolicies.TabIndex = 1;
            this.gridPolicies.SelectionChanged += new System.EventHandler(this.GridPolicies_SelectionChanged);
            // 
            // pnlPoliciesToolbar
            // 
            this.pnlPoliciesToolbar.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.pnlPoliciesToolbar.Controls.Add(this.btnDownloadPolicy);
            this.pnlPoliciesToolbar.Controls.Add(this.btnArchive);
            this.pnlPoliciesToolbar.Controls.Add(this.btnPublish);
            this.pnlPoliciesToolbar.Controls.Add(this.btnNewRevision);
            this.pnlPoliciesToolbar.Controls.Add(this.btnNewPolicy);
            this.pnlPoliciesToolbar.Controls.Add(this.btnEditPolicy);
            this.pnlPoliciesToolbar.Controls.Add(this.btnSearch);
            this.pnlPoliciesToolbar.Controls.Add(this.txtSearch);
            this.pnlPoliciesToolbar.Controls.Add(this.lblPoliciesTitle);
            this.pnlPoliciesToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPoliciesToolbar.Location = new System.Drawing.Point(3, 3);
            this.pnlPoliciesToolbar.Name = "pnlPoliciesToolbar";
            this.pnlPoliciesToolbar.Size = new System.Drawing.Size(1086, 72);
            this.pnlPoliciesToolbar.TabIndex = 0;
            // 
            // btnDownloadPolicy
            // 
            this.btnDownloadPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadPolicy.BackColor = System.Drawing.Color.White;
            this.btnDownloadPolicy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnDownloadPolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadPolicy.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDownloadPolicy.Location = new System.Drawing.Point(982, 37);
            this.btnDownloadPolicy.Name = "btnDownloadPolicy";
            this.btnDownloadPolicy.Size = new System.Drawing.Size(96, 28);
            this.btnDownloadPolicy.TabIndex = 7;
            this.btnDownloadPolicy.Text = "Download PDF";
            this.btnDownloadPolicy.UseVisualStyleBackColor = false;
            this.btnDownloadPolicy.Click += new System.EventHandler(this.BtnDownloadPolicy_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchive.BackColor = System.Drawing.Color.White;
            this.btnArchive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnArchive.Location = new System.Drawing.Point(890, 37);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(86, 28);
            this.btnArchive.TabIndex = 6;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Click += new System.EventHandler(this.BtnArchive_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPublish.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnPublish.FlatAppearance.BorderSize = 0;
            this.btnPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublish.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnPublish.ForeColor = System.Drawing.Color.White;
            this.btnPublish.Location = new System.Drawing.Point(802, 37);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(82, 28);
            this.btnPublish.TabIndex = 5;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Click += new System.EventHandler(this.BtnPublish_Click);
            // 
            // btnNewRevision
            // 
            this.btnNewRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewRevision.BackColor = System.Drawing.Color.White;
            this.btnNewRevision.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnNewRevision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRevision.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnNewRevision.Location = new System.Drawing.Point(700, 37);
            this.btnNewRevision.Name = "btnNewRevision";
            this.btnNewRevision.Size = new System.Drawing.Size(96, 28);
            this.btnNewRevision.TabIndex = 4;
            this.btnNewRevision.Text = "New Revision";
            this.btnNewRevision.UseVisualStyleBackColor = false;
            this.btnNewRevision.Click += new System.EventHandler(this.BtnNewRevision_Click);
            // 
            // btnEditPolicy
            // 
            this.btnEditPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPolicy.BackColor = System.Drawing.Color.White;
            this.btnEditPolicy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnEditPolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPolicy.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnEditPolicy.Location = new System.Drawing.Point(500, 37);
            this.btnEditPolicy.Name = "btnEditPolicy";
            this.btnEditPolicy.Size = new System.Drawing.Size(94, 28);
            this.btnEditPolicy.TabIndex = 3;
            this.btnEditPolicy.Text = "Edit Details";
            this.btnEditPolicy.UseVisualStyleBackColor = false;
            this.btnEditPolicy.Click += new System.EventHandler(this.BtnEditPolicy_Click);
            // 
            // btnNewPolicy
            // 
            this.btnNewPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewPolicy.BackColor = System.Drawing.Color.White;
            this.btnNewPolicy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnNewPolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPolicy.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnNewPolicy.Location = new System.Drawing.Point(600, 37);
            this.btnNewPolicy.Name = "btnNewPolicy";
            this.btnNewPolicy.Size = new System.Drawing.Size(94, 28);
            this.btnNewPolicy.TabIndex = 3;
            this.btnNewPolicy.Text = "New Policy";
            this.btnNewPolicy.UseVisualStyleBackColor = false;
            this.btnNewPolicy.Click += new System.EventHandler(this.BtnNewPolicy_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSearch.Location = new System.Drawing.Point(310, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(12, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(292, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // lblPoliciesTitle
            // 
            this.lblPoliciesTitle.AutoSize = true;
            this.lblPoliciesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPoliciesTitle.ForeColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.lblPoliciesTitle.Location = new System.Drawing.Point(9, 8);
            this.lblPoliciesTitle.Name = "lblPoliciesTitle";
            this.lblPoliciesTitle.Size = new System.Drawing.Size(177, 21);
            this.lblPoliciesTitle.TabIndex = 0;
            this.lblPoliciesTitle.Text = "Company Policies";
            // 
            // tabMyPolicies
            // 
            this.tabMyPolicies.Controls.Add(this.gridMyPolicies);
            this.tabMyPolicies.Controls.Add(this.pnlMyPoliciesToolbar);
            this.tabMyPolicies.Location = new System.Drawing.Point(4, 24);
            this.tabMyPolicies.Name = "tabMyPolicies";
            this.tabMyPolicies.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyPolicies.Size = new System.Drawing.Size(1092, 672);
            this.tabMyPolicies.TabIndex = 1;
            this.tabMyPolicies.Text = "My Policy Acknowledgements";
            this.tabMyPolicies.UseVisualStyleBackColor = true;
            // 
            // gridMyPolicies
            // 
            this.gridMyPolicies.AllowUserToAddRows = false;
            this.gridMyPolicies.AllowUserToDeleteRows = false;
            this.gridMyPolicies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMyPolicies.BackgroundColor = System.Drawing.Color.White;
            this.gridMyPolicies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMyPolicies.ColumnHeadersHeight = 38;
            this.gridMyPolicies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMyPolicies.Location = new System.Drawing.Point(3, 75);
            this.gridMyPolicies.MultiSelect = false;
            this.gridMyPolicies.Name = "gridMyPolicies";
            this.gridMyPolicies.ReadOnly = true;
            this.gridMyPolicies.RowHeadersVisible = false;
            this.gridMyPolicies.RowTemplate.Height = 34;
            this.gridMyPolicies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMyPolicies.Size = new System.Drawing.Size(1086, 594);
            this.gridMyPolicies.TabIndex = 1;
            this.gridMyPolicies.SelectionChanged += new System.EventHandler(this.GridMyPolicies_SelectionChanged);
            // 
            // pnlMyPoliciesToolbar
            // 
            this.pnlMyPoliciesToolbar.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.pnlMyPoliciesToolbar.Controls.Add(this.btnDownloadMyPolicy);
            this.pnlMyPoliciesToolbar.Controls.Add(this.btnAcknowledge);
            this.pnlMyPoliciesToolbar.Controls.Add(this.btnRefreshMyPolicies);
            this.pnlMyPoliciesToolbar.Controls.Add(this.lblMyPoliciesTitle);
            this.pnlMyPoliciesToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMyPoliciesToolbar.Location = new System.Drawing.Point(3, 3);
            this.pnlMyPoliciesToolbar.Name = "pnlMyPoliciesToolbar";
            this.pnlMyPoliciesToolbar.Size = new System.Drawing.Size(1086, 72);
            this.pnlMyPoliciesToolbar.TabIndex = 0;
            // 
            // btnDownloadMyPolicy
            // 
            this.btnDownloadMyPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadMyPolicy.BackColor = System.Drawing.Color.White;
            this.btnDownloadMyPolicy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnDownloadMyPolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadMyPolicy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDownloadMyPolicy.Location = new System.Drawing.Point(880, 25);
            this.btnDownloadMyPolicy.Name = "btnDownloadMyPolicy";
            this.btnDownloadMyPolicy.Size = new System.Drawing.Size(105, 32);
            this.btnDownloadMyPolicy.TabIndex = 3;
            this.btnDownloadMyPolicy.Text = "Download PDF";
            this.btnDownloadMyPolicy.UseVisualStyleBackColor = false;
            this.btnDownloadMyPolicy.Click += new System.EventHandler(this.BtnDownloadMyPolicy_Click);
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcknowledge.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnAcknowledge.FlatAppearance.BorderSize = 0;
            this.btnAcknowledge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcknowledge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAcknowledge.ForeColor = System.Drawing.Color.White;
            this.btnAcknowledge.Location = new System.Drawing.Point(991, 25);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(87, 32);
            this.btnAcknowledge.TabIndex = 2;
            this.btnAcknowledge.Text = "Acknowledge";
            this.btnAcknowledge.UseVisualStyleBackColor = false;
            this.btnAcknowledge.Click += new System.EventHandler(this.BtnAcknowledge_Click);
            // 
            // btnRefreshMyPolicies
            // 
            this.btnRefreshMyPolicies.BackColor = System.Drawing.Color.White;
            this.btnRefreshMyPolicies.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnRefreshMyPolicies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshMyPolicies.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshMyPolicies.Location = new System.Drawing.Point(12, 28);
            this.btnRefreshMyPolicies.Name = "btnRefreshMyPolicies";
            this.btnRefreshMyPolicies.Size = new System.Drawing.Size(80, 28);
            this.btnRefreshMyPolicies.TabIndex = 1;
            this.btnRefreshMyPolicies.Text = "Refresh";
            this.btnRefreshMyPolicies.UseVisualStyleBackColor = false;
            this.btnRefreshMyPolicies.Click += new System.EventHandler(this.BtnRefreshMyPolicies_Click);
            // 
            // lblMyPoliciesTitle
            // 
            this.lblMyPoliciesTitle.AutoSize = true;
            this.lblMyPoliciesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMyPoliciesTitle.ForeColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.lblMyPoliciesTitle.Location = new System.Drawing.Point(105, 31);
            this.lblMyPoliciesTitle.Name = "lblMyPoliciesTitle";
            this.lblMyPoliciesTitle.Size = new System.Drawing.Size(236, 21);
            this.lblMyPoliciesTitle.TabIndex = 0;
            this.lblMyPoliciesTitle.Text = "Policies Requiring Your Review";
            // 
            // tabCompliance
            // 
            this.tabCompliance.Controls.Add(this.gridCompliance);
            this.tabCompliance.Controls.Add(this.pnlComplianceToolbar);
            this.tabCompliance.Location = new System.Drawing.Point(4, 24);
            this.tabCompliance.Name = "tabCompliance";
            this.tabCompliance.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompliance.Size = new System.Drawing.Size(1092, 672);
            this.tabCompliance.TabIndex = 2;
            this.tabCompliance.Text = "Compliance Tracking";
            this.tabCompliance.UseVisualStyleBackColor = true;
            // 
            // gridCompliance
            // 
            this.gridCompliance.AllowUserToAddRows = false;
            this.gridCompliance.AllowUserToDeleteRows = false;
            this.gridCompliance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCompliance.BackgroundColor = System.Drawing.Color.White;
            this.gridCompliance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCompliance.ColumnHeadersHeight = 38;
            this.gridCompliance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCompliance.Location = new System.Drawing.Point(3, 75);
            this.gridCompliance.MultiSelect = false;
            this.gridCompliance.Name = "gridCompliance";
            this.gridCompliance.ReadOnly = true;
            this.gridCompliance.RowHeadersVisible = false;
            this.gridCompliance.RowTemplate.Height = 34;
            this.gridCompliance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCompliance.Size = new System.Drawing.Size(1086, 594);
            this.gridCompliance.TabIndex = 1;
            // 
            // pnlComplianceToolbar
            // 
            this.pnlComplianceToolbar.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.pnlComplianceToolbar.Controls.Add(this.btnRefreshCompliance);
            this.pnlComplianceToolbar.Controls.Add(this.cboPolicyFilter);
            this.pnlComplianceToolbar.Controls.Add(this.lblComplianceTitle);
            this.pnlComplianceToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComplianceToolbar.Location = new System.Drawing.Point(3, 3);
            this.pnlComplianceToolbar.Name = "pnlComplianceToolbar";
            this.pnlComplianceToolbar.Size = new System.Drawing.Size(1086, 72);
            this.pnlComplianceToolbar.TabIndex = 0;
            // 
            // btnRefreshCompliance
            // 
            this.btnRefreshCompliance.BackColor = System.Drawing.Color.White;
            this.btnRefreshCompliance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnRefreshCompliance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshCompliance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshCompliance.Location = new System.Drawing.Point(435, 28);
            this.btnRefreshCompliance.Name = "btnRefreshCompliance";
            this.btnRefreshCompliance.Size = new System.Drawing.Size(80, 28);
            this.btnRefreshCompliance.TabIndex = 2;
            this.btnRefreshCompliance.Text = "Refresh";
            this.btnRefreshCompliance.UseVisualStyleBackColor = false;
            this.btnRefreshCompliance.Click += new System.EventHandler(this.BtnRefreshCompliance_Click);
            // 
            // cboPolicyFilter
            // 
            this.cboPolicyFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPolicyFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPolicyFilter.FormattingEnabled = true;
            this.cboPolicyFilter.Location = new System.Drawing.Point(12, 30);
            this.cboPolicyFilter.Name = "cboPolicyFilter";
            this.cboPolicyFilter.Size = new System.Drawing.Size(410, 23);
            this.cboPolicyFilter.TabIndex = 1;
            // 
            // lblComplianceTitle
            // 
            this.lblComplianceTitle.AutoSize = true;
            this.lblComplianceTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblComplianceTitle.ForeColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.lblComplianceTitle.Location = new System.Drawing.Point(12, 5);
            this.lblComplianceTitle.Name = "lblComplianceTitle";
            this.lblComplianceTitle.Size = new System.Drawing.Size(197, 21);
            this.lblComplianceTitle.TabIndex = 0;
            this.lblComplianceTitle.Text = "Acknowledgement Status";
            // 
            // saveFileDialogPolicy
            // 
            this.saveFileDialogPolicy.Filter = "PDF files (*.pdf)|*.pdf";
            // 
            // CompanyPolicyManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 250, 254);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "CompanyPolicyManagementControl";
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.CompanyPolicyManagementControl_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPolicies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPolicies)).EndInit();
            this.pnlPoliciesToolbar.ResumeLayout(false);
            this.pnlPoliciesToolbar.PerformLayout();
            this.tabMyPolicies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMyPolicies)).EndInit();
            this.pnlMyPoliciesToolbar.ResumeLayout(false);
            this.pnlMyPoliciesToolbar.PerformLayout();
            this.tabCompliance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCompliance)).EndInit();
            this.pnlComplianceToolbar.ResumeLayout(false);
            this.pnlComplianceToolbar.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
