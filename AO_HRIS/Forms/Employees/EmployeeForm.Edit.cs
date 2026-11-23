using System;
using System.Data;
using System.Windows.Forms;
using AO_HRIS.Security;

namespace AO_HRIS.Forms.Employees
{
    public partial class EmployeeForm
    {
        private int? _editEmployeeId;
        private int? _editAssignmentId;
        private bool IsEditMode { get { return _editEmployeeId.HasValue; } }

        // Existing no-argument constructor remains unchanged for Add mode.
        public EmployeeForm(int employeeId, int assignmentId) : this()
        {
            if (employeeId <= 0 || assignmentId <= 0)
                throw new ArgumentOutOfRangeException("Employee and assignment IDs must be positive.");
            _editEmployeeId = employeeId;
            _editAssignmentId = assignmentId;
            Text = "Edit Employee";
            btnSave.Text = "Save Changes";
            btnAddAssignment.Enabled = true;
        }

        // Call this AFTER LoadCompanies() and LoadPositions() in EmployeeForm_Load.
        private void LoadEmployeeForEdit()
        {
            if (!IsEditMode) return;
            if (!UserSession.CompanyId.HasValue)
                throw new InvalidOperationException("Select a company before editing.");

            DataRow r = new EmployeeRepository().GetForEdit(
                _editEmployeeId.Value, _editAssignmentId.Value,
                UserSession.CompanyId.Value);

            txtEmployeeNo.Text = S(r, "EmployeeNo");
            txtFirstName.Text = S(r, "FirstName");
            txtMiddleName.Text = S(r, "MiddleName");
            txtLastName.Text = S(r, "LastName");
            cmbSuffix.Text = String.IsNullOrEmpty(S(r, "Suffix")) ? "None" : S(r, "Suffix");
            txtPreferredName.Text = S(r, "PreferredName");
            SetDate(dtpBirthDate, r, "BirthDate");
            cmbGender.SelectedItem = S(r, "Gender");
            cmbCivilStatus.SelectedItem = S(r, "CivilStatus");
            chkIsActive.Checked = B(r, "IsActive");

            txtEmail.Text = S(r, "Email");
            txtMobileNumber.Text = S(r, "MobileNumber");
            txtTelephoneNumber.Text = S(r, "TelephoneNumber");
            txtAddressLine1.Text = S(r, "AddressLine1");
            txtAddressLine2.Text = S(r, "AddressLine2");
            txtBarangay.Text = S(r, "Barangay");
            txtCity.Text = S(r, "City");
            txtProvince.Text = S(r, "Province");
            txtPostalCode.Text = S(r, "PostalCode");
            cmbCountry.Text = S(r, "Country");
            txtEmergencyContactName.Text = S(r, "EmergencyContactName");
            cmbEmergencyRelationship.Text = S(r, "EmergencyContactRelationship");
            txtEmergencyContactNumber.Text = S(r, "EmergencyContactNumber");

            cmbCompany.SelectedValue = Convert.ToInt32(r["CompanyId"]);
            cmbDepartment.SelectedValue = Convert.ToInt32(r["DepartmentId"]);
            cmbPosition.SelectedValue = Convert.ToInt32(r["PositionId"]);
            cmbManager.SelectedIndex = -1;
            if (r["ManagerAssignmentId"] != DBNull.Value)
                cmbManager.SelectedValue = Convert.ToInt32(r["ManagerAssignmentId"]);
            txtCompanyEmployeeNo.Text = S(r, "CompanyEmployeeNo");
            cmbEmploymentType.SelectedItem = S(r, "EmploymentType");
            cmbEmploymentStatus.SelectedItem = S(r, "EmploymentStatus");
            SetDate(dtpDateHired, r, "DateHired");
            SetDate(dtpRegularizationDate, r, "RegularizationDate");
            SetDate(dtpContractEndDate, r, "ContractEndDate");
            SetDate(dtpEffectiveFrom, r, "EffectiveFrom");
            SetDate(dtpEffectiveTo, r, "EffectiveTo");
            txtWorkLocation.Text = S(r, "WorkLocation");
            txtCostCenter.Text = S(r, "CostCenter");
            chkIsPrimary.Checked = B(r, "IsPrimary");
        }

        private static string S(DataRow r, string name)
        {
            return r[name] == DBNull.Value ? "" : Convert.ToString(r[name]);
        }
        private static bool B(DataRow r, string name)
        {
            return r[name] != DBNull.Value && Convert.ToBoolean(r[name]);
        }
        private static void SetDate(DateTimePicker p, DataRow r, string name)
        {
            if (r[name] == DBNull.Value)
            {
                if (p.ShowCheckBox) p.Checked = false;
                return;
            }
            p.Value = Convert.ToDateTime(r[name]);
            if (p.ShowCheckBox) p.Checked = true;
        }
    }
}
