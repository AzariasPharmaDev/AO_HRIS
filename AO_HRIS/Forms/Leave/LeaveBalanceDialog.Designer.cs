using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Leave
{
    partial class LeaveBalanceDialog
    {
        private IContainer components = null;
        private ComboBox employee;
        private NumericUpDown year;
        private NumericUpDown entitled;
        private NumericUpDown carry;
        private NumericUpDown adjustment;
        private Button btnSave;
        private Button btnCancel;
        private Label lblEmployee;
        private Label lblYear;
        private Label lblEntitled;
        private Label lblCarry;
        private Label lblAdjustment;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.employee = new ComboBox();
            this.year = new NumericUpDown();
            this.entitled = new NumericUpDown();
            this.carry = new NumericUpDown();
            this.adjustment = new NumericUpDown();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblEmployee = new Label();
            this.lblYear = new Label();
            this.lblEntitled = new Label();
            this.lblCarry = new Label();
            this.lblAdjustment = new Label();
            ((ISupportInitialize)(this.year)).BeginInit();
            ((ISupportInitialize)(this.entitled)).BeginInit();
            ((ISupportInitialize)(this.carry)).BeginInit();
            ((ISupportInitialize)(this.adjustment)).BeginInit();
            this.SuspendLayout();

            this.Text = "Set Annual Leave Balance";
            this.ClientSize = new Size(480, 310);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9F);

            this.lblEmployee.Text = "Employee";
            this.lblEmployee.SetBounds(18, 20, 130, 24);
            this.employee.DropDownStyle = ComboBoxStyle.DropDownList;
            this.employee.SetBounds(160, 16, 300, 27);

            this.lblYear.Text = "Leave Year";
            this.lblYear.SetBounds(18, 65, 130, 24);
            this.year.DecimalPlaces = 0;
            this.year.Minimum = 2000;
            this.year.Maximum = 2100;
            this.year.SetBounds(160, 61, 100, 27);

            this.lblEntitled.Text = "Annual Entitlement";
            this.lblEntitled.SetBounds(18, 110, 130, 24);
            this.entitled.DecimalPlaces = 2;
            this.entitled.Increment = 0.5M;
            this.entitled.Minimum = 0;
            this.entitled.Maximum = 366;
            this.entitled.SetBounds(160, 106, 100, 27);

            this.lblCarry.Text = "Carry Forward";
            this.lblCarry.SetBounds(18, 155, 130, 24);
            this.carry.DecimalPlaces = 2;
            this.carry.Increment = 0.5M;
            this.carry.Minimum = 0;
            this.carry.Maximum = 366;
            this.carry.SetBounds(160, 151, 100, 27);

            this.lblAdjustment.Text = "Adjustment (+/-)";
            this.lblAdjustment.SetBounds(18, 200, 130, 24);
            this.adjustment.DecimalPlaces = 2;
            this.adjustment.Increment = 0.5M;
            this.adjustment.Minimum = -366;
            this.adjustment.Maximum = 366;
            this.adjustment.SetBounds(160, 196, 100, 27);

            this.btnSave.Text = "Save Balance";
            this.btnSave.SetBounds(270, 255, 100, 28);
            this.btnSave.DialogResult = DialogResult.OK;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.SetBounds(380, 255, 80, 28);
            this.btnCancel.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] {
                this.lblEmployee, this.employee, this.lblYear, this.year,
                this.lblEntitled, this.entitled, this.lblCarry, this.carry,
                this.lblAdjustment, this.adjustment, this.btnSave, this.btnCancel
            });
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.Name = "LeaveBalanceDialog";

            ((ISupportInitialize)(this.year)).EndInit();
            ((ISupportInitialize)(this.entitled)).EndInit();
            ((ISupportInitialize)(this.carry)).EndInit();
            ((ISupportInitialize)(this.adjustment)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
