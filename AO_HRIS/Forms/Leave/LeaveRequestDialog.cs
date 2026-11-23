using AO_HRIS.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Leave
{
    internal partial class LeaveRequestDialog : Form
    {
        private readonly int companyId;
        private readonly bool canReview;
        private readonly int? employeeId;
        public int AssignmentId { get { return Convert.ToInt32(cmbEmployee.SelectedValue); } }
        public int LeaveTypeId { get { return Convert.ToInt32(leaveType.SelectedValue); } }
        public DateTime DateFrom { get { return from.Value.Date; } }
        public DateTime DateTo { get { return to.Value.Date; } }
        public decimal DaysRequested { get { return days.Value; } }
        public string Reason { get { return reason.Text.Trim(); } }

        // Parameterless constructor is required by the WinForms Designer.
        public LeaveRequestDialog()
        {
            InitializeComponent();
        }

        public LeaveRequestDialog(bool review, int? empId, int company) : this()
        {
            canReview = review;
            employeeId = empId;
            companyId = company;
            btnSave.Click += (s, e) => { if (ValidateInput()) DialogResult = DialogResult.OK; };
            LoadLists();
        }

        private void LoadLists()
        {
            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand(@"SELECT ea.AssignmentId, er.LastName+', '+er.FirstName AS DisplayName
                    FROM dbo.EmployeeAssignment ea JOIN dbo.EmployeeRecord er ON er.EmployeeId=ea.EmployeeId
                    WHERE ea.CompanyId=@CompanyId AND er.IsActive=1 AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CONVERT(date,GETDATE()))
                    AND (@CanReview=1 OR er.EmployeeId=@EmployeeId) ORDER BY er.LastName,er.FirstName", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId; cmd.Parameters.Add("@CanReview", SqlDbType.Bit).Value = canReview;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = (object)employeeId ?? DBNull.Value;
                    var dt = new DataTable(); da.Fill(dt); cmbEmployee.DataSource = dt; cmbEmployee.DisplayMember = "DisplayName"; cmbEmployee.ValueMember = "AssignmentId";
                }
                using (var cmd = new SqlCommand("SELECT LeaveTypeId,LeaveName FROM dbo.LeaveType WHERE CompanyId=@CompanyId AND IsActive=1 ORDER BY LeaveName", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                    var dt = new DataTable(); da.Fill(dt); leaveType.DataSource = dt; leaveType.DisplayMember = "LeaveName"; leaveType.ValueMember = "LeaveTypeId";
                }
            }
        }

        private bool ValidateInput()
        {
            if (cmbEmployee.SelectedValue == null || leaveType.SelectedValue == null) { MessageBox.Show("There are no available employees or active leave types for this company."); return false; }
            if (to.Value.Date < from.Value.Date) { MessageBox.Show("The end date cannot be earlier than the start date."); return false; }
            if (from.Value.Year != to.Value.Year) { MessageBox.Show("For now, submit separate requests when leave crosses calendar years."); return false; }
            if (reason.Text.Trim().Length == 0) { MessageBox.Show("Please enter a reason for the leave request."); return false; }
            return true;
        }
    }
}
