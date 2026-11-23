using System;
using System.Windows.Forms;
using AO_HRIS.Security;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace AO_HRIS.Forms.Employees
{
    public partial class EmployeeForm
    {
        // Call WireSaveButton() once in the EmployeeForm constructor, after InitializeComponent().
        private void WireSaveButton()
        {
            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;
        }

        private static string Selected(ComboBox combo)
        {
            return combo.SelectedIndex < 0 ? null : combo.Text.Trim();
        }

        private static int? SelectedId(ComboBox combo)
        {
            return combo.SelectedValue is int ? (int?)((int)combo.SelectedValue) : null;
        }

        private static DateTime? OptionalDate(DateTimePicker picker)
        {
            return picker.Checked ? (DateTime?)picker.Value.Date : null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtFirstName.Text) ||
                String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                tabEmployee.SelectedTab = tabPersonal;
                MessageBox.Show("First name and last name are required.");
                return;
            }

            int? companyId = SelectedId(cmbCompany);
            int? departmentId = SelectedId(cmbDepartment);

            string positionName = cmbPosition.Text.Trim();

            // Only use PositionId if the displayed text still matches
            // the actual selected item.
            int positionId = 0;

            if (cmbPosition.SelectedIndex >= 0)
            {
                string selectedPositionText =
                    cmbPosition.GetItemText(cmbPosition.SelectedItem).Trim();

                if (String.Equals(
                    positionName,
                    selectedPositionText,
                    StringComparison.OrdinalIgnoreCase))
                {
                    int? selectedPositionId = SelectedId(cmbPosition);

                    if (selectedPositionId.HasValue)
                        positionId = selectedPositionId.Value;
                }
            }

            if (!companyId.HasValue || !departmentId.HasValue ||
                String.IsNullOrWhiteSpace(positionName))
            {
                tabEmployee.SelectedTab = tabEmployment;
                MessageBox.Show("Company, department and position are required.");
                return;
            }

            if (positionName.Length > 400)
            {
                tabEmployee.SelectedTab = tabEmployment;
                MessageBox.Show("Position name cannot exceed 400 characters.");
                return;
            }

            if (!UserSession.CompanyId.HasValue ||
                companyId.Value != UserSession.CompanyId.Value)
            {
                MessageBox.Show("The selected company is not authorized.");
                return;
            }

            if (cmbEmploymentType.SelectedIndex < 0 ||
                cmbEmploymentStatus.SelectedIndex < 0)
            {
                tabEmployee.SelectedTab = tabEmployment;
                MessageBox.Show("Employment type and status are required.");
                return;
            }

            if (dtpEffectiveFrom.Value.Date < dtpDateHired.Value.Date ||
                (dtpEffectiveTo.Checked &&
                 dtpEffectiveTo.Value.Date < dtpEffectiveFrom.Value.Date))
            {
                tabEmployee.SelectedTab = tabEmployment;
                MessageBox.Show("Please check the employment effective dates.");
                return;
            }
            if (!dtpBirthDate.Checked)
            {
                tabEmployee.SelectedTab = tabPersonal;
                MessageBox.Show("Birth date is required.");
                dtpBirthDate.Focus();
                return;
            }
            EmployeeRegistration employee = new EmployeeRegistration
            {
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,

                Suffix = Selected(cmbSuffix),
                PreferredName = txtPreferredName.Text,
                //Previous: not requireing birthDdate
                /*BirthDate = dtpBirthDate.Checked || !dtpBirthDate.ShowCheckBox
                    ? (DateTime?)dtpBirthDate.Value.Date : null,*/
                BirthDate = GetBirthDateForSave(),
                Gender = Selected(cmbGender),
                CivilStatus = Selected(cmbCivilStatus),
                Email = txtEmail.Text,
                MobileNumber = txtMobileNumber.Text,
                TelephoneNumber = txtTelephoneNumber.Text,
                AddressLine1 = txtAddressLine1.Text,
                AddressLine2 = txtAddressLine2.Text,
                Barangay = txtBarangay.Text,
                City = txtCity.Text,
                Province = txtProvince.Text,
                PostalCode = txtPostalCode.Text,

                Country = Selected(cmbCountry),
                EmergencyContactName = txtEmergencyContactName.Text,
                EmergencyContactRelationship = Selected(cmbEmergencyRelationship),
                EmergencyContactNumber = txtEmergencyContactNumber.Text,
                IsActive = chkIsActive.Checked,

                CompanyId = companyId.Value,
                DepartmentId = departmentId.Value,
                PositionId = positionId,
                PositionName = positionName,

                ManagerAssignmentId = SelectedId(cmbManager),
                CompanyEmployeeNo = txtCompanyEmployeeNo.Text,
                EmploymentType = Selected(cmbEmploymentType),
                EmploymentStatus = Selected(cmbEmploymentStatus),
                DateHired = dtpDateHired.Value.Date,
                RegularizationDate = OptionalDate(dtpRegularizationDate),
                ContractEndDate = OptionalDate(dtpContractEndDate),
                EffectiveFrom = dtpEffectiveFrom.Value.Date,
                EffectiveTo = OptionalDate(dtpEffectiveTo),
                WorkLocation = txtWorkLocation.Text,
                CostCenter = txtCostCenter.Text,
                IsPrimary = chkIsPrimary.Checked
            };

            btnSave.Enabled = false;

            try
            {
                if (IsEditMode)
                {
                    new EmployeeRepository().Update(
                        _editEmployeeId.Value,
                        _editAssignmentId.Value,
                        companyId.Value,
                        employee);

                    MessageBox.Show(
                        "Employee changes saved successfully.",
                        "Update Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    string number = new EmployeeRepository().Create(employee);
                    txtEmployeeNo.Text = number;
                    MessageBox.Show(
                        "Employee registered successfully: " + number,
                        "Registration Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Save failed. No changes were saved.\n\n" + ex.Message,
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}