using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Attendance
{
    partial class AttendanceManagementControl
    {
        private IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Panel pnlHeader;
        private Label lblHeading;
        private Label lblSubtitle;
        private Panel pnlContent;
        private Panel pnlFilters;
        private Label lblFrom;
        private Label lblTo;
        private Label lblSearch;
        private Label lblEventType;
        private Label lblSource;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private TextBox txtSearch;
        private ComboBox cboEventType;
        private ComboBox cboSource;
        private CheckBox chkIncludeVoided;
        private Button btnApplyFilters;
        private Button btnResetFilters;
        private FlowLayoutPanel pnlActions;
        private Button btnManualEntry;
        private Button btnVoidEvent;
        private Button btnRefresh;
        private DataGridView dgvEvents;
        private Label lblCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainLayout = new TableLayoutPanel();
            this.pnlHeader = new Panel();
            this.lblHeading = new Label();
            this.lblSubtitle = new Label();
            this.pnlContent = new Panel();
            this.pnlFilters = new Panel();
            this.lblFrom = new Label(); this.lblTo = new Label(); this.lblSearch = new Label();
            this.lblEventType = new Label(); this.lblSource = new Label();
            this.dtpFrom = new DateTimePicker(); this.dtpTo = new DateTimePicker();
            this.txtSearch = new TextBox(); this.cboEventType = new ComboBox(); this.cboSource = new ComboBox();
            this.chkIncludeVoided = new CheckBox(); this.btnApplyFilters = new Button(); this.btnResetFilters = new Button();
            this.pnlActions = new FlowLayoutPanel(); this.btnManualEntry = new Button(); this.btnVoidEvent = new Button(); this.btnRefresh = new Button();
            this.dgvEvents = new DataGridView(); this.lblCount = new Label();
            this.mainLayout.SuspendLayout(); this.pnlHeader.SuspendLayout(); this.pnlContent.SuspendLayout();
            this.pnlFilters.SuspendLayout(); this.pnlActions.SuspendLayout(); ((ISupportInitialize)(this.dgvEvents)).BeginInit(); this.SuspendLayout();
            // mainLayout
            this.mainLayout.BackColor = Color.FromArgb(247, 250, 254);
            this.mainLayout.ColumnCount = 1; this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainLayout.RowCount = 2; this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); this.mainLayout.Padding = new Padding(24);
            this.mainLayout.Dock = DockStyle.Fill; this.mainLayout.Controls.Add(this.pnlHeader, 0, 0); this.mainLayout.Controls.Add(this.pnlContent, 0, 1);
            // header
            this.pnlHeader.BackColor = Color.FromArgb(247, 250, 254); this.pnlHeader.Dock = DockStyle.Fill;
            this.pnlHeader.Controls.Add(this.lblHeading); this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.lblHeading.AutoSize = true; this.lblHeading.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            this.lblHeading.ForeColor = Color.FromArgb(28, 55, 91); this.lblHeading.Location = new Point(0, 0); this.lblHeading.Text = "Attendance Management";
            this.lblSubtitle.AutoSize = true; this.lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = Color.FromArgb(107, 124, 144); this.lblSubtitle.Location = new Point(2, 40);
            this.lblSubtitle.Text = "Review attendance events, encode manual punches, and retain a traceable correction history.";
            // content
            this.pnlContent.BackColor = Color.White; this.pnlContent.Dock = DockStyle.Fill; this.pnlContent.Padding = new Padding(14);
            this.pnlContent.Controls.Add(this.dgvEvents); this.pnlContent.Controls.Add(this.pnlActions); this.pnlContent.Controls.Add(this.pnlFilters); this.pnlContent.Controls.Add(this.lblCount);
            // filters
            this.pnlFilters.Dock = DockStyle.Top; this.pnlFilters.Height = 108; this.pnlFilters.BackColor = Color.White;
            // Filter labels (keep initialization designer-compatible; no helper method calls here).
            this.lblFrom.AutoSize = true; this.lblFrom.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblFrom.ForeColor = Color.FromArgb(107, 124, 144); this.lblFrom.Location = new Point(0, 2); this.lblFrom.Text = "FROM";
            this.lblTo.AutoSize = true; this.lblTo.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblTo.ForeColor = Color.FromArgb(107, 124, 144); this.lblTo.Location = new Point(190, 2); this.lblTo.Text = "TO";
            this.lblSearch.AutoSize = true; this.lblSearch.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblSearch.ForeColor = Color.FromArgb(107, 124, 144); this.lblSearch.Location = new Point(380, 2); this.lblSearch.Text = "EMPLOYEE SEARCH";
            this.lblEventType.AutoSize = true; this.lblEventType.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblEventType.ForeColor = Color.FromArgb(107, 124, 144); this.lblEventType.Location = new Point(690, 2); this.lblEventType.Text = "EVENT TYPE";
            this.lblSource.AutoSize = true; this.lblSource.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold); this.lblSource.ForeColor = Color.FromArgb(107, 124, 144); this.lblSource.Location = new Point(900, 2); this.lblSource.Text = "SOURCE";
            // Date filters.
            this.dtpFrom.Font = new Font("Segoe UI", 9F); this.dtpFrom.Format = DateTimePickerFormat.Custom; this.dtpFrom.CustomFormat = "MMM dd, yyyy"; this.dtpFrom.Location = new Point(0, 25); this.dtpFrom.Size = new Size(175, 27);
            this.dtpTo.Font = new Font("Segoe UI", 9F); this.dtpTo.Format = DateTimePickerFormat.Custom; this.dtpTo.CustomFormat = "MMM dd, yyyy"; this.dtpTo.Location = new Point(190, 25); this.dtpTo.Size = new Size(175, 27);
            // Search and combo filters.
            this.txtSearch.Font = new Font("Segoe UI", 9F); this.txtSearch.Location = new Point(380, 25); this.txtSearch.Size = new Size(285, 27); this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.cboEventType.DropDownStyle = ComboBoxStyle.DropDownList; this.cboEventType.Font = new Font("Segoe UI", 9F); this.cboEventType.Location = new Point(690, 25); this.cboEventType.Size = new Size(190, 28);
            this.cboSource.DropDownStyle = ComboBoxStyle.DropDownList; this.cboSource.Font = new Font("Segoe UI", 9F); this.cboSource.Location = new Point(900, 25); this.cboSource.Size = new Size(190, 28);
            this.chkIncludeVoided.AutoSize = true; this.chkIncludeVoided.Font = new Font("Segoe UI", 9F); this.chkIncludeVoided.ForeColor = Color.FromArgb(40, 57, 77);
            this.chkIncludeVoided.Location = new Point(0, 70); this.chkIncludeVoided.Text = "Include voided events";
            this.btnApplyFilters.Text = "Apply filters"; this.btnApplyFilters.Location = new Point(190, 64); this.btnApplyFilters.Size = new Size(105, 30); this.btnApplyFilters.FlatStyle = FlatStyle.Flat;
            this.btnApplyFilters.FlatAppearance.BorderSize = 0; this.btnApplyFilters.FlatAppearance.BorderColor = Color.FromArgb(220, 229, 239);
            this.btnApplyFilters.BackColor = Color.FromArgb(35, 106, 213); this.btnApplyFilters.ForeColor = Color.White; this.btnApplyFilters.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            this.btnResetFilters.Text = "Reset"; this.btnResetFilters.Location = new Point(303, 64); this.btnResetFilters.Size = new Size(78, 30); this.btnResetFilters.FlatStyle = FlatStyle.Flat;
            this.btnResetFilters.FlatAppearance.BorderSize = 1; this.btnResetFilters.FlatAppearance.BorderColor = Color.FromArgb(220, 229, 239);
            this.btnResetFilters.BackColor = Color.White; this.btnResetFilters.ForeColor = Color.FromArgb(40, 57, 77); this.btnResetFilters.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            this.pnlFilters.Controls.AddRange(new Control[] { this.lblFrom, this.lblTo, this.lblSearch, this.lblEventType, this.lblSource,
                this.dtpFrom, this.dtpTo, this.txtSearch, this.cboEventType, this.cboSource, this.chkIncludeVoided, this.btnApplyFilters, this.btnResetFilters });
            // actions
            this.pnlActions.Dock = DockStyle.Top; this.pnlActions.Height = 48; this.pnlActions.FlowDirection = FlowDirection.LeftToRight;
            this.pnlActions.WrapContents = false; this.pnlActions.Padding = new Padding(0, 4, 0, 4);
            this.btnManualEntry.Text = "+  Manual entry"; this.btnManualEntry.Size = new Size(132, 34); this.btnManualEntry.Margin = new Padding(0, 0, 8, 0); this.btnManualEntry.FlatStyle = FlatStyle.Flat;
            this.btnManualEntry.FlatAppearance.BorderSize = 0; this.btnManualEntry.FlatAppearance.BorderColor = Color.FromArgb(220, 229, 239); this.btnManualEntry.BackColor = Color.FromArgb(35, 106, 213); this.btnManualEntry.ForeColor = Color.White; this.btnManualEntry.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnVoidEvent.Text = "Void selected"; this.btnVoidEvent.Size = new Size(112, 34); this.btnVoidEvent.Margin = new Padding(0, 0, 8, 0); this.btnVoidEvent.FlatStyle = FlatStyle.Flat;
            this.btnVoidEvent.FlatAppearance.BorderSize = 1; this.btnVoidEvent.FlatAppearance.BorderColor = Color.FromArgb(220, 229, 239); this.btnVoidEvent.BackColor = Color.White; this.btnVoidEvent.ForeColor = Color.FromArgb(40, 57, 77); this.btnVoidEvent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnRefresh.Text = "Refresh"; this.btnRefresh.Size = new Size(88, 34); this.btnRefresh.Margin = new Padding(0, 0, 8, 0); this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 1; this.btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(220, 229, 239); this.btnRefresh.BackColor = Color.White; this.btnRefresh.ForeColor = Color.FromArgb(40, 57, 77); this.btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.pnlActions.Controls.AddRange(new Control[] { this.btnManualEntry, this.btnVoidEvent, this.btnRefresh });
            // count
            this.lblCount.Dock = DockStyle.Bottom; this.lblCount.Height = 26; this.lblCount.TextAlign = ContentAlignment.MiddleLeft;
            this.lblCount.Font = new Font("Segoe UI", 9F); this.lblCount.ForeColor = Color.FromArgb(107, 124, 144); this.lblCount.Text = "0 attendance event(s)";
            // grid
            this.dgvEvents.Dock = DockStyle.Fill; this.dgvEvents.BackgroundColor = Color.White; this.dgvEvents.BorderStyle = BorderStyle.None;
            this.dgvEvents.AllowUserToAddRows = false; this.dgvEvents.AllowUserToDeleteRows = false; this.dgvEvents.ReadOnly = true;
            this.dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; this.dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.MultiSelect = false; this.dgvEvents.RowHeadersVisible = false; this.dgvEvents.AutoGenerateColumns = true;
            this.dgvEvents.EnableHeadersVisualStyles = false; this.dgvEvents.ColumnHeadersHeight = 40; this.dgvEvents.RowTemplate.Height = 36;
            this.dgvEvents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 246, 251);
            this.dgvEvents.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(40, 57, 77);
            this.dgvEvents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.dgvEvents.DefaultCellStyle.Font = new Font("Segoe UI", 9F); this.dgvEvents.DefaultCellStyle.ForeColor = Color.FromArgb(40, 57, 77);
            this.dgvEvents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 235, 255); this.dgvEvents.DefaultCellStyle.SelectionForeColor = Color.FromArgb(28, 55, 91);
            this.dgvEvents.GridColor = Color.FromArgb(228, 235, 243);
            // control
            this.Controls.Add(this.mainLayout); this.Name = "AttendanceManagementControl"; this.Size = new Size(1487, 739);
            this.mainLayout.ResumeLayout(false); this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false); this.pnlFilters.ResumeLayout(false); this.pnlFilters.PerformLayout(); this.pnlActions.ResumeLayout(false);
            ((ISupportInitialize)(this.dgvEvents)).EndInit(); this.ResumeLayout(false);
        }

    }
}
