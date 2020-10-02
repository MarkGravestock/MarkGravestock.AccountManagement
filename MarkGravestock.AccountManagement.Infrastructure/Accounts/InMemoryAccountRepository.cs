using System;
using System.Collections.Generic;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Optional;

namespace MarkGravestock.AccountManagement.Infrastructure.Accounts
{
    internal class InMemoryAccountRepository : IAccountRepository
    {
        private readonly IDictionary<Guid, Account> accountsByKey = new Dictionary<Guid, Account>();

        public void Save(Account account)
        {
            accountsByKey[account.Id] = account;
        }

        public Option<Account> Get(Guid accountId)
        {
            return accountsByKey.ContainsKey(accountId) ? Option.Some(accountsByKey[accountId]) : Option.None<Account>();
        }
    }
}