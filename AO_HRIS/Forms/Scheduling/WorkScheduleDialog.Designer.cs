
namespace AO_HRIS.Forms.Scheduling
{
    partial class WorkScheduleDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblScheduleName;
        private System.Windows.Forms.TextBox txtScheduleName;
        private System.Windows.Forms.Label lblScheduleType;
        private System.Windows.Forms.ComboBox cboScheduleType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblWeeklyTitle;
        private System.Windows.Forms.Label lblScheduleTypeNote;
        private System.Windows.Forms.Panel pnlWeeklyDays;

        private System.Windows.Forms.Label lblMonday;
        private System.Windows.Forms.Label lblTuesday;
        private System.Windows.Forms.Label lblWednesday;
        private System.Windows.Forms.Label lblThursday;
        private System.Windows.Forms.Label lblFriday;
        private System.Windows.Forms.Label lblSaturday;
        private System.Windows.Forms.Label lblSunday;

        private System.Windows.Forms.ComboBox cboMonday;
        private System.Windows.Forms.ComboBox cboTuesday;
        private System.Windows.Forms.ComboBox cboWednesday;
        private System.Windows.Forms.ComboBox cboThursday;
        private System.Windows.Forms.ComboBox cboFriday;
        private System.Windows.Forms.ComboBox cboSaturday;
        private System.Windows.Forms.ComboBox cboSunday;

        private System.Windows.Forms.CheckBox chkMondayRest;
        private System.Windows.Forms.CheckBox chkTuesdayRest;
        private System.Windows.Forms.CheckBox chkWednesdayRest;
        private System.Windows.Forms.CheckBox chkThursdayRest;
        private System.Windows.Forms.CheckBox chkFridayRest;
        private System.Windows.Forms.CheckBox chkSaturdayRest;
        private System.Windows.Forms.CheckBox chkSundayRest;

        private System.Windows.Forms.Panel pnlFooter;
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblScheduleName = new System.Windows.Forms.Label();
            this.txtScheduleName = new System.Windows.Forms.TextBox();
            this.lblScheduleType = new System.Windows.Forms.Label();
            this.cboScheduleType = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblWeeklyTitle = new System.Windows.Forms.Label();
            this.lblScheduleTypeNote = new System.Windows.Forms.Label();
            this.pnlWeeklyDays = new System.Windows.Forms.Panel();
            this.lblMonday = new System.Windows.Forms.Label();
            this.cboMonday = new System.Windows.Forms.ComboBox();
            this.chkMondayRest = new System.Windows.Forms.CheckBox();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.cboTuesday = new System.Windows.Forms.ComboBox();
            this.chkTuesdayRest = new System.Windows.Forms.CheckBox();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.cboWednesday = new System.Windows.Forms.ComboBox();
            this.chkWednesdayRest = new System.Windows.Forms.CheckBox();
            this.lblThursday = new System.Windows.Forms.Label();
            this.cboThursday = new System.Windows.Forms.ComboBox();
            this.chkThursdayRest = new System.Windows.Forms.CheckBox();
            this.lblFriday = new System.Windows.Forms.Label();
            this.cboFriday = new System.Windows.Forms.ComboBox();
            this.chkFridayRest = new System.Windows.Forms.CheckBox();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.cboSaturday = new System.Windows.Forms.ComboBox();
            this.chkSaturdayRest = new System.Windows.Forms.CheckBox();
            this.lblSunday = new System.Windows.Forms.Label();
            this.cboSunday = new System.Windows.Forms.ComboBox();
            this.chkSundayRest = new System.Windows.Forms.CheckBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlWeeklyDays.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 14, 24, 10);
            this.pnlHeader.Size = new System.Drawing.Size(650, 78);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(231)))), ((int)(((byte)(245)))));
            this.lblSubtitle.Location = new System.Drawing.Point(25, 44);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(283, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Define the schedule details and weekly work pattern.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Work Schedule";
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.pnlBody.Controls.Add(this.lblScheduleName);
            this.pnlBody.Controls.Add(this.txtScheduleName);
            this.pnlBody.Controls.Add(this.lblScheduleType);
            this.pnlBody.Controls.Add(this.cboScheduleType);
            this.pnlBody.Controls.Add(this.lblDescription);
            this.pnlBody.Controls.Add(this.txtDescription);
            this.pnlBody.Controls.Add(this.chkActive);
            this.pnlBody.Controls.Add(this.lblWeeklyTitle);
            this.pnlBody.Controls.Add(this.lblScheduleTypeNote);
            this.pnlBody.Controls.Add(this.pnlWeeklyDays);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 78);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(24, 18, 24, 18);
            this.pnlBody.Size = new System.Drawing.Size(650, 540);
            this.pnlBody.TabIndex = 1;
            // 
            // lblScheduleName
            // 
            this.lblScheduleName.AutoSize = true;
            this.lblScheduleName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblScheduleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblScheduleName.Location = new System.Drawing.Point(24, 16);
            this.lblScheduleName.Name = "lblScheduleName";
            this.lblScheduleName.Size = new System.Drawing.Size(91, 15);
            this.lblScheduleName.TabIndex = 0;
            this.lblScheduleName.Text = "Schedule Name";
            // 
            // txtScheduleName
            // 
            this.txtScheduleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheduleName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtScheduleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.txtScheduleName.Location = new System.Drawing.Point(27, 38);
            this.txtScheduleName.MaxLength = 200;
            this.txtScheduleName.Name = "txtScheduleName";
            this.txtScheduleName.Size = new System.Drawing.Size(360, 25);
            this.txtScheduleName.TabIndex = 1;
            // 
            // lblScheduleType
            // 
            this.lblScheduleType.AutoSize = true;
            this.lblScheduleType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblScheduleType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblScheduleType.Location = new System.Drawing.Point(405, 16);
            this.lblScheduleType.Name = "lblScheduleType";
            this.lblScheduleType.Size = new System.Drawing.Size(84, 15);
            this.lblScheduleType.TabIndex = 2;
            this.lblScheduleType.Text = "Schedule Type";
            // 
            // cboScheduleType
            // 
            this.cboScheduleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScheduleType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboScheduleType.FormattingEnabled = true;
            this.cboScheduleType.Items.AddRange(new object[] {
            "FIXED",
            "ROTATING"});
            this.cboScheduleType.Location = new System.Drawing.Point(408, 38);
            this.cboScheduleType.Name = "cboScheduleType";
            this.cboScheduleType.Size = new System.Drawing.Size(190, 25);
            this.cboScheduleType.TabIndex = 3;
            this.cboScheduleType.SelectedIndexChanged += new System.EventHandler(this.cboScheduleType_SelectedIndexChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.lblDescription.Location = new System.Drawing.Point(24, 78);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 15);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.txtDescription.Location = new System.Drawing.Point(27, 100);
            this.txtDescription.MaxLength = 510;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(571, 52);
            this.txtDescription.TabIndex = 5;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.chkActive.Location = new System.Drawing.Point(27, 164);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(59, 19);
            this.chkActive.TabIndex = 6;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblWeeklyTitle
            // 
            this.lblWeeklyTitle.AutoSize = true;
            this.lblWeeklyTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblWeeklyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(55)))), ((int)(((byte)(91)))));
            this.lblWeeklyTitle.Location = new System.Drawing.Point(24, 197);
            this.lblWeeklyTitle.Name = "lblWeeklyTitle";
            this.lblWeeklyTitle.Size = new System.Drawing.Size(113, 20);
            this.lblWeeklyTitle.TabIndex = 7;
            this.lblWeeklyTitle.Text = "Weekly Pattern";
            // 
            // lblScheduleTypeNote
            // 
            this.lblScheduleTypeNote.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblScheduleTypeNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(124)))), ((int)(((byte)(144)))));
            this.lblScheduleTypeNote.Location = new System.Drawing.Point(27, 222);
            this.lblScheduleTypeNote.Name = "lblScheduleTypeNote";
            this.lblScheduleTypeNote.Size = new System.Drawing.Size(570, 30);
            this.lblScheduleTypeNote.TabIndex = 8;
            this.lblScheduleTypeNote.Text = "Configure the shift or rest day for each day of the week.";
            // 
            // pnlWeeklyDays
            // 
            this.pnlWeeklyDays.BackColor = System.Drawing.Color.White;
            this.pnlWeeklyDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWeeklyDays.Controls.Add(this.lblMonday);
            this.pnlWeeklyDays.Controls.Add(this.cboMonday);
            this.pnlWeeklyDays.Controls.Add(this.chkMondayRest);
            this.pnlWeeklyDays.Controls.Add(this.lblTuesday);
            this.pnlWeeklyDays.Controls.Add(this.cboTuesday);
            this.pnlWeeklyDays.Controls.Add(this.chkTuesdayRest);
            this.pnlWeeklyDays.Controls.Add(this.lblWednesday);
            this.pnlWeeklyDays.Controls.Add(this.cboWednesday);
            this.pnlWeeklyDays.Controls.Add(this.chkWednesdayRest);
            this.pnlWeeklyDays.Controls.Add(this.lblThursday);
            this.pnlWeeklyDays.Controls.Add(this.cboThursday);
            this.pnlWeeklyDays.Controls.Add(this.chkThursdayRest);
            this.pnlWeeklyDays.Controls.Add(this.lblFriday);
            this.pnlWeeklyDays.Controls.Add(this.cboFriday);
            this.pnlWeeklyDays.Controls.Add(this.chkFridayRest);
            this.pnlWeeklyDays.Controls.Add(this.lblSaturday);
            this.pnlWeeklyDays.Controls.Add(this.cboSaturday);
            this.pnlWeeklyDays.Controls.Add(this.chkSaturdayRest);
            this.pnlWeeklyDays.Controls.Add(this.lblSunday);
            this.pnlWeeklyDays.Controls.Add(this.cboSunday);
            this.pnlWeeklyDays.Controls.Add(this.chkSundayRest);
            this.pnlWeeklyDays.Location = new System.Drawing.Point(27, 255);
            this.pnlWeeklyDays.Name = "pnlWeeklyDays";
            this.pnlWeeklyDays.Padding = new System.Windows.Forms.Padding(10);
            this.pnlWeeklyDays.Size = new System.Drawing.Size(571, 260);
            this.pnlWeeklyDays.TabIndex = 9;
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblMonday.Location = new System.Drawing.Point(15, 16);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(51, 15);
            this.lblMonday.TabIndex = 0;
            this.lblMonday.Text = "Monday";
            // 
            // cboMonday
            // 
            this.cboMonday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMonday.Location = new System.Drawing.Point(130, 12);
            this.cboMonday.Name = "cboMonday";
            this.cboMonday.Size = new System.Drawing.Size(260, 23);
            this.cboMonday.TabIndex = 1;
            // 
            // chkMondayRest
            // 
            this.chkMondayRest.AutoSize = true;
            this.chkMondayRest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkMondayRest.Location = new System.Drawing.Point(410, 15);
            this.chkMondayRest.Name = "chkMondayRest";
            this.chkMondayRest.Size = new System.Drawing.Size(70, 19);
            this.chkMondayRest.TabIndex = 2;
            this.chkMondayRest.Text = "Rest day";
            // 
            // lblTuesday
            // 
            this.lblTuesday.AutoSize = true;
            this.lblTuesday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTuesday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblTuesday.Location = new System.Drawing.Point(15, 49);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(50, 15);
            this.lblTuesday.TabIndex = 3;
            this.lblTuesday.Text = "Tuesday";
            // 
            // cboTuesday
            // 
            this.cboTuesday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTuesday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTuesday.Location = new System.Drawing.Point(130, 45);
            this.cboTuesday.Name = "cboTuesday";
            this.cboTuesday.Size = new System.Drawing.Size(260, 23);
            this.cboTuesday.TabIndex = 4;
            // 
            // chkTuesdayRest
            // 
            this.chkTuesdayRest.AutoSize = true;
            this.chkTuesdayRest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkTuesdayRest.Location = new System.Drawing.Point(410, 48);
            this.chkTuesdayRest.Name = "chkTuesdayRest";
            this.chkTuesdayRest.Size = new System.Drawing.Size(70, 19);
            this.chkTuesdayRest.TabIndex = 5;
            this.chkTuesdayRest.Text = "Rest day";
            // 
            // lblWednesday
            // 
            this.lblWednesday.AutoSize = true;
            this.lblWednesday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWednesday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblWednesday.Location = new System.Drawing.Point(15, 82);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(68, 15);
            this.lblWednesday.TabIndex = 6;
            this.lblWednesday.Text = "Wednesday";
            // 
            // cboWednesday
            // 
            this.cboWednesday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWednesday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboWednesday.Location = new System.Drawing.Point(130, 78);
            this.cboWednesday.Name = "cboWednesday";
            this.cboWednesday.Size = new System.Drawing.Size(260, 23);
            this.cboWednesday.TabIndex = 7;
            // 
            // chkWednesdayRest
            // 
            this.chkWednesdayRest.AutoSize = true;
            this.chkWednesdayRest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkWednesdayRest.Location = new System.Drawing.Point(410, 81);
            this.chkWednesdayRest.Name = "chkWednesdayRest";
            this.chkWednesdayRest.Size = new System.Drawing.Size(70, 19);
            this.chkWednesdayRest.TabIndex = 8;
            this.chkWednesdayRest.Text = "Rest day";
            // 
            // lblThursday
            // 
            this.lblThursday.AutoSize = true;
            this.lblThursday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThursday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblThursday.Location = new System.Drawing.Point(15, 115);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(55, 15);
            this.lblThursday.TabIndex = 9;
            this.lblThursday.Text = "Thursday";
            // 
            // cboThursday
            // 
            this.cboThursday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThursday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboThursday.Location = new System.Drawing.Point(130, 111);
            this.cboThursday.Name = "cboThursday";
            this.cboThursday.Size = new System.Drawing.Size(260, 23);
            this.cboThursday.TabIndex = 10;
            // 
            // chkThursdayRest
            // 
            this.chkThursdayRest.AutoSize = true;
            this.chkThursdayRest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkThursdayRest.Location = new System.Drawing.Point(410, 114);
            this.chkThursdayRest.Name = "chkThursdayRest";
            this.chkThursdayRest.Size = new System.Drawing.Size(70, 19);
            this.chkThursdayRest.TabIndex = 11;
            this.chkThursdayRest.Text = "Rest day";
            // 
            // lblFriday
            // 
            this.lblFriday.AutoSize = true;
            this.lblFriday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFriday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblFriday.Location = new System.Drawing.Point(15, 148);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(39, 15);
            this.lblFriday.TabIndex = 12;
            this.lblFriday.Text = "Friday";
            // 
            // cboFriday
            // 
            this.cboFriday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFriday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFriday.Location = new System.Drawing.Point(130, 144);
            this.cboFriday.Name = "cboFriday";
            this.cboFriday.Size = new System.Drawing.Size(260, 23);
            this.cboFriday.TabIndex = 13;
            // 
            // chkFridayRest
            // 
            this.chkFridayRest.AutoSize = true;
            this.chkFridayRest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkFridayRest.Location = new System.Drawing.Point(410, 147);
            this.chkFridayRest.Name = "chkFridayRest";
            this.chkFridayRest.Size = new System.Drawing.Size(70, 19);
            this.chkFridayRest.TabIndex = 14;
            this.chkFridayRest.Text = "Rest day";
            // 
            // lblSaturday
            // 
            this.lblSaturday.AutoSize = true;
            this.lblSaturday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSaturday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblSaturday.Location = new System.Drawing.Point(15, 181);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(53, 15);
            this.lblSaturday.TabIndex = 15;
            this.lblSaturday.Text = "Saturday";
            // 
            // cboSaturday
            // 
            this.cboSaturday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSaturday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSaturday.Location = new System.Drawing.Point(130, 177);
            this.cboSaturday.Name = "cboSaturday";
            this.cboSaturday.Size = new System.Drawing.Size(260, 23);
            this.cboSaturday.TabIndex = 16;
            // 
            // chkSaturdayRest
            // 
            this.chkSaturdayRest.AutoSize = true;
            this.chkSaturdayRest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkSaturdayRest.Location = new System.Drawing.Point(410, 180);
            this.chkSaturdayRest.Name = "chkSaturdayRest";
            this.chkSaturdayRest.Size = new System.Drawing.Size(70, 19);
            this.chkSaturdayRest.TabIndex = 17;
            this.chkSaturdayRest.Text = "Rest day";
            // 
            // lblSunday
            // 
            this.lblSunday.AutoSize = true;
            this.lblSunday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSunday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.lblSunday.Location = new System.Drawing.Point(15, 214);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(46, 15);
            this.lblSunday.TabIndex = 18;
            this.lblSunday.Text = "Sunday";
            // 
            // cboSunday
            // 
            this.cboSunday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSunday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSunday.Location = new System.Drawing.Point(130, 210);
            this.cboSunday.Name = "cboSunday";
            this.cboSunday.Size = new System.Drawing.Size(260, 23);
            this.cboSunday.TabIndex = 19;
            // 
            // chkSundayRest
            // 
            this.chkSundayRest.AutoSize = true;
            this.chkSundayRest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkSundayRest.Location = new System.Drawing.Point(410, 213);
            this.chkSundayRest.Name = "chkSundayRest";
            this.chkSundayRest.Size = new System.Drawing.Size(70, 19);
            this.chkSundayRest.TabIndex = 20;
            this.chkSundayRest.Text = "Rest day";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 618);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(20, 10, 24, 10);
            this.pnlFooter.Size = new System.Drawing.Size(650, 62);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(210)))), ((int)(((byte)(228)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            this.btnCancel.Location = new System.Drawing.Point(414, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 36);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(106)))), ((int)(((byte)(213)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(517, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Schedule";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // WorkScheduleDialog
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(650, 680);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkScheduleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work Schedule";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlWeeklyDays.ResumeLayout(false);
            this.pnlWeeklyDays.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
