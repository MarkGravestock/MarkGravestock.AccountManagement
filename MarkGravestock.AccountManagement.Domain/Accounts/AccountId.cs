using System;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class AccountId : Identity<AccountId>
    {
        public AccountId(Guid accountId) : base(accountId)
        {
        }

        public static AccountId Create()
        {
            return new AccountId(Guid.NewGuid());
        }
    }
}