using System.Data;
using System.Data.SqlClient;

namespace MarkGravestock.AccountManagement.Infrastructure.Database
{
    public class SqlServerConnectionFactory : ISqlConnectionFactory
    {
        private readonly string connectionString;

        public SqlServerConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}