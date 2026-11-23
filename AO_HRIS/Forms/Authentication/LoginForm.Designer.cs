namespace AO_HRIS
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblBrandCaption = new System.Windows.Forms.Label();
            this.lblBrandMark = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.pnlUsernameLine = new System.Windows.Forms.Panel();
            this.pnlPasswordLine = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlBrand.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(209)))), ((int)(((byte)(232)))));
            this.label1.Location = new System.Drawing.Point(34, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Human Resource\nInformation System";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 53);
            this.label2.TabIndex = 1;
            this.label2.Text = "AO_HRIS";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(39)))), ((int)(((byte)(65)))));
            this.txtUsername.Location = new System.Drawing.Point(62, 178);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(316, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(70)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(53, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(70)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(53, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(39)))), ((int)(((byte)(65)))));
            this.txtPassword.Location = new System.Drawing.Point(62, 251);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(276, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(169)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(75)))), ((int)(((byte)(144)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(55, 305);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(332, 42);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowPassword.BackColor = System.Drawing.Color.White;
            this.chkShowPassword.FlatAppearance.BorderSize = 0;
            this.chkShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(110)))), ((int)(((byte)(135)))));
            this.chkShowPassword.Location = new System.Drawing.Point(348, 244);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(35, 32);
            this.chkShowPassword.TabIndex = 2;
            this.chkShowPassword.TabStop = false;
            this.chkShowPassword.Text = "👁";
            this.chkShowPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowPassword.UseVisualStyleBackColor = false;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.lblStatus.Location = new System.Drawing.Point(55, 352);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(332, 36);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Test Connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.pnlBrand.Controls.Add(this.lblBrandCaption);
            this.pnlBrand.Controls.Add(this.label1);
            this.pnlBrand.Controls.Add(this.label2);
            this.pnlBrand.Controls.Add(this.lblBrandMark);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(310, 430);
            this.pnlBrand.TabIndex = 0;
            // 
            // lblBrandCaption
            // 
            this.lblBrandCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBrandCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(158)))), ((int)(((byte)(190)))));
            this.lblBrandCaption.Location = new System.Drawing.Point(36, 377);
            this.lblBrandCaption.Name = "lblBrandCaption";
            this.lblBrandCaption.Size = new System.Drawing.Size(244, 24);
            this.lblBrandCaption.TabIndex = 3;
            this.lblBrandCaption.Text = "ALPHA OMEGA  •  EMPLOYEE PORTAL";
            // 
            // lblBrandMark
            // 
            this.lblBrandMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(124)))));
            this.lblBrandMark.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBrandMark.ForeColor = System.Drawing.Color.White;
            this.lblBrandMark.Location = new System.Drawing.Point(36, 89);
            this.lblBrandMark.Name = "lblBrandMark";
            this.lblBrandMark.Size = new System.Drawing.Size(60, 60);
            this.lblBrandMark.TabIndex = 0;
            this.lblBrandMark.Text = "AO";
            this.lblBrandMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.Controls.Add(this.lblWelcome);
            this.pnlLogin.Controls.Add(this.lblInstructions);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.pnlUsernameLine);
            this.pnlLogin.Controls.Add(this.label4);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.pnlPasswordLine);
            this.pnlLogin.Controls.Add(this.chkShowPassword);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblStatus);
            this.pnlLogin.Controls.Add(this.button1);
            this.pnlLogin.Controls.Add(this.lblFooter);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(310, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(440, 430);
            this.pnlLogin.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(39)))), ((int)(((byte)(65)))));
            this.lblWelcome.Location = new System.Drawing.Point(49, 55);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(340, 49);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome back";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(123)))), ((int)(((byte)(143)))));
            this.lblInstructions.Location = new System.Drawing.Point(52, 107);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(340, 30);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "Sign in to continue to your workspace.";
            // 
            // pnlUsernameLine
            // 
            this.pnlUsernameLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(224)))), ((int)(((byte)(236)))));
            this.pnlUsernameLine.Location = new System.Drawing.Point(55, 206);
            this.pnlUsernameLine.Name = "pnlUsernameLine";
            this.pnlUsernameLine.Size = new System.Drawing.Size(332, 1);
            this.pnlUsernameLine.TabIndex = 3;
            // 
            // pnlPasswordLine
            // 
            this.pnlPasswordLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(224)))), ((int)(((byte)(236)))));
            this.pnlPasswordLine.Location = new System.Drawing.Point(55, 279);
            this.pnlPasswordLine.Name = "pnlPasswordLine";
            this.pnlPasswordLine.Size = new System.Drawing.Size(332, 1);
            this.pnlPasswordLine.TabIndex = 5;
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblFooter.Location = new System.Drawing.Point(55, 400);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(332, 18);
            this.lblFooter.TabIndex = 7;
            this.lblFooter.Text = "Authorized personnel only";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 430);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlBrand);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AO_HRIS - Login";
            this.pnlBrand.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblBrandMark;
        private System.Windows.Forms.Label lblBrandCaption;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Panel pnlUsernameLine;
        private System.Windows.Forms.Panel pnlPasswordLine;
        private System.Windows.Forms.Label lblFooter;
    }
}
