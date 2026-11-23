
namespace AO_HRIS.Forms.Organization
{
    partial class PositionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFooter;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblPositionCode;
        private System.Windows.Forms.Label lblPositionName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblPositionLevel;

        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbPositionLevel;

        private System.Windows.Forms.TextBox txtPositionCode;
        private System.Windows.Forms.TextBox txtPositionName;
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

            this.pnlContent = new System.Windows.Forms.Panel();

            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();

            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();

            this.lblPositionLevel = new System.Windows.Forms.Label();
            this.cmbPositionLevel = new System.Windows.Forms.ComboBox();

            this.lblPositionCode = new System.Windows.Forms.Label();
            this.txtPositionCode = new System.Windows.Forms.TextBox();

            this.lblPositionName = new System.Windows.Forms.Label();
            this.txtPositionName = new System.Windows.Forms.TextBox();

            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(28, 66, 112);

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(625, 90);
            this.pnlHeader.TabIndex = 2;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 18F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(26, 13);

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size =
                new System.Drawing.Size(192, 32);

            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Position Details";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(215, 229, 245);

            this.lblSubtitle.Location =
                new System.Drawing.Point(29, 55);

            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size =
                new System.Drawing.Size(271, 17);

            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text =
                "Manage position information and availability.";

            // 
            // pnlContent
            // 
            this.pnlContent.BackColor =
                System.Drawing.Color.White;

            this.pnlContent.Controls.Add(this.lblCompany);
            this.pnlContent.Controls.Add(this.cmbCompany);

            this.pnlContent.Controls.Add(this.lblDepartment);
            this.pnlContent.Controls.Add(this.cmbDepartment);

            this.pnlContent.Controls.Add(this.lblPositionLevel);
            this.pnlContent.Controls.Add(this.cmbPositionLevel);

            this.pnlContent.Controls.Add(this.lblPositionCode);
            this.pnlContent.Controls.Add(this.txtPositionCode);

            this.pnlContent.Controls.Add(this.lblPositionName);
            this.pnlContent.Controls.Add(this.txtPositionName);

            this.pnlContent.Controls.Add(this.lblDescription);
            this.pnlContent.Controls.Add(this.txtDescription);

            this.pnlContent.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.pnlContent.Location =
                new System.Drawing.Point(0, 90);

            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size =
                new System.Drawing.Size(625, 462);

            this.pnlContent.TabIndex = 0;

            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblCompany.Location =
                new System.Drawing.Point(30, 15);

            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Text = "Company *";

            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbCompany.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);

            this.cmbCompany.Location =
                new System.Drawing.Point(30, 36);

            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size =
                new System.Drawing.Size(560, 25);

            this.cmbCompany.TabIndex = 0;

            this.cmbCompany.SelectedIndexChanged +=
                new System.EventHandler(
                    this.cmbCompany_SelectedIndexChanged);

            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblDepartment.Location =
                new System.Drawing.Point(30, 76);

            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Text = "Department *";

            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbDepartment.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);

            this.cmbDepartment.Location =
                new System.Drawing.Point(30, 97);

            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size =
                new System.Drawing.Size(560, 25);

            this.cmbDepartment.TabIndex = 1;

            // 
            // lblPositionLevel
            // 
            this.lblPositionLevel.AutoSize = true;
            this.lblPositionLevel.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblPositionLevel.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);

            this.lblPositionLevel.Location =
                new System.Drawing.Point(30, 135);

            this.lblPositionLevel.Name = "lblPositionLevel";
            this.lblPositionLevel.Size =
                new System.Drawing.Size(89, 15);

            this.lblPositionLevel.TabIndex = 2;
            this.lblPositionLevel.Text = "Position Level *";

            // 
            // cmbPositionLevel
            // 
            this.cmbPositionLevel.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbPositionLevel.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.cmbPositionLevel.Location =
                new System.Drawing.Point(30, 156);

            this.cmbPositionLevel.Name = "cmbPositionLevel";
            this.cmbPositionLevel.Size =
                new System.Drawing.Size(560, 25);

            this.cmbPositionLevel.TabIndex = 2;

            // 
            // lblPositionCode
            // 
            this.lblPositionCode.AutoSize = true;
            this.lblPositionCode.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblPositionCode.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);

            this.lblPositionCode.Location =
                new System.Drawing.Point(30, 195);

            this.lblPositionCode.Name = "lblPositionCode";
            this.lblPositionCode.Size =
                new System.Drawing.Size(90, 15);

            this.lblPositionCode.TabIndex = 3;
            this.lblPositionCode.Text = "Position Code *";

            // 
            // txtPositionCode
            // 
            this.txtPositionCode.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtPositionCode.Location =
                new System.Drawing.Point(30, 220);

            this.txtPositionCode.MaxLength = 40;
            this.txtPositionCode.Name = "txtPositionCode";
            this.txtPositionCode.Size =
                new System.Drawing.Size(560, 25);

            this.txtPositionCode.TabIndex = 3;

            // 
            // lblPositionName
            // 
            this.lblPositionName.AutoSize = true;
            this.lblPositionName.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblPositionName.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);

            this.lblPositionName.Location =
                new System.Drawing.Point(30, 280);

            this.lblPositionName.Name = "lblPositionName";
            this.lblPositionName.Size =
                new System.Drawing.Size(95, 15);

            this.lblPositionName.TabIndex = 4;
            this.lblPositionName.Text = "Position Name *";

            // 
            // txtPositionName
            // 
            this.txtPositionName.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtPositionName.Location =
                new System.Drawing.Point(30, 305);

            this.txtPositionName.MaxLength = 400;
            this.txtPositionName.Name = "txtPositionName";
            this.txtPositionName.Size =
                new System.Drawing.Size(560, 25);

            this.txtPositionName.TabIndex = 4;

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblDescription.ForeColor =
                System.Drawing.Color.FromArgb(58, 73, 94);

            this.lblDescription.Location =
                new System.Drawing.Point(30, 365);

            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size =
                new System.Drawing.Size(71, 15);

            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";

            // 
            // txtDescription
            // 
            this.txtDescription.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtDescription.Location =
                new System.Drawing.Point(30, 390);

            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtDescription.Size =
                new System.Drawing.Size(560, 70);

            this.txtDescription.TabIndex = 5;

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor =
                System.Drawing.Color.FromArgb(246, 248, 252);

            this.pnlFooter.Controls.Add(this.chkIsActive);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);

            this.pnlFooter.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            this.pnlFooter.Location =
                new System.Drawing.Point(0, 552);

            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size =
                new System.Drawing.Size(625, 83);

            this.pnlFooter.TabIndex = 1;

            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState =
                System.Windows.Forms.CheckState.Checked;

            this.chkIsActive.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.chkIsActive.Location =
                new System.Drawing.Point(30, 29);

            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size =
                new System.Drawing.Size(117, 23);

            this.chkIsActive.TabIndex = 0;
            this.chkIsActive.Text = "Active Position";
            this.chkIsActive.UseVisualStyleBackColor = true;

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor =
                System.Drawing.Color.White;

            this.btnCancel.DialogResult =
                System.Windows.Forms.DialogResult.Cancel;

            this.btnCancel.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCancel.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);

            this.btnCancel.Location =
                new System.Drawing.Point(336, 22);

            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size =
                new System.Drawing.Size(110, 39);

            this.btnCancel.TabIndex = 1;
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
            this.btnSave.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSave.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnSave.ForeColor =
                System.Drawing.Color.White;

            this.btnSave.Location =
                new System.Drawing.Point(456, 22);

            this.btnSave.Name = "btnSave";
            this.btnSave.Size =
                new System.Drawing.Size(135, 39);

            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Position";
            this.btnSave.UseVisualStyleBackColor = false;

            this.btnSave.Click +=
                new System.EventHandler(this.btnSave_Click);

            // 
            // PositionForm
            // 
            this.AcceptButton = this.btnSave;

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.White;

            this.CancelButton = this.btnCancel;

            this.ClientSize =
                new System.Drawing.Size(625, 635);

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);

            this.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name = "PositionForm";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Position Details";

            this.Load +=
                new System.EventHandler(this.PositionForm_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();

            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
