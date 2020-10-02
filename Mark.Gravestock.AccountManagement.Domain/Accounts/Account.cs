using System;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class Account
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        public Account(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
        
        public static Account CreateFor(Guid customerId)
        {
            return new Account(Guid.NewGuid(), customerId);
        }
    }
}