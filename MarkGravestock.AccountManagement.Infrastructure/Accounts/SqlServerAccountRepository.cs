using System;
using System.Threading.Tasks;
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

        public async Task SaveAsync(Account account)
        {
            using var connection = connectionFactory.GetConnection();

            await connection.ExecuteAsync("INSERT INTO Account (Id, CustomerId) VALUES (@Id, @CustomerId)", new {account.Id, account.CustomerId});
        }

        public async Task<Option<Account>> GetAsync(Guid accountId)
        {
            using var connection = connectionFactory.GetConnection();

            var accounts = await connection.QueryAsync<Account>("SELECT * FROM Account WHERE Id = @Id ", new {Id = accountId});
            
            return accounts.SingleOrNone();
        }
    }
}