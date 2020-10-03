using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Optional;

namespace MarkGravestock.AccountManagement.Infrastructure.Accounts
{
    internal class InMemoryAccountRepository : IAccountRepository
    {
        private readonly IDictionary<Guid, Account> accountsByKey = new Dictionary<Guid, Account>();

        public Task SaveAsync(Account account)
        {
            accountsByKey[account.Id] = account;
            
            return Task.CompletedTask;
        }

        public Task<Option<Account>> GetAsync(Guid accountId)
        {
            return Task.FromResult(accountsByKey.ContainsKey(accountId) ? Option.Some(accountsByKey[accountId]) : Option.None<Account>());
        }
    }
}