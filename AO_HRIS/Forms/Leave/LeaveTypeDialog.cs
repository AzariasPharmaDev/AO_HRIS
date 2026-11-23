using System;
using System.Windows.Forms;
namespace AO_HRIS.Forms.Leave
{
    internal partial class LeaveTypeDialog : Form
    {
        public string Code { get { return code.Text.Trim().ToUpperInvariant(); } }
        public string LeaveName { get { return name.Text.Trim(); } }
        public bool IsPaid { get { return paid.Checked; } }
        public bool RequiresApproval { get { return approval.Checked; } }
        // Parameterless constructor is required by the WinForms Designer.
        public LeaveTypeDialog()
        {
            InitializeComponent();
        }

        public LeaveTypeDialog(string c, string n, bool p, bool a) : this()
        {
            code.Text = c;
            name.Text = n;
            paid.Checked = p;
            approval.Checked = a;
            btnSave.Click += (s, e) =>
            {
                if (Code.Length == 0 || LeaveName.Length == 0)
                {
                    MessageBox.Show("Enter a code and name.");
                    DialogResult = DialogResult.None;
                }
            };
        }
    }
}
