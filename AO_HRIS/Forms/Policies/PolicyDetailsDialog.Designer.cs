namespace AO_HRIS.Forms.Policies
{
    partial class PolicyDetailsDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPolicyCode;
        private System.Windows.Forms.TextBox txtPolicyCode;
        private System.Windows.Forms.Label lblPolicyTitle;
        private System.Windows.Forms.TextBox txtPolicyTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPolicyCode = new System.Windows.Forms.Label();
            this.txtPolicyCode = new System.Windows.Forms.TextBox();
            this.lblPolicyTitle = new System.Windows.Forms.Label();
            this.txtPolicyTitle = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(28, 55, 91);
            this.lblTitle.Location = new System.Drawing.Point(22, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit Policy Details";
            // 
            // lblPolicyCode
            // 
            this.lblPolicyCode.AutoSize = true;
            this.lblPolicyCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPolicyCode.Location = new System.Drawing.Point(25, 70);
            this.lblPolicyCode.Name = "lblPolicyCode";
            this.lblPolicyCode.Size = new System.Drawing.Size(72, 15);
            this.lblPolicyCode.TabIndex = 1;
            this.lblPolicyCode.Text = "Policy Code";
            // 
            // txtPolicyCode
            // 
            this.txtPolicyCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPolicyCode.Location = new System.Drawing.Point(28, 91);
            this.txtPolicyCode.MaxLength = 30;
            this.txtPolicyCode.Name = "txtPolicyCode";
            this.txtPolicyCode.Size = new System.Drawing.Size(300, 23);
            this.txtPolicyCode.TabIndex = 2;
            // 
            // lblPolicyTitle
            // 
            this.lblPolicyTitle.AutoSize = true;
            this.lblPolicyTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPolicyTitle.Location = new System.Drawing.Point(25, 128);
            this.lblPolicyTitle.Name = "lblPolicyTitle";
            this.lblPolicyTitle.Size = new System.Drawing.Size(70, 15);
            this.lblPolicyTitle.TabIndex = 3;
            this.lblPolicyTitle.Text = "Policy Title";
            // 
            // txtPolicyTitle
            // 
            this.txtPolicyTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPolicyTitle.Location = new System.Drawing.Point(28, 149);
            this.txtPolicyTitle.MaxLength = 200;
            this.txtPolicyTitle.Name = "txtPolicyTitle";
            this.txtPolicyTitle.Size = new System.Drawing.Size(500, 23);
            this.txtPolicyTitle.TabIndex = 4;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(25, 186);
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
            this.cboCategory.Location = new System.Drawing.Point(28, 207);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(300, 23);
            this.cboCategory.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(25, 244);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 15);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(28, 265);
            this.txtDescription.MaxLength = 2000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(500, 90);
            this.txtDescription.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(35, 106, 213);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(348, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 220, 233);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(454, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 34);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // PolicyDetailsDialog
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(558, 445);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtPolicyTitle);
            this.Controls.Add(this.lblPolicyTitle);
            this.Controls.Add(this.txtPolicyCode);
            this.Controls.Add(this.lblPolicyCode);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolicyDetailsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Policy Details";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
