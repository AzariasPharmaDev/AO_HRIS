namespace AO_HRIS.UserControls.Security
{
    partial class UserRoleManagementControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPageHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.pnlWorkspace = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblUsersSubtitle = new System.Windows.Forms.Label();
            this.lblUsersTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvUserRoles = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnAssignRole = new System.Windows.Forms.Button();
            this.btnRevokeRole = new System.Windows.Forms.Button();
            this.pnlAssignment = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblCompanyScope = new System.Windows.Forms.Label();
            this.pnlSelectedUser = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.lblRoleAssignmentSubtitle = new System.Windows.Forms.Label();
            this.lblRoleAssignmentTitle = new System.Windows.Forms.Label();
            this.pnlPageHeader.SuspendLayout();
            this.pnlWorkspace.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlAssignment.SuspendLayout();
            this.pnlSelectedUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPageHeader
            // 
            this.pnlPageHeader.BackColor = System.Drawing.Color.White;
            this.pnlPageHeader.Controls.Add(this.lblPageTitle);
            this.pnlPageHeader.Controls.Add(this.lblPageSubtitle);
            this.pnlPageHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPageHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlPageHeader.Name = "pnlPageHeader";
            this.pnlPageHeader.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnlPageHeader.Size = new System.Drawing.Size(1408, 90);
            this.pnlPageHeader.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(55)))), ((int)(((byte)(95)))));
            this.lblPageTitle.Location = new System.Drawing.Point(24, 13);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(270, 32);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "User Role Management";
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPageSubtitle.Location = new System.Drawing.Point(26, 53);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(349, 17);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "Assign and manage permissions for the selected company";
            // 
            // pnlWorkspace
            // 
            this.pnlWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlWorkspace.ColumnCount = 2;
            this.pnlWorkspace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.pnlWorkspace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.pnlWorkspace.Controls.Add(this.panel1, 0, 0);
            this.pnlWorkspace.Controls.Add(this.panel2, 1, 0);
            this.pnlWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkspace.Location = new System.Drawing.Point(0, 90);
            this.pnlWorkspace.Name = "pnlWorkspace";
            this.pnlWorkspace.Padding = new System.Windows.Forms.Padding(14);
            this.pnlWorkspace.RowCount = 1;
            this.pnlWorkspace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlWorkspace.Size = new System.Drawing.Size(1408, 560);
            this.pnlWorkspace.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvUsers);
            this.panel1.Controls.Add(this.pnlSearch);
            this.panel1.Controls.Add(this.lblUsersSubtitle);
            this.panel1.Controls.Add(this.lblUsersTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(19, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 7, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(18);
            this.panel1.Size = new System.Drawing.Size(650, 524);
            this.panel1.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(99)))));
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeight = 38;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.dgvUsers.Location = new System.Drawing.Point(18, 129);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 36;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(614, 377);
            this.dgvUsers.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.ColumnCount = 2;
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.pnlSearch.Controls.Add(this.txtSearch, 0, 0);
            this.pnlSearch.Controls.Add(this.btnRefresh, 1, 0);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(18, 80);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.RowCount = 1;
            this.pnlSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.Size = new System.Drawing.Size(614, 49);
            this.pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(0, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 6, 9, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(503, 25);
            this.txtSearch.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(212)))), ((int)(((byte)(233)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(167)))));
            this.btnRefresh.Location = new System.Drawing.Point(512, 3);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0, 3, 0, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 37);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // lblUsersSubtitle
            // 
            this.lblUsersSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsersSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsersSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblUsersSubtitle.Location = new System.Drawing.Point(18, 48);
            this.lblUsersSubtitle.Name = "lblUsersSubtitle";
            this.lblUsersSubtitle.Size = new System.Drawing.Size(614, 32);
            this.lblUsersSubtitle.TabIndex = 2;
            this.lblUsersSubtitle.Text = "Select an account to manage its roles";
            // 
            // lblUsersTitle
            // 
            this.lblUsersTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblUsersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(62)))), ((int)(((byte)(111)))));
            this.lblUsersTitle.Location = new System.Drawing.Point(18, 18);
            this.lblUsersTitle.Name = "lblUsersTitle";
            this.lblUsersTitle.Size = new System.Drawing.Size(614, 30);
            this.lblUsersTitle.TabIndex = 3;
            this.lblUsersTitle.Text = "Users";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgvUserRoles);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.pnlActions);
            this.panel2.Controls.Add(this.pnlAssignment);
            this.panel2.Controls.Add(this.pnlSelectedUser);
            this.panel2.Controls.Add(this.lblRoleAssignmentSubtitle);
            this.panel2.Controls.Add(this.lblRoleAssignmentTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(683, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(18);
            this.panel2.Size = new System.Drawing.Size(706, 524);
            this.panel2.TabIndex = 1;
            // 
            // dgvUserRoles
            // 
            this.dgvUserRoles.AllowUserToAddRows = false;
            this.dgvUserRoles.AllowUserToDeleteRows = false;
            this.dgvUserRoles.AllowUserToResizeRows = false;
            this.dgvUserRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserRoles.BackgroundColor = System.Drawing.Color.White;
            this.dgvUserRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(99)))));
            this.dgvUserRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserRoles.ColumnHeadersHeight = 38;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserRoles.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUserRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserRoles.EnableHeadersVisualStyles = false;
            this.dgvUserRoles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.dgvUserRoles.Location = new System.Drawing.Point(18, 312);
            this.dgvUserRoles.MultiSelect = false;
            this.dgvUserRoles.Name = "dgvUserRoles";
            this.dgvUserRoles.ReadOnly = true;
            this.dgvUserRoles.RowHeadersVisible = false;
            this.dgvUserRoles.RowTemplate.Height = 36;
            this.dgvUserRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserRoles.Size = new System.Drawing.Size(670, 194);
            this.dgvUserRoles.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(62)))), ((int)(((byte)(111)))));
            this.label8.Location = new System.Drawing.Point(18, 275);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.label8.Size = new System.Drawing.Size(670, 37);
            this.label8.TabIndex = 1;
            this.label8.Text = "Assigned Roles";
            // 
            // pnlActions
            // 
            this.pnlActions.ColumnCount = 2;
            this.pnlActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlActions.Controls.Add(this.btnAssignRole, 0, 0);
            this.pnlActions.Controls.Add(this.btnRevokeRole, 1, 0);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(18, 224);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.RowCount = 1;
            this.pnlActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlActions.Size = new System.Drawing.Size(670, 51);
            this.pnlActions.TabIndex = 2;
            // 
            // btnAssignRole
            // 
            this.btnAssignRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(105)))), ((int)(((byte)(224)))));
            this.btnAssignRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAssignRole.FlatAppearance.BorderSize = 0;
            this.btnAssignRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignRole.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAssignRole.ForeColor = System.Drawing.Color.White;
            this.btnAssignRole.Location = new System.Drawing.Point(0, 3);
            this.btnAssignRole.Margin = new System.Windows.Forms.Padding(0, 3, 8, 7);
            this.btnAssignRole.Name = "btnAssignRole";
            this.btnAssignRole.Size = new System.Drawing.Size(327, 41);
            this.btnAssignRole.TabIndex = 0;
            this.btnAssignRole.Text = "+ Assign Role";
            this.btnAssignRole.UseVisualStyleBackColor = false;
            // 
            // btnRevokeRole
            // 
            this.btnRevokeRole.BackColor = System.Drawing.Color.White;
            this.btnRevokeRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRevokeRole.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.btnRevokeRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevokeRole.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRevokeRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.btnRevokeRole.Location = new System.Drawing.Point(343, 3);
            this.btnRevokeRole.Margin = new System.Windows.Forms.Padding(8, 3, 0, 7);
            this.btnRevokeRole.Name = "btnRevokeRole";
            this.btnRevokeRole.Size = new System.Drawing.Size(327, 41);
            this.btnRevokeRole.TabIndex = 1;
            this.btnRevokeRole.Text = "Revoke Selected";
            this.btnRevokeRole.UseVisualStyleBackColor = false;
            // 
            // pnlAssignment
            // 
            this.pnlAssignment.ColumnCount = 2;
            this.pnlAssignment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlAssignment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlAssignment.Controls.Add(this.label6, 0, 0);
            this.pnlAssignment.Controls.Add(this.label7, 1, 0);
            this.pnlAssignment.Controls.Add(this.cmbRole, 0, 1);
            this.pnlAssignment.Controls.Add(this.lblCompanyScope, 1, 1);
            this.pnlAssignment.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAssignment.Location = new System.Drawing.Point(18, 141);
            this.pnlAssignment.Name = "pnlAssignment";
            this.pnlAssignment.Padding = new System.Windows.Forms.Padding(0, 12, 0, 5);
            this.pnlAssignment.RowCount = 2;
            this.pnlAssignment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.pnlAssignment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlAssignment.Size = new System.Drawing.Size(670, 83);
            this.pnlAssignment.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(68)))), ((int)(((byte)(95)))));
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(329, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Role";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(68)))), ((int)(((byte)(95)))));
            this.label7.Location = new System.Drawing.Point(338, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(329, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "Company Scope";
            // 
            // cmbRole
            // 
            this.cmbRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRole.Location = new System.Drawing.Point(0, 36);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(325, 25);
            this.cmbRole.TabIndex = 2;
            // 
            // lblCompanyScope
            // 
            this.lblCompanyScope.AutoEllipsis = true;
            this.lblCompanyScope.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lblCompanyScope.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompanyScope.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCompanyScope.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(73)))), ((int)(((byte)(112)))));
            this.lblCompanyScope.Location = new System.Drawing.Point(338, 36);
            this.lblCompanyScope.Name = "lblCompanyScope";
            this.lblCompanyScope.Padding = new System.Windows.Forms.Padding(8, 6, 0, 0);
            this.lblCompanyScope.Size = new System.Drawing.Size(329, 30);
            this.lblCompanyScope.TabIndex = 3;
            this.lblCompanyScope.Text = "Current company";
            // 
            // pnlSelectedUser
            // 
            this.pnlSelectedUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlSelectedUser.Controls.Add(this.label5);
            this.pnlSelectedUser.Controls.Add(this.lblSelectedUser);
            this.pnlSelectedUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectedUser.Location = new System.Drawing.Point(18, 80);
            this.pnlSelectedUser.Name = "pnlSelectedUser";
            this.pnlSelectedUser.Size = new System.Drawing.Size(670, 61);
            this.pnlSelectedUser.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(110)))), ((int)(((byte)(134)))));
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Selected User";
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedUser.AutoEllipsis = true;
            this.lblSelectedUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectedUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(62)))), ((int)(((byte)(111)))));
            this.lblSelectedUser.Location = new System.Drawing.Point(13, 29);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(990, 23);
            this.lblSelectedUser.TabIndex = 1;
            this.lblSelectedUser.Text = "No user selected";
            // 
            // lblRoleAssignmentSubtitle
            // 
            this.lblRoleAssignmentSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoleAssignmentSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoleAssignmentSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRoleAssignmentSubtitle.Location = new System.Drawing.Point(18, 48);
            this.lblRoleAssignmentSubtitle.Name = "lblRoleAssignmentSubtitle";
            this.lblRoleAssignmentSubtitle.Size = new System.Drawing.Size(670, 32);
            this.lblRoleAssignmentSubtitle.TabIndex = 5;
            this.lblRoleAssignmentSubtitle.Text = "Manage the selected user\'s access";
            // 
            // lblRoleAssignmentTitle
            // 
            this.lblRoleAssignmentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoleAssignmentTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblRoleAssignmentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(62)))), ((int)(((byte)(111)))));
            this.lblRoleAssignmentTitle.Location = new System.Drawing.Point(18, 18);
            this.lblRoleAssignmentTitle.Name = "lblRoleAssignmentTitle";
            this.lblRoleAssignmentTitle.Size = new System.Drawing.Size(670, 30);
            this.lblRoleAssignmentTitle.TabIndex = 6;
            this.lblRoleAssignmentTitle.Text = "Role Assignment";
            // 
            // UserRoleManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.pnlWorkspace);
            this.Controls.Add(this.pnlPageHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "UserRoleManagementControl";
            this.Size = new System.Drawing.Size(1408, 650);
            this.pnlPageHeader.ResumeLayout(false);
            this.pnlPageHeader.PerformLayout();
            this.pnlWorkspace.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlAssignment.ResumeLayout(false);
            this.pnlSelectedUser.ResumeLayout(false);
            this.pnlSelectedUser.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel pnlPageHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.TableLayoutPanel pnlWorkspace;
        private System.Windows.Forms.TableLayoutPanel pnlSearch;
        private System.Windows.Forms.Panel pnlSelectedUser;
        private System.Windows.Forms.TableLayoutPanel pnlAssignment;
        private System.Windows.Forms.TableLayoutPanel pnlActions;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblCompanyScope;
        private System.Windows.Forms.Button btnAssignRole;
        private System.Windows.Forms.Button btnRevokeRole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvUserRoles;
        private System.Windows.Forms.Label lblUsersSubtitle;
        private System.Windows.Forms.Label lblUsersTitle;
        private System.Windows.Forms.Label lblRoleAssignmentTitle;
        private System.Windows.Forms.Label lblRoleAssignmentSubtitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
