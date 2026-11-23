using AO_HRIS.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Leave
{

    internal partial class LeaveBalanceDialog : Form
    {
        public int EmployeeId { get { return Convert.ToInt32(employee.SelectedValue); } }
        public int LeaveYear { get { return Convert.ToInt32(year.Value); } }
        public decimal EntitledDays { get { return entitled.Value; } }
        public decimal CarriedForwardDays { get { return carry.Value; } }
        public decimal AdjustmentDays { get { return adjustment.Value; } }

        // Parameterless constructor is required by the WinForms Designer.
        public LeaveBalanceDialog()
        {
            InitializeComponent();
            year.Value = DateTime.Today.Year;
            entitled.Value = 5.00M;
        }

        public LeaveBalanceDialog(int companyId) : this()
        {
            btnSave.Click += (s, e) =>
            {
                if (employee.SelectedValue == null)
                {
                    MessageBox.Show("Select an employee.", "Leave Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                }
            };
            LoadEmployees(companyId);
        }

        private void LoadEmployees(int companyId)
        {
            const string sql = @"SELECT DISTINCT er.EmployeeId,
                    er.LastName + ', ' + er.FirstName +
                    CASE WHEN NULLIF(er.MiddleName, '') IS NULL THEN '' ELSE ' ' + er.MiddleName END AS DisplayName,
                    er.EmployeeNo
                FROM dbo.EmployeeRecord er
                INNER JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId = er.EmployeeId
                WHERE ea.CompanyId = @CompanyId
                  AND er.IsActive = 1
                  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo >= CONVERT(date, GETDATE()))
                ORDER BY DisplayName";

            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                var dt = new DataTable();
                da.Fill(dt);
                employee.DataSource = dt;
                employee.DisplayMember = "DisplayName";
                employee.ValueMember = "EmployeeId";
            }
        }
    }
}