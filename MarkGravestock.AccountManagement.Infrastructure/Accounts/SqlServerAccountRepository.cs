using System;
using Dapper;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using MarkGravestock.AccountManagement.Infrastructure.Database;
using Optional;
using Optional.Collections;

namespace MarkGravestock.AccountManagement.Infrastructure.Accounts
{
    internal class SqlServerAccountRepository : IAccountRepository
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
}