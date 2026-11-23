
using System.Configuration;
using System.Data.SqlClient;

namespace AO_HRIS.Data
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["AO_HRIS"].ConnectionString);
        }
    }
}
