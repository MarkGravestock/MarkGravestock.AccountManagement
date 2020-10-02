﻿using System;
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
        public IActionResult CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
        {
            //TODO: Move into application/mediatr
            var newAccount = Account.CreateFor(createAccountRequest.CustomerId);

            accountRepository.Save(newAccount);

            var createdPath = Url.RouteUrl(nameof(GetAccount), new {accountId = newAccount.Id});
            var createdUri = new Uri($"{Request.Scheme}://{Request.Host}{createdPath}", UriKind.Absolute);

            return Created(createdUri, null);
        }

        [HttpGet("{accountId:guid}", Name = nameof(GetAccount))]
        public IActionResult GetAccount(Guid accountId)
        {
            return accountRepository.Get(accountId).Map<IActionResult>(Ok).ValueOr(NotFound());
        }
    }
}