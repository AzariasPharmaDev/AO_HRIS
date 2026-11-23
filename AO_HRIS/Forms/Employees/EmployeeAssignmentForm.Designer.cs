using System;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Employees
{
    partial class EmployeeAssignmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlEmployee;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblOrgSection;
        private System.Windows.Forms.Label lblEmploymentSection;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblCompanyEmployeeNo;
        private System.Windows.Forms.Label lblEmploymentType;
        private System.Windows.Forms.Label lblEmploymentStatus;
        private System.Windows.Forms.Label lblDateHired;
        private System.Windows.Forms.Label lblEffectiveFrom;
        private System.Windows.Forms.Label lblEffectiveTo;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.ComboBox cmbEmploymentType;
        private System.Windows.Forms.ComboBox cmbEmploymentStatus;
        private System.Windows.Forms.TextBox txtCompanyEmployeeNo;
        private System.Windows.Forms.DateTimePicker dtpDateHired;
        private System.Windows.Forms.DateTimePicker dtpEffectiveFrom;
        private System.Windows.Forms.DateTimePicker dtpEffectiveTo;
        private System.Windows.Forms.CheckBox chkHasEffectiveTo;
        private System.Windows.Forms.CheckBox chkIsPrimary;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEnd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlEmployee = new System.Windows.Forms.Panel();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblOrgSection = new System.Windows.Forms.Label();
            this.lblEmploymentSection = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCompanyEmployeeNo = new System.Windows.Forms.Label();
            this.lblEmploymentType = new System.Windows.Forms.Label();
            this.lblEmploymentStatus = new System.Windows.Forms.Label();
            this.lblDateHired = new System.Windows.Forms.Label();
            this.lblEffectiveFrom = new System.Windows.Forms.Label();
            this.lblEffectiveTo = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cmbEmploymentType = new System.Windows.Forms.ComboBox();
            this.cmbEmploymentStatus = new System.Windows.Forms.ComboBox();
            this.txtCompanyEmployeeNo = new System.Windows.Forms.TextBox();
            this.dtpDateHired = new System.Windows.Forms.DateTimePicker();
            this.dtpEffectiveFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpEffectiveTo = new System.Windows.Forms.DateTimePicker();
            this.chkHasEffectiveTo = new System.Windows.Forms.CheckBox();
            this.chkIsPrimary = new System.Windows.Forms.CheckBox();
            this.pnlHeader.SuspendLayout();
            this.pnlEmployee.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(760, 106);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(695, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Employee Assignment";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSubtitle.Location = new System.Drawing.Point(32, 67);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(690, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage an employee\'s company and employment details";
            // 
            // pnlEmployee
            // 
            this.pnlEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.pnlEmployee.Controls.Add(this.lblEmployee);
            this.pnlEmployee.Location = new System.Drawing.Point(30, 122);
            this.pnlEmployee.Name = "pnlEmployee";
            this.pnlEmployee.Size = new System.Drawing.Size(700, 55);
            this.pnlEmployee.TabIndex = 1;
            // 
            // lblEmployee
            // 
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblEmployee.Location = new System.Drawing.Point(16, 13);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(665, 29);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employee information will appear here";
            this.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnEnd);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Location = new System.Drawing.Point(0, 694);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(760, 64);
            this.pnlFooter.TabIndex = 24;
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(228)))));
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnEnd.Location = new System.Drawing.Point(30, 13);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(155, 38);
            this.btnEnd.TabIndex = 0;
            this.btnEnd.Text = "End Assignment";
            this.btnEnd.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(228)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.btnCancel.Location = new System.Drawing.Point(498, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(228)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(614, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 38);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Assignment";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // lblOrgSection
            // 
            this.lblOrgSection.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrgSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblOrgSection.Location = new System.Drawing.Point(30, 191);
            this.lblOrgSection.Name = "lblOrgSection";
            this.lblOrgSection.Size = new System.Drawing.Size(650, 27);
            this.lblOrgSection.TabIndex = 2;
            this.lblOrgSection.Text = "ORGANIZATION ASSIGNMENT";
            // 
            // lblEmploymentSection
            // 
            this.lblEmploymentSection.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmploymentSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblEmploymentSection.Location = new System.Drawing.Point(30, 428);
            this.lblEmploymentSection.Name = "lblEmploymentSection";
            this.lblEmploymentSection.Size = new System.Drawing.Size(650, 27);
            this.lblEmploymentSection.TabIndex = 11;
            this.lblEmploymentSection.Text = "EMPLOYMENT DETAILS";
            // 
            // lblCompany
            // 
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblCompany.Location = new System.Drawing.Point(30, 226);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(330, 22);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "Company *";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblDepartment.Location = new System.Drawing.Point(30, 294);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(330, 22);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "Department *";
            // 
            // lblPosition
            // 
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblPosition.Location = new System.Drawing.Point(398, 294);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(330, 22);
            this.lblPosition.TabIndex = 7;
            this.lblPosition.Text = "Position *";
            // 
            // lblCompanyEmployeeNo
            // 
            this.lblCompanyEmployeeNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCompanyEmployeeNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblCompanyEmployeeNo.Location = new System.Drawing.Point(30, 360);
            this.lblCompanyEmployeeNo.Name = "lblCompanyEmployeeNo";
            this.lblCompanyEmployeeNo.Size = new System.Drawing.Size(330, 22);
            this.lblCompanyEmployeeNo.TabIndex = 9;
            this.lblCompanyEmployeeNo.Text = "Company Employee No. (optional)";
            // 
            // lblEmploymentType
            // 
            this.lblEmploymentType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmploymentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblEmploymentType.Location = new System.Drawing.Point(30, 463);
            this.lblEmploymentType.Name = "lblEmploymentType";
            this.lblEmploymentType.Size = new System.Drawing.Size(330, 22);
            this.lblEmploymentType.TabIndex = 12;
            this.lblEmploymentType.Text = "Employment Type *";
            // 
            // lblEmploymentStatus
            // 
            this.lblEmploymentStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmploymentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblEmploymentStatus.Location = new System.Drawing.Point(398, 463);
            this.lblEmploymentStatus.Name = "lblEmploymentStatus";
            this.lblEmploymentStatus.Size = new System.Drawing.Size(330, 22);
            this.lblEmploymentStatus.TabIndex = 14;
            this.lblEmploymentStatus.Text = "Employment Status *";
            // 
            // lblDateHired
            // 
            this.lblDateHired.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateHired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblDateHired.Location = new System.Drawing.Point(30, 529);
            this.lblDateHired.Name = "lblDateHired";
            this.lblDateHired.Size = new System.Drawing.Size(330, 22);
            this.lblDateHired.TabIndex = 16;
            this.lblDateHired.Text = "Date Hired *";
            // 
            // lblEffectiveFrom
            // 
            this.lblEffectiveFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEffectiveFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblEffectiveFrom.Location = new System.Drawing.Point(398, 529);
            this.lblEffectiveFrom.Name = "lblEffectiveFrom";
            this.lblEffectiveFrom.Size = new System.Drawing.Size(330, 22);
            this.lblEffectiveFrom.TabIndex = 18;
            this.lblEffectiveFrom.Text = "Effective From *";
            // 
            // lblEffectiveTo
            // 
            this.lblEffectiveTo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEffectiveTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblEffectiveTo.Location = new System.Drawing.Point(398, 594);
            this.lblEffectiveTo.Name = "lblEffectiveTo";
            this.lblEffectiveTo.Size = new System.Drawing.Size(330, 22);
            this.lblEffectiveTo.TabIndex = 20;
            this.lblEffectiveTo.Text = "Effective To";
            // 
            // cmbCompany
            // 
            this.cmbCompany.BackColor = System.Drawing.Color.White;
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(30, 249);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(700, 25);
            this.cmbCompany.TabIndex = 4;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.BackColor = System.Drawing.Color.White;
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(30, 317);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(332, 25);
            this.cmbDepartment.TabIndex = 6;
            // 
            // cmbPosition
            // 
            this.cmbPosition.BackColor = System.Drawing.Color.White;
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(398, 317);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(332, 25);
            this.cmbPosition.TabIndex = 8;
            // 
            // cmbEmploymentType
            // 
            this.cmbEmploymentType.BackColor = System.Drawing.Color.White;
            this.cmbEmploymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmploymentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmploymentType.FormattingEnabled = true;
            this.cmbEmploymentType.Location = new System.Drawing.Point(30, 486);
            this.cmbEmploymentType.Name = "cmbEmploymentType";
            this.cmbEmploymentType.Size = new System.Drawing.Size(332, 25);
            this.cmbEmploymentType.TabIndex = 13;
            // 
            // cmbEmploymentStatus
            // 
            this.cmbEmploymentStatus.BackColor = System.Drawing.Color.White;
            this.cmbEmploymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmploymentStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmploymentStatus.FormattingEnabled = true;
            this.cmbEmploymentStatus.Location = new System.Drawing.Point(398, 486);
            this.cmbEmploymentStatus.Name = "cmbEmploymentStatus";
            this.cmbEmploymentStatus.Size = new System.Drawing.Size(332, 25);
            this.cmbEmploymentStatus.TabIndex = 15;
            // 
            // txtCompanyEmployeeNo
            // 
            this.txtCompanyEmployeeNo.BackColor = System.Drawing.Color.White;
            this.txtCompanyEmployeeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyEmployeeNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCompanyEmployeeNo.Location = new System.Drawing.Point(30, 383);
            this.txtCompanyEmployeeNo.Name = "txtCompanyEmployeeNo";
            this.txtCompanyEmployeeNo.Size = new System.Drawing.Size(700, 25);
            this.txtCompanyEmployeeNo.TabIndex = 10;
            // 
            // dtpDateHired
            // 
            this.dtpDateHired.BackColor = System.Drawing.Color.White;
            this.dtpDateHired.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateHired.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateHired.Location = new System.Drawing.Point(30, 552);
            this.dtpDateHired.Name = "dtpDateHired";
            this.dtpDateHired.Size = new System.Drawing.Size(332, 25);
            this.dtpDateHired.TabIndex = 17;
            // 
            // dtpEffectiveFrom
            // 
            this.dtpEffectiveFrom.BackColor = System.Drawing.Color.White;
            this.dtpEffectiveFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEffectiveFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveFrom.Location = new System.Drawing.Point(398, 552);
            this.dtpEffectiveFrom.Name = "dtpEffectiveFrom";
            this.dtpEffectiveFrom.Size = new System.Drawing.Size(332, 25);
            this.dtpEffectiveFrom.TabIndex = 19;
            // 
            // dtpEffectiveTo
            // 
            this.dtpEffectiveTo.BackColor = System.Drawing.Color.White;
            this.dtpEffectiveTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEffectiveTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveTo.Location = new System.Drawing.Point(398, 617);
            this.dtpEffectiveTo.Name = "dtpEffectiveTo";
            this.dtpEffectiveTo.Size = new System.Drawing.Size(332, 25);
            this.dtpEffectiveTo.TabIndex = 21;
            // 
            // chkHasEffectiveTo
            // 
            this.chkHasEffectiveTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.chkHasEffectiveTo.Location = new System.Drawing.Point(30, 615);
            this.chkHasEffectiveTo.Name = "chkHasEffectiveTo";
            this.chkHasEffectiveTo.Size = new System.Drawing.Size(310, 28);
            this.chkHasEffectiveTo.TabIndex = 22;
            this.chkHasEffectiveTo.Text = "Set assignment end date";
            // 
            // chkIsPrimary
            // 
            this.chkIsPrimary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.chkIsPrimary.Location = new System.Drawing.Point(30, 654);
            this.chkIsPrimary.Name = "chkIsPrimary";
            this.chkIsPrimary.Size = new System.Drawing.Size(310, 28);
            this.chkIsPrimary.TabIndex = 23;
            this.chkIsPrimary.Text = "Primary assignment";
            // 
            // EmployeeAssignmentForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(760, 758);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlEmployee);
            this.Controls.Add(this.lblOrgSection);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.lblCompanyEmployeeNo);
            this.Controls.Add(this.txtCompanyEmployeeNo);
            this.Controls.Add(this.lblEmploymentSection);
            this.Controls.Add(this.lblEmploymentType);
            this.Controls.Add(this.cmbEmploymentType);
            this.Controls.Add(this.lblEmploymentStatus);
            this.Controls.Add(this.cmbEmploymentStatus);
            this.Controls.Add(this.lblDateHired);
            this.Controls.Add(this.dtpDateHired);
            this.Controls.Add(this.lblEffectiveFrom);
            this.Controls.Add(this.dtpEffectiveFrom);
            this.Controls.Add(this.lblEffectiveTo);
            this.Controls.Add(this.dtpEffectiveTo);
            this.Controls.Add(this.chkHasEffectiveTo);
            this.Controls.Add(this.chkIsPrimary);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeAssignmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee Assignment";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlEmployee.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
