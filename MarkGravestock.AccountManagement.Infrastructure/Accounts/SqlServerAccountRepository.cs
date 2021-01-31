using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Mark.Gravestock.AccountManagement.Domain.Customer;
using MarkGravestock.AccountManagement.Infrastructure.Database;
using NodaMoney;
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

            await connection.ExecuteAsync("INSERT INTO Account (Id, CustomerId, Balance) VALUES (@Id, @CustomerId, @Balance)", new {Id = account.Id.Value, CustomerId = account.CustomerId.Value, account.Balance});
        }

        public async Task<Option<Account>> GetAsync(AccountId accountId)
        {
            using var connection = connectionFactory.GetConnection();

            var dynamicAccounts = await connection.QueryAsync<dynamic>("SELECT * FROM Account WHERE Id = @Id ", new {Id = accountId.Value});

            var accounts = dynamicAccounts.Select(x => new Account(new AccountId(x.Id), new CustomerId(x.CustomerId), Money.PoundSterling(x.Balance)));

            return accounts.SingleOrNone();
        }
    }
}