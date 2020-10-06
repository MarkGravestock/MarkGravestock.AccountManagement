using System;
using Mark.Gravestock.AccountManagement.Domain.Core;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class Account
    {
        public Account(AccountId accountId, CustomerId customerId, decimal balanceGbp)
        {
            Id = accountId;
            CustomerId = customerId;

            if (balanceGbp < Decimal.Zero)
            {
                throw new BusinessRuleValidationException("Account Balance can't be negative");
            }

            Balance = balanceGbp;
        }

        public CustomerId CustomerId { get; }

        public AccountId Id { get; }
        public decimal Balance { get; }

        public static Account Open(CustomerId customerId, Decimal initialBalanceInGbp)
        {
            return new Account(AccountId.Create(), customerId, initialBalanceInGbp);
        }
    }
}