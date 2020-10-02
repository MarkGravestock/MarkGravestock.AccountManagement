using System;
using Optional;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public interface IAccountRepository
    {
        void Save(Account account);
        Option<Account> Get(Guid accountId);
    }
}