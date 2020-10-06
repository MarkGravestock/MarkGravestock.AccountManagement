using System;
using System.Net;
using System.Threading.Tasks;
using Mark.Gravestock.AccountManagement.Application.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarkGravestock.AccountManagement.Api.Accounts
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountsController(IMediator mediator)
        {
//            Contract.Requires<ArgumentNullException>(mediator != null, nameof(mediator));
            
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAccount([FromBody] OpenAccountRequest openAccountRequest)
        {
            var accountId = await mediator.Send(new OpenAccountCommand { CustomerId = openAccountRequest.CustomerId, InitialBalance = openAccountRequest.InitialBalance});

            return Created(CreatedUri(accountId), null);
        }

        private Uri CreatedUri(Guid accountId)
        {
            var createdPath = Url.RouteUrl(nameof(GetAccount), new {accountId});
            return new Uri($"{Request.Scheme}://{Request.Host}{createdPath}", UriKind.Absolute);
        }

        [HttpGet("{accountId:guid}", Name = nameof(GetAccount))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var account = await mediator.Send(new GetAccountQuery{ AccountId = accountId });

            var accountDto = account.Map(x => new {Id = x.Id.Value, CustomerId = x.CustomerId.Value, x.Balance});

            return accountDto.Map<IActionResult>(Ok).ValueOr(NotFound());
        }
    }
}