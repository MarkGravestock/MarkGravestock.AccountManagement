using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Mark.Gravestock.AccountManagement.Domain.Core;
using Mark.Gravestock.AccountManagement.Domain.Customer;
using NodaMoney;
using Xunit;

namespace MarkGravestock.AccountManagement.UnitTests
{
    public class AccountTest
    {
        [Theory, AutoData]
        public void it_can_be_identified_by_an_id(Guid accountId)
        {
            var sut = new Account(new AccountId(accountId), CustomerId.Create(), Money.PoundSterling(100));

            sut.Id.Should().Be(new AccountId(accountId));
        }

        [Theory, AutoData]
        public void it_can_be_identified_by_an_id_as_a_guid(Guid accountId)
        {
            var sut = new Account(new AccountId(accountId), CustomerId.Create(), Money.PoundSterling(100));

            ((Guid) sut.Id).Should().Be(accountId);
            sut.Id.Value.Should().Be(accountId);
        }

        [Theory, AutoData]
        public void it_can_return_the_balance(Guid accountId, decimal balance)
        {
            var sut = new Account(new AccountId(accountId), CustomerId.Create(), Money.PoundSterling(balance));

            sut.Balance.Should().Be(balance);
        }

        [Fact]
        public void it_raises_a_validation_error_when_the_initial_balance_is_negative()
        {
            Action openAccount = () => Account.Open(CustomerId.Create(), Money.PoundSterling(-100));

            openAccount.Should().Throw<BusinessRuleValidationException>().WithMessage("Account Balance can't be negative");
        }
    }
}