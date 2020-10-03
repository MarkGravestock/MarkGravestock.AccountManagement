using System;
using FluentAssertions;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Xunit;

namespace MarkGravestock.AccountManagement.UnitTests
{
    public class AccountTest
    {
        [Fact]
        public void it_can_be_identified_by_an_id()
        {
            var accountId = Guid.NewGuid();
            var sut = new Account(new AccountId(accountId), Guid.NewGuid());

            sut.Id.Should().Be(new AccountId(accountId));
        }
        
        [Fact]
        public void it_can_be_identified_by_an_id_as_a_guid()
        {
            var accountId = Guid.NewGuid();
            var sut = new Account(new AccountId(accountId), Guid.NewGuid());

            //sut.Id.As<Guid>().Should().Be(accountId);
            ((Guid)sut.Id).Should().Be(accountId);
        }
    }
}