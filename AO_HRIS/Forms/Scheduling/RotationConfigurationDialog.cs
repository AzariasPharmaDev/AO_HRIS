
using AO_HRIS.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Scheduling
{
    public partial class RotationConfigurationDialog : Form
    {
        private readonly int _companyId;
        private readonly int _workScheduleId;
        private readonly string _scheduleName;

        private readonly WorkScheduleRotationRepository _repository =
            new WorkScheduleRotationRepository();

        private DataTable _shifts;

        public WorkScheduleRotationModel Rotation { get; private set; }

        public RotationConfigurationDialog(
            int companyId,
            int workScheduleId,
            string scheduleName,
            WorkScheduleRotationModel existingRotation = null)
        {
            InitializeComponent();

            _companyId = companyId;
            _workScheduleId = workScheduleId;
            _scheduleName = scheduleName;

            Rotation = existingRotation;

            ConfigureDialog();
            LoadShiftOptions();

            if (Rotation != null)
                LoadRotation();
            else
            {
                txtRotationName.Text = "Standard Rotation";
                numCycleLength.Value = 7;
                GenerateDays();
            }
        }

        private void ConfigureDialog()
        {
            lblScheduleName.Text = _scheduleName;

            dgvDays.AllowUserToAddRows = false;
            dgvDays.AllowUserToDeleteRows = false;
            dgvDays.AllowUserToResizeRows = false;
            dgvDays.MultiSelect = false;
            dgvDays.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDays.AutoGenerateColumns = false;
            dgvDays.RowHeadersVisible = false;

            colCycleDay.SortMode = DataGridViewColumnSortMode.NotSortable;
            colShift.SortMode = DataGridViewColumnSortMode.NotSortable;
            colRestDay.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvDays.CellValueChanged += dgvDays_CellValueChanged;
            dgvDays.CurrentCellDirtyStateChanged +=
                dgvDays_CurrentCellDirtyStateChanged;
        }

        private void LoadShiftOptions()
        {
            _shifts = _repository.GetActiveShifts(_companyId);

            colShift.DataSource = _shifts;
            colShift.DisplayMember = "ShiftDisplay";
            colShift.ValueMember = "ShiftId";
            colShift.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            colShift.FlatStyle = FlatStyle.Flat;
        }

        private void LoadRotation()
        {
            txtRotationName.Text = Rotation.RotationName;
            numCycleLength.Value = Rotation.CycleLengthDays;

            GenerateDays();

            foreach (WorkScheduleRotationDayModel day in Rotation.Days)
            {
                if (day.CycleDayNumber < 1 ||
                    day.CycleDayNumber > dgvDays.Rows.Count)
                    continue;

                DataGridViewRow row = dgvDays.Rows[day.CycleDayNumber - 1];

                row.Cells["colRestDay"].Value = day.IsRestDay;

                if (day.ShiftId.HasValue &&
                    ShiftExists(day.ShiftId.Value))
                {
                    row.Cells["colShift"].Value = day.ShiftId.Value;
                }
                else if (!day.IsRestDay)
                {
                    row.Cells["colShift"].Value = DBNull.Value;
                }
            }

            UpdateGridState();
        }

        private bool ShiftExists(int shiftId)
        {
            foreach (DataRow row in _shifts.Rows)
            {
                if (Convert.ToInt32(row["ShiftId"]) == shiftId)
                    return true;
            }

            return false;
        }

        private void btnGenerateDays_Click(object sender, EventArgs e)
        {
            GenerateDays();
        }

        private void GenerateDays()
        {
            int cycleLength = Convert.ToInt32(numCycleLength.Value);

            dgvDays.Rows.Clear();

            for (int day = 1; day <= cycleLength; day++)
            {
                int rowIndex = dgvDays.Rows.Add();

                DataGridViewRow row = dgvDays.Rows[rowIndex];

                row.Cells["colCycleDay"].Value = "Day " + day;
                row.Cells["colShift"].Value = DBNull.Value;
                row.Cells["colRestDay"].Value = false;
            }

            UpdateGridState();
        }

        private void dgvDays_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e)
        {
            if (dgvDays.IsCurrentCellDirty)
                dgvDays.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvDays_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = dgvDays.Columns[e.ColumnIndex].Name;

            if (columnName == "colRestDay")
            {
                DataGridViewRow row = dgvDays.Rows[e.RowIndex];

                bool isRestDay =
                    Convert.ToBoolean(row.Cells["colRestDay"].Value);

                if (isRestDay)
                    row.Cells["colShift"].Value = DBNull.Value;

                UpdateGridState();
            }
        }

        private void UpdateGridState()
        {
            foreach (DataGridViewRow row in dgvDays.Rows)
            {
                bool isRestDay = false;

                if (row.Cells["colRestDay"].Value != null)
                    isRestDay = Convert.ToBoolean(
                        row.Cells["colRestDay"].Value);

                row.Cells["colShift"].ReadOnly = isRestDay;

                row.Cells["colShift"].Style.BackColor = isRestDay
                    ? System.Drawing.Color.FromArgb(242, 245, 249)
                    : System.Drawing.Color.White;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRotationName.Text))
            {
                MessageBox.Show(
                    "Enter a rotation name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtRotationName.Focus();
                return;
            }

            dgvDays.EndEdit();

            WorkScheduleRotationModel model =
                new WorkScheduleRotationModel
                {
                    RotationId = Rotation == null ? 0 : Rotation.RotationId,
                    WorkScheduleId = _workScheduleId,
                    RotationName = txtRotationName.Text.Trim(),
                    CycleLengthDays = Convert.ToInt32(numCycleLength.Value)
                };

            foreach (DataGridViewRow row in dgvDays.Rows)
            {
                bool isRestDay =
                    Convert.ToBoolean(row.Cells["colRestDay"].Value);

                object shiftValue = row.Cells["colShift"].Value;

                int? shiftId = null;

                if (shiftValue != null && shiftValue != DBNull.Value)
                    shiftId = Convert.ToInt32(shiftValue);

                model.Days.Add(new WorkScheduleRotationDayModel
                {
                    CycleDayNumber = row.Index + 1,
                    ShiftId = shiftId,
                    IsRestDay = isRestDay
                });
            }

            try
            {
                _repository.Save(
                    _companyId,
                    _workScheduleId,
                    model);

                Rotation = model;

                MessageBox.Show(
                    "Rotation configuration saved successfully.",
                    "Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Unable to Save Rotation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
