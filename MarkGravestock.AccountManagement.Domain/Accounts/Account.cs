using System;
using Mark.Gravestock.AccountManagement.Domain.Core;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class Account
    {
        public Account(AccountId accountId, CustomerId customerId, decimal initialBalanceGbp)
        {
            Id = accountId;
            CustomerId = customerId;

            if (initialBalanceGbp < Decimal.Zero)
            {
                throw new BusinessRuleValidationException("Initial Balance can't be negative");
            }
        }

        public CustomerId CustomerId { get; }

        public AccountId Id { get; }

        public static Account Open(CustomerId customerId, Decimal initialBalanceInGbp)
        {
            return new Account(AccountId.Create(), customerId, initialBalanceInGbp);
        }
        public static Account Open(CustomerId customerId)
        {
            return new Account(AccountId.Create(), customerId, Decimal.Zero);
        }
    }
}