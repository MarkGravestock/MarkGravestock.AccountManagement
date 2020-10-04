using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Optional;

namespace MarkGravestock.AccountManagement.Infrastructure.Accounts
{
    [ExcludeFromCodeCoverage]
    internal class InMemoryAccountRepository : IAccountRepository
    {
        private readonly IDictionary<AccountId, Account> accountsByKey = new Dictionary<AccountId, Account>();

        public Task SaveAsync(Account account)
        {
            accountsByKey[account.Id] = account;

            return Task.CompletedTask;
        }

        public Task<Option<Account>> GetAsync(AccountId accountId)
        {
            return Task.FromResult(accountsByKey.ContainsKey(accountId) ? Option.Some(accountsByKey[accountId]) : Option.None<Account>());
        }
    }
}