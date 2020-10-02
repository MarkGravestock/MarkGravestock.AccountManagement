using System.Data;

namespace MarkGravestock.AccountManagement.Infrastructure.Database
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetConnection();
    }
}