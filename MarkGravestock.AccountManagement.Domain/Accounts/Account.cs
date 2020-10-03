using System;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class Account
    {
        //TODO: IDs
        
        public Account(AccountId accountId, Guid customerId)
        {
            Id = accountId;
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }

        public AccountId Id { get; }

        public static Account CreateFor(Guid customerId)
        {
            return new Account(new AccountId(Guid.NewGuid()), customerId);
        }
    }
}