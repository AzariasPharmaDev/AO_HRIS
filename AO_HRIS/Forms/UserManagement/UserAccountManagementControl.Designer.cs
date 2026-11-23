namespace AO_HRIS.Forms.UserManagement
{
    partial class UserAccountManagementControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel layout, header, listLayout, editorLayout, fields, roleLayout;
        private System.Windows.Forms.FlowLayoutPanel toolbar, actions, roleActions;
        private System.Windows.Forms.Panel headerPanel, listPanel, editorPanel;
        private System.Windows.Forms.Label lblTitle, lblSubtitle, lblList, lblSelection, lblUsername, lblEmail, lblEmployee, lblPassword, lblRole, lblRolesTitle;
        private System.Windows.Forms.TextBox txtSearch, txtUsername, txtEmail, txtPassword;
        private System.Windows.Forms.ComboBox cboEmployee, cboRole;
        private System.Windows.Forms.DataGridView dgvAccounts, dgvUserRoles;
        private System.Windows.Forms.Button btnNew, btnSave, btnRefresh, btnResetPassword, btnToggleActive, btnToggleLock, btnAssignRole, btnRevokeRole;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.listPanel = new System.Windows.Forms.Panel();
            this.listLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblList = new System.Windows.Forms.Label();
            this.toolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.editorPanel = new System.Windows.Forms.Panel();
            this.editorLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelection = new System.Windows.Forms.Label();
            this.fields = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.roleLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblRolesTitle = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.dgvUserRoles = new System.Windows.Forms.DataGridView();
            this.roleActions = new System.Windows.Forms.FlowLayoutPanel();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.btnAssignRole = new System.Windows.Forms.Button();
            this.btnRevokeRole = new System.Windows.Forms.Button();
            this.actions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnToggleActive = new System.Windows.Forms.Button();
            this.btnToggleLock = new System.Windows.Forms.Button();
            this.layout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.header.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.listLayout.SuspendLayout();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.editorPanel.SuspendLayout();
            this.editorLayout.SuspendLayout();
            this.fields.SuspendLayout();
            this.roleLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).BeginInit();
            this.roleActions.SuspendLayout();
            this.actions.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.headerPanel, 0, 0);
            this.layout.Controls.Add(this.listPanel, 0, 1);
            this.layout.Controls.Add(this.editorPanel, 0, 2);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.Padding = new System.Windows.Forms.Padding(24);
            this.layout.RowCount = 3;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.layout.Size = new System.Drawing.Size(1487, 731);
            this.layout.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.header);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(24, 24);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.headerPanel.Size = new System.Drawing.Size(1439, 76);
            this.headerPanel.TabIndex = 0;
            // 
            // header
            // 
            this.header.ColumnCount = 1;
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.header.Controls.Add(this.lblTitle, 0, 0);
            this.header.Controls.Add(this.lblSubtitle, 0, 1);
            this.header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header.Location = new System.Drawing.Point(16, 8);
            this.header.Name = "header";
            this.header.RowCount = 2;
            this.header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.header.Size = new System.Drawing.Size(1407, 60);
            this.header.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1401, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User & Access Management";
            this.lblTitle.UseMnemonic = false;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSubtitle.Location = new System.Drawing.Point(3, 36);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(1401, 24);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage employee accounts, company-specific roles and security.";
            // 
            // listPanel
            // 
            this.listPanel.BackColor = System.Drawing.Color.White;
            this.listPanel.Controls.Add(this.listLayout);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPanel.Location = new System.Drawing.Point(24, 112);
            this.listPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.listPanel.Name = "listPanel";
            this.listPanel.Padding = new System.Windows.Forms.Padding(16);
            this.listPanel.Size = new System.Drawing.Size(1439, 255);
            this.listPanel.TabIndex = 1;
            // 
            // listLayout
            // 
            this.listLayout.ColumnCount = 1;
            this.listLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.listLayout.Controls.Add(this.lblList, 0, 0);
            this.listLayout.Controls.Add(this.toolbar, 0, 1);
            this.listLayout.Controls.Add(this.dgvAccounts, 0, 2);
            this.listLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLayout.Location = new System.Drawing.Point(16, 16);
            this.listLayout.Name = "listLayout";
            this.listLayout.RowCount = 3;
            this.listLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.listLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.listLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.listLayout.Size = new System.Drawing.Size(1407, 223);
            this.listLayout.TabIndex = 0;
            // 
            // lblList
            // 
            this.lblList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblList.Location = new System.Drawing.Point(3, 0);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(1401, 32);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "User Accounts";
            // 
            // toolbar
            // 
            this.toolbar.AutoScroll = true;
            this.toolbar.Controls.Add(this.txtSearch);
            this.toolbar.Controls.Add(this.btnNew);
            this.toolbar.Controls.Add(this.btnRefresh);
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbar.Location = new System.Drawing.Point(3, 35);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1401, 38);
            this.toolbar.TabIndex = 1;
            this.toolbar.WrapContents = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(0, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 6, 12, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(265, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(135, 32);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "+ New Account";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(228)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnRefresh.Location = new System.Drawing.Point(406, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 32);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.dgvAccounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAccounts.ColumnHeadersHeight = 38;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccounts.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccounts.EnableHeadersVisualStyles = false;
            this.dgvAccounts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.dgvAccounts.Location = new System.Drawing.Point(3, 79);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.RowHeadersVisible = false;
            this.dgvAccounts.RowTemplate.Height = 34;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(1401, 141);
            this.dgvAccounts.TabIndex = 2;
            this.dgvAccounts.SelectionChanged += new System.EventHandler(this.dgvAccounts_SelectionChanged);
            // 
            // editorPanel
            // 
            this.editorPanel.BackColor = System.Drawing.Color.White;
            this.editorPanel.Controls.Add(this.editorLayout);
            this.editorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorPanel.Location = new System.Drawing.Point(24, 379);
            this.editorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.editorPanel.Name = "editorPanel";
            this.editorPanel.Padding = new System.Windows.Forms.Padding(16);
            this.editorPanel.Size = new System.Drawing.Size(1439, 328);
            this.editorPanel.TabIndex = 2;
            // 
            // editorLayout
            // 
            this.editorLayout.ColumnCount = 1;
            this.editorLayout.Controls.Add(this.lblSelection, 0, 0);
            this.editorLayout.Controls.Add(this.fields, 0, 1);
            this.editorLayout.Controls.Add(this.roleLayout, 0, 2);
            this.editorLayout.Controls.Add(this.actions, 0, 3);
            this.editorLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorLayout.Location = new System.Drawing.Point(16, 16);
            this.editorLayout.Name = "editorLayout";
            this.editorLayout.RowCount = 4;
            this.editorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.editorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.editorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.editorLayout.Size = new System.Drawing.Size(1407, 296);
            this.editorLayout.TabIndex = 0;
            // 
            // lblSelection
            // 
            this.lblSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelection.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblSelection.Location = new System.Drawing.Point(3, 0);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(1401, 36);
            this.lblSelection.TabIndex = 0;
            this.lblSelection.Text = "New Account";
            // 
            // fields
            // 
            this.fields.ColumnCount = 4;
            this.fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.fields.Controls.Add(this.lblEmployee, 0, 0);
            this.fields.Controls.Add(this.lblUsername, 1, 0);
            this.fields.Controls.Add(this.lblEmail, 2, 0);
            this.fields.Controls.Add(this.lblPassword, 3, 0);
            this.fields.Controls.Add(this.cboEmployee, 0, 1);
            this.fields.Controls.Add(this.txtUsername, 1, 1);
            this.fields.Controls.Add(this.txtEmail, 2, 1);
            this.fields.Controls.Add(this.txtPassword, 3, 1);
            this.fields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fields.Location = new System.Drawing.Point(3, 39);
            this.fields.Name = "fields";
            this.fields.RowCount = 2;
            this.fields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.fields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fields.Size = new System.Drawing.Size(1401, 100);
            this.fields.TabIndex = 1;
            // 
            // lblEmployee
            // 
            this.lblEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblEmployee.Location = new System.Drawing.Point(3, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(344, 28);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employee";
            // 
            // lblUsername
            // 
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblUsername.Location = new System.Drawing.Point(353, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(344, 28);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblEmail.Location = new System.Drawing.Point(703, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(344, 28);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email Address";
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblPassword.Location = new System.Drawing.Point(1053, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(345, 28);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password (new/reset, min 12)";
            // 
            // cboEmployee
            // 
            this.cboEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEmployee.Location = new System.Drawing.Point(0, 32);
            this.cboEmployee.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(338, 25);
            this.cboEmployee.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(350, 32);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(338, 25);
            this.txtUsername.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(700, 32);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(0, 4, 12, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(338, 25);
            this.txtEmail.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(1050, 32);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(351, 25);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // roleLayout
            // 
            this.roleLayout.ColumnCount = 2;
            this.roleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.roleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.roleLayout.Controls.Add(this.lblRolesTitle, 0, 0);
            this.roleLayout.Controls.Add(this.lblRole, 1, 0);
            this.roleLayout.Controls.Add(this.dgvUserRoles, 0, 1);
            this.roleLayout.Controls.Add(this.roleActions, 1, 1);
            this.roleLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roleLayout.Location = new System.Drawing.Point(3, 145);
            this.roleLayout.Name = "roleLayout";
            this.roleLayout.RowCount = 2;
            this.roleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.roleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.roleLayout.Size = new System.Drawing.Size(1401, 100);
            this.roleLayout.TabIndex = 2;
            // 
            // lblRolesTitle
            // 
            this.lblRolesTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRolesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblRolesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblRolesTitle.Location = new System.Drawing.Point(3, 0);
            this.lblRolesTitle.Name = "lblRolesTitle";
            this.lblRolesTitle.Size = new System.Drawing.Size(834, 28);
            this.lblRolesTitle.TabIndex = 0;
            this.lblRolesTitle.Text = "Roles & Access — Current Company";
            this.lblRolesTitle.UseMnemonic = false;
            // 
            // lblRole
            // 
            this.lblRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblRole.Location = new System.Drawing.Point(843, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(555, 28);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Assign another role";
            // 
            // dgvUserRoles
            // 
            this.dgvUserRoles.AllowUserToAddRows = false;
            this.dgvUserRoles.AllowUserToDeleteRows = false;
            this.dgvUserRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserRoles.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserRoles.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvUserRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserRoles.EnableHeadersVisualStyles = false;
            this.dgvUserRoles.Location = new System.Drawing.Point(3, 31);
            this.dgvUserRoles.MultiSelect = false;
            this.dgvUserRoles.Name = "dgvUserRoles";
            this.dgvUserRoles.ReadOnly = true;
            this.dgvUserRoles.RowHeadersVisible = false;
            this.dgvUserRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserRoles.Size = new System.Drawing.Size(834, 66);
            this.dgvUserRoles.TabIndex = 2;
            this.dgvUserRoles.SelectionChanged += new System.EventHandler(this.dgvUserRoles_SelectionChanged);
            // 
            // roleActions
            // 
            this.roleActions.AutoScroll = true;
            this.roleActions.Controls.Add(this.cboRole);
            this.roleActions.Controls.Add(this.btnAssignRole);
            this.roleActions.Controls.Add(this.btnRevokeRole);
            this.roleActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roleActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.roleActions.Location = new System.Drawing.Point(843, 31);
            this.roleActions.Name = "roleActions";
            this.roleActions.Padding = new System.Windows.Forms.Padding(12, 4, 0, 0);
            this.roleActions.Size = new System.Drawing.Size(555, 66);
            this.roleActions.TabIndex = 3;
            this.roleActions.WrapContents = false;
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRole.Location = new System.Drawing.Point(15, 7);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(200, 25);
            this.cboRole.TabIndex = 0;
            // 
            // btnAssignRole
            // 
            this.btnAssignRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnAssignRole.FlatAppearance.BorderSize = 0;
            this.btnAssignRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignRole.ForeColor = System.Drawing.Color.White;
            this.btnAssignRole.Location = new System.Drawing.Point(15, 38);
            this.btnAssignRole.Name = "btnAssignRole";
            this.btnAssignRole.Size = new System.Drawing.Size(140, 32);
            this.btnAssignRole.TabIndex = 1;
            this.btnAssignRole.Text = "Assign Role";
            this.btnAssignRole.UseVisualStyleBackColor = false;
            this.btnAssignRole.Click += new System.EventHandler(this.btnAssignRole_Click);
            // 
            // btnRevokeRole
            // 
            this.btnRevokeRole.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(228)))));
            this.btnRevokeRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevokeRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnRevokeRole.Location = new System.Drawing.Point(15, 76);
            this.btnRevokeRole.Name = "btnRevokeRole";
            this.btnRevokeRole.Size = new System.Drawing.Size(160, 32);
            this.btnRevokeRole.TabIndex = 2;
            this.btnRevokeRole.Text = "Revoke Selected Role";
            this.btnRevokeRole.Click += new System.EventHandler(this.btnRevokeRole_Click);
            // 
            // actions
            // 
            this.actions.AutoScroll = true;
            this.actions.Controls.Add(this.btnSave);
            this.actions.Controls.Add(this.btnResetPassword);
            this.actions.Controls.Add(this.btnToggleActive);
            this.actions.Controls.Add(this.btnToggleLock);
            this.actions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.actions.Location = new System.Drawing.Point(3, 251);
            this.actions.Name = "actions";
            this.actions.Size = new System.Drawing.Size(1401, 42);
            this.actions.TabIndex = 3;
            this.actions.WrapContents = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1268, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Create Account";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Location = new System.Drawing.Point(1132, 3);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(130, 34);
            this.btnResetPassword.TabIndex = 1;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnToggleActive
            // 
            this.btnToggleActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleActive.Location = new System.Drawing.Point(1011, 3);
            this.btnToggleActive.Name = "btnToggleActive";
            this.btnToggleActive.Size = new System.Drawing.Size(115, 34);
            this.btnToggleActive.TabIndex = 2;
            this.btnToggleActive.Text = "Deactivate";
            this.btnToggleActive.Click += new System.EventHandler(this.btnToggleActive_Click);
            // 
            // btnToggleLock
            // 
            this.btnToggleLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLock.Location = new System.Drawing.Point(905, 3);
            this.btnToggleLock.Name = "btnToggleLock";
            this.btnToggleLock.Size = new System.Drawing.Size(100, 34);
            this.btnToggleLock.TabIndex = 3;
            this.btnToggleLock.Text = "Lock";
            this.btnToggleLock.Click += new System.EventHandler(this.btnToggleLock_Click);
            // 
            // UserAccountManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.layout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "UserAccountManagementControl";
            this.Size = new System.Drawing.Size(1487, 731);
            this.layout.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.listPanel.ResumeLayout(false);
            this.listLayout.ResumeLayout(false);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.editorPanel.ResumeLayout(false);
            this.editorLayout.ResumeLayout(false);
            this.fields.ResumeLayout(false);
            this.fields.PerformLayout();
            this.roleLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).EndInit();
            this.roleActions.ResumeLayout(false);
            this.actions.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
