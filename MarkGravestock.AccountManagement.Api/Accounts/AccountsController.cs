using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MarkGravestock.OrderManagement.Api.Accounts
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
        public IActionResult CreateAccount([FromBody]CreateAccountRequest createAccountRequest)
        {
            var newAccountId = Guid.NewGuid();
            
            var newAccount = new Account(newAccountId, createAccountRequest.CustomerId);

            accountRepository.Save(newAccount);
            
            var createdPath = Url.RouteUrl(nameof(GetAccount), new {accountId = newAccountId});

            var createdUri = new Uri( $"{Request.Scheme}://{Request.Host}{createdPath}", UriKind.Absolute);
            
            return Created(createdUri, null);
        }
        
        [HttpGet("{accountId:guid}", Name = nameof(GetAccount))]
        public IActionResult GetAccount(Guid accountId)
        {
            return Ok(accountRepository.Get(accountId));
        }
    }

    internal class InMemoryAccountRepository : IAccountRepository
    {
        private IDictionary<Guid, Account> accountsByKey = new Dictionary<Guid, Account>();
        
        public void Save(Account account)
        {
            accountsByKey[account.Id] = account;
        }

        public Account Get(Guid accountId)
        {
            return accountsByKey[accountId];
        }
    }

    public interface IAccountRepository
    {
        void Save(Account account);
        Account Get(Guid accountId);
    }

    public class Account
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        public Account(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}