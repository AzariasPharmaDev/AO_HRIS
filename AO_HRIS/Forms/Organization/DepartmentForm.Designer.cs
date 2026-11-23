
namespace AO_HRIS.Forms.Organization
{
    partial class DepartmentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlContent;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblDepartmentCode;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label lblParentDepartment;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ComboBox cmbParentDepartment;

        private System.Windows.Forms.TextBox txtDepartmentCode;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.CheckBox chkIsActive;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlContent = new System.Windows.Forms.Panel();

            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();

            this.lblDepartmentCode = new System.Windows.Forms.Label();
            this.txtDepartmentCode = new System.Windows.Forms.TextBox();

            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();

            this.lblParentDepartment = new System.Windows.Forms.Label();
            this.cmbParentDepartment = new System.Windows.Forms.ComboBox();

            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(28, 66, 112);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(625, 90);
            this.pnlHeader.TabIndex = 2;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(26, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(237, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Department Details";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(215, 229, 245);
            this.lblSubtitle.Location = new System.Drawing.Point(29, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(355, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text =
                "Manage department information and company assignment.";

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor =
                System.Drawing.Color.FromArgb(246, 248, 252);
            this.pnlFooter.Controls.Add(this.chkIsActive);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 567);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(625, 83);
            this.pnlFooter.TabIndex = 1;

            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState =
                System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsActive.Location = new System.Drawing.Point(30, 29);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(143, 23);
            this.chkIsActive.TabIndex = 5;
            this.chkIsActive.Text = "Active Department";

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult =
                System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.Location = new System.Drawing.Point(336, 22);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 39);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click +=
                new System.EventHandler(this.btnCancel_Click);

            // 
            // btnSave
            // 
            this.btnSave.BackColor =
                System.Drawing.Color.FromArgb(30, 100, 190);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(456, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 39);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Department";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click +=
                new System.EventHandler(this.btnSave_Click);

            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;

            this.pnlContent.Controls.Add(this.lblCompany);
            this.pnlContent.Controls.Add(this.cmbCompany);

            this.pnlContent.Controls.Add(this.lblDepartmentCode);
            this.pnlContent.Controls.Add(this.txtDepartmentCode);

            this.pnlContent.Controls.Add(this.lblDepartmentName);
            this.pnlContent.Controls.Add(this.txtDepartmentName);

            this.pnlContent.Controls.Add(this.lblParentDepartment);
            this.pnlContent.Controls.Add(this.cmbParentDepartment);

            this.pnlContent.Controls.Add(this.lblDescription);
            this.pnlContent.Controls.Add(this.txtDescription);

            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 90);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(625, 477);
            this.pnlContent.TabIndex = 0;

            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCompany.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);
            this.lblCompany.Location = new System.Drawing.Point(30, 25);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 15);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company *";

            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(30, 49);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(560, 25);
            this.cmbCompany.TabIndex = 0;

            // 
            // lblDepartmentCode
            // 
            this.lblDepartmentCode.AutoSize = true;
            this.lblDepartmentCode.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDepartmentCode.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);
            this.lblDepartmentCode.Location =
                new System.Drawing.Point(30, 105);
            this.lblDepartmentCode.Name = "lblDepartmentCode";
            this.lblDepartmentCode.Size = new System.Drawing.Size(115, 15);
            this.lblDepartmentCode.TabIndex = 1;
            this.lblDepartmentCode.Text = "Department Code *";

            // 
            // txtDepartmentCode
            // 
            this.txtDepartmentCode.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.txtDepartmentCode.Location =
                new System.Drawing.Point(30, 129);
            this.txtDepartmentCode.MaxLength = 40;
            this.txtDepartmentCode.Name = "txtDepartmentCode";
            this.txtDepartmentCode.Size =
                new System.Drawing.Size(560, 25);
            this.txtDepartmentCode.TabIndex = 1;

            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDepartmentName.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);
            this.lblDepartmentName.Location =
                new System.Drawing.Point(30, 185);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(120, 15);
            this.lblDepartmentName.TabIndex = 2;
            this.lblDepartmentName.Text = "Department Name *";

            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.txtDepartmentName.Location =
                new System.Drawing.Point(30, 209);
            this.txtDepartmentName.MaxLength = 400;
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size =
                new System.Drawing.Size(560, 25);
            this.txtDepartmentName.TabIndex = 2;

            // 
            // lblParentDepartment
            // 
            this.lblParentDepartment.AutoSize = true;
            this.lblParentDepartment.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblParentDepartment.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);
            this.lblParentDepartment.Location =
                new System.Drawing.Point(30, 265);
            this.lblParentDepartment.Name = "lblParentDepartment";
            this.lblParentDepartment.Size = new System.Drawing.Size(112, 15);
            this.lblParentDepartment.TabIndex = 3;
            this.lblParentDepartment.Text = "Parent Department";

            // 
            // cmbParentDepartment
            // 
            this.cmbParentDepartment.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentDepartment.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.cmbParentDepartment.FormattingEnabled = true;
            this.cmbParentDepartment.Location =
                new System.Drawing.Point(30, 289);
            this.cmbParentDepartment.Name = "cmbParentDepartment";
            this.cmbParentDepartment.Size =
                new System.Drawing.Size(560, 25);
            this.cmbParentDepartment.TabIndex = 3;

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);
            this.lblDescription.Location =
                new System.Drawing.Point(30, 345);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(71, 15);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";

            // 
            // txtDescription
            // 
            this.txtDescription.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location =
                new System.Drawing.Point(30, 369);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size =
                new System.Drawing.Size(560, 90);
            this.txtDescription.TabIndex = 4;

            // 
            // DepartmentForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(625, 650);

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);

            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentForm";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Department Details";

            this.Load +=
                new System.EventHandler(this.DepartmentForm_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();

            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
