
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Compensation
{
    partial class CompensationManagementControl
    {
        private IContainer components = null;

        private TableLayoutPanel mainLayout;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Label lblHeading;
        private Label lblSubtitle;

        private SplitContainer splitMain;
        private Panel pnlEmployees;
        private Panel pnlDetails;
        private Label lblEmployeeHeading;
        private TextBox txtSearch;
        private Button btnRefresh;
        private DataGridView dgvEmployees;

        private Label lblSelectedEmployee;
        private Panel pnlCurrent;
        private Label lblCurrentHeading;
        private Label lblCurrentSalary;
        private Label lblCurrentCurrency;
        private Label lblCurrentEffective;

        private Label lblHistoryHeading;
        private DataGridView dgvHistory;

        private Panel pnlEntry;
        private Label lblEntryHeading;
        private Label lblSalary;
        private Label lblCurrency;
        private Label lblEffective;
        private Label lblRemarks;
        private NumericUpDown nudBasicSalary;
        private TextBox txtCurrency;
        private DateTimePicker dtpEffectiveFrom;
        private TextBox txtRemarks;
        private Button btnRecordSalary;
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlEmployees = new System.Windows.Forms.Panel();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblEmployeeHeading = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.btnRecordSalary = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dtpEffectiveFrom = new System.Windows.Forms.DateTimePicker();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.nudBasicSalary = new System.Windows.Forms.NumericUpDown();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblEffective = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblEntryHeading = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.lblHistoryHeading = new System.Windows.Forms.Label();
            this.pnlCurrent = new System.Windows.Forms.Panel();
            this.lblCurrentEffective = new System.Windows.Forms.Label();
            this.lblCurrentCurrency = new System.Windows.Forms.Label();
            this.lblCurrentSalary = new System.Windows.Forms.Label();
            this.lblCurrentHeading = new System.Windows.Forms.Label();
            this.lblSelectedEmployee = new System.Windows.Forms.Label();
            this.mainLayout.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasicSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlCurrent.SuspendLayout();
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
            this.lblHeading.Size = new System.Drawing.Size(365, 37);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Compensation Management";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSubtitle.Location = new System.Drawing.Point(2, 39);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(534, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Record employee basic salary and review compensation history for the selected company.";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.splitMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(27, 103);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Size = new System.Drawing.Size(1433, 609);
            this.pnlContent.TabIndex = 1;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(12, 12);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlEmployees);
            this.splitMain.Panel1MinSize = 0;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlDetails);
            this.splitMain.Panel2MinSize = 0;
            this.splitMain.Size = new System.Drawing.Size(1409, 585);
            this.splitMain.SplitterDistance = 420;
            this.splitMain.SplitterWidth = 6;
            this.splitMain.TabIndex = 0;
            // 
            // pnlEmployees
            // 
            this.pnlEmployees.BackColor = System.Drawing.Color.White;
            this.pnlEmployees.Controls.Add(this.dgvEmployees);
            this.pnlEmployees.Controls.Add(this.btnRefresh);
            this.pnlEmployees.Controls.Add(this.txtSearch);
            this.pnlEmployees.Controls.Add(this.lblEmployeeHeading);
            this.pnlEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmployees.Location = new System.Drawing.Point(0, 0);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(420, 585);
            this.pnlEmployees.TabIndex = 0;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToResizeRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmployees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEmployees.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployees.ColumnHeadersHeight = 42;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployees.EnableHeadersVisualStyles = false;
            this.dgvEmployees.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.dgvEmployees.Location = new System.Drawing.Point(4, 82);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.RowTemplate.Height = 36;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(588, 1055);
            this.dgvEmployees.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnRefresh.Location = new System.Drawing.Point(257, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(4, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(245, 23);
            this.txtSearch.TabIndex = 2;
            // 
            // lblEmployeeHeading
            // 
            this.lblEmployeeHeading.AutoSize = true;
            this.lblEmployeeHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmployeeHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblEmployeeHeading.Location = new System.Drawing.Point(4, 8);
            this.lblEmployeeHeading.Name = "lblEmployeeHeading";
            this.lblEmployeeHeading.Size = new System.Drawing.Size(82, 20);
            this.lblEmployeeHeading.TabIndex = 3;
            this.lblEmployeeHeading.Text = "Employees";
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.Controls.Add(this.pnlEntry);
            this.pnlDetails.Controls.Add(this.dgvHistory);
            this.pnlDetails.Controls.Add(this.lblHistoryHeading);
            this.pnlDetails.Controls.Add(this.pnlCurrent);
            this.pnlDetails.Controls.Add(this.lblSelectedEmployee);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Padding = new System.Windows.Forms.Padding(12, 4, 4, 4);
            this.pnlDetails.Size = new System.Drawing.Size(983, 585);
            this.pnlDetails.TabIndex = 0;
            // pnlEntry
            this.pnlEntry.BackColor = Color.FromArgb(247, 250, 254);
            this.pnlEntry.Controls.Add(this.btnRecordSalary);
            this.pnlEntry.Controls.Add(this.txtRemarks);
            this.pnlEntry.Controls.Add(this.dtpEffectiveFrom);
            this.pnlEntry.Controls.Add(this.txtCurrency);
            this.pnlEntry.Controls.Add(this.nudBasicSalary);
            this.pnlEntry.Controls.Add(this.lblRemarks);
            this.pnlEntry.Controls.Add(this.lblEffective);
            this.pnlEntry.Controls.Add(this.lblCurrency);
            this.pnlEntry.Controls.Add(this.lblSalary);
            this.pnlEntry.Controls.Add(this.lblEntryHeading);

            this.pnlEntry.Location = new Point(12, 434);
            this.pnlEntry.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.pnlEntry.Size = new Size(850, 185);
            this.pnlEntry.Padding = new Padding(12);
            // 
            // btnRecordSalary
            // 
            this.btnRecordSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnRecordSalary.FlatAppearance.BorderSize = 0;
            this.btnRecordSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecordSalary.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRecordSalary.ForeColor = System.Drawing.Color.White;
            this.btnRecordSalary.Location = new System.Drawing.Point(8, 0);
            this.btnRecordSalary.Name = "btnRecordSalary";
            this.btnRecordSalary.Size = new System.Drawing.Size(170, 36);
            this.btnRecordSalary.TabIndex = 0;
            this.btnRecordSalary.Text = "Record New Salary";
            this.btnRecordSalary.UseVisualStyleBackColor = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(492, 64);
            this.txtRemarks.MaxLength = 500;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(1013, 23);
            this.txtRemarks.TabIndex = 1;
            // 
            // dtpEffectiveFrom
            // 
            this.dtpEffectiveFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEffectiveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveFrom.Location = new System.Drawing.Point(326, 64);
            this.dtpEffectiveFrom.Name = "dtpEffectiveFrom";
            this.dtpEffectiveFrom.Size = new System.Drawing.Size(150, 23);
            this.dtpEffectiveFrom.TabIndex = 2;
            // 
            // txtCurrency
            // 
            this.txtCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurrency.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCurrency.Location = new System.Drawing.Point(220, 64);
            this.txtCurrency.MaxLength = 3;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(90, 23);
            this.txtCurrency.TabIndex = 3;
            this.txtCurrency.Text = "PHP";
            // 
            // nudBasicSalary
            // 
            this.nudBasicSalary.DecimalPlaces = 2;
            this.nudBasicSalary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudBasicSalary.Location = new System.Drawing.Point(14, 64);
            this.nudBasicSalary.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudBasicSalary.Name = "nudBasicSalary";
            this.nudBasicSalary.Size = new System.Drawing.Size(190, 23);
            this.nudBasicSalary.TabIndex = 4;
            this.nudBasicSalary.ThousandsSeparator = true;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblRemarks.Location = new System.Drawing.Point(492, 42);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(52, 15);
            this.lblRemarks.TabIndex = 5;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblEffective
            // 
            this.lblEffective.AutoSize = true;
            this.lblEffective.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblEffective.Location = new System.Drawing.Point(326, 42);
            this.lblEffective.Name = "lblEffective";
            this.lblEffective.Size = new System.Drawing.Size(83, 15);
            this.lblEffective.TabIndex = 6;
            this.lblEffective.Text = "Effective From";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblCurrency.Location = new System.Drawing.Point(220, 42);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 15);
            this.lblCurrency.TabIndex = 7;
            this.lblCurrency.Text = "Currency";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSalary.Location = new System.Drawing.Point(14, 42);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(68, 15);
            this.lblSalary.TabIndex = 8;
            this.lblSalary.Text = "Basic Salary";
            // 
            // lblEntryHeading
            // 
            this.lblEntryHeading.AutoSize = true;
            this.lblEntryHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblEntryHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblEntryHeading.Location = new System.Drawing.Point(12, 8);
            this.lblEntryHeading.Name = "lblEntryHeading";
            this.lblEntryHeading.Size = new System.Drawing.Size(129, 19);
            this.lblEntryHeading.TabIndex = 9;
            this.lblEntryHeading.Text = "Record New Salary";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.dgvHistory.Location = new Point(12, 188);
            this.dgvHistory.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;
            this.dgvHistory.Size = new Size(850, 230);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 34;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.TabIndex = 1;
            // 
            // lblHistoryHeading
            // 
            this.lblHistoryHeading.AutoSize = true;
            this.lblHistoryHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblHistoryHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblHistoryHeading.Location = new System.Drawing.Point(12, 158);
            this.lblHistoryHeading.Name = "lblHistoryHeading";
            this.lblHistoryHeading.Size = new System.Drawing.Size(106, 20);
            this.lblHistoryHeading.TabIndex = 2;
            this.lblHistoryHeading.Text = "Salary History";
            // 
            // pnlCurrent
            // 
            this.pnlCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnlCurrent.Controls.Add(this.lblCurrentEffective);
            this.pnlCurrent.Controls.Add(this.lblCurrentCurrency);
            this.pnlCurrent.Controls.Add(this.lblCurrentSalary);
            this.pnlCurrent.Controls.Add(this.lblCurrentHeading);
            this.pnlCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCurrent.Location = new System.Drawing.Point(12, 38);
            this.pnlCurrent.Name = "pnlCurrent";
            this.pnlCurrent.Padding = new System.Windows.Forms.Padding(14);
            this.pnlCurrent.Size = new System.Drawing.Size(967, 132);
            this.pnlCurrent.TabIndex = 3;
            // 
            // lblCurrentEffective
            // 
            this.lblCurrentEffective.AutoSize = true;
            this.lblCurrentEffective.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentEffective.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblCurrentEffective.Location = new System.Drawing.Point(16, 91);
            this.lblCurrentEffective.Name = "lblCurrentEffective";
            this.lblCurrentEffective.Size = new System.Drawing.Size(0, 15);
            this.lblCurrentEffective.TabIndex = 0;
            // 
            // lblCurrentCurrency
            // 
            this.lblCurrentCurrency.AutoSize = true;
            this.lblCurrentCurrency.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblCurrentCurrency.Location = new System.Drawing.Point(230, 52);
            this.lblCurrentCurrency.Name = "lblCurrentCurrency";
            this.lblCurrentCurrency.Size = new System.Drawing.Size(0, 19);
            this.lblCurrentCurrency.TabIndex = 1;
            // 
            // lblCurrentSalary
            // 
            this.lblCurrentSalary.AutoSize = true;
            this.lblCurrentSalary.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblCurrentSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblCurrentSalary.Location = new System.Drawing.Point(12, 32);
            this.lblCurrentSalary.Name = "lblCurrentSalary";
            this.lblCurrentSalary.Size = new System.Drawing.Size(52, 45);
            this.lblCurrentSalary.TabIndex = 2;
            this.lblCurrentSalary.Text = "—";
            // 
            // lblCurrentHeading
            // 
            this.lblCurrentHeading.AutoSize = true;
            this.lblCurrentHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrentHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblCurrentHeading.Location = new System.Drawing.Point(14, 10);
            this.lblCurrentHeading.Name = "lblCurrentHeading";
            this.lblCurrentHeading.Size = new System.Drawing.Size(140, 15);
            this.lblCurrentHeading.TabIndex = 3;
            this.lblCurrentHeading.Text = "CURRENT BASIC SALARY";
            // 
            // lblSelectedEmployee
            // 
            this.lblSelectedEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectedEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSelectedEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblSelectedEmployee.Location = new System.Drawing.Point(12, 4);
            this.lblSelectedEmployee.Name = "lblSelectedEmployee";
            this.lblSelectedEmployee.Size = new System.Drawing.Size(967, 34);
            this.lblSelectedEmployee.TabIndex = 4;
            this.lblSelectedEmployee.Text = "No employee selected";
            this.lblSelectedEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CompensationManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "CompensationManagementControl";
            this.Size = new System.Drawing.Size(1487, 739);
            this.mainLayout.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlEmployees.ResumeLayout(false);
            this.pnlEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlEntry.ResumeLayout(false);
            this.pnlEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasicSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlCurrent.ResumeLayout(false);
            this.pnlCurrent.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
