using System;
using Mark.Gravestock.AccountManagement.Application.Core;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Optional;

namespace Mark.Gravestock.AccountManagement.Application.Accounts
{
    public class GetAccountQuery : IQuery<Option<Account>>
    {
        public Guid AccountId { get; set; }
    }
}