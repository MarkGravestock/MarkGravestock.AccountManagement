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
            var sut = new Account(new AccountId(accountId), CustomerId.Create());

            sut.Id.Should().Be(new AccountId(accountId));
        }
        
        [Fact]
        public void it_can_be_identified_by_an_id_as_a_guid()
        {
            var accountId = Guid.NewGuid();
            var sut = new Account(new AccountId(accountId), CustomerId.Create());

            ((Guid)sut.Id).Should().Be(accountId);
            sut.Id.Value.Should().Be(accountId);
        }
    }
}