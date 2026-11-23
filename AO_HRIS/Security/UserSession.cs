
using System;

namespace AO_HRIS.Security
{

    public static class UserSession
    {
        public static int UserId { get; private set; }
        public static int? EmployeeId { get; private set; }
        public static string Username { get; private set; }
        public static int? CompanyId { get; private set; }

        public static void SetSession(int userId, int? employeeId, string username)
        {
            UserId = userId;
            EmployeeId = employeeId;
            Username = username;
        }

        public static void Clear()
        {
            UserId = 0;
            EmployeeId = null;
            Username = null;
            CompanyId = null;
        }

        public static void SetCompany(int companyId)
        {
            if (companyId <= 0)
                throw new ArgumentOutOfRangeException(nameof(companyId));

            CompanyId = companyId;
        }
    }
}
