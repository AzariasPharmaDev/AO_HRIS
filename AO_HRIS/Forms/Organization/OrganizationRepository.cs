
using AO_HRIS.Data;
using AO_HRIS.Security;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AO_HRIS.Forms.Organization
{
    public class OrganizationRepository
    {
        private SqlConnection CreateConnection()
        {
            return DatabaseConnection.GetConnection();
        }

        // =========================================================
        // COMMON VALIDATION AND DATABASE HELPERS
        // =========================================================

        private int RequireCompanyId()
        {
            if (!UserSession.CompanyId.HasValue ||
                UserSession.CompanyId.Value <= 0)
            {
                throw new InvalidOperationException(
                    "No active company is selected. Please log in again.");
            }

            return UserSession.CompanyId.Value;
        }

        private void EnsureActiveCompany(int companyId)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
                SELECT COUNT(*)
                FROM dbo.Company
                WHERE CompanyId = @CompanyId
                  AND IsActive = 1;", connection))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    companyId;

                connection.Open();

                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    throw new InvalidOperationException(
                        "The active company does not exist or is inactive.");
                }
            }
        }

        private void EnsureDepartmentBelongsToCompany(
            int departmentId,
            int companyId)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
                SELECT COUNT(*)
                FROM dbo.Department d
                INNER JOIN dbo.Company c
                    ON c.CompanyId = d.CompanyId
                WHERE d.DepartmentId = @DepartmentId
                  AND d.CompanyId = @CompanyId
                  AND d.IsActive = 1
                  AND c.IsActive = 1;", connection))
            {
                command.Parameters.Add("@DepartmentId", SqlDbType.Int).Value =
                    departmentId;

                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    companyId;

                connection.Open();

                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    throw new InvalidOperationException(
                        "The selected department does not belong to the active company, " +
                        "or it is inactive.");
                }
            }
        }

        private void EnsurePositionLevelIsActive(int positionLevelId)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
                SELECT COUNT(*)
                FROM dbo.PositionLevel
                WHERE PositionLevelId = @PositionLevelId
                  AND IsActive = 1;", connection))
            {
                command.Parameters.Add("@PositionLevelId", SqlDbType.Int).Value =
                    positionLevelId;

                connection.Open();

                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    throw new InvalidOperationException(
                        "The selected position level does not exist or is inactive.");
                }
            }
        }

        private static object DbValue(string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? (object)DBNull.Value
                : value.Trim();
        }

        private static void AddText(
            SqlCommand command,
            string name,
            int length,
            string value,
            bool required = false)
        {
            if (required && string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(name + " is required.");
            }

            if (value != null && value.Trim().Length > length)
            {
                throw new ArgumentException(
                    name + " cannot exceed " + length + " characters.");
            }

            command.Parameters.Add(name, SqlDbType.NVarChar, length).Value =
                DbValue(value);
        }

        private DataTable Query(
            string sql,
            Action<SqlCommand> parameters = null)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                parameters?.Invoke(command);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        private int Execute(
            string sql,
            Action<SqlCommand> parameters)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                parameters?.Invoke(command);
                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        private int Insert(
            string sql,
            Action<SqlCommand> parameters)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                parameters?.Invoke(command);
                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private static void EnsureUpdated(int affected, string entity)
        {
            if (affected == 0)
            {
                throw new InvalidOperationException(
                    entity + " record was not found.");
            }
        }

        // =========================================================
        // COMPANY
        // =========================================================

        public DataTable GetCompanies()
        {
            return Query(@"
                SELECT
                    c.CompanyId,
                    c.CompanyCode,
                    c.CompanyName,
                    c.LegalName,
                    c.Address,
                    c.ContactNumber,
                    c.Email,
                    ISNULL(ec.EmployeeCount, 0) AS EmployeeCount,
                    c.IsActive,
                    c.CreatedAt,
                    c.UpdatedAt
                FROM dbo.Company c
                OUTER APPLY
                (
                    SELECT COUNT(DISTINCT ea.EmployeeId) AS EmployeeCount
                    FROM dbo.EmployeeAssignment ea
                    WHERE ea.CompanyId = c.CompanyId
                ) ec
                ORDER BY c.CompanyName;");
        }

        public DataTable GetCompany(int companyId)
        {
            return Query(@"
                SELECT *
                FROM dbo.Company
                WHERE CompanyId = @CompanyId;",
                cmd => cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId);
        }

        public int AddCompany(
            string companyCode,
            string companyName,
            string legalName,
            string address,
            string contactNumber,
            string email,
            bool isActive)
        {
            return Insert(@"
                INSERT INTO dbo.Company
                (
                    CompanyCode,
                    CompanyName,
                    LegalName,
                    Address,
                    ContactNumber,
                    Email,
                    IsActive
                )
                OUTPUT INSERTED.CompanyId
                VALUES
                (
                    @CompanyCode,
                    @CompanyName,
                    @LegalName,
                    @Address,
                    @ContactNumber,
                    @Email,
                    @IsActive
                );",
                cmd =>
                {
                    SetCompanyParameters(
                        cmd,
                        companyCode,
                        companyName,
                        legalName,
                        address,
                        contactNumber,
                        email,
                        isActive);
                });
        }

        public void UpdateCompany(
            int companyId,
            string companyCode,
            string companyName,
            string legalName,
            string address,
            string contactNumber,
            string email,
            bool isActive)
        {
            int affected = Execute(@"
                UPDATE dbo.Company
                SET CompanyCode = @CompanyCode,
                    CompanyName = @CompanyName,
                    LegalName = @LegalName,
                    Address = @Address,
                    ContactNumber = @ContactNumber,
                    Email = @Email,
                    IsActive = @IsActive,
                    UpdatedAt = SYSUTCDATETIME()
                WHERE CompanyId = @CompanyId;",
                cmd =>
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                        companyId;

                    SetCompanyParameters(
                        cmd,
                        companyCode,
                        companyName,
                        legalName,
                        address,
                        contactNumber,
                        email,
                        isActive);
                });

            EnsureUpdated(affected, "Company");
        }

        public void DeactivateCompany(int companyId)
        {
            int affected = Execute(@"
                UPDATE dbo.Company
                SET IsActive = 0,
                    UpdatedAt = SYSUTCDATETIME()
                WHERE CompanyId = @CompanyId;",
                cmd => cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId);

            EnsureUpdated(affected, "Company");
        }

        private static void SetCompanyParameters(SqlCommand cmd, string code, string name, string legalName, string address, string contactNumber, string email, bool active)
        {
            AddText(cmd, "@CompanyCode", 20, code, true);
            AddText(cmd, "@CompanyName", 200, name, true);
            AddText(cmd, "@LegalName", 250, legalName);
            AddText(cmd, "@Address", 500, address);
            AddText(cmd, "@ContactNumber", 30, contactNumber);
            AddText(cmd, "@Email", 150, email);
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = active;
        }

        // =========================================================
        // DEPARTMENT
        // =========================================================

        // Returns departments belonging to the currently selected company.
        public DataTable GetDepartments()
        {
            int companyId = RequireCompanyId();

            return GetDepartments(companyId);
        }

        // Explicit company filter. Does not permit an unfiltered
        // all-company department query.

        public DataTable GetDepartments(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentException("Valid company is required.");

            return Query(@"
        SELECT
            d.DepartmentId,
            d.CompanyId,
            c.CompanyName,
            d.DepartmentCode,
            d.DepartmentName,
            d.ParentDepartmentId,
            ISNULL(parent.DepartmentName, NULL)
                AS ParentDepartmentName,
            d.Description,
            ISNULL(ec.EmployeeCount, 0) AS EmployeeCount,
            d.IsActive,
            d.CreatedAt,
            d.UpdatedAt
        FROM dbo.Department d
        INNER JOIN dbo.Company c
            ON c.CompanyId = d.CompanyId
        LEFT JOIN dbo.Department parent
            ON parent.DepartmentId = d.ParentDepartmentId
           AND parent.CompanyId = d.CompanyId
        OUTER APPLY
        (
            SELECT COUNT(DISTINCT ea.EmployeeId) AS EmployeeCount
            FROM dbo.EmployeeAssignment ea
            WHERE ea.DepartmentId = d.DepartmentId
              AND ea.CompanyId = d.CompanyId
        ) ec
        WHERE d.CompanyId = @CompanyId
        ORDER BY d.DepartmentName;",
                cmd => cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId);
        }


        public DataTable GetDepartment(int departmentId)
        {
            int companyId = RequireCompanyId();

            return Query(@"
                SELECT *
                FROM dbo.Department
                WHERE DepartmentId = @DepartmentId
                  AND CompanyId = @CompanyId;",
                cmd =>
                {
                    cmd.Parameters.Add("@DepartmentId", SqlDbType.Int)
                        .Value = departmentId;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                        .Value = companyId;
                });
        }

        public int AddDepartment(
            string departmentCode,
            string departmentName,
            string description,
            bool isActive,
            int? parentDepartmentId)
        {
            int companyId = RequireCompanyId();

            EnsureActiveCompany(companyId);
            EnsureValidParentDepartment(companyId, parentDepartmentId);

            return Insert(@"
        INSERT INTO dbo.Department
        (
            CompanyId,
            ParentDepartmentId,
            DepartmentCode,
            DepartmentName,
            Description,
            IsActive
        )
        OUTPUT INSERTED.DepartmentId
        VALUES
        (
            @CompanyId,
            @ParentDepartmentId,
            @DepartmentCode,
            @DepartmentName,
            @Description,
            @IsActive
        );",
                cmd =>
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                        companyId;

                    cmd.Parameters.Add("@ParentDepartmentId", SqlDbType.Int).Value =
                        parentDepartmentId.HasValue
                            ? (object)parentDepartmentId.Value
                            : DBNull.Value;

                    AddText(cmd, "@DepartmentCode", 40, departmentCode, true);
                    AddText(cmd, "@DepartmentName", 400, departmentName, true);
                    AddText(cmd, "@Description", 1000, description);

                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                        isActive;
                });
        }

        public void UpdateDepartment(
    int departmentId,
    string departmentCode,
    string departmentName,
    string description,
    bool isActive,
    int? parentDepartmentId)
        {
            int companyId = RequireCompanyId();

            EnsureActiveCompany(companyId);

            // Confirm the department being edited belongs to this company.
            DataTable existing = GetDepartment(departmentId);

            if (existing.Rows.Count == 0)
                throw new InvalidOperationException(
                    "Department was not found in the active company.");

            EnsureValidParentDepartment(
                companyId,
                parentDepartmentId,
                departmentId);

            int affected = Execute(@"
        UPDATE dbo.Department
        SET ParentDepartmentId = @ParentDepartmentId,
            DepartmentCode = @DepartmentCode,
            DepartmentName = @DepartmentName,
            Description = @Description,
            IsActive = @IsActive,
            UpdatedAt = SYSUTCDATETIME()
        WHERE DepartmentId = @DepartmentId
          AND CompanyId = @CompanyId;",
                cmd =>
                {
                    cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value =
                        departmentId;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                        companyId;

                    cmd.Parameters.Add("@ParentDepartmentId", SqlDbType.Int).Value =
                        parentDepartmentId.HasValue
                            ? (object)parentDepartmentId.Value
                            : DBNull.Value;

                    AddText(cmd, "@DepartmentCode", 40, departmentCode, true);
                    AddText(cmd, "@DepartmentName", 400, departmentName, true);
                    AddText(cmd, "@Description", 1000, description);

                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                        isActive;
                });

            EnsureUpdated(affected, "Department");
        }

        public void DeactivateDepartment(int departmentId)
        {
            int companyId = RequireCompanyId();

            int affected = Execute(@"
                UPDATE dbo.Department
                SET IsActive = 0,
                    UpdatedAt = SYSUTCDATETIME()
                WHERE DepartmentId = @DepartmentId
                  AND CompanyId = @CompanyId;",
                cmd =>
                {
                    cmd.Parameters.Add("@DepartmentId", SqlDbType.Int)
                        .Value = departmentId;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                        .Value = companyId;
                });

            EnsureUpdated(affected, "Department");
        }
        // Returns valid parent departments for the active company.
        // Excludes the department being edited and all its descendants.
        public DataTable GetParentDepartments(
            int companyId,
            int? currentDepartmentId = null)
        {
            if (companyId <= 0)
                throw new ArgumentException("Valid company is required.");

            return Query(@"
        ;WITH DepartmentTree AS
        (
            SELECT DepartmentId
            FROM dbo.Department
            WHERE DepartmentId = @CurrentDepartmentId
              AND CompanyId = @CompanyId

            UNION ALL

            SELECT child.DepartmentId
            FROM dbo.Department child
            INNER JOIN DepartmentTree parent
                ON child.ParentDepartmentId = parent.DepartmentId
            WHERE child.CompanyId = @CompanyId
        )
        SELECT
            d.DepartmentId,
            d.DepartmentCode,
            d.DepartmentName,
            d.IsActive
        FROM dbo.Department d
        WHERE d.CompanyId = @CompanyId
          AND d.IsActive = 1
          AND (@CurrentDepartmentId IS NULL
               OR d.DepartmentId <> @CurrentDepartmentId)
          AND
          (
              @CurrentDepartmentId IS NULL
              OR NOT EXISTS
              (
                  SELECT 1
                  FROM DepartmentTree tree
                  WHERE tree.DepartmentId = d.DepartmentId
              )
          )
        ORDER BY d.DepartmentName
        OPTION (MAXRECURSION 32767);",
                cmd =>
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                        companyId;

                    cmd.Parameters.Add("@CurrentDepartmentId", SqlDbType.Int).Value =
                        currentDepartmentId.HasValue
                            ? (object)currentDepartmentId.Value
                            : DBNull.Value;
                });
        }

        // Validates that the proposed parent belongs to the same company
        // and does not create a circular department hierarchy.
        private void EnsureValidParentDepartment(
            int companyId,
            int? parentDepartmentId,
            int? currentDepartmentId = null)
        {
            if (!parentDepartmentId.HasValue)
                return;

            if (parentDepartmentId.Value <= 0)
                throw new ArgumentException("Invalid parent department.");

            if (currentDepartmentId.HasValue &&
                parentDepartmentId.Value == currentDepartmentId.Value)
            {
                throw new InvalidOperationException(
                    "A department cannot be its own parent.");
            }

            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
        ;WITH DepartmentTree AS
        (
            SELECT DepartmentId
            FROM dbo.Department
            WHERE DepartmentId = @CurrentDepartmentId
              AND CompanyId = @CompanyId

            UNION ALL

            SELECT child.DepartmentId
            FROM dbo.Department child
            INNER JOIN DepartmentTree parent
                ON child.ParentDepartmentId = parent.DepartmentId
            WHERE child.CompanyId = @CompanyId
        )
        SELECT
            CASE
                WHEN EXISTS
                (
                    SELECT 1
                    FROM dbo.Department
                    WHERE DepartmentId = @ParentDepartmentId
                      AND CompanyId = @CompanyId
                      AND IsActive = 1
                )
                AND
                (
                    @CurrentDepartmentId IS NULL
                    OR NOT EXISTS
                    (
                        SELECT 1
                        FROM DepartmentTree
                        WHERE DepartmentId = @ParentDepartmentId
                    )
                )
                THEN 1
                ELSE 0
            END
        OPTION (MAXRECURSION 32767);", connection))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value =
                    companyId;

                command.Parameters.Add("@ParentDepartmentId", SqlDbType.Int).Value =
                    parentDepartmentId.Value;

                command.Parameters.Add("@CurrentDepartmentId", SqlDbType.Int).Value =
                    currentDepartmentId.HasValue
                        ? (object)currentDepartmentId.Value
                        : DBNull.Value;

                connection.Open();

                if (Convert.ToInt32(command.ExecuteScalar()) != 1)
                {
                    throw new InvalidOperationException(
                        "The selected parent department is invalid, inactive, " +
                        "belongs to another company, or would create a circular hierarchy.");
                }
            }
        }
        // =========================================================
        // POSITION LEVEL
        // =========================================================

        public DataTable GetPositionLevels()
        {
            return Query(@"
                SELECT
                    PositionLevelId,
                    LevelCode,
                    LevelName,
                    LevelOrder,
                    Description,
                    IsActive
                FROM dbo.PositionLevel
                WHERE IsActive = 1
                ORDER BY LevelOrder;");
        }

        // =========================================================
        // POSITION
        // =========================================================

        public DataTable GetPositions()
        {
            int companyId = RequireCompanyId();

            return Query(@"
                SELECT
                    p.PositionId,
                    p.PositionCode,
                    p.PositionName,
                    p.DepartmentId,
                    d.DepartmentName,
                    d.CompanyId,
                    c.CompanyName,
                    p.Description,
                    ISNULL(ec.EmployeeCount, 0) AS EmployeeCount,
                    p.IsActive,
                    p.CreatedAt,
                    p.UpdatedAt,
                    p.PositionLevelId,
                    pl.LevelName AS PositionLevelName,
                    pl.LevelOrder
                FROM dbo.Position p
                INNER JOIN dbo.Department d
                    ON d.DepartmentId = p.DepartmentId
                INNER JOIN dbo.Company c
                    ON c.CompanyId = d.CompanyId
                LEFT JOIN dbo.PositionLevel pl
                    ON pl.PositionLevelId = p.PositionLevelId
                OUTER APPLY
                (
                    SELECT COUNT(DISTINCT ea.EmployeeId) AS EmployeeCount
                    FROM dbo.EmployeeAssignment ea
                    WHERE ea.PositionId = p.PositionId
                      AND ea.DepartmentId = p.DepartmentId
                      AND ea.CompanyId = d.CompanyId
                ) ec
                WHERE d.CompanyId = @CompanyId
                ORDER BY d.DepartmentName, p.PositionName;",
                cmd => cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId);
        }

        public DataTable GetPosition(int positionId)
        {
            int companyId = RequireCompanyId();

            return Query(@"
                SELECT p.*
                FROM dbo.Position p
                INNER JOIN dbo.Department d
                    ON d.DepartmentId = p.DepartmentId
                WHERE p.PositionId = @PositionId
                  AND d.CompanyId = @CompanyId;",
                cmd =>
                {
                    cmd.Parameters.Add("@PositionId", SqlDbType.Int)
                        .Value = positionId;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                        .Value = companyId;
                });
        }

        public int AddPosition(
    int departmentId,
    int positionLevelId,
    string positionCode,
    string positionName,
    string description,
    bool isActive)
        {
            int companyId = RequireCompanyId();

            EnsureActiveCompany(companyId);
            EnsureDepartmentBelongsToCompany(departmentId, companyId);
            EnsurePositionLevelIsActive(positionLevelId);

            if (string.IsNullOrWhiteSpace(positionName))
                throw new ArgumentException("Position Name is required.");

            if (string.IsNullOrWhiteSpace(positionCode))
                positionCode = GetNextPositionCode();

            return Insert(@"
        INSERT INTO dbo.Position
        (
            DepartmentId,
            PositionLevelId,
            PositionCode,
            PositionName,
            Description,
            IsActive
        )
        OUTPUT INSERTED.PositionId
        VALUES
        (
            @DepartmentId,
            @PositionLevelId,
            @PositionCode,
            @PositionName,
            @Description,
            @IsActive
        );",
                cmd =>
                {
                    SetPositionParameters(
                        cmd,
                        departmentId,
                        positionLevelId,
                        positionCode,
                        positionName,
                        description,
                        isActive);
                });
        }

        public void UpdatePosition(
            int positionId,
            int departmentId,
            int positionLevelId,
            string positionCode,
            string positionName,
            string description,
            bool isActive)
        {
            int companyId = RequireCompanyId();

            EnsureActiveCompany(companyId);
            EnsureDepartmentBelongsToCompany(departmentId, companyId);
            EnsurePositionLevelIsActive(positionLevelId);
            if (string.IsNullOrWhiteSpace(positionName))
                throw new ArgumentException("Position Name is required.");

            if (string.IsNullOrWhiteSpace(positionCode))
                positionCode = GetNextPositionCode();
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                using (SqlTransaction transaction =
                    connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        // Confirm that the position belongs to the active company.
                        using (SqlCommand check = new SqlCommand(@"
                            SELECT COUNT(*)
                            FROM dbo.Position p WITH (UPDLOCK, HOLDLOCK)
                            INNER JOIN dbo.Department d
                                ON d.DepartmentId = p.DepartmentId
                            WHERE p.PositionId = @PositionId
                              AND d.CompanyId = @CompanyId;",
                            connection,
                            transaction))
                        {
                            check.Parameters.Add("@PositionId", SqlDbType.Int)
                                .Value = positionId;

                            check.Parameters.Add("@CompanyId", SqlDbType.Int)
                                .Value = companyId;


                            if (Convert.ToInt32(check.ExecuteScalar()) == 0)
                            {
                                throw new InvalidOperationException(
                                    "Position was not found in the active company.");
                            }
                        }

                        // Prevent moving a position to another department
                        // while employee assignments still reference it
                        // under a different department.
                        using (SqlCommand check = new SqlCommand(@"
                            SELECT COUNT(*)
                            FROM dbo.EmployeeAssignment WITH (UPDLOCK, HOLDLOCK)
                            WHERE PositionId = @PositionId
                              AND DepartmentId <> @DepartmentId;",
                            connection,
                            transaction))
                        {
                            check.Parameters.Add("@PositionId", SqlDbType.Int)
                                .Value = positionId;

                            check.Parameters.Add("@DepartmentId", SqlDbType.Int)
                                .Value = departmentId;

                            if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                            {
                                throw new InvalidOperationException(
                                    "This position is used by employee assignments " +
                                    "in another department. Review those assignments " +
                                    "before changing its department.");
                            }
                        }

                        using (SqlCommand command = new SqlCommand(@"
                            UPDATE dbo.Position
                            SET DepartmentId = @DepartmentId,
                                PositionLevelId = @PositionLevelId,
                                PositionCode = @PositionCode,
                                PositionName = @PositionName,
                                Description = @Description,
                                IsActive = @IsActive,
                                UpdatedAt = SYSUTCDATETIME()
                            WHERE PositionId = @PositionId
                              AND EXISTS
                              (
                                  SELECT 1
                                  FROM dbo.Department d
                                  WHERE d.DepartmentId = @DepartmentId
                                    AND d.CompanyId = @CompanyId
                                    AND d.IsActive = 1
                              );",
                            connection,
                            transaction))
                        {
                            command.Parameters.Add("@PositionId", SqlDbType.Int)
                                .Value = positionId;

                            command.Parameters.Add("@CompanyId", SqlDbType.Int)
                                .Value = companyId;


                            SetPositionParameters(
                                command,
                                departmentId,
                                positionLevelId,
                                positionCode,
                                positionName,
                                description,
                                isActive);

                            EnsureUpdated(
                                command.ExecuteNonQuery(),
                                "Position");
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void DeactivatePosition(int positionId)
        {
            int companyId = RequireCompanyId();

            int affected = Execute(@"
                UPDATE p
                SET p.IsActive = 0,
                    p.UpdatedAt = SYSUTCDATETIME()
                FROM dbo.Position p
                INNER JOIN dbo.Department d
                    ON d.DepartmentId = p.DepartmentId
                WHERE p.PositionId = @PositionId
                  AND d.CompanyId = @CompanyId;",
                cmd =>
                {
                    cmd.Parameters.Add("@PositionId", SqlDbType.Int)
                        .Value = positionId;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                        .Value = companyId;
                });

            EnsureUpdated(affected, "Position");
        }

        private void SetPositionParameters(
    SqlCommand cmd,
    int departmentId,
    int positionLevelId,
    string positionCode,
    string positionName,
    string description,
    bool isActive)
        {
            if (string.IsNullOrWhiteSpace(positionCode))
                throw new ArgumentException("PositionCode is required.");

            if (string.IsNullOrWhiteSpace(positionName))
                throw new ArgumentException("PositionName is required.");

            AddText(cmd, "@PositionCode", 40, positionCode, true);
            AddText(cmd, "@PositionName", 400, positionName, true);

            cmd.Parameters.Add("@DepartmentId", SqlDbType.Int)
                .Value = departmentId;

            cmd.Parameters.Add("@PositionLevelId", SqlDbType.Int)
                .Value = positionLevelId;

            AddText(cmd, "@Description", 1000, description);

            cmd.Parameters.Add("@IsActive", SqlDbType.Bit)
                .Value = isActive;
        }

        // =========================================================
        // COMPANY LOGO
        // =========================================================

        public DataTable GetCompanyLogos()
        {
            return Query(@"
                SELECT
                    l.CompanyLogoId,
                    l.CompanyId,
                    c.CompanyCode,
                    c.CompanyName,
                    l.FileName,
                    l.ContentType,
                    DATALENGTH(l.LogoData) AS FileSize,
                    l.CreatedAt,
                    l.UpdatedAt
                FROM dbo.CompanyLogo l
                INNER JOIN dbo.Company c
                    ON c.CompanyId = l.CompanyId
                ORDER BY c.CompanyName;");
        }

        public byte[] GetCompanyLogoData(int companyId)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
                SELECT LogoData
                FROM dbo.CompanyLogo
                WHERE CompanyId = @CompanyId;", connection))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId;

                connection.Open();

                object result = command.ExecuteScalar();

                return result == null || result == DBNull.Value
                    ? null
                    : (byte[])result;
            }
        }

        public void SaveCompanyLogo(
            int companyId,
            byte[] logoData,
            string fileName,
            string contentType)
        {
            if (companyId <= 0)
                throw new ArgumentException("Valid company is required.");

            if (logoData == null || logoData.Length == 0)
                throw new ArgumentException("Logo image is required.");

            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
                UPDATE dbo.CompanyLogo
                SET LogoData = @LogoData,
                    FileName = @FileName,
                    ContentType = @ContentType,
                    UpdatedAt = SYSUTCDATETIME()
                WHERE CompanyId = @CompanyId;

                IF @@ROWCOUNT = 0
                BEGIN
                    INSERT INTO dbo.CompanyLogo
                    (
                        CompanyId,
                        LogoData,
                        FileName,
                        ContentType
                    )
                    VALUES
                    (
                        @CompanyId,
                        @LogoData,
                        @FileName,
                        @ContentType
                    );
                END;", connection))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId;

                command.Parameters.Add("@LogoData", SqlDbType.VarBinary, -1)
                    .Value = logoData;

                AddText(command, "@FileName", 255, fileName);
                AddText(command, "@ContentType", 50, contentType);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCompanyLogo(int companyId)
        {
            Execute(@"
                DELETE FROM dbo.CompanyLogo
                WHERE CompanyId = @CompanyId;",
                cmd => cmd.Parameters.Add("@CompanyId", SqlDbType.Int)
                    .Value = companyId);
        }
        public string GetNextPositionCode()
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(@"
        SELECT ISNULL(
            MAX(TRY_CONVERT(INT, SUBSTRING(PositionCode, 5, 20))),
            0
        ) + 1
        FROM dbo.Position
        WHERE PositionCode LIKE 'POS-%'
          AND SUBSTRING(PositionCode, 5, 20) <> ''
          AND SUBSTRING(PositionCode, 5, 20) NOT LIKE '%[^0-9]%';",
                connection))
            {
                connection.Open();

                int nextNumber = Convert.ToInt32(command.ExecuteScalar());

                return "POS-" + nextNumber.ToString("D4");
            }
        }
        public string GetNextDepartmentCode(int companyId)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
            SELECT
                'DEPT-' +
                RIGHT(
                    '0000' +
                    CAST(
                        ISNULL(
                            MAX(TRY_CONVERT(INT, SUBSTRING(DepartmentCode, 6, 20))),
                            0
                        ) + 1 AS VARCHAR(10)
                    ),
                    4
                )
            FROM Department
            WHERE CompanyId = @CompanyId
              AND DepartmentCode LIKE 'DEPT-%'
              AND SUBSTRING(DepartmentCode, 6, 20) <> ''
              AND SUBSTRING(DepartmentCode, 6, 20) NOT LIKE '%[^0-9]%';";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", companyId);

                    return Convert.ToString(command.ExecuteScalar());
                }
            }
        }
    }
}
