using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Leave
{
    partial class LeaveTypeDialog
    {
        private IContainer components = null;
        private TextBox code;
        private TextBox name;
        private CheckBox paid;
        private CheckBox approval;
        private Button btnSave;
        private Button btnCancel;
        private Label lblCode;
        private Label lblName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.code = new TextBox(); this.name = new TextBox();
            this.paid = new CheckBox(); this.approval = new CheckBox();
            this.btnSave = new Button(); this.btnCancel = new Button();
            this.lblCode = new Label(); this.lblName = new Label();
            this.SuspendLayout();
            this.Text = "Leave Type"; this.ClientSize = new Size(412, 250);
            this.StartPosition = FormStartPosition.CenterParent; this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false; this.Font = new Font("Segoe UI", 9F);
            this.lblCode.Text = "Leave Code"; this.lblCode.SetBounds(18, 22, 110, 24);
            this.code.SetBounds(135, 18, 250, 28); this.code.MaxLength = 30;
            this.lblName.Text = "Leave Name"; this.lblName.SetBounds(18, 65, 110, 24);
            this.name.SetBounds(135, 61, 250, 28); this.name.MaxLength = 100;
            this.paid.Text = "Paid leave"; this.paid.SetBounds(135, 105, 180, 25);
            this.approval.Text = "Requires approval"; this.approval.SetBounds(135, 137, 180, 25);
            this.btnSave.Text = "Save"; this.btnSave.SetBounds(220, 190, 75, 28); this.btnSave.DialogResult = DialogResult.OK;
            this.btnCancel.Text = "Cancel"; this.btnCancel.SetBounds(305, 190, 80, 28); this.btnCancel.DialogResult = DialogResult.Cancel;
            this.Controls.AddRange(new Control[] { this.lblCode, this.code, this.lblName, this.name, this.paid, this.approval, this.btnSave, this.btnCancel });
            this.AcceptButton = this.btnSave; this.CancelButton = this.btnCancel;
            this.Name = "LeaveTypeDialog";
            this.ResumeLayout(false);
        }
    }
}
