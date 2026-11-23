namespace AO_HRIS.Forms.UserManagement
{
    partial class RoleManagementControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel root;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel contentLayout;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblListHint;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel editorPanel;
        private System.Windows.Forms.Label lblEditorTitle;
        private System.Windows.Forms.Label lblEditorHint;
        private System.Windows.Forms.TableLayoutPanel editor;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.CheckedListBox permissionList;
        private System.Windows.Forms.FlowLayoutPanel buttons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.root = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.contentLayout = new System.Windows.Forms.TableLayoutPanel();
            this.listPanel = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblListHint = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.editorPanel = new System.Windows.Forms.Panel();
            this.editor = new System.Windows.Forms.TableLayoutPanel();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.permissionList = new System.Windows.Forms.CheckedListBox();
            this.buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblEditorHint = new System.Windows.Forms.Label();
            this.lblEditorTitle = new System.Windows.Forms.Label();
            this.root.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.contentLayout.SuspendLayout();
            this.listPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.editorPanel.SuspendLayout();
            this.editor.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.root.ColumnCount = 1;
            this.root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Controls.Add(this.headerPanel, 0, 0);
            this.root.Controls.Add(this.contentLayout, 0, 1);
            this.root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.Padding = new System.Windows.Forms.Padding(28, 24, 28, 24);
            this.root.RowCount = 2;
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.root.Size = new System.Drawing.Size(1100, 700);
            this.root.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(31, 27);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1038, 80);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1388, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Role Management";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSubtitle.Location = new System.Drawing.Point(2, 46);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(620, 24);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Create roles and configure access to HRIS modules.";
            // 
            // contentLayout
            // 
            this.contentLayout.ColumnCount = 2;
            this.contentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.contentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.contentLayout.Controls.Add(this.listPanel, 0, 0);
            this.contentLayout.Controls.Add(this.editorPanel, 1, 0);
            this.contentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentLayout.Location = new System.Drawing.Point(31, 113);
            this.contentLayout.Name = "contentLayout";
            this.contentLayout.RowCount = 1;
            this.contentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentLayout.Size = new System.Drawing.Size(1038, 560);
            this.contentLayout.TabIndex = 1;
            // 
            // listPanel
            // 
            this.listPanel.BackColor = System.Drawing.Color.White;
            this.listPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listPanel.Controls.Add(this.grid);
            this.listPanel.Controls.Add(this.lblListHint);
            this.listPanel.Controls.Add(this.lblListTitle);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPanel.Location = new System.Drawing.Point(0, 0);
            this.listPanel.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.listPanel.Name = "listPanel";
            this.listPanel.Padding = new System.Windows.Forms.Padding(18);
            this.listPanel.Size = new System.Drawing.Size(446, 560);
            this.listPanel.TabIndex = 0;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.ColumnHeadersHeight = 40;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.grid.Location = new System.Drawing.Point(18, 86);
            this.grid.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 36;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(408, 454);
            this.grid.TabIndex = 0;
            this.grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
            // 
            // lblListHint
            // 
            this.lblListHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblListHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblListHint.Location = new System.Drawing.Point(18, 48);
            this.lblListHint.Name = "lblListHint";
            this.lblListHint.Size = new System.Drawing.Size(408, 38);
            this.lblListHint.TabIndex = 1;
            this.lblListHint.Text = "Select a role to view or edit its permissions.";
            // 
            // lblListTitle
            // 
            this.lblListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblListTitle.Location = new System.Drawing.Point(18, 18);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(408, 30);
            this.lblListTitle.TabIndex = 2;
            this.lblListTitle.Text = "Available Roles";
            // 
            // editorPanel
            // 
            this.editorPanel.BackColor = System.Drawing.Color.White;
            this.editorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorPanel.Controls.Add(this.editor);
            this.editorPanel.Controls.Add(this.lblEditorHint);
            this.editorPanel.Controls.Add(this.lblEditorTitle);
            this.editorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorPanel.Location = new System.Drawing.Point(466, 0);
            this.editorPanel.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.editorPanel.Name = "editorPanel";
            this.editorPanel.Padding = new System.Windows.Forms.Padding(20);
            this.editorPanel.Size = new System.Drawing.Size(572, 560);
            this.editorPanel.TabIndex = 1;
            // 
            // editor
            // 
            this.editor.ColumnCount = 1;
            this.editor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editor.Controls.Add(this.lblCode, 0, 0);
            this.editor.Controls.Add(this.txtCode, 0, 1);
            this.editor.Controls.Add(this.lblName, 0, 2);
            this.editor.Controls.Add(this.txtName, 0, 3);
            this.editor.Controls.Add(this.chkActive, 0, 4);
            this.editor.Controls.Add(this.lblPermissions, 0, 5);
            this.editor.Controls.Add(this.permissionList, 0, 6);
            this.editor.Controls.Add(this.buttons, 0, 7);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(20, 88);
            this.editor.Name = "editor";
            this.editor.RowCount = 8;
            this.editor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.editor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.editor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.editor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.editor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.editor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.editor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.editor.Size = new System.Drawing.Size(530, 450);
            this.editor.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblCode.Location = new System.Drawing.Point(3, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(524, 27);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "ROLE CODE";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.txtCode.Location = new System.Drawing.Point(3, 29);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 9);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(524, 25);
            this.txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblName.Location = new System.Drawing.Point(3, 71);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(524, 27);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "ROLE NAME";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.txtName.Location = new System.Drawing.Point(3, 100);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 9);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(524, 25);
            this.txtName.TabIndex = 3;
            // 
            // chkActive
            // 
            this.chkActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.chkActive.Location = new System.Drawing.Point(3, 152);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(103, 21);
            this.chkActive.TabIndex = 4;
            this.chkActive.Text = "Role is active";
            // 
            // lblPermissions
            // 
            this.lblPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPermissions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblPermissions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblPermissions.Location = new System.Drawing.Point(3, 184);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(524, 34);
            this.lblPermissions.TabIndex = 5;
            this.lblPermissions.Text = "MODULE PERMISSIONS";
            // 
            // permissionList
            // 
            this.permissionList.BackColor = System.Drawing.Color.White;
            this.permissionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.permissionList.CheckOnClick = true;
            this.permissionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permissionList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.permissionList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.permissionList.IntegralHeight = false;
            this.permissionList.Location = new System.Drawing.Point(3, 218);
            this.permissionList.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.permissionList.Name = "permissionList";
            this.permissionList.Size = new System.Drawing.Size(524, 160);
            this.permissionList.TabIndex = 6;
            // 
            // buttons
            // 
            this.buttons.Controls.Add(this.btnSave);
            this.buttons.Controls.Add(this.btnNew);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttons.Location = new System.Drawing.Point(3, 391);
            this.buttons.Name = "buttons";
            this.buttons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.buttons.Size = new System.Drawing.Size(524, 56);
            this.buttons.TabIndex = 7;
            this.buttons.WrapContents = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(395, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Role";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(228)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnNew.Location = new System.Drawing.Point(263, 13);
            this.btnNew.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(126, 38);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New Role";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // lblEditorHint
            // 
            this.lblEditorHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEditorHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEditorHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblEditorHint.Location = new System.Drawing.Point(20, 50);
            this.lblEditorHint.Name = "lblEditorHint";
            this.lblEditorHint.Size = new System.Drawing.Size(530, 38);
            this.lblEditorHint.TabIndex = 1;
            this.lblEditorHint.Text = "Manage role information and module access.";
            // 
            // lblEditorTitle
            // 
            this.lblEditorTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEditorTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEditorTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblEditorTitle.Location = new System.Drawing.Point(20, 20);
            this.lblEditorTitle.Name = "lblEditorTitle";
            this.lblEditorTitle.Size = new System.Drawing.Size(530, 30);
            this.lblEditorTitle.TabIndex = 2;
            this.lblEditorTitle.Text = "Role Details";
            // 
            // RoleManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.root);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "RoleManagementControl";
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.RoleManagementControl_Load);
            this.root.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.contentLayout.ResumeLayout(false);
            this.listPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.editorPanel.ResumeLayout(false);
            this.editor.ResumeLayout(false);
            this.editor.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
