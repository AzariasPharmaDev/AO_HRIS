namespace AO_HRIS.UserControls.Employees
{
    partial class EmployeeDirectoryControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlDetailsHeader;
        private System.Windows.Forms.Panel pnlDetailsBody;
        private System.Windows.Forms.Panel pnlGridTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblSelectedName;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Label lblSearchCaption;
        private System.Windows.Forms.Label lblDirectoryTag;
        private System.Windows.Forms.Label lblEmployeeNoCaption;
        private System.Windows.Forms.Label lblEmployeeNoValue;
        private System.Windows.Forms.Label lblEmailCaption;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Label lblMobileCaption;
        private System.Windows.Forms.Label lblMobileValue;
        private System.Windows.Forms.Label lblTelephoneCaption;
        private System.Windows.Forms.Label lblTelephoneValue;
        private System.Windows.Forms.Label lblAddressCaption;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblCompanyCaption;
        private System.Windows.Forms.Label lblCompanyValue;
        private System.Windows.Forms.Label lblDepartmentCaption;
        private System.Windows.Forms.Label lblDepartmentValue;
        private System.Windows.Forms.Label lblPositionCaption;
        private System.Windows.Forms.Label lblPositionValue;
        private System.Windows.Forms.Label lblHireDateCaption;
        private System.Windows.Forms.Label lblHireDateValue;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView gridEmployees;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblDirectoryTag = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblSearchCaption = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlDetailsBody = new System.Windows.Forms.Panel();
            this.lblEmployeeNoCaption = new System.Windows.Forms.Label();
            this.lblEmployeeNoValue = new System.Windows.Forms.Label();
            this.lblEmailCaption = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblMobileCaption = new System.Windows.Forms.Label();
            this.lblMobileValue = new System.Windows.Forms.Label();
            this.lblTelephoneCaption = new System.Windows.Forms.Label();
            this.lblTelephoneValue = new System.Windows.Forms.Label();
            this.lblAddressCaption = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblCompanyCaption = new System.Windows.Forms.Label();
            this.lblCompanyValue = new System.Windows.Forms.Label();
            this.lblDepartmentCaption = new System.Windows.Forms.Label();
            this.lblDepartmentValue = new System.Windows.Forms.Label();
            this.lblPositionCaption = new System.Windows.Forms.Label();
            this.lblPositionValue = new System.Windows.Forms.Label();
            this.lblHireDateCaption = new System.Windows.Forms.Label();
            this.lblHireDateValue = new System.Windows.Forms.Label();
            this.pnlDetailsHeader = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblSelectedName = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.gridEmployees = new System.Windows.Forms.DataGridView();
            this.pnlGridTitle = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlDetailsBody.SuspendLayout();
            this.pnlDetailsHeader.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            this.pnlGridTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblDirectoryTag);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1250, 108);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(257, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Employee Directory";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSubtitle.Location = new System.Drawing.Point(32, 66);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(364, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Find colleagues, contact details and company assignments";
            // 
            // lblDirectoryTag
            // 
            this.lblDirectoryTag.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDirectoryTag.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblDirectoryTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.lblDirectoryTag.Location = new System.Drawing.Point(1050, 0);
            this.lblDirectoryTag.Name = "lblDirectoryTag";
            this.lblDirectoryTag.Size = new System.Drawing.Size(170, 108);
            this.lblDirectoryTag.TabIndex = 2;
            this.lblDirectoryTag.Text = "STAFF DIRECTORY";
            this.lblDirectoryTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnlToolbar.Controls.Add(this.lblSearchCaption);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.btnSearch);
            this.pnlToolbar.Controls.Add(this.btnExport);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 108);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1250, 104);
            this.pnlToolbar.TabIndex = 2;
            // 
            // lblSearchCaption
            // 
            this.lblSearchCaption.AutoSize = true;
            this.lblSearchCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblSearchCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblSearchCaption.Location = new System.Drawing.Point(30, 14);
            this.lblSearchCaption.Name = "lblSearchCaption";
            this.lblSearchCaption.Size = new System.Drawing.Size(119, 15);
            this.lblSearchCaption.TabIndex = 0;
            this.lblSearchCaption.Text = "SEARCH EMPLOYEES";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.txtSearch.Location = new System.Drawing.Point(30, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(430, 25);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(474, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 34);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnRefresh.Location = new System.Drawing.Point(589, 37);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 34);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.Controls.Add(this.pnlDetailsBody);
            this.pnlDetails.Controls.Add(this.pnlDetailsHeader);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(880, 212);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(370, 568);
            this.pnlDetails.TabIndex = 1;
            // 
            // pnlDetailsBody
            // 
            this.pnlDetailsBody.AutoScroll = true;
            this.pnlDetailsBody.AutoScrollMinSize = new System.Drawing.Size(0, 700);
            this.pnlDetailsBody.BackColor = System.Drawing.Color.White;
            this.pnlDetailsBody.Controls.Add(this.lblEmployeeNoCaption);
            this.pnlDetailsBody.Controls.Add(this.lblEmployeeNoValue);
            this.pnlDetailsBody.Controls.Add(this.lblEmailCaption);
            this.pnlDetailsBody.Controls.Add(this.lblEmailValue);
            this.pnlDetailsBody.Controls.Add(this.lblMobileCaption);
            this.pnlDetailsBody.Controls.Add(this.lblMobileValue);
            this.pnlDetailsBody.Controls.Add(this.lblTelephoneCaption);
            this.pnlDetailsBody.Controls.Add(this.lblTelephoneValue);
            this.pnlDetailsBody.Controls.Add(this.lblAddressCaption);
            this.pnlDetailsBody.Controls.Add(this.lblAddressValue);
            this.pnlDetailsBody.Controls.Add(this.lblCompanyCaption);
            this.pnlDetailsBody.Controls.Add(this.lblCompanyValue);
            this.pnlDetailsBody.Controls.Add(this.lblDepartmentCaption);
            this.pnlDetailsBody.Controls.Add(this.lblDepartmentValue);
            this.pnlDetailsBody.Controls.Add(this.lblPositionCaption);
            this.pnlDetailsBody.Controls.Add(this.lblPositionValue);
            this.pnlDetailsBody.Controls.Add(this.lblHireDateCaption);
            this.pnlDetailsBody.Controls.Add(this.lblHireDateValue);
            this.pnlDetailsBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailsBody.Location = new System.Drawing.Point(0, 124);
            this.pnlDetailsBody.Name = "pnlDetailsBody";
            this.pnlDetailsBody.Size = new System.Drawing.Size(370, 444);
            this.pnlDetailsBody.TabIndex = 0;
            // 
            // lblEmployeeNoCaption
            // 
            this.lblEmployeeNoCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblEmployeeNoCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblEmployeeNoCaption.Location = new System.Drawing.Point(24, 18);
            this.lblEmployeeNoCaption.Name = "lblEmployeeNoCaption";
            this.lblEmployeeNoCaption.Size = new System.Drawing.Size(320, 19);
            this.lblEmployeeNoCaption.TabIndex = 0;
            this.lblEmployeeNoCaption.Text = "EMPLOYEE NO.";
            // 
            // lblEmployeeNoValue
            // 
            this.lblEmployeeNoValue.AutoEllipsis = true;
            this.lblEmployeeNoValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmployeeNoValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblEmployeeNoValue.Location = new System.Drawing.Point(24, 41);
            this.lblEmployeeNoValue.Name = "lblEmployeeNoValue";
            this.lblEmployeeNoValue.Size = new System.Drawing.Size(318, 30);
            this.lblEmployeeNoValue.TabIndex = 1;
            this.lblEmployeeNoValue.Text = "—";
            // 
            // lblEmailCaption
            // 
            this.lblEmailCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblEmailCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblEmailCaption.Location = new System.Drawing.Point(24, 86);
            this.lblEmailCaption.Name = "lblEmailCaption";
            this.lblEmailCaption.Size = new System.Drawing.Size(320, 19);
            this.lblEmailCaption.TabIndex = 2;
            this.lblEmailCaption.Text = "EMAIL ADDRESS";
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.AutoEllipsis = true;
            this.lblEmailValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmailValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblEmailValue.Location = new System.Drawing.Point(24, 109);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(318, 30);
            this.lblEmailValue.TabIndex = 3;
            this.lblEmailValue.Text = "—";
            // 
            // lblMobileCaption
            // 
            this.lblMobileCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblMobileCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblMobileCaption.Location = new System.Drawing.Point(24, 154);
            this.lblMobileCaption.Name = "lblMobileCaption";
            this.lblMobileCaption.Size = new System.Drawing.Size(320, 19);
            this.lblMobileCaption.TabIndex = 4;
            this.lblMobileCaption.Text = "MOBILE NUMBER";
            // 
            // lblMobileValue
            // 
            this.lblMobileValue.AutoEllipsis = true;
            this.lblMobileValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMobileValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblMobileValue.Location = new System.Drawing.Point(24, 177);
            this.lblMobileValue.Name = "lblMobileValue";
            this.lblMobileValue.Size = new System.Drawing.Size(318, 30);
            this.lblMobileValue.TabIndex = 5;
            this.lblMobileValue.Text = "—";
            // 
            // lblTelephoneCaption
            // 
            this.lblTelephoneCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblTelephoneCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblTelephoneCaption.Location = new System.Drawing.Point(24, 222);
            this.lblTelephoneCaption.Name = "lblTelephoneCaption";
            this.lblTelephoneCaption.Size = new System.Drawing.Size(320, 19);
            this.lblTelephoneCaption.TabIndex = 6;
            this.lblTelephoneCaption.Text = "TELEPHONE NUMBER";
            // 
            // lblTelephoneValue
            // 
            this.lblTelephoneValue.AutoEllipsis = true;
            this.lblTelephoneValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTelephoneValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblTelephoneValue.Location = new System.Drawing.Point(24, 245);
            this.lblTelephoneValue.Name = "lblTelephoneValue";
            this.lblTelephoneValue.Size = new System.Drawing.Size(318, 30);
            this.lblTelephoneValue.TabIndex = 7;
            this.lblTelephoneValue.Text = "—";
            // 
            // lblAddressCaption
            // 
            this.lblAddressCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblAddressCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblAddressCaption.Location = new System.Drawing.Point(24, 290);
            this.lblAddressCaption.Name = "lblAddressCaption";
            this.lblAddressCaption.Size = new System.Drawing.Size(320, 19);
            this.lblAddressCaption.TabIndex = 8;
            this.lblAddressCaption.Text = "RESIDENTIAL ADDRESS";
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.AutoEllipsis = true;
            this.lblAddressValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAddressValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblAddressValue.Location = new System.Drawing.Point(24, 313);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(318, 42);
            this.lblAddressValue.TabIndex = 9;
            this.lblAddressValue.Text = "—";
            // 
            // lblCompanyCaption
            // 
            this.lblCompanyCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblCompanyCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblCompanyCaption.Location = new System.Drawing.Point(24, 374);
            this.lblCompanyCaption.Name = "lblCompanyCaption";
            this.lblCompanyCaption.Size = new System.Drawing.Size(320, 19);
            this.lblCompanyCaption.TabIndex = 10;
            this.lblCompanyCaption.Text = "COMPANY";
            // 
            // lblCompanyValue
            // 
            this.lblCompanyValue.AutoEllipsis = true;
            this.lblCompanyValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCompanyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblCompanyValue.Location = new System.Drawing.Point(24, 397);
            this.lblCompanyValue.Name = "lblCompanyValue";
            this.lblCompanyValue.Size = new System.Drawing.Size(318, 30);
            this.lblCompanyValue.TabIndex = 11;
            this.lblCompanyValue.Text = "—";
            // 
            // lblDepartmentCaption
            // 
            this.lblDepartmentCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblDepartmentCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblDepartmentCaption.Location = new System.Drawing.Point(24, 442);
            this.lblDepartmentCaption.Name = "lblDepartmentCaption";
            this.lblDepartmentCaption.Size = new System.Drawing.Size(320, 19);
            this.lblDepartmentCaption.TabIndex = 12;
            this.lblDepartmentCaption.Text = "DEPARTMENT";
            // 
            // lblDepartmentValue
            // 
            this.lblDepartmentValue.AutoEllipsis = true;
            this.lblDepartmentValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDepartmentValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblDepartmentValue.Location = new System.Drawing.Point(24, 465);
            this.lblDepartmentValue.Name = "lblDepartmentValue";
            this.lblDepartmentValue.Size = new System.Drawing.Size(318, 30);
            this.lblDepartmentValue.TabIndex = 13;
            this.lblDepartmentValue.Text = "—";
            // 
            // lblPositionCaption
            // 
            this.lblPositionCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblPositionCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblPositionCaption.Location = new System.Drawing.Point(24, 510);
            this.lblPositionCaption.Name = "lblPositionCaption";
            this.lblPositionCaption.Size = new System.Drawing.Size(320, 19);
            this.lblPositionCaption.TabIndex = 14;
            this.lblPositionCaption.Text = "POSITION";
            // 
            // lblPositionValue
            // 
            this.lblPositionValue.AutoEllipsis = true;
            this.lblPositionValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPositionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblPositionValue.Location = new System.Drawing.Point(24, 533);
            this.lblPositionValue.Name = "lblPositionValue";
            this.lblPositionValue.Size = new System.Drawing.Size(318, 30);
            this.lblPositionValue.TabIndex = 15;
            this.lblPositionValue.Text = "—";
            // 
            // lblHireDateCaption
            // 
            this.lblHireDateCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblHireDateCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblHireDateCaption.Location = new System.Drawing.Point(24, 578);
            this.lblHireDateCaption.Name = "lblHireDateCaption";
            this.lblHireDateCaption.Size = new System.Drawing.Size(320, 19);
            this.lblHireDateCaption.TabIndex = 16;
            this.lblHireDateCaption.Text = "HIRE DATE";
            // 
            // lblHireDateValue
            // 
            this.lblHireDateValue.AutoEllipsis = true;
            this.lblHireDateValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHireDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblHireDateValue.Location = new System.Drawing.Point(24, 601);
            this.lblHireDateValue.Name = "lblHireDateValue";
            this.lblHireDateValue.Size = new System.Drawing.Size(318, 30);
            this.lblHireDateValue.TabIndex = 17;
            this.lblHireDateValue.Text = "—";
            // 
            // pnlDetailsHeader
            // 
            this.pnlDetailsHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.pnlDetailsHeader.Controls.Add(this.lblDetailsTitle);
            this.pnlDetailsHeader.Controls.Add(this.lblSelectedName);
            this.pnlDetailsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailsHeader.Name = "pnlDetailsHeader";
            this.pnlDetailsHeader.Size = new System.Drawing.Size(370, 124);
            this.pnlDetailsHeader.TabIndex = 1;
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.lblDetailsTitle.Location = new System.Drawing.Point(24, 23);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(113, 15);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "EMPLOYEE PROFILE";
            // 
            // lblSelectedName
            // 
            this.lblSelectedName.AutoEllipsis = true;
            this.lblSelectedName.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblSelectedName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblSelectedName.Location = new System.Drawing.Point(24, 53);
            this.lblSelectedName.Name = "lblSelectedName";
            this.lblSelectedName.Size = new System.Drawing.Size(320, 60);
            this.lblSelectedName.TabIndex = 1;
            this.lblSelectedName.Text = "Select an employee";
            // 
            // pnlList
            // 
            this.pnlList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnlList.Controls.Add(this.gridEmployees);
            this.pnlList.Controls.Add(this.pnlGridTitle);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(0, 212);
            this.pnlList.Name = "pnlList";
            this.pnlList.Padding = new System.Windows.Forms.Padding(24, 20, 20, 24);
            this.pnlList.Size = new System.Drawing.Size(880, 568);
            this.pnlList.TabIndex = 0;
            // 
            // gridEmployees
            // 
            this.gridEmployees.AllowUserToAddRows = false;
            this.gridEmployees.AllowUserToDeleteRows = false;
            this.gridEmployees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridEmployees.BackgroundColor = System.Drawing.Color.White;
            this.gridEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridEmployees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridEmployees.ColumnHeadersHeight = 46;
            this.gridEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridEmployees.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmployees.EnableHeadersVisualStyles = false;
            this.gridEmployees.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.gridEmployees.Location = new System.Drawing.Point(24, 72);
            this.gridEmployees.MultiSelect = false;
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.ReadOnly = true;
            this.gridEmployees.RowHeadersVisible = false;
            this.gridEmployees.RowTemplate.Height = 42;
            this.gridEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmployees.Size = new System.Drawing.Size(836, 472);
            this.gridEmployees.TabIndex = 0;
            // 
            // pnlGridTitle
            // 
            this.pnlGridTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnlGridTitle.Controls.Add(this.lblGridTitle);
            this.pnlGridTitle.Controls.Add(this.lblCount);
            this.pnlGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridTitle.Location = new System.Drawing.Point(24, 20);
            this.pnlGridTitle.Name = "pnlGridTitle";
            this.pnlGridTitle.Size = new System.Drawing.Size(836, 52);
            this.pnlGridTitle.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblGridTitle.Location = new System.Drawing.Point(0, 8);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(101, 25);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "Employees";
            // 
            // lblCount
            // 
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblCount.Location = new System.Drawing.Point(601, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(235, 52);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "0 assignment(s) found";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnExport.Location = new System.Drawing.Point(700, 37);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(105, 34);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // EmployeeDirectoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(850, 520);
            this.Name = "EmployeeDirectoryControl";
            this.Size = new System.Drawing.Size(1250, 780);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetailsBody.ResumeLayout(false);
            this.pnlDetailsHeader.ResumeLayout(false);
            this.pnlDetailsHeader.PerformLayout();
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            this.pnlGridTitle.ResumeLayout(false);
            this.pnlGridTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnExport;
    }
}
