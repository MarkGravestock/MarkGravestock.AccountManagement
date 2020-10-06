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
        public async Task<IActionResult> CreateAccount([FromBody] OpenAccountRequest openAccountRequest)
        {
            var newAccount = Account.Open(new CustomerId(openAccountRequest.CustomerId), openAccountRequest.InitialBalance);

            await accountRepository.SaveAsync(newAccount);

            return Created(CreatedUri(newAccount), null);
        }

        private Uri CreatedUri(Account newAccount)
        {
            var createdPath = Url.RouteUrl(nameof(GetAccount), new {accountId = (Guid) newAccount.Id});
            return new Uri($"{Request.Scheme}://{Request.Host}{createdPath}", UriKind.Absolute);
        }

        [HttpGet("{accountId:guid}", Name = nameof(GetAccount))]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var account = await accountRepository.GetAsync(new AccountId(accountId));

            var accountDto = account.Map(x => new {Id = x.Id.Value, CustomerId = x.CustomerId.Value, x.Balance});

            return accountDto.Map<IActionResult>(Ok).ValueOr(NotFound());
        }
    }
}