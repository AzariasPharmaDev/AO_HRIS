namespace AO_HRIS
{
    partial class CompanySelectionForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.flwCompanies = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderNote = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblTitle.Location = new System.Drawing.Point(36, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(273, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Select your company";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblSubtitle.Location = new System.Drawing.Point(40, 68);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(327, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Choose the subsidiary company you want to access.";
            // 
            // flwCompanies
            // 
            this.flwCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flwCompanies.AutoScroll = true;
            this.flwCompanies.BackColor = System.Drawing.Color.White;
            this.flwCompanies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flwCompanies.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flwCompanies.Location = new System.Drawing.Point(40, 137);
            this.flwCompanies.Name = "flwCompanies";
            this.flwCompanies.Padding = new System.Windows.Forms.Padding(12);
            this.flwCompanies.Size = new System.Drawing.Size(1184, 358);
            this.flwCompanies.TabIndex = 3;
            this.flwCompanies.WrapContents = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.pnlHeader.Controls.Add(this.lblHeaderNote);
            this.pnlHeader.Controls.Add(this.lblBrand);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1264, 92);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderNote
            // 
            this.lblHeaderNote.AutoSize = true;
            this.lblHeaderNote.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(217)))), ((int)(((byte)(237)))));
            this.lblHeaderNote.Location = new System.Drawing.Point(39, 55);
            this.lblHeaderNote.Name = "lblHeaderNote";
            this.lblHeaderNote.Size = new System.Drawing.Size(210, 15);
            this.lblHeaderNote.TabIndex = 1;
            this.lblHeaderNote.Text = "ALPHA OMEGA  /  COMPANY ACCESS";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(36, 14);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(111, 32);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "AO_HRIS";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnlBody.Controls.Add(this.flwCompanies);
            this.pnlBody.Controls.Add(this.lblHint);
            this.pnlBody.Controls.Add(this.lblSection);
            this.pnlBody.Controls.Add(this.lblSubtitle);
            this.pnlBody.Controls.Add(this.lblTitle);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 92);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.pnlBody.Size = new System.Drawing.Size(1264, 547);
            this.pnlBody.TabIndex = 1;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // lblHint
            // 
            this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblHint.Location = new System.Drawing.Point(40, 512);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(339, 15);
            this.lblHint.TabIndex = 4;
            this.lblHint.Text = "Your access and permissions depend on the selected company.";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblSection.Location = new System.Drawing.Point(40, 111);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(136, 15);
            this.lblSection.TabIndex = 2;
            this.lblSection.Text = "AVAILABLE COMPANIES";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 639);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1264, 42);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblFooter.Location = new System.Drawing.Point(40, 13);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(263, 15);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "AO_HRIS  •  Secure company-specific workspace";
            // 
            // CompanySelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(680, 490);
            this.Name = "CompanySelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Company - Alpha Omega HRIS";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.FlowLayoutPanel flwCompanies;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblHeaderNote;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}
