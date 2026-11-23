namespace AO_HRIS.Forms.Main
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.picCompanyLogo = new System.Windows.Forms.PictureBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.flwMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnEmployeeDirectory = new System.Windows.Forms.Button();
            this.btnEmployeeDocuments = new System.Windows.Forms.Button();
            this.btnPolicies = new System.Windows.Forms.Button();
            this.btnOrgChart = new System.Windows.Forms.Button();
            this.btnScheduling = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnUserAccount = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnOrganization = new System.Windows.Forms.Button();
            this.btnLeaves = new System.Windows.Forms.Button();
            this.btnSample = new System.Windows.Forms.Button();
            this.pnlCurrentUser = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCurrentUser = new System.Windows.Forms.Button();
            this.picCurrentUser = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnCompensation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCompanyLogo)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.flwMenu.SuspendLayout();
            this.pnlCurrentUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentUser)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCompanyLogo
            // 
            this.picCompanyLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.picCompanyLogo.Location = new System.Drawing.Point(16, 22);
            this.picCompanyLogo.Name = "picCompanyLogo";
            this.picCompanyLogo.Size = new System.Drawing.Size(48, 48);
            this.picCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCompanyLogo.TabIndex = 6;
            this.picCompanyLogo.TabStop = false;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblCompanyName.Location = new System.Drawing.Point(73, 15);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(145, 75);
            this.lblCompanyName.TabIndex = 5;
            this.lblCompanyName.Text = "Company Name";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Location = new System.Drawing.Point(0, 0);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(100, 23);
            this.lblEmployeeName.TabIndex = 4;
            this.lblEmployeeName.Visible = false;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.pnlSidebar.Controls.Add(this.flwMenu);
            this.pnlSidebar.Controls.Add(this.pnlCurrentUser);
            this.pnlSidebar.Controls.Add(this.panel2);
            this.pnlSidebar.Controls.Add(this.label3);
            this.pnlSidebar.Controls.Add(this.panel3);
            this.pnlSidebar.Controls.Add(this.lblCompanyName);
            this.pnlSidebar.Controls.Add(this.picCompanyLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 834);
            this.pnlSidebar.TabIndex = 2;
            this.pnlSidebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            // 
            // flwMenu
            // 
            this.flwMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flwMenu.AutoScroll = true;
            this.flwMenu.Controls.Add(this.btnDashboard);
            this.flwMenu.Controls.Add(this.btnEmployees);
            this.flwMenu.Controls.Add(this.btnEmployeeDirectory);
            this.flwMenu.Controls.Add(this.btnEmployeeDocuments);
            this.flwMenu.Controls.Add(this.btnPolicies);
            this.flwMenu.Controls.Add(this.btnOrgChart);
            this.flwMenu.Controls.Add(this.btnScheduling);
            this.flwMenu.Controls.Add(this.btnAttendance);
            this.flwMenu.Controls.Add(this.btnUserAccount);
            this.flwMenu.Controls.Add(this.btnRoles);
            this.flwMenu.Controls.Add(this.btnOrganization);
            this.flwMenu.Controls.Add(this.btnLeaves);
            this.flwMenu.Controls.Add(this.btnCompensation);
            this.flwMenu.Controls.Add(this.btnSample);
            this.flwMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flwMenu.Location = new System.Drawing.Point(0, 146);
            this.flwMenu.Name = "flwMenu";
            this.flwMenu.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.flwMenu.Size = new System.Drawing.Size(230, 576);
            this.flwMenu.TabIndex = 0;
            this.flwMenu.WrapContents = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnDashboard.Location = new System.Drawing.Point(11, 3);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(211, 48);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEmployees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnEmployees.Location = new System.Drawing.Point(11, 57);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnEmployees.Size = new System.Drawing.Size(211, 48);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnEmployeeDirectory
            // 
            this.btnEmployeeDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnEmployeeDirectory.FlatAppearance.BorderSize = 0;
            this.btnEmployeeDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnEmployeeDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeDirectory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEmployeeDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnEmployeeDirectory.Location = new System.Drawing.Point(11, 111);
            this.btnEmployeeDirectory.Name = "btnEmployeeDirectory";
            this.btnEmployeeDirectory.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnEmployeeDirectory.Size = new System.Drawing.Size(211, 48);
            this.btnEmployeeDirectory.TabIndex = 2;
            this.btnEmployeeDirectory.Text = "Employee Directory";
            this.btnEmployeeDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeDirectory.UseVisualStyleBackColor = false;
            this.btnEmployeeDirectory.Click += new System.EventHandler(this.btnEmployeeDirectory_Click);
            // 
            // btnEmployeeDocuments
            // 
            this.btnEmployeeDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnEmployeeDocuments.FlatAppearance.BorderSize = 0;
            this.btnEmployeeDocuments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnEmployeeDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeDocuments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEmployeeDocuments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnEmployeeDocuments.Location = new System.Drawing.Point(11, 165);
            this.btnEmployeeDocuments.Name = "btnEmployeeDocuments";
            this.btnEmployeeDocuments.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnEmployeeDocuments.Size = new System.Drawing.Size(211, 48);
            this.btnEmployeeDocuments.TabIndex = 3;
            this.btnEmployeeDocuments.Text = "Employee Documents";
            this.btnEmployeeDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeDocuments.UseVisualStyleBackColor = false;
            this.btnEmployeeDocuments.Visible = false;
            this.btnEmployeeDocuments.Click += new System.EventHandler(this.btnEmployeeDocuments_Click);
            // 
            // btnPolicies
            // 
            this.btnPolicies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnPolicies.FlatAppearance.BorderSize = 0;
            this.btnPolicies.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnPolicies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPolicies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPolicies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnPolicies.Location = new System.Drawing.Point(11, 219);
            this.btnPolicies.Name = "btnPolicies";
            this.btnPolicies.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnPolicies.Size = new System.Drawing.Size(211, 48);
            this.btnPolicies.TabIndex = 3;
            this.btnPolicies.Text = "Company Policies";
            this.btnPolicies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPolicies.UseVisualStyleBackColor = false;
            this.btnPolicies.Visible = false;
            this.btnPolicies.Click += new System.EventHandler(this.btnPolicies_Click);
            // 
            // btnOrgChart
            // 
            this.btnOrgChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnOrgChart.FlatAppearance.BorderSize = 0;
            this.btnOrgChart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnOrgChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrgChart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOrgChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnOrgChart.Location = new System.Drawing.Point(11, 273);
            this.btnOrgChart.Name = "btnOrgChart";
            this.btnOrgChart.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnOrgChart.Size = new System.Drawing.Size(211, 48);
            this.btnOrgChart.TabIndex = 5;
            this.btnOrgChart.Text = "Org. Chart";
            this.btnOrgChart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrgChart.UseMnemonic = false;
            this.btnOrgChart.UseVisualStyleBackColor = false;
            this.btnOrgChart.Click += new System.EventHandler(this.btnOrgChart_Click);
            // 
            // btnScheduling
            // 
            this.btnScheduling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnScheduling.FlatAppearance.BorderSize = 0;
            this.btnScheduling.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnScheduling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduling.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnScheduling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnScheduling.Location = new System.Drawing.Point(11, 327);
            this.btnScheduling.Name = "btnScheduling";
            this.btnScheduling.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnScheduling.Size = new System.Drawing.Size(211, 48);
            this.btnScheduling.TabIndex = 4;
            this.btnScheduling.Text = "Schedule";
            this.btnScheduling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScheduling.UseVisualStyleBackColor = false;
            this.btnScheduling.Click += new System.EventHandler(this.btnScheduling_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnAttendance.FlatAppearance.BorderSize = 0;
            this.btnAttendance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAttendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnAttendance.Location = new System.Drawing.Point(11, 381);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnAttendance.Size = new System.Drawing.Size(211, 48);
            this.btnAttendance.TabIndex = 5;
            this.btnAttendance.Text = "Attendance";
            this.btnAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Visible = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnUserAccount
            // 
            this.btnUserAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnUserAccount.FlatAppearance.BorderSize = 0;
            this.btnUserAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUserAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnUserAccount.Location = new System.Drawing.Point(11, 435);
            this.btnUserAccount.Name = "btnUserAccount";
            this.btnUserAccount.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnUserAccount.Size = new System.Drawing.Size(211, 48);
            this.btnUserAccount.TabIndex = 5;
            this.btnUserAccount.Text = "User & Access";
            this.btnUserAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserAccount.UseMnemonic = false;
            this.btnUserAccount.UseVisualStyleBackColor = false;
            this.btnUserAccount.Click += new System.EventHandler(this.btnUserAccount_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnRoles.FlatAppearance.BorderSize = 0;
            this.btnRoles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnRoles.Location = new System.Drawing.Point(11, 489);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnRoles.Size = new System.Drawing.Size(211, 48);
            this.btnRoles.TabIndex = 5;
            this.btnRoles.Text = "Roles";
            this.btnRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.UseMnemonic = false;
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnOrganization
            // 
            this.btnOrganization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnOrganization.FlatAppearance.BorderSize = 0;
            this.btnOrganization.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnOrganization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrganization.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOrganization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnOrganization.Location = new System.Drawing.Point(11, 543);
            this.btnOrganization.Name = "btnOrganization";
            this.btnOrganization.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnOrganization.Size = new System.Drawing.Size(211, 48);
            this.btnOrganization.TabIndex = 3;
            this.btnOrganization.Text = "Organization";
            this.btnOrganization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrganization.UseVisualStyleBackColor = false;
            this.btnOrganization.Click += new System.EventHandler(this.btnOrganization_Click);
            // 
            // btnLeaves
            // 
            this.btnLeaves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnLeaves.FlatAppearance.BorderSize = 0;
            this.btnLeaves.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnLeaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaves.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLeaves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnLeaves.Location = new System.Drawing.Point(11, 597);
            this.btnLeaves.Name = "btnLeaves";
            this.btnLeaves.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnLeaves.Size = new System.Drawing.Size(211, 48);
            this.btnLeaves.TabIndex = 3;
            this.btnLeaves.Text = "Leaves";
            this.btnLeaves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeaves.UseVisualStyleBackColor = false;
            this.btnLeaves.Visible = false;
            this.btnLeaves.Click += new System.EventHandler(this.btnLeaveManagement_Click);
            // 
            // btnSample
            // 
            this.btnSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.btnSample.FlatAppearance.BorderSize = 0;
            this.btnSample.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.btnSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSample.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSample.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(245)))));
            this.btnSample.Location = new System.Drawing.Point(11, 705);
            this.btnSample.Name = "btnSample";
            this.btnSample.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnSample.Size = new System.Drawing.Size(211, 48);
            this.btnSample.TabIndex = 3;
            this.btnSample.Text = "SAMPLE";
            this.btnSample.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSample.UseVisualStyleBackColor = false;
            this.btnSample.Visible = false;
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // pnlCurrentUser
            // 
            this.pnlCurrentUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            this.pnlCurrentUser.Controls.Add(this.btnLogout);
            this.pnlCurrentUser.Controls.Add(this.btnCurrentUser);
            this.pnlCurrentUser.Controls.Add(this.picCurrentUser);
            this.pnlCurrentUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCurrentUser.Location = new System.Drawing.Point(0, 721);
            this.pnlCurrentUser.Name = "pnlCurrentUser";
            this.pnlCurrentUser.Size = new System.Drawing.Size(230, 112);
            this.pnlCurrentUser.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(40)))), ((int)(((byte)(69)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnLogout.Location = new System.Drawing.Point(17, 70);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(196, 32);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "↪   Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCurrentUser
            // 
            this.btnCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.btnCurrentUser.FlatAppearance.BorderSize = 0;
            this.btnCurrentUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurrentUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCurrentUser.ForeColor = System.Drawing.Color.White;
            this.btnCurrentUser.Location = new System.Drawing.Point(63, 5);
            this.btnCurrentUser.Name = "btnCurrentUser";
            this.btnCurrentUser.Size = new System.Drawing.Size(155, 53);
            this.btnCurrentUser.TabIndex = 0;
            this.btnCurrentUser.Text = "Current User";
            this.btnCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrentUser.UseVisualStyleBackColor = false;
            // 
            // picCurrentUser
            // 
            this.picCurrentUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(123)))), ((int)(((byte)(161)))));
            this.picCurrentUser.Enabled = false;
            this.picCurrentUser.Location = new System.Drawing.Point(17, 12);
            this.picCurrentUser.Name = "picCurrentUser";
            this.picCurrentUser.Size = new System.Drawing.Size(38, 38);
            this.picCurrentUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCurrentUser.TabIndex = 1;
            this.picCurrentUser.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(78)))), ((int)(((byte)(104)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 833);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 1);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(158)))), ((int)(((byte)(190)))));
            this.label3.Location = new System.Drawing.Point(19, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "WORKSPACE";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(64)))), ((int)(((byte)(91)))));
            this.panel3.Location = new System.Drawing.Point(0, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 1);
            this.panel3.TabIndex = 4;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(230, 58);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Size = new System.Drawing.Size(970, 776);
            this.pnlContent.TabIndex = 0;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btnMaximize);
            this.panel4.Controls.Add(this.btnMinimize);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(230, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(970, 58);
            this.panel4.TabIndex = 1;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(200)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1647, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(202)))), ((int)(((byte)(78)))));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Location = new System.Drawing.Point(915, 3);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(23, 23);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Visible = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(188)))), ((int)(((byte)(46)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(886, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 23);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Visible = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(944, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(0, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Visible = false;
            // 
            // btnCompensation
            // 
            this.btnCompensation.BackColor = System.Drawing.Color.FromArgb(17, 29, 53);
            this.btnCompensation.FlatAppearance.BorderSize = 0;
            this.btnCompensation.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(34, 72, 124);
            this.btnCompensation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompensation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCompensation.ForeColor =
                System.Drawing.Color.FromArgb(226, 234, 245);
            this.btnCompensation.Padding = new System.Windows.Forms.Padding(57, 0, 0, 0);
            this.btnCompensation.Size = new System.Drawing.Size(211, 48);
            this.btnCompensation.TabIndex = 6;
            this.btnCompensation.Text = "Compensation";
            this.btnCompensation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompensation.UseVisualStyleBackColor = false;
            this.btnCompensation.Visible = false;
            this.btnCompensation.Click +=
                new System.EventHandler(this.btnCompensation_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 834);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblEmployeeName);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "MainForm";
            this.Text = "AO_HRIS - MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCompanyLogo)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.flwMenu.ResumeLayout(false);
            this.pnlCurrentUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentUser)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.PictureBox picCompanyLogo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.FlowLayoutPanel flwMenu;
        private System.Windows.Forms.Panel pnlCurrentUser;
        private System.Windows.Forms.Button btnCurrentUser;
        private System.Windows.Forms.PictureBox picCurrentUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnEmployeeDirectory;
        private System.Windows.Forms.Button btnEmployeeDocuments;
        private System.Windows.Forms.Button btnPolicies;
        private System.Windows.Forms.Button btnOrganization;
        private System.Windows.Forms.Button btnScheduling;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnUserAccount;
        private System.Windows.Forms.Button btnOrgChart;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnSample;
        private System.Windows.Forms.Button btnLeaves;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCompensation;
    }
}
