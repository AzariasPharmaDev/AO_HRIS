using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Leave
{
    partial class LeaveManagementControl
    {
        private IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Label lblHeading;
        private Label lblSubtitle;
        private TabControl tabs;
        private TabPage tabRequests;
        private TabPage tabLeaveTypes;
        private TabPage tabLeaveBalances;
        private DataGridView dgvRequests;
        private DataGridView dgvTypes;
        private DataGridView dgvBalances;
        private FlowLayoutPanel requestBar;
        private FlowLayoutPanel typeBar;
        private FlowLayoutPanel balanceBar;
        private Button btnNewRequest;
        private Button btnRefreshRequests;
        private Button btnApprove;
        private Button btnReject;
        private Button btnAddLeaveType;
        private Button btnEditLeaveType;
        private Button btnToggleLeaveType;
        private Button btnRefreshTypes;
        private Button btnSetBalance;
        private Button btnRefreshBalances;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabRequests = new System.Windows.Forms.TabPage();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.requestBar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewRequest = new System.Windows.Forms.Button();
            this.btnRefreshRequests = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.tabLeaveTypes = new System.Windows.Forms.TabPage();
            this.dgvTypes = new System.Windows.Forms.DataGridView();
            this.typeBar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddLeaveType = new System.Windows.Forms.Button();
            this.btnEditLeaveType = new System.Windows.Forms.Button();
            this.btnToggleLeaveType = new System.Windows.Forms.Button();
            this.btnRefreshTypes = new System.Windows.Forms.Button();
            this.tabLeaveBalances = new System.Windows.Forms.TabPage();
            this.dgvBalances = new System.Windows.Forms.DataGridView();
            this.balanceBar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSetBalance = new System.Windows.Forms.Button();
            this.btnRefreshBalances = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.requestBar.SuspendLayout();
            this.tabLeaveTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).BeginInit();
            this.typeBar.SuspendLayout();
            this.tabLeaveBalances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalances)).BeginInit();
            this.balanceBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.pnlHeader, 0, 0);
            this.mainLayout.Controls.Add(this.pnlContent, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(24);
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1487, 739);
            this.mainLayout.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnlHeader.Controls.Add(this.lblHeading);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(24, 24);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1439, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblHeading.Location = new System.Drawing.Point(0, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(256, 37);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Leave Management";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSubtitle.Location = new System.Drawing.Point(2, 39);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(426, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage leave requests, leave categories, and shared annual balances across subsidiaries.";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.tabs);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(24, 100);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Size = new System.Drawing.Size(1439, 615);
            this.pnlContent.TabIndex = 1;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabRequests);
            this.tabs.Controls.Add(this.tabLeaveTypes);
            this.tabs.Controls.Add(this.tabLeaveBalances);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(16, 6);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1415, 591);
            this.tabs.TabIndex = 0;
            // 
            // tabRequests
            // 
            this.tabRequests.BackColor = System.Drawing.Color.White;
            this.tabRequests.Controls.Add(this.dgvRequests);
            this.tabRequests.Controls.Add(this.requestBar);
            this.tabRequests.Location = new System.Drawing.Point(4, 30);
            this.tabRequests.Name = "tabRequests";
            this.tabRequests.Padding = new System.Windows.Forms.Padding(10);
            this.tabRequests.Size = new System.Drawing.Size(1407, 557);
            this.tabRequests.TabIndex = 0;
            this.tabRequests.Text = "Leave Requests";
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.dgvRequests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRequests.ColumnHeadersHeight = 42;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequests.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequests.EnableHeadersVisualStyles = false;
            this.dgvRequests.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.dgvRequests.Location = new System.Drawing.Point(10, 58);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.RowTemplate.Height = 36;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(1387, 489);
            this.dgvRequests.TabIndex = 0;
            // 
            // requestBar
            // 
            this.requestBar.BackColor = System.Drawing.Color.White;
            this.requestBar.Controls.Add(this.btnNewRequest);
            this.requestBar.Controls.Add(this.btnRefreshRequests);
            this.requestBar.Controls.Add(this.btnApprove);
            this.requestBar.Controls.Add(this.btnReject);
            this.requestBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.requestBar.Location = new System.Drawing.Point(10, 10);
            this.requestBar.Margin = new System.Windows.Forms.Padding(0);
            this.requestBar.Name = "requestBar";
            this.requestBar.Padding = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.requestBar.Size = new System.Drawing.Size(1387, 48);
            this.requestBar.TabIndex = 1;
            this.requestBar.WrapContents = false;
            // 
            // btnNewRequest
            // 
            this.btnNewRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnNewRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewRequest.FlatAppearance.BorderSize = 0;
            this.btnNewRequest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnNewRequest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnNewRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRequest.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnNewRequest.ForeColor = System.Drawing.Color.White;
            this.btnNewRequest.Location = new System.Drawing.Point(0, 4);
            this.btnNewRequest.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnNewRequest.Name = "btnNewRequest";
            this.btnNewRequest.Size = new System.Drawing.Size(150, 36);
            this.btnNewRequest.TabIndex = 0;
            this.btnNewRequest.Text = "New Leave Request";
            this.btnNewRequest.UseVisualStyleBackColor = false;
            // 
            // btnRefreshRequests
            // 
            this.btnRefreshRequests.BackColor = System.Drawing.Color.White;
            this.btnRefreshRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshRequests.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnRefreshRequests.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnRefreshRequests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnRefreshRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshRequests.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshRequests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnRefreshRequests.Location = new System.Drawing.Point(158, 4);
            this.btnRefreshRequests.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnRefreshRequests.Name = "btnRefreshRequests";
            this.btnRefreshRequests.Size = new System.Drawing.Size(90, 36);
            this.btnRefreshRequests.TabIndex = 1;
            this.btnRefreshRequests.Text = "Refresh";
            this.btnRefreshRequests.UseVisualStyleBackColor = false;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnApprove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(256, 4);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 36);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnReject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnReject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(364, 4);
            this.btnReject.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(90, 36);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            // 
            // tabLeaveTypes
            // 
            this.tabLeaveTypes.BackColor = System.Drawing.Color.White;
            this.tabLeaveTypes.Controls.Add(this.dgvTypes);
            this.tabLeaveTypes.Controls.Add(this.typeBar);
            this.tabLeaveTypes.Location = new System.Drawing.Point(4, 30);
            this.tabLeaveTypes.Name = "tabLeaveTypes";
            this.tabLeaveTypes.Padding = new System.Windows.Forms.Padding(10);
            this.tabLeaveTypes.Size = new System.Drawing.Size(192, 66);
            this.tabLeaveTypes.TabIndex = 1;
            this.tabLeaveTypes.Text = "Leave Types";
            // 
            // dgvTypes
            // 
            this.dgvTypes.AllowUserToAddRows = false;
            this.dgvTypes.AllowUserToDeleteRows = false;
            this.dgvTypes.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.dgvTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTypes.ColumnHeadersHeight = 42;
            this.dgvTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTypes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTypes.EnableHeadersVisualStyles = false;
            this.dgvTypes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.dgvTypes.Location = new System.Drawing.Point(10, 58);
            this.dgvTypes.MultiSelect = false;
            this.dgvTypes.Name = "dgvTypes";
            this.dgvTypes.ReadOnly = true;
            this.dgvTypes.RowHeadersVisible = false;
            this.dgvTypes.RowTemplate.Height = 36;
            this.dgvTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTypes.Size = new System.Drawing.Size(172, 0);
            this.dgvTypes.TabIndex = 0;
            // 
            // typeBar
            // 
            this.typeBar.BackColor = System.Drawing.Color.White;
            this.typeBar.Controls.Add(this.btnAddLeaveType);
            this.typeBar.Controls.Add(this.btnEditLeaveType);
            this.typeBar.Controls.Add(this.btnToggleLeaveType);
            this.typeBar.Controls.Add(this.btnRefreshTypes);
            this.typeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.typeBar.Location = new System.Drawing.Point(10, 10);
            this.typeBar.Margin = new System.Windows.Forms.Padding(0);
            this.typeBar.Name = "typeBar";
            this.typeBar.Padding = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.typeBar.Size = new System.Drawing.Size(172, 48);
            this.typeBar.TabIndex = 1;
            this.typeBar.WrapContents = false;
            // 
            // btnAddLeaveType
            // 
            this.btnAddLeaveType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnAddLeaveType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLeaveType.FlatAppearance.BorderSize = 0;
            this.btnAddLeaveType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnAddLeaveType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnAddLeaveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLeaveType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddLeaveType.ForeColor = System.Drawing.Color.White;
            this.btnAddLeaveType.Location = new System.Drawing.Point(0, 4);
            this.btnAddLeaveType.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnAddLeaveType.Name = "btnAddLeaveType";
            this.btnAddLeaveType.Size = new System.Drawing.Size(130, 36);
            this.btnAddLeaveType.TabIndex = 0;
            this.btnAddLeaveType.Text = "Add Leave Type";
            this.btnAddLeaveType.UseVisualStyleBackColor = false;
            // 
            // btnEditLeaveType
            // 
            this.btnEditLeaveType.BackColor = System.Drawing.Color.White;
            this.btnEditLeaveType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditLeaveType.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnEditLeaveType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnEditLeaveType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnEditLeaveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditLeaveType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditLeaveType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnEditLeaveType.Location = new System.Drawing.Point(138, 4);
            this.btnEditLeaveType.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnEditLeaveType.Name = "btnEditLeaveType";
            this.btnEditLeaveType.Size = new System.Drawing.Size(120, 36);
            this.btnEditLeaveType.TabIndex = 1;
            this.btnEditLeaveType.Text = "Edit Selected";
            this.btnEditLeaveType.UseVisualStyleBackColor = false;
            // 
            // btnToggleLeaveType
            // 
            this.btnToggleLeaveType.BackColor = System.Drawing.Color.White;
            this.btnToggleLeaveType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleLeaveType.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnToggleLeaveType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnToggleLeaveType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnToggleLeaveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLeaveType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleLeaveType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnToggleLeaveType.Location = new System.Drawing.Point(266, 4);
            this.btnToggleLeaveType.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnToggleLeaveType.Name = "btnToggleLeaveType";
            this.btnToggleLeaveType.Size = new System.Drawing.Size(160, 36);
            this.btnToggleLeaveType.TabIndex = 2;
            this.btnToggleLeaveType.Text = "Activate / Deactivate";
            this.btnToggleLeaveType.UseVisualStyleBackColor = false;
            // 
            // btnRefreshTypes
            // 
            this.btnRefreshTypes.BackColor = System.Drawing.Color.White;
            this.btnRefreshTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshTypes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnRefreshTypes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnRefreshTypes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnRefreshTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTypes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnRefreshTypes.Location = new System.Drawing.Point(434, 4);
            this.btnRefreshTypes.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnRefreshTypes.Name = "btnRefreshTypes";
            this.btnRefreshTypes.Size = new System.Drawing.Size(90, 36);
            this.btnRefreshTypes.TabIndex = 3;
            this.btnRefreshTypes.Text = "Refresh";
            this.btnRefreshTypes.UseVisualStyleBackColor = false;
            // 
            // tabLeaveBalances
            // 
            this.tabLeaveBalances.BackColor = System.Drawing.Color.White;
            this.tabLeaveBalances.Controls.Add(this.dgvBalances);
            this.tabLeaveBalances.Controls.Add(this.balanceBar);
            this.tabLeaveBalances.Location = new System.Drawing.Point(4, 30);
            this.tabLeaveBalances.Name = "tabLeaveBalances";
            this.tabLeaveBalances.Padding = new System.Windows.Forms.Padding(10);
            this.tabLeaveBalances.Size = new System.Drawing.Size(192, 66);
            this.tabLeaveBalances.TabIndex = 2;
            this.tabLeaveBalances.Text = "Annual Leave Balances";
            // 
            // dgvBalances
            // 
            this.dgvBalances.AllowUserToAddRows = false;
            this.dgvBalances.AllowUserToDeleteRows = false;
            this.dgvBalances.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.dgvBalances.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBalances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBalances.BackgroundColor = System.Drawing.Color.White;
            this.dgvBalances.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBalances.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBalances.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBalances.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBalances.ColumnHeadersHeight = 42;
            this.dgvBalances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBalances.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBalances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalances.EnableHeadersVisualStyles = false;
            this.dgvBalances.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.dgvBalances.Location = new System.Drawing.Point(10, 58);
            this.dgvBalances.MultiSelect = false;
            this.dgvBalances.Name = "dgvBalances";
            this.dgvBalances.ReadOnly = true;
            this.dgvBalances.RowHeadersVisible = false;
            this.dgvBalances.RowTemplate.Height = 36;
            this.dgvBalances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalances.Size = new System.Drawing.Size(172, 0);
            this.dgvBalances.TabIndex = 0;
            // 
            // balanceBar
            // 
            this.balanceBar.BackColor = System.Drawing.Color.White;
            this.balanceBar.Controls.Add(this.btnSetBalance);
            this.balanceBar.Controls.Add(this.btnRefreshBalances);
            this.balanceBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.balanceBar.Location = new System.Drawing.Point(10, 10);
            this.balanceBar.Margin = new System.Windows.Forms.Padding(0);
            this.balanceBar.Name = "balanceBar";
            this.balanceBar.Padding = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.balanceBar.Size = new System.Drawing.Size(172, 48);
            this.balanceBar.TabIndex = 1;
            this.balanceBar.WrapContents = false;
            // 
            // btnSetBalance
            // 
            this.btnSetBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSetBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetBalance.FlatAppearance.BorderSize = 0;
            this.btnSetBalance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnSetBalance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnSetBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSetBalance.ForeColor = System.Drawing.Color.White;
            this.btnSetBalance.Location = new System.Drawing.Point(0, 4);
            this.btnSetBalance.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnSetBalance.Name = "btnSetBalance";
            this.btnSetBalance.Size = new System.Drawing.Size(160, 36);
            this.btnSetBalance.TabIndex = 0;
            this.btnSetBalance.Text = "Set / Update Balance";
            this.btnSetBalance.UseVisualStyleBackColor = false;
            // 
            // btnRefreshBalances
            // 
            this.btnRefreshBalances.BackColor = System.Drawing.Color.White;
            this.btnRefreshBalances.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshBalances.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnRefreshBalances.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnRefreshBalances.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.btnRefreshBalances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBalances.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshBalances.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnRefreshBalances.Location = new System.Drawing.Point(168, 4);
            this.btnRefreshBalances.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.btnRefreshBalances.Name = "btnRefreshBalances";
            this.btnRefreshBalances.Size = new System.Drawing.Size(90, 36);
            this.btnRefreshBalances.TabIndex = 1;
            this.btnRefreshBalances.Text = "Refresh";
            this.btnRefreshBalances.UseVisualStyleBackColor = false;
            // 
            // LeaveManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "LeaveManagementControl";
            this.Size = new System.Drawing.Size(1487, 739);
            this.mainLayout.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.requestBar.ResumeLayout(false);
            this.tabLeaveTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).EndInit();
            this.typeBar.ResumeLayout(false);
            this.tabLeaveBalances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalances)).EndInit();
            this.balanceBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
