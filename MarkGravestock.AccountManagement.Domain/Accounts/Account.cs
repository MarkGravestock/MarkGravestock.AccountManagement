using System;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class Account
    {
        //TODO: IDs
        public Account(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }

        public Guid Id { get; }
        public Guid CustomerId { get; }

        public static Account CreateFor(Guid customerId)
        {
            return new Account(Guid.NewGuid(), customerId);
        }
    }
}