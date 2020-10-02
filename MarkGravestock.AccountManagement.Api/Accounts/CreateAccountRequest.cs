using System;

namespace MarkGravestock.AccountManagement.Api.Accounts
{
    public struct CreateAccountRequest
    {
        public Guid CustomerId { get; set; }
        public decimal InitialBalance { get; set; }
    }
}