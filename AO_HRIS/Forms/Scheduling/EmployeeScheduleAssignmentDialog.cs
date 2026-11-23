using AO_HRIS.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Scheduling
{
    public partial class EmployeeScheduleAssignmentDialog : Form
    {
        private readonly int _companyId;
        private readonly int? _scheduleAssignmentId;

        private readonly EmployeeScheduleAssignmentRepository _repository =
            new EmployeeScheduleAssignmentRepository();

        private bool _loading;

        public EmployeeScheduleAssignmentDialog(int companyId)
        {
            InitializeComponent();

            _companyId = companyId;
            _scheduleAssignmentId = null;

            InitializeDialog();
        }

        public EmployeeScheduleAssignmentDialog(
            int companyId,
            int scheduleAssignmentId)
        {
            InitializeComponent();

            _companyId = companyId;
            _scheduleAssignmentId = scheduleAssignmentId;

            InitializeDialog();
        }

        private void InitializeDialog()
        {
            _loading = true;

            cboAssignment.DataSource = null;

            cboAssignment.DropDownStyle = ComboBoxStyle.DropDownList;

            DataTable employees =
                _repository.GetEmployeeAssignments(_companyId);

            if (!employees.Columns.Contains("EmployeeDisplay"))
            {
                employees.Columns.Add("EmployeeDisplay", typeof(string));
            }

            foreach (DataRow row in employees.Rows)
            {
                string employeeName =
                    Convert.ToString(row["EmployeeName"]);

                string department =
                    Convert.ToString(row["DepartmentName"]);

                string position =
                    Convert.ToString(row["PositionName"]);

                row["EmployeeDisplay"] =
                    employeeName + " | " + department + " / " + position;
            }

            cboAssignment.DisplayMember = "EmployeeDisplay";
            cboAssignment.ValueMember = "AssignmentId";
            cboAssignment.DataSource = employees;

            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.Items.Clear();
            cboMode.Items.Add("FIXED");
            cboMode.Items.Add("ROTATING");
            cboMode.Items.Add("INDIVIDUAL");
            cboMode.SelectedIndex = 0;

            dtpEffectiveFrom.Value = DateTime.Today;
            dtpEffectiveTo.Value = DateTime.Today;
            dtpRotationStart.Value = DateTime.Today;

            dtpEffectiveTo.ShowCheckBox = true;
            dtpEffectiveTo.Checked = false;

            LoadSchedules();

            if (_scheduleAssignmentId.HasValue)
                LoadExistingAssignment();

            _loading = false;

            UpdateModeControls();

            if (_scheduleAssignmentId.HasValue)
            {
                lblTitle.Text = "Edit Schedule Assignment";
                lblSubtitle.Text =
                    "Update the employee's assigned work schedule.";
            }
        }

        private void LoadSchedules()
        {
            string mode = Convert.ToString(cboMode.SelectedItem);

            cboSchedule.DataSource = null;
            cboSchedule.Items.Clear();

            if (mode == "INDIVIDUAL")
                return;

            DataTable schedules =
                _repository.GetAvailableSchedules(_companyId, mode);

            cboSchedule.DisplayMember = "ScheduleName";
            cboSchedule.ValueMember = "WorkScheduleId";
            cboSchedule.DataSource = schedules;
        }

        private void LoadExistingAssignment()
        {
            EmployeeScheduleAssignmentModel model =
                _repository.GetById(
                    _companyId,
                    _scheduleAssignmentId.Value);

            if (model == null)
            {
                throw new InvalidOperationException(
                    "The selected schedule assignment could not be found.");
            }

            model.CompanyId = _companyId;

            SelectComboValue(cboAssignment, model.AssignmentId);

            cboMode.SelectedItem = model.AssignmentMode;

            LoadSchedules();

            if (model.WorkScheduleId.HasValue)
                SelectComboValue(cboSchedule, model.WorkScheduleId.Value);

            dtpEffectiveFrom.Value = model.EffectiveFrom;

            if (model.EffectiveTo.HasValue)
            {
                dtpEffectiveTo.Value = model.EffectiveTo.Value;
                dtpEffectiveTo.Checked = true;
            }
            else
            {
                dtpEffectiveTo.Checked = false;
            }

            if (model.RotationStartDate.HasValue)
            {
                dtpRotationStart.Value = model.RotationStartDate.Value;
            }
        }

        private static void SelectComboValue(
            ComboBox combo,
            int value)
        {
            if (combo.DataSource == null)
                return;

            combo.SelectedValue = value;
        }

        private void UpdateModeControls()
        {
            string mode = Convert.ToString(cboMode.SelectedItem);

            bool individual = mode == "INDIVIDUAL";
            bool rotating = mode == "ROTATING";

            lblSchedule.Enabled = !individual;
            cboSchedule.Enabled = !individual;

            lblRotationStart.Visible = rotating;
            dtpRotationStart.Visible = rotating;

            if (individual)
                cboSchedule.SelectedIndex = -1;
        }

        private void cboMode_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (_loading)
                return;

            LoadSchedules();
            UpdateModeControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboAssignment.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Select an employee assignment.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string mode = Convert.ToString(cboMode.SelectedItem);

                if (string.IsNullOrWhiteSpace(mode))
                {
                    MessageBox.Show(
                        "Select a schedule assignment mode.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                int? workScheduleId = null;

                if (mode != "INDIVIDUAL")
                {
                    if (cboSchedule.SelectedValue == null)
                    {
                        MessageBox.Show(
                            "Select a work schedule.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    workScheduleId =
                        Convert.ToInt32(cboSchedule.SelectedValue);
                }

                EmployeeScheduleAssignmentModel model =
                    new EmployeeScheduleAssignmentModel();

                model.ScheduleAssignmentId =
                    _scheduleAssignmentId.HasValue
                        ? _scheduleAssignmentId.Value
                        : 0;

                model.CompanyId = _companyId;

                model.AssignmentId =
                    Convert.ToInt32(cboAssignment.SelectedValue);

                model.AssignmentMode = mode;
                model.WorkScheduleId = workScheduleId;

                model.RotationStartDate =
                    mode == "ROTATING"
                        ? (DateTime?)dtpRotationStart.Value.Date
                        : null;

                model.EffectiveFrom = dtpEffectiveFrom.Value.Date;

                model.EffectiveTo = dtpEffectiveTo.Checked
                    ? (DateTime?)dtpEffectiveTo.Value.Date
                    : null;

                if (_scheduleAssignmentId.HasValue)
                    _repository.Update(_companyId, model);
                else
                    _repository.Insert(_companyId, model);

                MessageBox.Show(
                    "Employee schedule assignment saved successfully.",
                    "Scheduling",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to save employee schedule assignment.\n\n" +
                    ex.Message,
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}