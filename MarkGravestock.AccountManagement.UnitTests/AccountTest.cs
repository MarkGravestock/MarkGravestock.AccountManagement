using System;
using FluentAssertions;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Mark.Gravestock.AccountManagement.Domain.Core;
using Xunit;

namespace MarkGravestock.AccountManagement.UnitTests
{
    public class AccountTest
    {
        [Fact]
        public void it_can_be_identified_by_an_id()
        {
            var accountId = Guid.NewGuid();
            var sut = new Account(new AccountId(accountId), CustomerId.Create(), Decimal.Zero);

            sut.Id.Should().Be(new AccountId(accountId));
        }

        [Fact]
        public void it_can_be_identified_by_an_id_as_a_guid()
        {
            var accountId = Guid.NewGuid();
            var sut = new Account(new AccountId(accountId), CustomerId.Create(), Decimal.Zero);

            ((Guid) sut.Id).Should().Be(accountId);
            sut.Id.Value.Should().Be(accountId);
        }
        
        [Fact]
        public void it_raises_a_validation_error_when_the_initial_balance_is_negative()
        {
            Action openAccount = () => new Account(AccountId.Create(), CustomerId.Create(), -100m);

            openAccount.Should().Throw<BusinessRuleValidationException>().WithMessage("Initial Balance can't be negative");
        }
    }
}