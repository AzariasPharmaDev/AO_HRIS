namespace AO_HRIS.Forms.Employees
{
    partial class EmployeeForm
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

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblFormSubtitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabEmployee = new System.Windows.Forms.TabControl();
            this.tabPersonal = new System.Windows.Forms.TabPage();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.lblTxtEmployeeNo = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblTxtFirstName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblTxtMiddleName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblTxtLastName = new System.Windows.Forms.Label();
            this.cmbSuffix = new System.Windows.Forms.ComboBox();
            this.lblCmbSuffix = new System.Windows.Forms.Label();
            this.txtPreferredName = new System.Windows.Forms.TextBox();
            this.lblTxtPreferredName = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblDtpBirthDate = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblCmbGender = new System.Windows.Forms.Label();
            this.cmbCivilStatus = new System.Windows.Forms.ComboBox();
            this.lblCmbCivilStatus = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.tabContact = new System.Windows.Forms.TabPage();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTxtEmail = new System.Windows.Forms.Label();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.lblTxtMobileNumber = new System.Windows.Forms.Label();
            this.txtTelephoneNumber = new System.Windows.Forms.TextBox();
            this.lblTxtTelephoneNumber = new System.Windows.Forms.Label();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.lblTxtAddressLine1 = new System.Windows.Forms.Label();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.lblTxtAddressLine2 = new System.Windows.Forms.Label();
            this.txtBarangay = new System.Windows.Forms.TextBox();
            this.lblTxtBarangay = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblTxtCity = new System.Windows.Forms.Label();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.lblTxtProvince = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblTxtPostalCode = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblCmbCountry = new System.Windows.Forms.Label();
            this.tabEmergency = new System.Windows.Forms.TabPage();
            this.txtEmergencyContactName = new System.Windows.Forms.TextBox();
            this.lblTxtEmergencyContactName = new System.Windows.Forms.Label();
            this.cmbEmergencyRelationship = new System.Windows.Forms.ComboBox();
            this.lblCmbEmergencyRelationship = new System.Windows.Forms.Label();
            this.txtEmergencyContactNumber = new System.Windows.Forms.TextBox();
            this.lblTxtEmergencyContactNumber = new System.Windows.Forms.Label();
            this.tabEmployment = new System.Windows.Forms.TabPage();
            this.btnClearManager = new System.Windows.Forms.Button();
            this.btnAddAssignment = new System.Windows.Forms.Button();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCmbCompany = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblCmbDepartment = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblCmbPosition = new System.Windows.Forms.Label();
            this.txtCompanyEmployeeNo = new System.Windows.Forms.TextBox();
            this.lblTxtCompanyEmployeeNo = new System.Windows.Forms.Label();
            this.cmbManager = new System.Windows.Forms.ComboBox();
            this.lblCmbManager = new System.Windows.Forms.Label();
            this.cmbEmploymentType = new System.Windows.Forms.ComboBox();
            this.lblCmbEmploymentType = new System.Windows.Forms.Label();
            this.cmbEmploymentStatus = new System.Windows.Forms.ComboBox();
            this.lblCmbEmploymentStatus = new System.Windows.Forms.Label();
            this.dtpDateHired = new System.Windows.Forms.DateTimePicker();
            this.lblDtpDateHired = new System.Windows.Forms.Label();
            this.dtpRegularizationDate = new System.Windows.Forms.DateTimePicker();
            this.lblDtpRegularizationDate = new System.Windows.Forms.Label();
            this.dtpContractEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblDtpContractEndDate = new System.Windows.Forms.Label();
            this.dtpEffectiveFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDtpEffectiveFrom = new System.Windows.Forms.Label();
            this.dtpEffectiveTo = new System.Windows.Forms.DateTimePicker();
            this.lblDtpEffectiveTo = new System.Windows.Forms.Label();
            this.txtWorkLocation = new System.Windows.Forms.TextBox();
            this.lblTxtWorkLocation = new System.Windows.Forms.Label();
            this.txtCostCenter = new System.Windows.Forms.TextBox();
            this.lblTxtCostCenter = new System.Windows.Forms.Label();
            this.chkIsPrimary = new System.Windows.Forms.CheckBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.tabEmployee.SuspendLayout();
            this.tabPersonal.SuspendLayout();
            this.tabContact.SuspendLayout();
            this.tabEmergency.SuspendLayout();
            this.tabEmployment.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Controls.Add(this.lblFormSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 94);
            this.pnlHeader.TabIndex = 2;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(30, 18);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(271, 32);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Employee Registration";
            // 
            // lblFormSubtitle
            // 
            this.lblFormSubtitle.AutoSize = true;
            this.lblFormSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFormSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(199)))), ((int)(((byte)(224)))));
            this.lblFormSubtitle.Location = new System.Drawing.Point(32, 60);
            this.lblFormSubtitle.Name = "lblFormSubtitle";
            this.lblFormSubtitle.Size = new System.Drawing.Size(302, 15);
            this.lblFormSubtitle.TabIndex = 1;
            this.lblFormSubtitle.Text = "Personal information and company employment details";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 664);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(980, 76);
            this.pnlFooter.TabIndex = 1;
            this.pnlFooter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(169)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(812, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 39);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Employee";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(701, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 39);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // tabEmployee
            // 
            this.tabEmployee.Controls.Add(this.tabPersonal);
            this.tabEmployee.Controls.Add(this.tabContact);
            this.tabEmployee.Controls.Add(this.tabEmergency);
            this.tabEmployee.Controls.Add(this.tabEmployment);
            this.tabEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabEmployee.Location = new System.Drawing.Point(0, 94);
            this.tabEmployee.Name = "tabEmployee";
            this.tabEmployee.Padding = new System.Drawing.Point(20, 10);
            this.tabEmployee.SelectedIndex = 0;
            this.tabEmployee.Size = new System.Drawing.Size(980, 570);
            this.tabEmployee.TabIndex = 0;
            this.tabEmployee.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drag_MouseDown);
            // 
            // tabPersonal
            // 
            this.tabPersonal.AutoScroll = true;
            this.tabPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.tabPersonal.Controls.Add(this.txtEmployeeNo);
            this.tabPersonal.Controls.Add(this.lblTxtEmployeeNo);
            this.tabPersonal.Controls.Add(this.txtFirstName);
            this.tabPersonal.Controls.Add(this.lblTxtFirstName);
            this.tabPersonal.Controls.Add(this.txtMiddleName);
            this.tabPersonal.Controls.Add(this.lblTxtMiddleName);
            this.tabPersonal.Controls.Add(this.txtLastName);
            this.tabPersonal.Controls.Add(this.lblTxtLastName);
            this.tabPersonal.Controls.Add(this.cmbSuffix);
            this.tabPersonal.Controls.Add(this.lblCmbSuffix);
            this.tabPersonal.Controls.Add(this.txtPreferredName);
            this.tabPersonal.Controls.Add(this.lblTxtPreferredName);
            this.tabPersonal.Controls.Add(this.dtpBirthDate);
            this.tabPersonal.Controls.Add(this.lblDtpBirthDate);
            this.tabPersonal.Controls.Add(this.cmbGender);
            this.tabPersonal.Controls.Add(this.lblCmbGender);
            this.tabPersonal.Controls.Add(this.cmbCivilStatus);
            this.tabPersonal.Controls.Add(this.lblCmbCivilStatus);
            this.tabPersonal.Controls.Add(this.chkIsActive);
            this.tabPersonal.Location = new System.Drawing.Point(4, 40);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Padding = new System.Windows.Forms.Padding(25);
            this.tabPersonal.Size = new System.Drawing.Size(972, 526);
            this.tabPersonal.TabIndex = 0;
            this.tabPersonal.Text = "Personal Information";
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.txtEmployeeNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmployeeNo.Location = new System.Drawing.Point(32, 59);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.ReadOnly = true;
            this.txtEmployeeNo.Size = new System.Drawing.Size(398, 25);
            this.txtEmployeeNo.TabIndex = 0;
            // 
            // lblTxtEmployeeNo
            // 
            this.lblTxtEmployeeNo.AutoSize = true;
            this.lblTxtEmployeeNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtEmployeeNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtEmployeeNo.Location = new System.Drawing.Point(32, 34);
            this.lblTxtEmployeeNo.Name = "lblTxtEmployeeNo";
            this.lblTxtEmployeeNo.Size = new System.Drawing.Size(110, 15);
            this.lblTxtEmployeeNo.TabIndex = 1;
            this.lblTxtEmployeeNo.Text = "Employee Number";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(480, 59);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(398, 25);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblTxtFirstName
            // 
            this.lblTxtFirstName.AutoSize = true;
            this.lblTxtFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtFirstName.Location = new System.Drawing.Point(480, 34);
            this.lblTxtFirstName.Name = "lblTxtFirstName";
            this.lblTxtFirstName.Size = new System.Drawing.Size(75, 15);
            this.lblTxtFirstName.TabIndex = 3;
            this.lblTxtFirstName.Text = "First Name *";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMiddleName.Location = new System.Drawing.Point(32, 145);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(398, 25);
            this.txtMiddleName.TabIndex = 4;
            // 
            // lblTxtMiddleName
            // 
            this.lblTxtMiddleName.AutoSize = true;
            this.lblTxtMiddleName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtMiddleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtMiddleName.Location = new System.Drawing.Point(32, 120);
            this.lblTxtMiddleName.Name = "lblTxtMiddleName";
            this.lblTxtMiddleName.Size = new System.Drawing.Size(81, 15);
            this.lblTxtMiddleName.TabIndex = 5;
            this.lblTxtMiddleName.Text = "Middle Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.Location = new System.Drawing.Point(480, 145);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(398, 25);
            this.txtLastName.TabIndex = 6;
            // 
            // lblTxtLastName
            // 
            this.lblTxtLastName.AutoSize = true;
            this.lblTxtLastName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtLastName.Location = new System.Drawing.Point(480, 120);
            this.lblTxtLastName.Name = "lblTxtLastName";
            this.lblTxtLastName.Size = new System.Drawing.Size(73, 15);
            this.lblTxtLastName.TabIndex = 7;
            this.lblTxtLastName.Text = "Last Name *";
            // 
            // cmbSuffix
            // 
            this.cmbSuffix.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSuffix.Location = new System.Drawing.Point(32, 231);
            this.cmbSuffix.Name = "cmbSuffix";
            this.cmbSuffix.Size = new System.Drawing.Size(398, 25);
            this.cmbSuffix.TabIndex = 8;
            // 
            // lblCmbSuffix
            // 
            this.lblCmbSuffix.AutoSize = true;
            this.lblCmbSuffix.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbSuffix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbSuffix.Location = new System.Drawing.Point(32, 206);
            this.lblCmbSuffix.Name = "lblCmbSuffix";
            this.lblCmbSuffix.Size = new System.Drawing.Size(41, 15);
            this.lblCmbSuffix.TabIndex = 9;
            this.lblCmbSuffix.Text = "Suffix";
            // 
            // txtPreferredName
            // 
            this.txtPreferredName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPreferredName.Location = new System.Drawing.Point(480, 231);
            this.txtPreferredName.Name = "txtPreferredName";
            this.txtPreferredName.Size = new System.Drawing.Size(398, 25);
            this.txtPreferredName.TabIndex = 10;
            // 
            // lblTxtPreferredName
            // 
            this.lblTxtPreferredName.AutoSize = true;
            this.lblTxtPreferredName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtPreferredName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtPreferredName.Location = new System.Drawing.Point(480, 206);
            this.lblTxtPreferredName.Name = "lblTxtPreferredName";
            this.lblTxtPreferredName.Size = new System.Drawing.Size(98, 15);
            this.lblTxtPreferredName.TabIndex = 11;
            this.lblTxtPreferredName.Text = "Preferred Name";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(32, 317);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.ShowCheckBox = true;
            this.dtpBirthDate.Size = new System.Drawing.Size(398, 25);
            this.dtpBirthDate.TabIndex = 12;
            // 
            // lblDtpBirthDate
            // 
            this.lblDtpBirthDate.AutoSize = true;
            this.lblDtpBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDtpBirthDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblDtpBirthDate.Location = new System.Drawing.Point(32, 292);
            this.lblDtpBirthDate.Name = "lblDtpBirthDate";
            this.lblDtpBirthDate.Size = new System.Drawing.Size(65, 15);
            this.lblDtpBirthDate.TabIndex = 13;
            this.lblDtpBirthDate.Text = "Birth Date";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.Location = new System.Drawing.Point(480, 317);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(398, 25);
            this.cmbGender.TabIndex = 14;
            // 
            // lblCmbGender
            // 
            this.lblCmbGender.AutoSize = true;
            this.lblCmbGender.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbGender.Location = new System.Drawing.Point(480, 292);
            this.lblCmbGender.Name = "lblCmbGender";
            this.lblCmbGender.Size = new System.Drawing.Size(49, 15);
            this.lblCmbGender.TabIndex = 15;
            this.lblCmbGender.Text = "Gender";
            // 
            // cmbCivilStatus
            // 
            this.cmbCivilStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCivilStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCivilStatus.Location = new System.Drawing.Point(32, 403);
            this.cmbCivilStatus.Name = "cmbCivilStatus";
            this.cmbCivilStatus.Size = new System.Drawing.Size(398, 25);
            this.cmbCivilStatus.TabIndex = 16;
            // 
            // lblCmbCivilStatus
            // 
            this.lblCmbCivilStatus.AutoSize = true;
            this.lblCmbCivilStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbCivilStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbCivilStatus.Location = new System.Drawing.Point(32, 378);
            this.lblCmbCivilStatus.Name = "lblCmbCivilStatus";
            this.lblCmbCivilStatus.Size = new System.Drawing.Size(68, 15);
            this.lblCmbCivilStatus.TabIndex = 17;
            this.lblCmbCivilStatus.Text = "Civil Status";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(480, 396);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(128, 23);
            this.chkIsActive.TabIndex = 18;
            this.chkIsActive.Text = "Active Employee";
            // 
            // tabContact
            // 
            this.tabContact.AutoScroll = true;
            this.tabContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.tabContact.Controls.Add(this.txtEmail);
            this.tabContact.Controls.Add(this.lblTxtEmail);
            this.tabContact.Controls.Add(this.txtMobileNumber);
            this.tabContact.Controls.Add(this.lblTxtMobileNumber);
            this.tabContact.Controls.Add(this.txtTelephoneNumber);
            this.tabContact.Controls.Add(this.lblTxtTelephoneNumber);
            this.tabContact.Controls.Add(this.txtAddressLine1);
            this.tabContact.Controls.Add(this.lblTxtAddressLine1);
            this.tabContact.Controls.Add(this.txtAddressLine2);
            this.tabContact.Controls.Add(this.lblTxtAddressLine2);
            this.tabContact.Controls.Add(this.txtBarangay);
            this.tabContact.Controls.Add(this.lblTxtBarangay);
            this.tabContact.Controls.Add(this.txtCity);
            this.tabContact.Controls.Add(this.lblTxtCity);
            this.tabContact.Controls.Add(this.txtProvince);
            this.tabContact.Controls.Add(this.lblTxtProvince);
            this.tabContact.Controls.Add(this.txtPostalCode);
            this.tabContact.Controls.Add(this.lblTxtPostalCode);
            this.tabContact.Controls.Add(this.cmbCountry);
            this.tabContact.Controls.Add(this.lblCmbCountry);
            this.tabContact.Location = new System.Drawing.Point(4, 40);
            this.tabContact.Name = "tabContact";
            this.tabContact.Padding = new System.Windows.Forms.Padding(25);
            this.tabContact.Size = new System.Drawing.Size(972, 526);
            this.tabContact.TabIndex = 1;
            this.tabContact.Text = "Contact & Address";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(32, 59);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(398, 25);
            this.txtEmail.TabIndex = 0;
            // 
            // lblTxtEmail
            // 
            this.lblTxtEmail.AutoSize = true;
            this.lblTxtEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtEmail.Location = new System.Drawing.Point(32, 34);
            this.lblTxtEmail.Name = "lblTxtEmail";
            this.lblTxtEmail.Size = new System.Drawing.Size(83, 15);
            this.lblTxtEmail.TabIndex = 1;
            this.lblTxtEmail.Text = "Email Address";
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMobileNumber.Location = new System.Drawing.Point(480, 59);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(398, 25);
            this.txtMobileNumber.TabIndex = 2;
            // 
            // lblTxtMobileNumber
            // 
            this.lblTxtMobileNumber.AutoSize = true;
            this.lblTxtMobileNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtMobileNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtMobileNumber.Location = new System.Drawing.Point(480, 34);
            this.lblTxtMobileNumber.Name = "lblTxtMobileNumber";
            this.lblTxtMobileNumber.Size = new System.Drawing.Size(94, 15);
            this.lblTxtMobileNumber.TabIndex = 3;
            this.lblTxtMobileNumber.Text = "Mobile Number";
            // 
            // txtTelephoneNumber
            // 
            this.txtTelephoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelephoneNumber.Location = new System.Drawing.Point(32, 145);
            this.txtTelephoneNumber.Name = "txtTelephoneNumber";
            this.txtTelephoneNumber.Size = new System.Drawing.Size(398, 25);
            this.txtTelephoneNumber.TabIndex = 4;
            // 
            // lblTxtTelephoneNumber
            // 
            this.lblTxtTelephoneNumber.AutoSize = true;
            this.lblTxtTelephoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtTelephoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtTelephoneNumber.Location = new System.Drawing.Point(32, 120);
            this.lblTxtTelephoneNumber.Name = "lblTxtTelephoneNumber";
            this.lblTxtTelephoneNumber.Size = new System.Drawing.Size(114, 15);
            this.lblTxtTelephoneNumber.TabIndex = 5;
            this.lblTxtTelephoneNumber.Text = "Telephone Number";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddressLine1.Location = new System.Drawing.Point(480, 145);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(398, 25);
            this.txtAddressLine1.TabIndex = 6;
            // 
            // lblTxtAddressLine1
            // 
            this.lblTxtAddressLine1.AutoSize = true;
            this.lblTxtAddressLine1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtAddressLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtAddressLine1.Location = new System.Drawing.Point(480, 120);
            this.lblTxtAddressLine1.Name = "lblTxtAddressLine1";
            this.lblTxtAddressLine1.Size = new System.Drawing.Size(87, 15);
            this.lblTxtAddressLine1.TabIndex = 7;
            this.lblTxtAddressLine1.Text = "Address Line 1";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddressLine2.Location = new System.Drawing.Point(32, 231);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(398, 25);
            this.txtAddressLine2.TabIndex = 8;
            // 
            // lblTxtAddressLine2
            // 
            this.lblTxtAddressLine2.AutoSize = true;
            this.lblTxtAddressLine2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtAddressLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtAddressLine2.Location = new System.Drawing.Point(32, 206);
            this.lblTxtAddressLine2.Name = "lblTxtAddressLine2";
            this.lblTxtAddressLine2.Size = new System.Drawing.Size(87, 15);
            this.lblTxtAddressLine2.TabIndex = 9;
            this.lblTxtAddressLine2.Text = "Address Line 2";
            // 
            // txtBarangay
            // 
            this.txtBarangay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBarangay.Location = new System.Drawing.Point(480, 231);
            this.txtBarangay.Name = "txtBarangay";
            this.txtBarangay.Size = new System.Drawing.Size(398, 25);
            this.txtBarangay.TabIndex = 10;
            // 
            // lblTxtBarangay
            // 
            this.lblTxtBarangay.AutoSize = true;
            this.lblTxtBarangay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtBarangay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtBarangay.Location = new System.Drawing.Point(480, 206);
            this.lblTxtBarangay.Name = "lblTxtBarangay";
            this.lblTxtBarangay.Size = new System.Drawing.Size(58, 15);
            this.lblTxtBarangay.TabIndex = 11;
            this.lblTxtBarangay.Text = "Barangay";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCity.Location = new System.Drawing.Point(32, 317);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(398, 25);
            this.txtCity.TabIndex = 12;
            // 
            // lblTxtCity
            // 
            this.lblTxtCity.AutoSize = true;
            this.lblTxtCity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtCity.Location = new System.Drawing.Point(32, 292);
            this.lblTxtCity.Name = "lblTxtCity";
            this.lblTxtCity.Size = new System.Drawing.Size(106, 15);
            this.lblTxtCity.TabIndex = 13;
            this.lblTxtCity.Text = "City / Municipality";
            // 
            // txtProvince
            // 
            this.txtProvince.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProvince.Location = new System.Drawing.Point(480, 317);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(398, 25);
            this.txtProvince.TabIndex = 14;
            // 
            // lblTxtProvince
            // 
            this.lblTxtProvince.AutoSize = true;
            this.lblTxtProvince.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtProvince.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtProvince.Location = new System.Drawing.Point(480, 292);
            this.lblTxtProvince.Name = "lblTxtProvince";
            this.lblTxtProvince.Size = new System.Drawing.Size(56, 15);
            this.lblTxtProvince.TabIndex = 15;
            this.lblTxtProvince.Text = "Province";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPostalCode.Location = new System.Drawing.Point(32, 403);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(398, 25);
            this.txtPostalCode.TabIndex = 16;
            // 
            // lblTxtPostalCode
            // 
            this.lblTxtPostalCode.AutoSize = true;
            this.lblTxtPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtPostalCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtPostalCode.Location = new System.Drawing.Point(32, 378);
            this.lblTxtPostalCode.Name = "lblTxtPostalCode";
            this.lblTxtPostalCode.Size = new System.Drawing.Size(71, 15);
            this.lblTxtPostalCode.TabIndex = 17;
            this.lblTxtPostalCode.Text = "Postal Code";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCountry.Location = new System.Drawing.Point(480, 403);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(398, 25);
            this.cmbCountry.TabIndex = 18;
            // 
            // lblCmbCountry
            // 
            this.lblCmbCountry.AutoSize = true;
            this.lblCmbCountry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbCountry.Location = new System.Drawing.Point(480, 378);
            this.lblCmbCountry.Name = "lblCmbCountry";
            this.lblCmbCountry.Size = new System.Drawing.Size(51, 15);
            this.lblCmbCountry.TabIndex = 19;
            this.lblCmbCountry.Text = "Country";
            // 
            // tabEmergency
            // 
            this.tabEmergency.AutoScroll = true;
            this.tabEmergency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.tabEmergency.Controls.Add(this.txtEmergencyContactName);
            this.tabEmergency.Controls.Add(this.lblTxtEmergencyContactName);
            this.tabEmergency.Controls.Add(this.cmbEmergencyRelationship);
            this.tabEmergency.Controls.Add(this.lblCmbEmergencyRelationship);
            this.tabEmergency.Controls.Add(this.txtEmergencyContactNumber);
            this.tabEmergency.Controls.Add(this.lblTxtEmergencyContactNumber);
            this.tabEmergency.Location = new System.Drawing.Point(4, 40);
            this.tabEmergency.Name = "tabEmergency";
            this.tabEmergency.Padding = new System.Windows.Forms.Padding(25);
            this.tabEmergency.Size = new System.Drawing.Size(972, 526);
            this.tabEmergency.TabIndex = 2;
            this.tabEmergency.Text = "Emergency Contact";
            // 
            // txtEmergencyContactName
            // 
            this.txtEmergencyContactName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmergencyContactName.Location = new System.Drawing.Point(32, 59);
            this.txtEmergencyContactName.Name = "txtEmergencyContactName";
            this.txtEmergencyContactName.Size = new System.Drawing.Size(398, 25);
            this.txtEmergencyContactName.TabIndex = 0;
            // 
            // lblTxtEmergencyContactName
            // 
            this.lblTxtEmergencyContactName.AutoSize = true;
            this.lblTxtEmergencyContactName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtEmergencyContactName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtEmergencyContactName.Location = new System.Drawing.Point(32, 34);
            this.lblTxtEmergencyContactName.Name = "lblTxtEmergencyContactName";
            this.lblTxtEmergencyContactName.Size = new System.Drawing.Size(86, 15);
            this.lblTxtEmergencyContactName.TabIndex = 1;
            this.lblTxtEmergencyContactName.Text = "Contact Name";
            // 
            // cmbEmergencyRelationship
            // 
            this.cmbEmergencyRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmergencyRelationship.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmergencyRelationship.Location = new System.Drawing.Point(480, 59);
            this.cmbEmergencyRelationship.Name = "cmbEmergencyRelationship";
            this.cmbEmergencyRelationship.Size = new System.Drawing.Size(398, 25);
            this.cmbEmergencyRelationship.TabIndex = 2;
            // 
            // lblCmbEmergencyRelationship
            // 
            this.lblCmbEmergencyRelationship.AutoSize = true;
            this.lblCmbEmergencyRelationship.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbEmergencyRelationship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbEmergencyRelationship.Location = new System.Drawing.Point(480, 34);
            this.lblCmbEmergencyRelationship.Name = "lblCmbEmergencyRelationship";
            this.lblCmbEmergencyRelationship.Size = new System.Drawing.Size(75, 15);
            this.lblCmbEmergencyRelationship.TabIndex = 3;
            this.lblCmbEmergencyRelationship.Text = "Relationship";
            // 
            // txtEmergencyContactNumber
            // 
            this.txtEmergencyContactNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmergencyContactNumber.Location = new System.Drawing.Point(32, 145);
            this.txtEmergencyContactNumber.Name = "txtEmergencyContactNumber";
            this.txtEmergencyContactNumber.Size = new System.Drawing.Size(398, 25);
            this.txtEmergencyContactNumber.TabIndex = 4;
            // 
            // lblTxtEmergencyContactNumber
            // 
            this.lblTxtEmergencyContactNumber.AutoSize = true;
            this.lblTxtEmergencyContactNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtEmergencyContactNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtEmergencyContactNumber.Location = new System.Drawing.Point(32, 120);
            this.lblTxtEmergencyContactNumber.Name = "lblTxtEmergencyContactNumber";
            this.lblTxtEmergencyContactNumber.Size = new System.Drawing.Size(99, 15);
            this.lblTxtEmergencyContactNumber.TabIndex = 5;
            this.lblTxtEmergencyContactNumber.Text = "Contact Number";
            // 
            // tabEmployment
            // 
            this.tabEmployment.AutoScroll = true;
            this.tabEmployment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.tabEmployment.Controls.Add(this.btnClearManager);
            this.tabEmployment.Controls.Add(this.btnAddAssignment);
            this.tabEmployment.Controls.Add(this.cmbCompany);
            this.tabEmployment.Controls.Add(this.lblCmbCompany);
            this.tabEmployment.Controls.Add(this.cmbDepartment);
            this.tabEmployment.Controls.Add(this.lblCmbDepartment);
            this.tabEmployment.Controls.Add(this.cmbPosition);
            this.tabEmployment.Controls.Add(this.lblCmbPosition);
            this.tabEmployment.Controls.Add(this.txtCompanyEmployeeNo);
            this.tabEmployment.Controls.Add(this.lblTxtCompanyEmployeeNo);
            this.tabEmployment.Controls.Add(this.cmbManager);
            this.tabEmployment.Controls.Add(this.lblCmbManager);
            this.tabEmployment.Controls.Add(this.cmbEmploymentType);
            this.tabEmployment.Controls.Add(this.lblCmbEmploymentType);
            this.tabEmployment.Controls.Add(this.cmbEmploymentStatus);
            this.tabEmployment.Controls.Add(this.lblCmbEmploymentStatus);
            this.tabEmployment.Controls.Add(this.dtpDateHired);
            this.tabEmployment.Controls.Add(this.lblDtpDateHired);
            this.tabEmployment.Controls.Add(this.dtpRegularizationDate);
            this.tabEmployment.Controls.Add(this.lblDtpRegularizationDate);
            this.tabEmployment.Controls.Add(this.dtpContractEndDate);
            this.tabEmployment.Controls.Add(this.lblDtpContractEndDate);
            this.tabEmployment.Controls.Add(this.dtpEffectiveFrom);
            this.tabEmployment.Controls.Add(this.lblDtpEffectiveFrom);
            this.tabEmployment.Controls.Add(this.dtpEffectiveTo);
            this.tabEmployment.Controls.Add(this.lblDtpEffectiveTo);
            this.tabEmployment.Controls.Add(this.txtWorkLocation);
            this.tabEmployment.Controls.Add(this.lblTxtWorkLocation);
            this.tabEmployment.Controls.Add(this.txtCostCenter);
            this.tabEmployment.Controls.Add(this.lblTxtCostCenter);
            this.tabEmployment.Controls.Add(this.chkIsPrimary);
            this.tabEmployment.Location = new System.Drawing.Point(4, 40);
            this.tabEmployment.Name = "tabEmployment";
            this.tabEmployment.Padding = new System.Windows.Forms.Padding(25);
            this.tabEmployment.Size = new System.Drawing.Size(972, 526);
            this.tabEmployment.TabIndex = 3;
            this.tabEmployment.Text = "Employment";
            // 
            // btnClearManager
            // 
            this.btnClearManager.BackColor = System.Drawing.Color.Gray;
            this.btnClearManager.FlatAppearance.BorderSize = 0;
            this.btnClearManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearManager.ForeColor = System.Drawing.Color.White;
            this.btnClearManager.Location = new System.Drawing.Point(375, 231);
            this.btnClearManager.Name = "btnClearManager";
            this.btnClearManager.Size = new System.Drawing.Size(55, 25);
            this.btnClearManager.TabIndex = 0;
            this.btnClearManager.Text = "Clear";
            this.btnClearManager.UseVisualStyleBackColor = false;
            this.btnClearManager.Click += new System.EventHandler(this.btnClearManager_Click);
            // 
            // btnAddAssignment
            // 
            this.btnAddAssignment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(169)))));
            this.btnAddAssignment.Enabled = false;
            this.btnAddAssignment.FlatAppearance.BorderSize = 0;
            this.btnAddAssignment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAssignment.ForeColor = System.Drawing.Color.White;
            this.btnAddAssignment.Location = new System.Drawing.Point(240, 90);
            this.btnAddAssignment.Name = "btnAddAssignment";
            this.btnAddAssignment.Size = new System.Drawing.Size(190, 25);
            this.btnAddAssignment.TabIndex = 0;
            this.btnAddAssignment.Text = "Add Company Assignment";
            this.btnAddAssignment.UseVisualStyleBackColor = false;
            this.btnAddAssignment.Click += new System.EventHandler(this.btnAddAssignment_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCompany.Location = new System.Drawing.Point(32, 59);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(398, 25);
            this.cmbCompany.TabIndex = 0;
            // 
            // lblCmbCompany
            // 
            this.lblCmbCompany.AutoSize = true;
            this.lblCmbCompany.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbCompany.Location = new System.Drawing.Point(32, 34);
            this.lblCmbCompany.Name = "lblCmbCompany";
            this.lblCmbCompany.Size = new System.Drawing.Size(58, 15);
            this.lblCmbCompany.TabIndex = 1;
            this.lblCmbCompany.Text = "Company";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDepartment.Location = new System.Drawing.Point(480, 59);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(398, 25);
            this.cmbDepartment.TabIndex = 2;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // lblCmbDepartment
            // 
            this.lblCmbDepartment.AutoSize = true;
            this.lblCmbDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbDepartment.Location = new System.Drawing.Point(480, 34);
            this.lblCmbDepartment.Name = "lblCmbDepartment";
            this.lblCmbDepartment.Size = new System.Drawing.Size(76, 15);
            this.lblCmbDepartment.TabIndex = 3;
            this.lblCmbDepartment.Text = "Department";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPosition.Location = new System.Drawing.Point(32, 145);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(398, 25);
            this.cmbPosition.TabIndex = 4;
            // 
            // lblCmbPosition
            // 
            this.lblCmbPosition.AutoSize = true;
            this.lblCmbPosition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbPosition.Location = new System.Drawing.Point(32, 120);
            this.lblCmbPosition.Name = "lblCmbPosition";
            this.lblCmbPosition.Size = new System.Drawing.Size(51, 15);
            this.lblCmbPosition.TabIndex = 5;
            this.lblCmbPosition.Text = "Position";
            // 
            // txtCompanyEmployeeNo
            // 
            this.txtCompanyEmployeeNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCompanyEmployeeNo.Location = new System.Drawing.Point(480, 145);
            this.txtCompanyEmployeeNo.Name = "txtCompanyEmployeeNo";
            this.txtCompanyEmployeeNo.Size = new System.Drawing.Size(398, 25);
            this.txtCompanyEmployeeNo.TabIndex = 6;
            // 
            // lblTxtCompanyEmployeeNo
            // 
            this.lblTxtCompanyEmployeeNo.AutoSize = true;
            this.lblTxtCompanyEmployeeNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtCompanyEmployeeNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtCompanyEmployeeNo.Location = new System.Drawing.Point(480, 120);
            this.lblTxtCompanyEmployeeNo.Name = "lblTxtCompanyEmployeeNo";
            this.lblTxtCompanyEmployeeNo.Size = new System.Drawing.Size(137, 15);
            this.lblTxtCompanyEmployeeNo.TabIndex = 7;
            this.lblTxtCompanyEmployeeNo.Text = "Company Employee No.";
            // 
            // cmbManager
            // 
            this.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManager.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbManager.Location = new System.Drawing.Point(32, 231);
            this.cmbManager.Name = "cmbManager";
            this.cmbManager.Size = new System.Drawing.Size(337, 25);
            this.cmbManager.TabIndex = 8;
            // 
            // lblCmbManager
            // 
            this.lblCmbManager.AutoSize = true;
            this.lblCmbManager.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbManager.Location = new System.Drawing.Point(32, 206);
            this.lblCmbManager.Name = "lblCmbManager";
            this.lblCmbManager.Size = new System.Drawing.Size(115, 15);
            this.lblCmbManager.TabIndex = 9;
            this.lblCmbManager.Text = "Reporting Manager";
            // 
            // cmbEmploymentType
            // 
            this.cmbEmploymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmploymentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmploymentType.Location = new System.Drawing.Point(480, 231);
            this.cmbEmploymentType.Name = "cmbEmploymentType";
            this.cmbEmploymentType.Size = new System.Drawing.Size(398, 25);
            this.cmbEmploymentType.TabIndex = 10;
            // 
            // lblCmbEmploymentType
            // 
            this.lblCmbEmploymentType.AutoSize = true;
            this.lblCmbEmploymentType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbEmploymentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbEmploymentType.Location = new System.Drawing.Point(480, 206);
            this.lblCmbEmploymentType.Name = "lblCmbEmploymentType";
            this.lblCmbEmploymentType.Size = new System.Drawing.Size(106, 15);
            this.lblCmbEmploymentType.TabIndex = 11;
            this.lblCmbEmploymentType.Text = "Employment Type";
            // 
            // cmbEmploymentStatus
            // 
            this.cmbEmploymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmploymentStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmploymentStatus.Location = new System.Drawing.Point(32, 317);
            this.cmbEmploymentStatus.Name = "cmbEmploymentStatus";
            this.cmbEmploymentStatus.Size = new System.Drawing.Size(398, 25);
            this.cmbEmploymentStatus.TabIndex = 12;
            // 
            // lblCmbEmploymentStatus
            // 
            this.lblCmbEmploymentStatus.AutoSize = true;
            this.lblCmbEmploymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCmbEmploymentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblCmbEmploymentStatus.Location = new System.Drawing.Point(32, 292);
            this.lblCmbEmploymentStatus.Name = "lblCmbEmploymentStatus";
            this.lblCmbEmploymentStatus.Size = new System.Drawing.Size(115, 15);
            this.lblCmbEmploymentStatus.TabIndex = 13;
            this.lblCmbEmploymentStatus.Text = "Employment Status";
            // 
            // dtpDateHired
            // 
            this.dtpDateHired.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateHired.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateHired.Location = new System.Drawing.Point(480, 317);
            this.dtpDateHired.Name = "dtpDateHired";
            this.dtpDateHired.Size = new System.Drawing.Size(398, 25);
            this.dtpDateHired.TabIndex = 14;
            // 
            // lblDtpDateHired
            // 
            this.lblDtpDateHired.AutoSize = true;
            this.lblDtpDateHired.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDtpDateHired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblDtpDateHired.Location = new System.Drawing.Point(480, 292);
            this.lblDtpDateHired.Name = "lblDtpDateHired";
            this.lblDtpDateHired.Size = new System.Drawing.Size(68, 15);
            this.lblDtpDateHired.TabIndex = 15;
            this.lblDtpDateHired.Text = "Date Hired";
            // 
            // dtpRegularizationDate
            // 
            this.dtpRegularizationDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpRegularizationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegularizationDate.Location = new System.Drawing.Point(32, 403);
            this.dtpRegularizationDate.Name = "dtpRegularizationDate";
            this.dtpRegularizationDate.ShowCheckBox = true;
            this.dtpRegularizationDate.Size = new System.Drawing.Size(398, 25);
            this.dtpRegularizationDate.TabIndex = 16;
            // 
            // lblDtpRegularizationDate
            // 
            this.lblDtpRegularizationDate.AutoSize = true;
            this.lblDtpRegularizationDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDtpRegularizationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblDtpRegularizationDate.Location = new System.Drawing.Point(32, 378);
            this.lblDtpRegularizationDate.Name = "lblDtpRegularizationDate";
            this.lblDtpRegularizationDate.Size = new System.Drawing.Size(117, 15);
            this.lblDtpRegularizationDate.TabIndex = 17;
            this.lblDtpRegularizationDate.Text = "Regularization Date";
            // 
            // dtpContractEndDate
            // 
            this.dtpContractEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpContractEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContractEndDate.Location = new System.Drawing.Point(480, 403);
            this.dtpContractEndDate.Name = "dtpContractEndDate";
            this.dtpContractEndDate.ShowCheckBox = true;
            this.dtpContractEndDate.Size = new System.Drawing.Size(398, 25);
            this.dtpContractEndDate.TabIndex = 18;
            // 
            // lblDtpContractEndDate
            // 
            this.lblDtpContractEndDate.AutoSize = true;
            this.lblDtpContractEndDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDtpContractEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblDtpContractEndDate.Location = new System.Drawing.Point(480, 378);
            this.lblDtpContractEndDate.Name = "lblDtpContractEndDate";
            this.lblDtpContractEndDate.Size = new System.Drawing.Size(108, 15);
            this.lblDtpContractEndDate.TabIndex = 19;
            this.lblDtpContractEndDate.Text = "Contract End Date";
            // 
            // dtpEffectiveFrom
            // 
            this.dtpEffectiveFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEffectiveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveFrom.Location = new System.Drawing.Point(32, 489);
            this.dtpEffectiveFrom.Name = "dtpEffectiveFrom";
            this.dtpEffectiveFrom.Size = new System.Drawing.Size(398, 25);
            this.dtpEffectiveFrom.TabIndex = 20;
            // 
            // lblDtpEffectiveFrom
            // 
            this.lblDtpEffectiveFrom.AutoSize = true;
            this.lblDtpEffectiveFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDtpEffectiveFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblDtpEffectiveFrom.Location = new System.Drawing.Point(32, 464);
            this.lblDtpEffectiveFrom.Name = "lblDtpEffectiveFrom";
            this.lblDtpEffectiveFrom.Size = new System.Drawing.Size(90, 15);
            this.lblDtpEffectiveFrom.TabIndex = 21;
            this.lblDtpEffectiveFrom.Text = "Effective From";
            // 
            // dtpEffectiveTo
            // 
            this.dtpEffectiveTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEffectiveTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveTo.Location = new System.Drawing.Point(480, 489);
            this.dtpEffectiveTo.Name = "dtpEffectiveTo";
            this.dtpEffectiveTo.ShowCheckBox = true;
            this.dtpEffectiveTo.Size = new System.Drawing.Size(398, 25);
            this.dtpEffectiveTo.TabIndex = 22;
            // 
            // lblDtpEffectiveTo
            // 
            this.lblDtpEffectiveTo.AutoSize = true;
            this.lblDtpEffectiveTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDtpEffectiveTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblDtpEffectiveTo.Location = new System.Drawing.Point(480, 464);
            this.lblDtpEffectiveTo.Name = "lblDtpEffectiveTo";
            this.lblDtpEffectiveTo.Size = new System.Drawing.Size(74, 15);
            this.lblDtpEffectiveTo.TabIndex = 23;
            this.lblDtpEffectiveTo.Text = "Effective To";
            // 
            // txtWorkLocation
            // 
            this.txtWorkLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWorkLocation.Location = new System.Drawing.Point(32, 575);
            this.txtWorkLocation.Name = "txtWorkLocation";
            this.txtWorkLocation.Size = new System.Drawing.Size(398, 25);
            this.txtWorkLocation.TabIndex = 24;
            // 
            // lblTxtWorkLocation
            // 
            this.lblTxtWorkLocation.AutoSize = true;
            this.lblTxtWorkLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtWorkLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtWorkLocation.Location = new System.Drawing.Point(32, 550);
            this.lblTxtWorkLocation.Name = "lblTxtWorkLocation";
            this.lblTxtWorkLocation.Size = new System.Drawing.Size(88, 15);
            this.lblTxtWorkLocation.TabIndex = 25;
            this.lblTxtWorkLocation.Text = "Work Location";
            // 
            // txtCostCenter
            // 
            this.txtCostCenter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCostCenter.Location = new System.Drawing.Point(480, 575);
            this.txtCostCenter.Name = "txtCostCenter";
            this.txtCostCenter.Size = new System.Drawing.Size(398, 25);
            this.txtCostCenter.TabIndex = 26;
            // 
            // lblTxtCostCenter
            // 
            this.lblTxtCostCenter.AutoSize = true;
            this.lblTxtCostCenter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTxtCostCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(108)))));
            this.lblTxtCostCenter.Location = new System.Drawing.Point(480, 550);
            this.lblTxtCostCenter.Name = "lblTxtCostCenter";
            this.lblTxtCostCenter.Size = new System.Drawing.Size(72, 15);
            this.lblTxtCostCenter.TabIndex = 27;
            this.lblTxtCostCenter.Text = "Cost Center";
            // 
            // chkIsPrimary
            // 
            this.chkIsPrimary.AutoSize = true;
            this.chkIsPrimary.Location = new System.Drawing.Point(32, 654);
            this.chkIsPrimary.Name = "chkIsPrimary";
            this.chkIsPrimary.Size = new System.Drawing.Size(151, 23);
            this.chkIsPrimary.TabIndex = 28;
            this.chkIsPrimary.Text = "Primary Assignment";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(980, 740);
            this.Controls.Add(this.tabEmployee);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(920, 650);
            this.Name = "EmployeeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee Registration - AO_HRIS";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.tabEmployee.ResumeLayout(false);
            this.tabPersonal.ResumeLayout(false);
            this.tabPersonal.PerformLayout();
            this.tabContact.ResumeLayout(false);
            this.tabContact.PerformLayout();
            this.tabEmergency.ResumeLayout(false);
            this.tabEmergency.PerformLayout();
            this.tabEmployment.ResumeLayout(false);
            this.tabEmployment.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TabControl tabEmployee;
        private System.Windows.Forms.TabPage tabPersonal;
        private System.Windows.Forms.TabPage tabContact;
        private System.Windows.Forms.TabPage tabEmergency;
        private System.Windows.Forms.TabPage tabEmployment;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblFormSubtitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.Label lblTxtEmployeeNo;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblTxtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblTxtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblTxtLastName;
        private System.Windows.Forms.ComboBox cmbSuffix;
        private System.Windows.Forms.Label lblCmbSuffix;
        private System.Windows.Forms.TextBox txtPreferredName;
        private System.Windows.Forms.Label lblTxtPreferredName;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblDtpBirthDate;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblCmbGender;
        private System.Windows.Forms.ComboBox cmbCivilStatus;
        private System.Windows.Forms.Label lblCmbCivilStatus;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTxtEmail;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.Label lblTxtMobileNumber;
        private System.Windows.Forms.TextBox txtTelephoneNumber;
        private System.Windows.Forms.Label lblTxtTelephoneNumber;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.Label lblTxtAddressLine1;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.Label lblTxtAddressLine2;
        private System.Windows.Forms.TextBox txtBarangay;
        private System.Windows.Forms.Label lblTxtBarangay;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblTxtCity;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.Label lblTxtProvince;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label lblTxtPostalCode;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label lblCmbCountry;
        private System.Windows.Forms.TextBox txtEmergencyContactName;
        private System.Windows.Forms.Label lblTxtEmergencyContactName;
        private System.Windows.Forms.ComboBox cmbEmergencyRelationship;
        private System.Windows.Forms.Label lblCmbEmergencyRelationship;
        private System.Windows.Forms.TextBox txtEmergencyContactNumber;
        private System.Windows.Forms.Label lblTxtEmergencyContactNumber;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCmbCompany;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblCmbDepartment;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblCmbPosition;
        private System.Windows.Forms.TextBox txtCompanyEmployeeNo;
        private System.Windows.Forms.Label lblTxtCompanyEmployeeNo;
        private System.Windows.Forms.ComboBox cmbManager;
        private System.Windows.Forms.Label lblCmbManager;
        private System.Windows.Forms.ComboBox cmbEmploymentType;
        private System.Windows.Forms.Label lblCmbEmploymentType;
        private System.Windows.Forms.ComboBox cmbEmploymentStatus;
        private System.Windows.Forms.Label lblCmbEmploymentStatus;
        private System.Windows.Forms.DateTimePicker dtpDateHired;
        private System.Windows.Forms.Label lblDtpDateHired;
        private System.Windows.Forms.DateTimePicker dtpRegularizationDate;
        private System.Windows.Forms.Label lblDtpRegularizationDate;
        private System.Windows.Forms.DateTimePicker dtpContractEndDate;
        private System.Windows.Forms.Label lblDtpContractEndDate;
        private System.Windows.Forms.DateTimePicker dtpEffectiveFrom;
        private System.Windows.Forms.Label lblDtpEffectiveFrom;
        private System.Windows.Forms.DateTimePicker dtpEffectiveTo;
        private System.Windows.Forms.Label lblDtpEffectiveTo;
        private System.Windows.Forms.TextBox txtWorkLocation;
        private System.Windows.Forms.Label lblTxtWorkLocation;
        private System.Windows.Forms.TextBox txtCostCenter;
        private System.Windows.Forms.Label lblTxtCostCenter;
        private System.Windows.Forms.CheckBox chkIsPrimary;
        private System.Windows.Forms.Button btnAddAssignment;
        private System.Windows.Forms.Button btnClearManager;
    }
}