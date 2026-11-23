using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Leave
{
    public partial class LeaveManagementControl : UserControl
    {
        private readonly bool canReview;

        public LeaveManagementControl()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            try
            {
                if (!UserSession.CompanyId.HasValue)
                    throw new InvalidOperationException("Select a company before opening Leave Management.");

                canReview = CanReviewLeave();
                btnApprove.Visible = canReview;
                btnReject.Visible = canReview;

                if (!canReview)
                {
                    tabs.TabPages.Remove(tabLeaveTypes);
                    tabs.TabPages.Remove(tabLeaveBalances);
                }

                WireEvents();
                LoadAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Leave Management could not load. Verify that the shared annual leave balance database migration has been installed.\r\n\r\n" + ex.Message,
                    "Leave Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static void EnsureLeavePermission()
        {
            if (!UserSession.CompanyId.HasValue ||
                UserSession.CompanyId.Value <= 0)
            {
                throw new UnauthorizedAccessException(
                    "No valid company is selected.");
            }

            if (!PermissionService.HasPermissionForCompany(
                PermissionCodes.LeaveManagement,
                UserSession.CompanyId.Value))
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to manage leave for this company.");
            }
        }

        private void EnsureReviewPermission()
        {
            EnsureLeavePermission();

            if (!canReview)
            {
                throw new UnauthorizedAccessException(
                    "You do not have permission to review leave requests.");
            }
        }
        private void EnsureRequestAccess()
        {
            if (!UserSession.CompanyId.HasValue ||
                UserSession.CompanyId.Value <= 0)
            {
                throw new UnauthorizedAccessException(
                    "No valid company is selected.");
            }

            if (canReview)
            {
                EnsureReviewPermission();
                return;
            }

            if (!UserSession.EmployeeId.HasValue ||
                UserSession.EmployeeId.Value <= 0)
            {
                throw new UnauthorizedAccessException(
                    "Your account is not linked to an employee record.");
            }
        }
        private void WireEvents()
        {
            btnNewRequest.Click += (s, e) => RunSafe(() => CreateRequest());
            btnRefreshRequests.Click += (s, e) => RunSafe(() => LoadRequests());
            btnApprove.Click += (s, e) => RunSafe(() => ReviewSelected("APPROVED"));
            btnReject.Click += (s, e) => RunSafe(() => ReviewSelected("REJECTED"));
            btnAddLeaveType.Click += (s, e) => RunSafe(() => EditLeaveType(null));
            btnEditLeaveType.Click += (s, e) => RunSafe(() =>
            {
                if (dgvTypes.CurrentRow != null)
                    EditLeaveType(Convert.ToInt32(dgvTypes.CurrentRow.Cells["LeaveTypeId"].Value));
            });
            btnToggleLeaveType.Click += (s, e) => RunSafe(() => ToggleLeaveType());
            btnRefreshTypes.Click += (s, e) => RunSafe(() => LoadTypes());
            btnSetBalance.Click += (s, e) => RunSafe(() => EditBalance());
            btnRefreshBalances.Click += (s, e) => RunSafe(() => LoadBalances());
        }

        /* private bool CanReviewLeave()
         {
             if (!UserSession.CompanyId.HasValue || UserSession.UserId <= 0)
                 return false;

             const string sql = @"SELECT CASE WHEN EXISTS (
                 SELECT 1 FROM dbo.UserRole ur
                 INNER JOIN dbo.Role r ON r.RoleId = ur.RoleId
                 WHERE ur.UserId = @UserId
                   AND (ur.CompanyId = @CompanyId OR ur.CompanyId IS NULL)
                   AND ur.IsActive = 1 AND r.IsActive = 1
                   AND (r.RoleName LIKE '%ADMIN%' OR r.RoleName LIKE '%HR%' OR r.RoleName LIKE '%MANAGER%')
             ) THEN 1 ELSE 0 END";

             using (var con = DatabaseConnection.GetConnection())
             using (var cmd = new SqlCommand(sql, con))
             {
                 cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                 cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                 con.Open();
                 return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
             }
         }*/
        private bool CanReviewLeave()
        {
            if (!UserSession.CompanyId.HasValue || UserSession.UserId <= 0)
                return false;

            return PermissionService.HasPermissionForCompany(
                PermissionCodes.LeaveManagement,
                UserSession.CompanyId.Value);
        }
        private void RunSafe(Action action)
        {
            try { action(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Leave Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAll()
        {
            LoadRequests();
            if (canReview)
            {
                LoadTypes();
                LoadBalances();
            }
        }

        private void LoadRequests()
        {
            EnsureRequestAccess();
            const string sql = @"SELECT lr.LeaveRequestId, er.EmployeeNo,
                    er.LastName + ', ' + er.FirstName AS EmployeeName,
                    lt.LeaveName, lr.DateFrom, lr.DateTo, lr.DaysRequested,
                    lr.Status, lr.SubmittedAt, lr.Reason, lr.ReviewRemarks
                FROM dbo.LeaveRequest lr
                INNER JOIN dbo.EmployeeAssignment ea ON ea.AssignmentId = lr.AssignmentId
                INNER JOIN dbo.EmployeeRecord er ON er.EmployeeId = ea.EmployeeId
                INNER JOIN dbo.LeaveType lt ON lt.LeaveTypeId = lr.LeaveTypeId
                WHERE ea.CompanyId = @CompanyId
                  AND (@CanReview = 1 OR er.EmployeeId = @EmployeeId)
                ORDER BY CASE lr.Status WHEN 'PENDING' THEN 0 ELSE 1 END, lr.SubmittedAt DESC";

            var dt = new DataTable();
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                cmd.Parameters.Add("@CanReview", SqlDbType.Bit).Value = canReview;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = (object)UserSession.EmployeeId ?? DBNull.Value;
                da.Fill(dt);
            }

            dgvRequests.DataSource = dt;
            HideColumn(dgvRequests, "LeaveRequestId");
            if (dgvRequests.Columns.Contains("Reason")) dgvRequests.Columns["Reason"].Visible = false;
            if (dgvRequests.Columns.Contains("ReviewRemarks")) dgvRequests.Columns["ReviewRemarks"].HeaderText = "Review Remarks";
            if (dgvRequests.Columns.Contains("EmployeeName")) dgvRequests.Columns["EmployeeName"].HeaderText = "Employee";
            if (dgvRequests.Columns.Contains("DateFrom")) dgvRequests.Columns["DateFrom"].HeaderText = "From";
            if (dgvRequests.Columns.Contains("DateTo")) dgvRequests.Columns["DateTo"].HeaderText = "To";
            if (dgvRequests.Columns.Contains("DaysRequested")) dgvRequests.Columns["DaysRequested"].HeaderText = "Days";
        }

        private void LoadTypes()
        {
            EnsureReviewPermission();
            const string sql = @"SELECT LeaveTypeId, LeaveCode, LeaveName, IsPaid, RequiresApproval, IsActive
                FROM dbo.LeaveType WHERE CompanyId = @CompanyId ORDER BY LeaveName";

            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                var dt = new DataTable();
                da.Fill(dt);
                dgvTypes.DataSource = dt;
            }
            HideColumn(dgvTypes, "LeaveTypeId");
        }

        private void LoadBalances()
        {
            EnsureReviewPermission();
            int companyId = UserSession.CompanyId.Value;
            int leaveYear = DateTime.Today.Year;

            // Create the current year's shared 5-day balance once for each employee
            // who has an active assignment in the selected company.
            const string ensureSql = @"INSERT INTO dbo.LeaveBalance
                    (EmployeeId, LeaveYear, EntitledDays, CarriedForwardDays, AdjustmentDays, CreatedAt)
                SELECT DISTINCT er.EmployeeId, @LeaveYear, 5.00, 0.00, 0.00, SYSDATETIME()
                FROM dbo.EmployeeRecord er
                INNER JOIN dbo.EmployeeAssignment ea ON ea.EmployeeId = er.EmployeeId
                WHERE ea.CompanyId = @CompanyId
                  AND er.IsActive = 1
                  AND (ea.EffectiveTo IS NULL OR ea.EffectiveTo >= CONVERT(date, GETDATE()))
                  AND NOT EXISTS (
                      SELECT 1 FROM dbo.LeaveBalance lb WITH (UPDLOCK, HOLDLOCK)
                      WHERE lb.EmployeeId = er.EmployeeId AND lb.LeaveYear = @LeaveYear
                  )";

            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                using (var cmd = new SqlCommand(ensureSql, con, tx))
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                    cmd.Parameters.Add("@LeaveYear", SqlDbType.Int).Value = leaveYear;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                }
            }

            const string sql = @"SELECT lb.LeaveBalanceId, er.EmployeeNo,
                    er.LastName + ', ' + er.FirstName AS EmployeeName,
                    lb.LeaveYear, lb.EntitledDays, lb.CarriedForwardDays, lb.AdjustmentDays,
                    ISNULL(leaveUsage.ApprovedDays, 0) AS UsedDays,
                    ISNULL(leaveUsage.PendingDays, 0) AS PendingDays,
                    (lb.EntitledDays + lb.CarriedForwardDays + lb.AdjustmentDays
                        - ISNULL(leaveUsage.ApprovedDays, 0) - ISNULL(leaveUsage.PendingDays, 0)) AS RemainingDays
                FROM dbo.LeaveBalance lb
                INNER JOIN dbo.EmployeeRecord er ON er.EmployeeId = lb.EmployeeId
                OUTER APPLY (
                    SELECT SUM(CASE WHEN lr.Status = 'APPROVED' THEN lr.DaysRequested ELSE 0 END) AS ApprovedDays,
                           SUM(CASE WHEN lr.Status = 'PENDING' THEN lr.DaysRequested ELSE 0 END) AS PendingDays
                    FROM dbo.LeaveRequest lr
                    INNER JOIN dbo.EmployeeAssignment ea2 ON ea2.AssignmentId = lr.AssignmentId
                    WHERE ea2.EmployeeId = lb.EmployeeId
                      AND YEAR(lr.DateFrom) = lb.LeaveYear
                      AND lr.Status IN ('APPROVED', 'PENDING')
                ) leaveUsage
                WHERE EXISTS (
                    SELECT 1 FROM dbo.EmployeeAssignment ea
                    WHERE ea.EmployeeId = lb.EmployeeId AND ea.CompanyId = @CompanyId
                )
                ORDER BY er.LastName, er.FirstName, lb.LeaveYear DESC";

            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                var dt = new DataTable();
                da.Fill(dt);
                dgvBalances.DataSource = dt;
            }

            HideColumn(dgvBalances, "LeaveBalanceId");
            if (dgvBalances.Columns.Contains("EmployeeName")) dgvBalances.Columns["EmployeeName"].HeaderText = "Employee";
            if (dgvBalances.Columns.Contains("UsedDays")) dgvBalances.Columns["UsedDays"].HeaderText = "Approved Used";
            if (dgvBalances.Columns.Contains("PendingDays")) dgvBalances.Columns["PendingDays"].HeaderText = "Pending";
            if (dgvBalances.Columns.Contains("RemainingDays")) dgvBalances.Columns["RemainingDays"].HeaderText = "Available Balance";
        }

        private void CreateRequest()
        {
            EnsureRequestAccess();
            using (var dialog = new LeaveRequestDialog(canReview, UserSession.EmployeeId, UserSession.CompanyId.Value))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                    return;

                using (var con = DatabaseConnection.GetConnection())
                {
                    con.Open();
                    using (var tx = con.BeginTransaction(IsolationLevel.Serializable))
                    {
                        try
                        {
                            int employeeId = GetEmployeeIdForAssignment(con, tx, dialog.AssignmentId);
                            if (!canReview && (!UserSession.EmployeeId.HasValue || employeeId != UserSession.EmployeeId.Value))
                            {
                                throw new UnauthorizedAccessException(
                                    "You can only submit leave requests for your own employee record.");
                            }
                            EnsureAnnualBalance(con, tx, employeeId, dialog.DateFrom.Year);

                            using (var overlap = new SqlCommand(@"SELECT COUNT(1)
                                FROM dbo.LeaveRequest lr
                                INNER JOIN dbo.EmployeeAssignment ea ON ea.AssignmentId = lr.AssignmentId
                                WHERE ea.EmployeeId = @EmployeeId
                                  AND lr.Status IN ('PENDING', 'APPROVED')
                                  AND lr.DateFrom <= @DateTo AND lr.DateTo >= @DateFrom", con, tx))
                            {
                                overlap.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                                overlap.Parameters.Add("@DateFrom", SqlDbType.Date).Value = dialog.DateFrom;
                                overlap.Parameters.Add("@DateTo", SqlDbType.Date).Value = dialog.DateTo;
                                if (Convert.ToInt32(overlap.ExecuteScalar()) > 0)
                                    throw new InvalidOperationException("This employee already has a pending or approved leave request that overlaps these dates, including in another subsidiary.");
                            }

                            bool requiresApproval;
                            using (var typeCheck = new SqlCommand(@"SELECT RequiresApproval FROM dbo.LeaveType
                                WHERE LeaveTypeId = @TypeId AND CompanyId = @CompanyId AND IsActive = 1", con, tx))
                            {
                                typeCheck.Parameters.Add("@TypeId", SqlDbType.Int).Value = dialog.LeaveTypeId;
                                typeCheck.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                                object value = typeCheck.ExecuteScalar();
                                if (value == null || value == DBNull.Value)
                                    throw new InvalidOperationException("The selected leave type is no longer available for this company.");
                                requiresApproval = Convert.ToBoolean(value);
                            }

                            decimal totalEntitlement;
                            decimal reservedDays;
                            using (var balanceCheck = new SqlCommand(@"SELECT
                                    lb.EntitledDays + lb.CarriedForwardDays + lb.AdjustmentDays,
                                    ISNULL((SELECT SUM(lr.DaysRequested)
                                        FROM dbo.LeaveRequest lr
                                        INNER JOIN dbo.EmployeeAssignment ea ON ea.AssignmentId = lr.AssignmentId
                                        WHERE ea.EmployeeId = lb.EmployeeId
                                          AND YEAR(lr.DateFrom) = lb.LeaveYear
                                          AND lr.Status IN ('PENDING', 'APPROVED')), 0)
                                FROM dbo.LeaveBalance lb WITH (UPDLOCK, HOLDLOCK)
                                WHERE lb.EmployeeId = @EmployeeId AND lb.LeaveYear = @LeaveYear", con, tx))
                            {
                                balanceCheck.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                                balanceCheck.Parameters.Add("@LeaveYear", SqlDbType.Int).Value = dialog.DateFrom.Year;
                                using (var reader = balanceCheck.ExecuteReader())
                                {
                                    if (!reader.Read())
                                        throw new InvalidOperationException("The employee's annual leave balance could not be initialized.");
                                    totalEntitlement = Convert.ToDecimal(reader.GetValue(0));
                                    reservedDays = Convert.ToDecimal(reader.GetValue(1));
                                }
                            }

                            if (totalEntitlement - reservedDays < dialog.DaysRequested)
                                throw new InvalidOperationException("Insufficient shared annual leave balance. The employee has " +
                                    Math.Max(0M, totalEntitlement - reservedDays).ToString("0.00") + " day(s) available across all leave types and subsidiaries.");

                            string status = requiresApproval ? "PENDING" : "APPROVED";
                            using (var insert = new SqlCommand(@"INSERT INTO dbo.LeaveRequest
                                (AssignmentId, LeaveTypeId, DateFrom, DateTo, DaysRequested, Reason, Status,
                                 SubmittedByUserId, ReviewedByUserId, ReviewedAt, ReviewRemarks)
                                VALUES
                                (@AssignmentId, @LeaveTypeId, @DateFrom, @DateTo, @DaysRequested, @Reason, @Status,
                                 @UserId,
                                 CASE WHEN @Status = 'APPROVED' THEN @UserId ELSE NULL END,
                                 CASE WHEN @Status = 'APPROVED' THEN SYSDATETIME() ELSE NULL END,
                                 CASE WHEN @Status = 'APPROVED' THEN N'Automatically approved; approval is not required for this leave type.' ELSE NULL END)", con, tx))
                            {
                                insert.Parameters.Add("@AssignmentId", SqlDbType.Int).Value = dialog.AssignmentId;
                                insert.Parameters.Add("@LeaveTypeId", SqlDbType.Int).Value = dialog.LeaveTypeId;
                                insert.Parameters.Add("@DateFrom", SqlDbType.Date).Value = dialog.DateFrom;
                                insert.Parameters.Add("@DateTo", SqlDbType.Date).Value = dialog.DateTo;
                                AddDecimal(insert, "@DaysRequested", dialog.DaysRequested);
                                insert.Parameters.Add("@Reason", SqlDbType.NVarChar, 1000).Value = dialog.Reason;
                                insert.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = status;
                                insert.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                                insert.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }
            }

            LoadRequests();
            if (canReview) LoadBalances();
            MessageBox.Show("Leave request submitted successfully.", "Leave Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static int GetEmployeeIdForAssignment(SqlConnection con, SqlTransaction tx, int assignmentId)
        {
            using (var cmd = new SqlCommand(@"SELECT EmployeeId FROM dbo.EmployeeAssignment
                WHERE AssignmentId = @AssignmentId AND CompanyId = @CompanyId
                  AND (EffectiveTo IS NULL OR EffectiveTo >= CONVERT(date, GETDATE()))", con, tx))
            {
                cmd.Parameters.Add("@AssignmentId", SqlDbType.Int).Value = assignmentId;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                object value = cmd.ExecuteScalar();
                if (value == null || value == DBNull.Value)
                    throw new InvalidOperationException("The selected employee assignment is no longer active in this company.");
                return Convert.ToInt32(value);
            }
        }

        private static void EnsureAnnualBalance(SqlConnection con, SqlTransaction tx, int employeeId, int leaveYear)
        {
            using (var cmd = new SqlCommand(@"IF NOT EXISTS (
                    SELECT 1 FROM dbo.LeaveBalance WITH (UPDLOCK, HOLDLOCK)
                    WHERE EmployeeId = @EmployeeId AND LeaveYear = @LeaveYear
                )
                INSERT INTO dbo.LeaveBalance
                    (EmployeeId, LeaveYear, EntitledDays, CarriedForwardDays, AdjustmentDays, CreatedAt)
                VALUES (@EmployeeId, @LeaveYear, 5.00, 0.00, 0.00, SYSDATETIME())", con, tx))
            {
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@LeaveYear", SqlDbType.Int).Value = leaveYear;
                cmd.ExecuteNonQuery();
            }
        }

        private void ReviewSelected(string newStatus)
        {
            EnsureReviewPermission();

            if (dgvRequests.CurrentRow == null)
                return;

            int requestId = Convert.ToInt32(dgvRequests.CurrentRow.Cells["LeaveRequestId"].Value);
            string currentStatus = Convert.ToString(dgvRequests.CurrentRow.Cells["Status"].Value);
            if (currentStatus != "PENDING")
            {
                MessageBox.Show("Only pending requests can be reviewed.");
                return;
            }

            string remarks = "";
            if (newStatus == "REJECTED")
            {
                remarks = PromptText("Enter the reason for rejection:", "Reject Leave Request");
                if (remarks == null) return;
                if (remarks.Trim().Length == 0)
                {
                    MessageBox.Show("Please enter a rejection reason.");
                    return;
                }
            }

            using (var con = DatabaseConnection.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        if (newStatus == "APPROVED")
                        {
                            const string balanceSql = @"SELECT er.EmployeeId, YEAR(lr.DateFrom) AS LeaveYear,                    
                                    lb.EntitledDays + lb.CarriedForwardDays + lb.AdjustmentDays AS TotalDays,
                                    ISNULL((SELECT SUM(x.DaysRequested)
                                        FROM dbo.LeaveRequest x
                                        INNER JOIN dbo.EmployeeAssignment xea ON xea.AssignmentId = x.AssignmentId
                                        WHERE xea.EmployeeId = er.EmployeeId
                                          AND YEAR(x.DateFrom) = YEAR(lr.DateFrom)
                                          AND x.Status IN ('PENDING', 'APPROVED')), 0) AS ReservedDays
                                FROM dbo.LeaveRequest lr
                                INNER JOIN dbo.EmployeeAssignment ea ON ea.AssignmentId = lr.AssignmentId
                                INNER JOIN dbo.EmployeeRecord er ON er.EmployeeId = ea.EmployeeId
                                INNER JOIN dbo.LeaveBalance lb WITH (UPDLOCK, HOLDLOCK)
                                    ON lb.EmployeeId = er.EmployeeId AND lb.LeaveYear = YEAR(lr.DateFrom)
                                WHERE lr.LeaveRequestId = @Id
                                  AND lr.Status = 'PENDING'
                                  AND ea.CompanyId = @CompanyId";

                            using (var check = new SqlCommand(balanceSql, con, tx))
                            {
                                check.Parameters.Add("@Id", SqlDbType.Int).Value = requestId;
                                check.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                                using (var reader = check.ExecuteReader())
                                {
                                    if (!reader.Read())
                                        throw new InvalidOperationException("This request is no longer pending or its annual balance is missing.");
                                    decimal total = Convert.ToDecimal(reader["TotalDays"]);
                                    decimal reserved = Convert.ToDecimal(reader["ReservedDays"]);
                                    if (reserved > total)
                                        throw new InvalidOperationException("This request cannot be approved because the employee's shared annual leave balance is no longer sufficient. Review other pending requests or adjust the balance.");
                                }
                            }
                        }

                        using (var update = new SqlCommand(@"UPDATE dbo.LeaveRequest
                            SET Status = @Status,
                                ReviewedByUserId = @UserId,
                                ReviewedAt = SYSDATETIME(),
                                ReviewRemarks = @Remarks
                            WHERE LeaveRequestId = @Id
                              AND Status = 'PENDING'
                              AND EXISTS
                              (
                                  SELECT 1
                                  FROM dbo.EmployeeAssignment ea
                                  WHERE ea.AssignmentId = dbo.LeaveRequest.AssignmentId
                                    AND ea.CompanyId = @CompanyId
                              )", con, tx))
                        {
                            update.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = newStatus;
                            update.Parameters.Add("@UserId", SqlDbType.Int).Value = UserSession.UserId;
                            update.Parameters.Add("@Remarks", SqlDbType.NVarChar, 1000).Value =
                                string.IsNullOrWhiteSpace(remarks) ? (object)DBNull.Value : remarks.Trim();
                            update.Parameters.Add("@Id", SqlDbType.Int).Value = requestId;
                            if (update.ExecuteNonQuery() != 1)
                                throw new InvalidOperationException("The request could not be updated. Refresh and try again.");
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            LoadRequests();
            LoadBalances();
            MessageBox.Show("Leave request " + newStatus.ToLowerInvariant() + ".", "Leave Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditLeaveType(int? id)
        {
            EnsureReviewPermission();
            string code = "", name = "";
            bool paid = true, approval = true;
            if (id.HasValue)
            {
                using (var con = DatabaseConnection.GetConnection())
                using (var cmd = new SqlCommand(@"SELECT LeaveCode, LeaveName, IsPaid, RequiresApproval
                    FROM dbo.LeaveType WHERE LeaveTypeId = @Id AND CompanyId = @CompanyId", con))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id.Value;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return;
                        code = Convert.ToString(reader[0]);
                        name = Convert.ToString(reader[1]);
                        paid = Convert.ToBoolean(reader[2]);
                        approval = Convert.ToBoolean(reader[3]);
                    }
                }
            }

            using (var dialog = new LeaveTypeDialog(code, name, paid, approval))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK) return;
                using (var con = DatabaseConnection.GetConnection())
                using (var cmd = new SqlCommand(id.HasValue
                    ? @"UPDATE dbo.LeaveType SET LeaveCode = @Code, LeaveName = @Name, IsPaid = @Paid,
                        RequiresApproval = @Approval, UpdatedAt = SYSDATETIME()
                        WHERE LeaveTypeId = @Id AND CompanyId = @CompanyId"
                    : @"INSERT INTO dbo.LeaveType(CompanyId, LeaveCode, LeaveName, IsPaid, RequiresApproval)
                        VALUES(@CompanyId, @Code, @Name, @Paid, @Approval)", con))
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                    cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 30).Value = dialog.Code;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = dialog.LeaveName;
                    cmd.Parameters.Add("@Paid", SqlDbType.Bit).Value = dialog.IsPaid;
                    cmd.Parameters.Add("@Approval", SqlDbType.Bit).Value = dialog.RequiresApproval;
                    if (id.HasValue) cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id.Value;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Could not save the leave type. Check that its code is not already in use.\r\n\r\n" + ex.Message);
                        return;
                    }
                }
            }
            LoadTypes();
        }

        private void ToggleLeaveType()
        {
            EnsureReviewPermission();
            if (dgvTypes.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvTypes.CurrentRow.Cells["LeaveTypeId"].Value);
            using (var con = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(@"UPDATE dbo.LeaveType
                SET IsActive = CASE WHEN IsActive = 1 THEN 0 ELSE 1 END, UpdatedAt = SYSDATETIME()
                WHERE LeaveTypeId = @Id AND CompanyId = @CompanyId", con))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = UserSession.CompanyId.Value;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadTypes();
        }

        private void EditBalance()
        {
            EnsureReviewPermission();

            using (var dialog = new LeaveBalanceDialog(UserSession.CompanyId.Value))
            {
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK) return;
                using (var con = DatabaseConnection.GetConnection())
                {
                    con.Open();

                    using (var tx = con.BeginTransaction(IsolationLevel.Serializable))

                    using (var cmd = new SqlCommand(@"IF EXISTS (
                            SELECT 1 FROM dbo.LeaveBalance WITH (UPDLOCK, HOLDLOCK)
                            WHERE EmployeeId = @EmployeeId AND LeaveYear = @Year
                        )
                        UPDATE dbo.LeaveBalance
                        SET EntitledDays = @Entitled, CarriedForwardDays = @Carry,
                            AdjustmentDays = @Adjustment, UpdatedAt = SYSDATETIME()
                        WHERE EmployeeId = @EmployeeId AND LeaveYear = @Year
                        ELSE
                        INSERT INTO dbo.LeaveBalance
                            (EmployeeId, LeaveYear, EntitledDays, CarriedForwardDays, AdjustmentDays, CreatedAt)
                        VALUES (@EmployeeId, @Year, @Entitled, @Carry, @Adjustment, SYSDATETIME())", con, tx))
                    {
                        cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = dialog.EmployeeId;
                        cmd.Parameters.Add("@Year", SqlDbType.Int).Value = dialog.LeaveYear;
                        AddDecimal(cmd, "@Entitled", dialog.EntitledDays);
                        AddDecimal(cmd, "@Carry", dialog.CarriedForwardDays);
                        AddDecimal(cmd, "@Adjustment", dialog.AdjustmentDays);
                        using (var verify = new SqlCommand(@"
                        SELECT COUNT(1)
                        FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK)
                        WHERE EmployeeId = @EmployeeId
                          AND CompanyId = @CompanyId
                          AND (EffectiveTo IS NULL OR EffectiveTo >= CONVERT(date, GETDATE()))",
                        con, tx))
                        {
                            verify.Parameters.Add("@EmployeeId", SqlDbType.Int).Value =
                                dialog.EmployeeId;

                            verify.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                                UserSession.CompanyId.Value;

                            if (Convert.ToInt32(verify.ExecuteScalar()) == 0)
                            {
                                throw new UnauthorizedAccessException(
                                    "The selected employee does not have an active assignment in this company.");
                            }
                        }
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                }
            }
            LoadBalances();
        }

        private static void AddDecimal(SqlCommand cmd, string name, decimal value)
        {
            var parameter = cmd.Parameters.Add(name, SqlDbType.Decimal);
            parameter.Precision = 8;
            parameter.Scale = 2;
            parameter.Value = value;
        }

        private static string PromptText(string message, string title)
        {
            using (var form = new Form
            {
                Text = title, Width = 440, Height = 190,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false, MinimizeBox = false
            })
            {
                var label = new Label { Text = message, Left = 14, Top = 14, Width = 390 };
                var input = new TextBox { Left = 14, Top = 42, Width = 390 };
                var ok = new Button { Text = "Continue", Left = 224, Top = 82, Width = 85, DialogResult = DialogResult.OK };
                var cancel = new Button { Text = "Cancel", Left = 319, Top = 82, Width = 85, DialogResult = DialogResult.Cancel };
                form.Controls.AddRange(new Control[] { label, input, ok, cancel });
                form.AcceptButton = ok;
                form.CancelButton = cancel;
                return form.ShowDialog() == DialogResult.OK ? input.Text : null;
            }
        }

        private static void HideColumn(DataGridView grid, string name)
        {
            if (grid.Columns.Contains(name)) grid.Columns[name].Visible = false;
        }
    }
}
