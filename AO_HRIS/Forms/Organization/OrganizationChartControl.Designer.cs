namespace AO_HRIS.Forms.Organization
{
    partial class OrganizationChartControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel toolbar;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh, btnZoomIn, btnZoomOut, btnFit, btnExpand, btnCollapse, btnViewEmployee;
        private System.Windows.Forms.Label lblTitle, lblCount, lblDetails;
        private ChartCanvas canvas;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.toolbar = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnFit = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnViewEmployee = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.canvas = new AO_HRIS.Forms.Organization.ChartCanvas();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.White;
            this.toolbar.Controls.Add(this.lblCount);
            this.toolbar.Controls.Add(this.cboDepartment);
            this.toolbar.Controls.Add(this.txtSearch);
            this.toolbar.Controls.Add(this.btnRefresh);
            this.toolbar.Controls.Add(this.btnZoomIn);
            this.toolbar.Controls.Add(this.btnZoomOut);
            this.toolbar.Controls.Add(this.btnFit);
            this.toolbar.Controls.Add(this.btnExpand);
            this.toolbar.Controls.Add(this.btnCollapse);
            this.toolbar.Controls.Add(this.btnViewEmployee);
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 54);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1487, 88);
            this.toolbar.TabIndex = 2;
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(570, 52);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(270, 22);
            this.lblCount.TabIndex = 9;
            this.lblCount.Text = "0 assignments";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Location = new System.Drawing.Point(12, 12);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(210, 21);
            this.cboDepartment.TabIndex = 0;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(230, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.FilterChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(448, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(12, 46);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(42, 30);
            this.btnZoomIn.TabIndex = 3;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(60, 46);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(42, 30);
            this.btnZoomOut.TabIndex = 4;
            this.btnZoomOut.Text = "−";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnFit
            // 
            this.btnFit.Location = new System.Drawing.Point(108, 46);
            this.btnFit.Name = "btnFit";
            this.btnFit.Size = new System.Drawing.Size(58, 30);
            this.btnFit.TabIndex = 5;
            this.btnFit.Text = "Fit";
            this.btnFit.Click += new System.EventHandler(this.btnFit_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(174, 46);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(90, 30);
            this.btnExpand.TabIndex = 6;
            this.btnExpand.Text = "Expand all";
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Location = new System.Drawing.Point(270, 46);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(96, 30);
            this.btnCollapse.TabIndex = 7;
            this.btnCollapse.Text = "Collapse all";
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnViewEmployee
            // 
            this.btnViewEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnViewEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewEmployee.Enabled = false;
            this.btnViewEmployee.FlatAppearance.BorderSize = 0;
            this.btnViewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewEmployee.ForeColor = System.Drawing.Color.White;
            this.btnViewEmployee.Location = new System.Drawing.Point(375, 46);
            this.btnViewEmployee.Name = "btnViewEmployee";
            this.btnViewEmployee.Size = new System.Drawing.Size(185, 30);
            this.btnViewEmployee.TabIndex = 8;
            this.btnViewEmployee.Text = "View Employee Record";
            this.btnViewEmployee.UseVisualStyleBackColor = false;
            this.btnViewEmployee.Click += new System.EventHandler(this.btnViewEmployee_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1487, 54);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Organizational Chart";
            // 
            // lblDetails
            // 
            this.lblDetails.BackColor = System.Drawing.Color.White;
            this.lblDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDetails.Location = new System.Drawing.Point(0, 688);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Padding = new System.Windows.Forms.Padding(12, 9, 0, 0);
            this.lblDetails.Size = new System.Drawing.Size(1487, 43);
            this.lblDetails.TabIndex = 1;
            this.lblDetails.Text = "Select an employee card to view details. Drag to pan; mouse wheel to zoom.";
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.canvas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 142);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1487, 546);
            this.canvas.TabIndex = 0;
            this.canvas.CardSelected += new System.Action<int>(this.Canvas_CardSelected);
            // 
            // OrganizationChartControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.lblTitle);
            this.Name = "OrganizationChartControl";
            this.Size = new System.Drawing.Size(1487, 731);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
