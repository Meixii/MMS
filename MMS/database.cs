using System.Data.SqlClient;

namespace MMS
{
    public static class database
    {
        public static string GetConnectionString()
        {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "localhost";
        builder.InitialCatalog = "mms";
        builder.IntegratedSecurity = true;
        string connectionString = builder.ConnectionString;

            return connectionString;
        }
    }
}
