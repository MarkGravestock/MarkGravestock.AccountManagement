using System;
using System.Threading.Tasks;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace MarkGravestock.AccountManagement.Api.Accounts
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
        {
            //TODO: Move into application/mediatr
            var newAccount = Account.CreateFor(createAccountRequest.CustomerId);

            await accountRepository.SaveAsync(newAccount);

            var createdPath = Url.RouteUrl(nameof(GetAccount), new {accountId = (Guid)newAccount.Id});
            var createdUri = new Uri($"{Request.Scheme}://{Request.Host}{createdPath}", UriKind.Absolute);

            return Created(createdUri, null);
        }

        [HttpGet("{accountId:guid}", Name = nameof(GetAccount))]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var account = await accountRepository.GetAsync(accountId);

            var accountDto = account.Map(x => new {x.Id.Value, x.CustomerId});
            
            return accountDto.Map<IActionResult>(Ok).ValueOr(NotFound());
        }
    }
}