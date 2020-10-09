using System;
using Mark.Gravestock.AccountManagement.Domain.Core;
using Mark.Gravestock.AccountManagement.Domain.Customer;
using NodaMoney;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class Account
    {
        private readonly Money balance;

        public Account(AccountId accountId, CustomerId customerId, Money initialBalance)
        {
            Id = accountId;
            CustomerId = customerId;

            if (initialBalance.Amount < Decimal.Zero)
            {
                throw new BusinessRuleValidationException("Account Balance can't be negative");
            }

            balance = initialBalance;
        }

        public CustomerId CustomerId { get; }

        public AccountId Id { get; }
        public decimal Balance => balance.Amount;

        public static Account Open(CustomerId customerId, Money initialBalance)
        {
            return new Account(AccountId.Create(), customerId, initialBalance);
        }
    }
}