using System.Data;

namespace MarkGravestock.AccountManagement.Infrastructure.Database
{
    internal interface ISqlConnectionFactory
    {
        IDbConnection GetConnection();
    }
}