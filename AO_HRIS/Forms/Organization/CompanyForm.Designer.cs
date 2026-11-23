
namespace AO_HRIS.Forms.Organization
{
    partial class CompanyForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TableLayoutPanel tblFields;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblCompanyCode;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblLegalName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.Label lblEmail;

        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtLegalName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.TextBox txtEmail;

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
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.tblFields = new System.Windows.Forms.TableLayoutPanel();
            this.lblCompanyCode = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblLegalName = new System.Windows.Forms.Label();
            this.txtLegalName = new System.Windows.Forms.TextBox();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.tblFields.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(66)))), ((int)(((byte)(112)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(26, 14, 26, 12);
            this.pnlHeader.Size = new System.Drawing.Size(781, 92);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(207, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Company Details";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.lblSubtitle.Location = new System.Drawing.Point(27, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(330, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage company registration and contact information.";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlFooter.Controls.Add(this.pnlButtons);
            this.pnlFooter.Controls.Add(this.chkIsActive);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 505);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(26, 14, 26, 14);
            this.pnlFooter.Size = new System.Drawing.Size(781, 85);
            this.pnlFooter.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(475, 14);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.pnlButtons.Size = new System.Drawing.Size(280, 57);
            this.pnlButtons.TabIndex = 0;
            this.pnlButtons.WrapContents = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(132, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 39);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Company";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(228)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btnCancel.Location = new System.Drawing.Point(21, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 39);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.chkIsActive.Location = new System.Drawing.Point(28, 30);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(128, 23);
            this.chkIsActive.TabIndex = 1;
            this.chkIsActive.Text = "Active Company";
            // 
            // tblFields
            // 
            this.tblFields.BackColor = System.Drawing.Color.White;
            this.tblFields.ColumnCount = 2;
            this.tblFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFields.Controls.Add(this.lblCompanyCode, 0, 0);
            this.tblFields.Controls.Add(this.lblCompanyName, 1, 0);
            this.tblFields.Controls.Add(this.txtCompanyCode, 0, 1);
            this.tblFields.Controls.Add(this.txtCompanyName, 1, 1);
            this.tblFields.Controls.Add(this.lblLegalName, 0, 2);
            this.tblFields.Controls.Add(this.txtLegalName, 0, 3);
            this.tblFields.Controls.Add(this.lblContactNumber, 0, 4);
            this.tblFields.Controls.Add(this.lblEmail, 1, 4);
            this.tblFields.Controls.Add(this.txtContactNumber, 0, 5);
            this.tblFields.Controls.Add(this.txtEmail, 1, 5);
            this.tblFields.Controls.Add(this.pnlAddress, 0, 6);
            this.tblFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFields.Location = new System.Drawing.Point(0, 92);
            this.tblFields.Name = "tblFields";
            this.tblFields.Padding = new System.Windows.Forms.Padding(26, 18, 26, 14);
            this.tblFields.RowCount = 7;
            this.tblFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tblFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tblFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tblFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFields.Size = new System.Drawing.Size(781, 413);
            this.tblFields.TabIndex = 0;
            // 
            // lblCompanyCode
            // 
            this.lblCompanyCode.AutoSize = true;
            this.lblCompanyCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCompanyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCompanyCode.Location = new System.Drawing.Point(30, 23);
            this.lblCompanyCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.lblCompanyCode.Name = "lblCompanyCode";
            this.lblCompanyCode.Size = new System.Drawing.Size(97, 15);
            this.lblCompanyCode.TabIndex = 0;
            this.lblCompanyCode.Text = "Company Code *";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCompanyName.Location = new System.Drawing.Point(394, 23);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(102, 15);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "Company Name *";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCompanyCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCompanyCode.Location = new System.Drawing.Point(30, 49);
            this.txtCompanyCode.Margin = new System.Windows.Forms.Padding(4, 4, 12, 6);
            this.txtCompanyCode.MaxLength = 20;
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(348, 25);
            this.txtCompanyCode.TabIndex = 2;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCompanyName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCompanyName.Location = new System.Drawing.Point(394, 49);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4, 4, 12, 6);
            this.txtCompanyName.MaxLength = 200;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(349, 25);
            this.txtCompanyName.TabIndex = 3;
            // 
            // lblLegalName
            // 
            this.lblLegalName.AutoSize = true;
            this.lblLegalName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegalName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblLegalName.Location = new System.Drawing.Point(30, 101);
            this.lblLegalName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.lblLegalName.Name = "lblLegalName";
            this.lblLegalName.Size = new System.Drawing.Size(72, 15);
            this.lblLegalName.TabIndex = 4;
            this.lblLegalName.Text = "Legal Name";
            // 
            // txtLegalName
            // 
            this.txtLegalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblFields.SetColumnSpan(this.txtLegalName, 2);
            this.txtLegalName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLegalName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLegalName.Location = new System.Drawing.Point(30, 127);
            this.txtLegalName.Margin = new System.Windows.Forms.Padding(4, 4, 12, 6);
            this.txtLegalName.MaxLength = 250;
            this.txtLegalName.Name = "txtLegalName";
            this.txtLegalName.Size = new System.Drawing.Size(713, 25);
            this.txtLegalName.TabIndex = 5;
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContactNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblContactNumber.Location = new System.Drawing.Point(30, 179);
            this.lblContactNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(99, 15);
            this.lblContactNumber.TabIndex = 6;
            this.lblContactNumber.Text = "Contact Number";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblEmail.Location = new System.Drawing.Point(394, 179);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(83, 15);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email Address";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtContactNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContactNumber.Location = new System.Drawing.Point(30, 205);
            this.txtContactNumber.Margin = new System.Windows.Forms.Padding(4, 4, 12, 6);
            this.txtContactNumber.MaxLength = 30;
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(348, 25);
            this.txtContactNumber.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(394, 205);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 12, 6);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(349, 25);
            this.txtEmail.TabIndex = 9;
            // 
            // pnlAddress
            // 
            this.tblFields.SetColumnSpan(this.pnlAddress, 2);
            this.pnlAddress.Controls.Add(this.lblAddress);
            this.pnlAddress.Controls.Add(this.txtAddress);
            this.pnlAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddress.Location = new System.Drawing.Point(26, 306);
            this.pnlAddress.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(729, 93);
            this.pnlAddress.TabIndex = 10;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAddress.Location = new System.Drawing.Point(4, 4);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(105, 15);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Company Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(4, 30);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 12, 6);
            this.txtAddress.MaxLength = 500;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(722, 57);
            this.txtAddress.TabIndex = 1;
            // 
            // CompanyForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(781, 590);
            this.Controls.Add(this.tblFields);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Company Details";
            this.Load += new System.EventHandler(this.CompanyForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.tblFields.ResumeLayout(false);
            this.tblFields.PerformLayout();
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Panel pnlAddress;
        

    }
}
