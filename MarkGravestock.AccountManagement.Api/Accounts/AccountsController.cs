using System;
using Microsoft.AspNetCore.Mvc;

namespace MarkGravestock.OrderManagement.Api.Accounts
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateAccount([FromBody]CreateAccountRequest createAccountRequest)
        {
            var createdUri = new Uri( $"{Request.Scheme}://{Request.Host}{Url.RouteUrl(nameof(GetAccount), Guid.NewGuid())}", UriKind.Absolute);
            
            return Created(createdUri, null);
        }
        
        [HttpGet("{id}", Name = nameof(GetAccount))]
        public IActionResult GetAccount(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}