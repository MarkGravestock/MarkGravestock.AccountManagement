using System;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class AccountId
    {
        private readonly Guid accountId;

        public AccountId(Guid accountId)
        {
            this.accountId = accountId;
        }

        protected bool Equals(AccountId other)
        {
            return accountId.Equals(other.accountId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AccountId) obj);
        }

        public override int GetHashCode()
        {
            return accountId.GetHashCode();
        }

        public Guid Value => accountId;
        public static implicit operator Guid(AccountId accountId) => accountId.accountId;
    }
}