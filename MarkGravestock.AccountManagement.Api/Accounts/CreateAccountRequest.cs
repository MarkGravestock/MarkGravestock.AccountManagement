using System;

namespace MarkGravestock.OrderManagement.Api.Accounts
{
    public struct CreateAccountRequest
    {
        public Guid CustomerId { get; set; }
        public decimal InitialBalance { get; set; }
    }
}