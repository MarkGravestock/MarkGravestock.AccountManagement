using System.Threading.Tasks;
using FluentAssertions;
using Mark.Gravestock.AccountManagement.Application.Accounts;
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
        public async Task it_can_create_an_account(IMediator mediator, OpenAccountCommand command)
        {
            var accountId = await mediator.Send(command);

            var result = await mediator.Send(new GetAccountQuery{ AccountId = accountId });
            
            result.ValueOrFailure().CustomerId.Value.Should().Be(command.CustomerId);
            result.ValueOrFailure().Balance.Should().Be(command.InitialBalance);
        }
    }
}