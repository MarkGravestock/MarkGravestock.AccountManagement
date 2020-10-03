using System;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class Identity<T>
    {
        private readonly Guid identity;
        
        protected Identity(Guid identity)
        {
            this.identity = identity;
        }
        
        protected bool Equals(Identity<T> other)
        {
            return identity.Equals(other.identity);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Identity<T>) obj);
        }

        public override int GetHashCode()
        {
            return identity.GetHashCode();
        }

        public Guid Value => identity;
        public static implicit operator Guid(Identity<T> identity) => identity.identity;
    }
}