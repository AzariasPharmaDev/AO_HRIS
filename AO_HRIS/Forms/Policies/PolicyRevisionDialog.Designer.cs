namespace AO_HRIS.Forms.Policies
{
    partial class PolicyRevisionDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblDialogTitle;
        private System.Windows.Forms.Label lblPolicyCode;
        private System.Windows.Forms.TextBox txtPolicyCode;
        private System.Windows.Forms.Label lblPolicyTitle;
        private System.Windows.Forms.TextBox txtPolicyTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblRevisionLabel;
        private System.Windows.Forms.TextBox txtRevisionLabel;
        private System.Windows.Forms.Label lblEffectiveDate;
        private System.Windows.Forms.DateTimePicker dtpEffectiveDate;
        private System.Windows.Forms.Label lblPolicyFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialogPolicy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDialogTitle = new System.Windows.Forms.Label();
            this.lblPolicyCode = new System.Windows.Forms.Label();
            this.txtPolicyCode = new System.Windows.Forms.TextBox();
            this.lblPolicyTitle = new System.Windows.Forms.Label();
            this.txtPolicyTitle = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblRevisionLabel = new System.Windows.Forms.Label();
            this.txtRevisionLabel = new System.Windows.Forms.TextBox();
            this.lblEffectiveDate = new System.Windows.Forms.Label();
            this.dtpEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.lblPolicyFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialogPolicy = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblDialogTitle
            // 
            this.lblDialogTitle.AutoSize = true;
            this.lblDialogTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDialogTitle.ForeColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.lblDialogTitle.Location = new System.Drawing.Point(22, 18);
            this.lblDialogTitle.Name = "lblDialogTitle";
            this.lblDialogTitle.Size = new System.Drawing.Size(184, 25);
            this.lblDialogTitle.TabIndex = 0;
            this.lblDialogTitle.Text = "Create a company policy";
            // 
            // lblPolicyCode
            // 
            this.lblPolicyCode.AutoSize = true;
            this.lblPolicyCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPolicyCode.Location = new System.Drawing.Point(25, 68);
            this.lblPolicyCode.Name = "lblPolicyCode";
            this.lblPolicyCode.Size = new System.Drawing.Size(72, 15);
            this.lblPolicyCode.TabIndex = 1;
            this.lblPolicyCode.Text = "Policy Code";
            // 
            // txtPolicyCode
            // 
            this.txtPolicyCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPolicyCode.Location = new System.Drawing.Point(28, 89);
            this.txtPolicyCode.MaxLength = 30;
            this.txtPolicyCode.Name = "txtPolicyCode";
            this.txtPolicyCode.Size = new System.Drawing.Size(300, 23);
            this.txtPolicyCode.TabIndex = 2;
            // 
            // lblPolicyTitle
            // 
            this.lblPolicyTitle.AutoSize = true;
            this.lblPolicyTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPolicyTitle.Location = new System.Drawing.Point(25, 126);
            this.lblPolicyTitle.Name = "lblPolicyTitle";
            this.lblPolicyTitle.Size = new System.Drawing.Size(70, 15);
            this.lblPolicyTitle.TabIndex = 3;
            this.lblPolicyTitle.Text = "Policy Title";
            // 
            // txtPolicyTitle
            // 
            this.txtPolicyTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPolicyTitle.Location = new System.Drawing.Point(28, 147);
            this.txtPolicyTitle.MaxLength = 200;
            this.txtPolicyTitle.Name = "txtPolicyTitle";
            this.txtPolicyTitle.Size = new System.Drawing.Size(520, 23);
            this.txtPolicyTitle.TabIndex = 4;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(25, 184);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(57, 15);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(28, 205);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(300, 23);
            this.cboCategory.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(25, 242);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 15);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(28, 263);
            this.txtDescription.MaxLength = 2000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(520, 75);
            this.txtDescription.TabIndex = 8;
            // 
            // lblRevisionLabel
            // 
            this.lblRevisionLabel.AutoSize = true;
            this.lblRevisionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRevisionLabel.Location = new System.Drawing.Point(25, 351);
            this.lblRevisionLabel.Name = "lblRevisionLabel";
            this.lblRevisionLabel.Size = new System.Drawing.Size(81, 15);
            this.lblRevisionLabel.TabIndex = 9;
            this.lblRevisionLabel.Text = "Revision Label";
            // 
            // txtRevisionLabel
            // 
            this.txtRevisionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRevisionLabel.Location = new System.Drawing.Point(28, 372);
            this.txtRevisionLabel.MaxLength = 30;
            this.txtRevisionLabel.Name = "txtRevisionLabel";
            this.txtRevisionLabel.Size = new System.Drawing.Size(220, 23);
            this.txtRevisionLabel.TabIndex = 10;
            // 
            // lblEffectiveDate
            // 
            this.lblEffectiveDate.AutoSize = true;
            this.lblEffectiveDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEffectiveDate.Location = new System.Drawing.Point(280, 351);
            this.lblEffectiveDate.Name = "lblEffectiveDate";
            this.lblEffectiveDate.Size = new System.Drawing.Size(83, 15);
            this.lblEffectiveDate.TabIndex = 11;
            this.lblEffectiveDate.Text = "Effective Date";
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(283, 372);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(265, 23);
            this.dtpEffectiveDate.TabIndex = 12;
            // 
            // lblPolicyFile
            // 
            this.lblPolicyFile.AutoSize = true;
            this.lblPolicyFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPolicyFile.Location = new System.Drawing.Point(25, 410);
            this.lblPolicyFile.Name = "lblPolicyFile";
            this.lblPolicyFile.Size = new System.Drawing.Size(83, 15);
            this.lblPolicyFile.TabIndex = 13;
            this.lblPolicyFile.Text = "Policy PDF File";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilePath.Location = new System.Drawing.Point(28, 431);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(420, 23);
            this.txtFilePath.TabIndex = 14;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowse.Location = new System.Drawing.Point(456, 429);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(92, 28);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnSaveDraft.FlatAppearance.BorderSize = 0;
            this.btnSaveDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDraft.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveDraft.ForeColor = System.Drawing.Color.White;
            this.btnSaveDraft.Location = new System.Drawing.Point(356, 482);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(112, 34);
            this.btnSaveDraft.TabIndex = 16;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = false;
            this.btnSaveDraft.Click += new System.EventHandler(this.BtnSaveDraft_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(474, 482);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 34);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // openFileDialogPolicy
            // 
            this.openFileDialogPolicy.Filter = "PDF files (*.pdf)|*.pdf";
            this.openFileDialogPolicy.Title = "Select Policy PDF";
            // 
            // PolicyRevisionDialog
            // 
            this.AcceptButton = this.btnSaveDraft;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(578, 540);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblPolicyFile);
            this.Controls.Add(this.dtpEffectiveDate);
            this.Controls.Add(this.lblEffectiveDate);
            this.Controls.Add(this.txtRevisionLabel);
            this.Controls.Add(this.lblRevisionLabel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtPolicyTitle);
            this.Controls.Add(this.lblPolicyTitle);
            this.Controls.Add(this.txtPolicyCode);
            this.Controls.Add(this.lblPolicyCode);
            this.Controls.Add(this.lblDialogTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolicyRevisionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Company Policy";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
