using System;
using System.Threading.Tasks;
using FluentAssertions;
using Mark.Gravestock.AccountManagement.Application.Accounts;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using MarkGravestock.AccountManagement.IntegrationTests.Core;
using MediatR;
using Optional.Unsafe;
using Xunit;

namespace MarkGravestock.AccountManagement.IntegrationTests
{
    [Collection(Collections.Database)]
    public class OpenAccountApplicationTest
    {
        [Theory, TestConventions]
        public async Task it_can_create_an_account(IMediator mediator)
        {
            var aCustomerId = Guid.NewGuid();
            var anInitialBalance = 2000m;

            var accountId = await mediator.Send(new OpenAccountCommand { CustomerId = aCustomerId, InitialBalance = anInitialBalance});

            var result = await mediator.Send(new GetAccountQuery{ AccountId = accountId });
            
            result.ValueOrFailure().CustomerId.Should().Be(new CustomerId(aCustomerId));
            result.ValueOrFailure().Balance.Should().Be(anInitialBalance);
        }
    }
}