
using AO_HRIS.Data;
using AO_HRIS.Forms.Main;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;
            lblStatus.Text = "";
            this.AcceptButton = btnLogin;
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrEmpty(password))
            {
                lblStatus.Text =
                    "Please enter your username and password.";
                return;
            }

            btnLogin.Enabled = false;
            lblStatus.Text = "";

            try
            {
                using (SqlConnection conn =
                    DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    int userId;
                    int? employeeId;
                    string storedHash;
                    bool isActive;
                    bool isLocked;

                    string query = @"
                    SELECT
                        UserId,
                        EmployeeId,
                        PasswordHash,
                        IsActive,
                        IsLocked
                    FROM dbo.UserAccount
                    WHERE Username = @Username";

                    using (SqlCommand cmd =
                        new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(
                            "@Username",
                            SqlDbType.NVarChar, 100
                        ).Value = username;

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                lblStatus.Text =
                                    "Invalid username or password.";
                                return;
                            }

                            userId = reader.GetInt32(0);

                            employeeId = reader.IsDBNull(1)
                                ? (int?)null
                                : reader.GetInt32(1);

                            storedHash = reader.GetString(2);
                            isActive = reader.GetBoolean(3);
                            isLocked = reader.GetBoolean(4);
                        }
                    }

                    if (!isActive || isLocked)
                    {
                        lblStatus.Text =
                            "Account unavailable. Contact administrator.";
                        return;
                    }

                    if (!PasswordHelper.VerifyPassword(password, storedHash))
                    {
                        using (SqlCommand failed = new SqlCommand(@"UPDATE dbo.UserAccount
                            SET FailedLoginAttempts=FailedLoginAttempts+1,
                                IsLocked=CASE WHEN FailedLoginAttempts+1>=5 THEN 1 ELSE IsLocked END,
                                UpdatedAt=SYSUTCDATETIME()
                            WHERE UserId=@UserId AND IsActive=1 AND IsLocked=0", conn))
                        {
                            failed.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                            failed.ExecuteNonQuery();
                        }
                        lblStatus.Text = "Invalid username or password.";
                        return;
                    }

                    if (!employeeId.HasValue)
                    {
                        lblStatus.Text = "This account is not linked to an active employee.";
                        return;
                    }

                    // Every login must still belong to an active employee with at least
                    // one current assignment, including global administrators.
                    using (SqlCommand employment = new SqlCommand(@"SELECT COUNT(*)
                        FROM dbo.EmployeeRecord er JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                        WHERE er.EmployeeId=@EmployeeId AND er.IsActive=1 AND ea.EmploymentStatus='ACTIVE'
                          AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                          AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date))", conn))
                    {
                        employment.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId.Value;
                        if (Convert.ToInt32(employment.ExecuteScalar()) == 0)
                        {
                            lblStatus.Text = "No active employment assignment is associated with this account.";
                            return;
                        }
                    }

                    // Require an active company-scoped role plus a current assignment,
                    // or a global System Administrator role.
                    string roleQuery = @"
                         SELECT COUNT(*)
                         FROM dbo.UserRole ur
                         INNER JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                         WHERE ur.UserId=@UserId AND ur.IsActive=1 AND r.IsActive=1
                           AND (
                             (ur.CompanyId IS NOT NULL AND EXISTS(
                                SELECT 1 FROM dbo.EmployeeRecord er
                                JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId=er.EmployeeId
                                JOIN dbo.Company c ON c.CompanyId=ea.CompanyId
                                WHERE er.EmployeeId=@EmployeeId AND er.IsActive=1 AND c.IsActive=1
                                  AND ea.CompanyId=ur.CompanyId AND ea.EmploymentStatus='ACTIVE'
                                  AND ea.EffectiveFrom<=CAST(GETDATE() AS date)
                                  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS date))))
                             OR (ur.CompanyId IS NULL AND UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(r.RoleCode,''),r.RoleName),'_',''),'-',''),' ',''))='SYSTEMADMIN')
                           )";

                    using (SqlCommand cmd =
                        new SqlCommand(roleQuery, conn))
                    {
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                        cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId.Value;

                        int roleCount =
                            (int)cmd.ExecuteScalar();

                        if (roleCount == 0)
                        {
                            lblStatus.Text =
                                "No active role assigned.";
                            return;
                        }
                    }

                    string updateQuery = @"
                         UPDATE dbo.UserAccount
                         SET LastLoginAt = SYSUTCDATETIME(),
                             FailedLoginAttempts = 0
                         WHERE UserId = @UserId
                           AND IsActive = 1
                           AND IsLocked = 0";

                    using (SqlCommand cmd =
                        new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.Add(
                            "@UserId", SqlDbType.Int
                        ).Value = userId;

                        if (cmd.ExecuteNonQuery() != 1)
                        {
                            lblStatus.Text =
                                "Account unavailable.";
                            return;
                        }
                    }

                    UserSession.SetSession(
                        userId, employeeId, username);

                    using (CompanySelectionForm companySelection = new CompanySelectionForm())
                    {
                        this.Hide();
                        companySelection.ShowDialog();
                    }

                    // Reset session after returning from company selection.
                    UserSession.Clear();

                    // Return to the login screen instead of closing the application.
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();

                    txtPassword.Clear();
                    txtUsername.Focus();
                    lblStatus.Text = "";
                }
            }
            catch (SqlException)
            {
                lblStatus.Text =
                    "Database connection or query failed.";
            }
            catch (Exception)
            {
                lblStatus.Text =
                    "Unable to sign in. Contact administrator.";
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void chkShowPassword_CheckedChanged(
            object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        //test connection 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn =
                    DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    MessageBox.Show(
                        "Connected successfully to AO_HRIS!",
                        "Database Connection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
