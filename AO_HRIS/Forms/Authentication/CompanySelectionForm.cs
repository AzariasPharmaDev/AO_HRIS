
using AO_HRIS.Data;
using AO_HRIS.Forms.Main;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AO_HRIS
{
    public partial class CompanySelectionForm : Form
    {
        public CompanySelectionForm()
        {
            InitializeComponent();
            LoadCompanies();
        }
        
        private void LoadCompanies()
        {
            flwCompanies.Controls.Clear();
            flwCompanies.FlowDirection = FlowDirection.TopDown;
            flwCompanies.WrapContents = false;
            flwCompanies.AutoScroll = true;

            string query = @"
                SELECT DISTINCT c.CompanyId,c.CompanyName,cl.LogoData
                FROM dbo.Company c
                LEFT JOIN dbo.CompanyLogo cl ON cl.CompanyId=c.CompanyId
                WHERE c.IsActive=1 AND EXISTS(
                    SELECT 1 FROM dbo.UserAccount ua
                    WHERE ua.UserId=@UserId AND ua.IsActive=1 AND ua.IsLocked=0
                      AND ua.EmployeeId IS NOT NULL
                      AND EXISTS(SELECT 1 FROM dbo.EmployeeRecord er WHERE er.EmployeeId=ua.EmployeeId AND er.IsActive=1)
                      AND EXISTS(SELECT 1 FROM dbo.EmployeeAssignment ea0 WHERE ea0.EmployeeId=ua.EmployeeId
                          AND ea0.EmploymentStatus='ACTIVE' AND ea0.EffectiveFrom<=CAST(GETDATE() AS DATE)
                          AND (ea0.EffectiveTo IS NULL OR ea0.EffectiveTo>=CAST(GETDATE() AS DATE)))
                      AND (
                        (EXISTS(SELECT 1 FROM dbo.EmployeeAssignment ea
                            WHERE ea.EmployeeId=ua.EmployeeId AND ea.CompanyId=c.CompanyId
                              AND ea.EmploymentStatus='ACTIVE' AND ea.EffectiveFrom<=CAST(GETDATE() AS DATE)
                              AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo>=CAST(GETDATE() AS DATE)))
                         AND EXISTS(SELECT 1 FROM dbo.UserRole ur JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                            WHERE ur.UserId=ua.UserId AND ur.CompanyId=c.CompanyId AND ur.IsActive=1 AND r.IsActive=1))
                        OR EXISTS(SELECT 1 FROM dbo.UserRole ur JOIN dbo.[Role] r ON r.RoleId=ur.RoleId
                            WHERE ur.UserId=ua.UserId AND ur.CompanyId IS NULL AND ur.IsActive=1 AND r.IsActive=1
                              AND UPPER(REPLACE(REPLACE(REPLACE(COALESCE(NULLIF(r.RoleCode,''),r.RoleName),'_',''),'-',''),' ',''))='SYSTEMADMIN')
                      )
                ) ORDER BY c.CompanyName";

            using (SqlConnection con =
                DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(
                    "@UserId", SqlDbType.Int
                ).Value = UserSession.UserId;

                DataTable dt = new DataTable();

                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                foreach (DataRow row in dt.Rows)
                {
                    int companyId =
                        Convert.ToInt32(row["CompanyId"]);

                    string companyName =
                        row["CompanyName"].ToString();

                    Panel companyPanel = new Panel
                    {
                        Width = flwCompanies.ClientSize.Width - 25,
                        Height = 180,
                        BackColor = Color.White,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = companyId
                    };

                    Button btnCompanyLogo = new Button
                    {
                        Name = "btnCompanyLogo",
                        Width = 120,
                        Height = 120,
                        Location = new Point(
                            (companyPanel.Width - 120) / 2, 10),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.White,
                        Cursor = Cursors.Hand,
                        TabStop = false,
                        Tag = companyId
                    };

                    btnCompanyLogo.FlatAppearance.BorderSize = 0;

                    if (row["LogoData"] != DBNull.Value)
                    {
                        byte[] logoData =
                            (byte[])row["LogoData"];

                        using (MemoryStream ms =
                            new MemoryStream(logoData))
                        using (Image image = Image.FromStream(ms))
                        {
                            btnCompanyLogo.BackgroundImage =
                                new Bitmap(image);

                            btnCompanyLogo.BackgroundImageLayout =
                                ImageLayout.Zoom;
                        }
                    }
                    else
                    {
                        btnCompanyLogo.Text = "No Logo";
                    }

                    Label lblCompany = new Label
                    {
                        Name = "lblCompany",
                        Text = companyName,
                        AutoSize = false,
                        Width = companyPanel.Width - 20,
                        Height = 35,
                        Location = new Point(10, 135),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(
                            "Segoe UI", 11, FontStyle.Bold),
                        ForeColor = Color.FromArgb(40, 40, 40),
                        Cursor = Cursors.Hand,
                        Tag = companyId
                    };

                    btnCompanyLogo.Click += Company_Click;
                    lblCompany.Click += Company_Click;

                    companyPanel.Controls.Add(btnCompanyLogo);
                    companyPanel.Controls.Add(lblCompany);

                    flwCompanies.Controls.Add(companyPanel);
                }
            }
        }

        private void Company_Click(object sender, EventArgs e)
        {
            Control selectedControl = sender as Control;

            if (selectedControl == null)
                return;

            int companyId =
                Convert.ToInt32(selectedControl.Tag);

            OpenMainForm(companyId);
        }

        private void OpenMainForm(int companyId)
        {
            UserSession.SetCompany(companyId);

            using (MainForm main = new MainForm())
            {
                this.Hide();
                main.ShowDialog();
            }

            this.Close();
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
