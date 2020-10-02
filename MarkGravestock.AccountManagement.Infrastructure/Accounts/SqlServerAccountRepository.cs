using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Optional;
using Optional.Collections;

namespace MarkGravestock.AccountManagement.Infrastructure.Accounts
{
    public class SqlServerAccountRepository : IAccountRepository
    {
        private readonly ISqlConnectionFactory connectionFactory;

        public SqlServerAccountRepository(ISqlConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public void Save(Account account)
        {
            using var connection = connectionFactory.GetConnection();

            connection.Execute("INSERT INTO Account (Id, CustomerId) VALUES (@Id, @CustomerId)", new {account.Id, account.CustomerId});
        }

        public Option<Account> Get(Guid accountId)
        {
            using var connection = connectionFactory.GetConnection();

            return connection.Query<Account>("SELECT * FROM Account WHERE Id = @Id ", new {Id = accountId}).SingleOrNone();
        }
    }

    public interface ISqlConnectionFactory
    {
        IDbConnection GetConnection();
    }

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