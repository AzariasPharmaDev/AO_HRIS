namespace AO_HRIS.Forms.Documents
{
    partial class DocumentUploadDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.Label lblDocumentName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.DateTimePicker dtIssue;
        private System.Windows.Forms.DateTimePicker dtExpiry;
        private System.Windows.Forms.CheckBox chkIssue;
        private System.Windows.Forms.CheckBox chkExpiry;
        private System.Windows.Forms.CheckBox chkConfidential;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.FlowLayoutPanel flpIssueDate;
        private System.Windows.Forms.FlowLayoutPanel flpExpiryDate;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblDocumentName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.flpIssueDate = new System.Windows.Forms.FlowLayoutPanel();
            this.chkIssue = new System.Windows.Forms.CheckBox();
            this.dtIssue = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.flpExpiryDate = new System.Windows.Forms.FlowLayoutPanel();
            this.chkExpiry = new System.Windows.Forms.CheckBox();
            this.dtExpiry = new System.Windows.Forms.DateTimePicker();
            this.lblAccess = new System.Windows.Forms.Label();
            this.chkConfidential = new System.Windows.Forms.CheckBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpLayout.SuspendLayout();
            this.flpIssueDate.SuspendLayout();
            this.flpExpiryDate.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 2;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Controls.Add(this.lblDocumentName, 0, 0);
            this.tlpLayout.Controls.Add(this.txtName, 1, 0);
            this.tlpLayout.Controls.Add(this.lblCategory, 0, 1);
            this.tlpLayout.Controls.Add(this.cboCategory, 1, 1);
            this.tlpLayout.Controls.Add(this.lblIssueDate, 0, 2);
            this.tlpLayout.Controls.Add(this.flpIssueDate, 1, 2);
            this.tlpLayout.Controls.Add(this.lblExpiryDate, 0, 3);
            this.tlpLayout.Controls.Add(this.flpExpiryDate, 1, 3);
            this.tlpLayout.Controls.Add(this.lblAccess, 0, 4);
            this.tlpLayout.Controls.Add(this.chkConfidential, 1, 4);
            this.tlpLayout.Controls.Add(this.lblNotes, 0, 5);
            this.tlpLayout.Controls.Add(this.txtNotes, 1, 5);
            this.tlpLayout.Controls.Add(this.flpButtons, 1, 6);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.Padding = new System.Windows.Forms.Padding(22);
            this.tlpLayout.RowCount = 7;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Size = new System.Drawing.Size(520, 470);
            this.tlpLayout.TabIndex = 0;
            // 
            // lblDocumentName
            // 
            this.lblDocumentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocumentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblDocumentName.Location = new System.Drawing.Point(25, 22);
            this.lblDocumentName.Name = "lblDocumentName";
            this.lblDocumentName.Size = new System.Drawing.Size(129, 43);
            this.lblDocumentName.TabIndex = 0;
            this.lblDocumentName.Text = "Document name";
            this.lblDocumentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtName.Location = new System.Drawing.Point(160, 25);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(335, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblCategory.Location = new System.Drawing.Point(25, 65);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(129, 43);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCategory
            // 
            this.cboCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Location = new System.Drawing.Point(160, 68);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(335, 23);
            this.cboCategory.TabIndex = 3;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.CboCategory_SelectedIndexChanged);
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIssueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblIssueDate.Location = new System.Drawing.Point(25, 108);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(129, 43);
            this.lblIssueDate.TabIndex = 4;
            this.lblIssueDate.Text = "Issue date";
            this.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpIssueDate
            // 
            this.flpIssueDate.Controls.Add(this.chkIssue);
            this.flpIssueDate.Controls.Add(this.dtIssue);
            this.flpIssueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpIssueDate.Location = new System.Drawing.Point(160, 111);
            this.flpIssueDate.Name = "flpIssueDate";
            this.flpIssueDate.Size = new System.Drawing.Size(335, 37);
            this.flpIssueDate.TabIndex = 5;
            this.flpIssueDate.WrapContents = false;
            // 
            // chkIssue
            // 
            this.chkIssue.AutoSize = true;
            this.chkIssue.Location = new System.Drawing.Point(3, 3);
            this.chkIssue.Name = "chkIssue";
            this.chkIssue.Size = new System.Drawing.Size(101, 19);
            this.chkIssue.TabIndex = 0;
            this.chkIssue.Text = "Has issue date";
            this.chkIssue.CheckedChanged += new System.EventHandler(this.ChkIssue_CheckedChanged);
            // 
            // dtIssue
            // 
            this.dtIssue.Enabled = false;
            this.dtIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtIssue.Location = new System.Drawing.Point(110, 3);
            this.dtIssue.Name = "dtIssue";
            this.dtIssue.Size = new System.Drawing.Size(120, 23);
            this.dtIssue.TabIndex = 1;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExpiryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblExpiryDate.Location = new System.Drawing.Point(25, 151);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(129, 43);
            this.lblExpiryDate.TabIndex = 6;
            this.lblExpiryDate.Text = "Expiration";
            this.lblExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpExpiryDate
            // 
            this.flpExpiryDate.Controls.Add(this.chkExpiry);
            this.flpExpiryDate.Controls.Add(this.dtExpiry);
            this.flpExpiryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpExpiryDate.Location = new System.Drawing.Point(160, 154);
            this.flpExpiryDate.Name = "flpExpiryDate";
            this.flpExpiryDate.Size = new System.Drawing.Size(335, 37);
            this.flpExpiryDate.TabIndex = 7;
            this.flpExpiryDate.WrapContents = false;
            // 
            // chkExpiry
            // 
            this.chkExpiry.AutoSize = true;
            this.chkExpiry.Location = new System.Drawing.Point(3, 3);
            this.chkExpiry.Name = "chkExpiry";
            this.chkExpiry.Size = new System.Drawing.Size(128, 19);
            this.chkExpiry.TabIndex = 0;
            this.chkExpiry.Text = "Has expiration date";
            this.chkExpiry.CheckedChanged += new System.EventHandler(this.ChkExpiry_CheckedChanged);
            // 
            // dtExpiry
            // 
            this.dtExpiry.Enabled = false;
            this.dtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpiry.Location = new System.Drawing.Point(137, 3);
            this.dtExpiry.Name = "dtExpiry";
            this.dtExpiry.Size = new System.Drawing.Size(120, 23);
            this.dtExpiry.TabIndex = 1;
            // 
            // lblAccess
            // 
            this.lblAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblAccess.Location = new System.Drawing.Point(25, 194);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(129, 43);
            this.lblAccess.TabIndex = 8;
            this.lblAccess.Text = "Access";
            this.lblAccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkConfidential
            // 
            this.chkConfidential.AutoSize = true;
            this.chkConfidential.Location = new System.Drawing.Point(160, 197);
            this.chkConfidential.Name = "chkConfidential";
            this.chkConfidential.Size = new System.Drawing.Size(149, 19);
            this.chkConfidential.TabIndex = 9;
            this.chkConfidential.Text = "Confidential document";
            // 
            // lblNotes
            // 
            this.lblNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblNotes.Location = new System.Drawing.Point(25, 237);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(129, 78);
            this.lblNotes.TabIndex = 10;
            this.lblNotes.Text = "Notes";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Location = new System.Drawing.Point(160, 240);
            this.txtNotes.MaxLength = 1000;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(335, 72);
            this.txtNotes.TabIndex = 11;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnSave);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(160, 318);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(335, 127);
            this.flpButtons.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(232, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Continue";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(136, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            // 
            // DocumentUploadDialog
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(520, 470);
            this.Controls.Add(this.tlpLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentUploadDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Employee Document";
            this.tlpLayout.ResumeLayout(false);
            this.tlpLayout.PerformLayout();
            this.flpIssueDate.ResumeLayout(false);
            this.flpIssueDate.PerformLayout();
            this.flpExpiryDate.ResumeLayout(false);
            this.flpExpiryDate.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
