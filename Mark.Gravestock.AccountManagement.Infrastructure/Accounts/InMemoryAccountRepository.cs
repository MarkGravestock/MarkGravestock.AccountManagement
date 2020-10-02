using System;
using System.Collections.Generic;
using Mark.Gravestock.AccountManagement.Domain.Accounts;

namespace Mark.Gravestock.AccountManagement.Infrastructure.Accounts
{
    internal class InMemoryAccountRepository : IAccountRepository
    {
        private readonly IDictionary<Guid, Account> accountsByKey = new Dictionary<Guid, Account>();
        
        public void Save(Account account)
        {
            accountsByKey[account.Id] = account;
        }

        public Account Get(Guid accountId)
        {
            return accountsByKey[accountId];
        }
    }
}