using System;
using Mark.Gravestock.AccountManagement.Application.Core;

namespace Mark.Gravestock.AccountManagement.Application.Accounts
{
    public class OpenAccountCommand : ICommand<Guid>
    {
        public Guid CustomerId { get; set; }
        public decimal InitialBalance { get; set; }
    }
}