using System;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public interface IAccountRepository
    {
        void Save(Account account);
        Account Get(Guid accountId);
    }
}