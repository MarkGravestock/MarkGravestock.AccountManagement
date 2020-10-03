using System;
using Mark.Gravestock.AccountManagement.Domain.Core;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class CustomerId : Identity<CustomerId>
    {
        public CustomerId(Guid identity) : base(identity)
        {
        }

        public static CustomerId Create()
        {
            return new CustomerId(Guid.NewGuid());
        }
    }
}