using System;

namespace Mark.Gravestock.AccountManagement.Domain.Core
{
    public class Identity<T>
    {
        protected Identity(Guid identity)
        {
            Value = identity;
        }

        public Guid Value { get; }

        private bool Equals(Identity<T> other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Identity<T>) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator Guid(Identity<T> identity)
        {
            return identity.Value;
        }
    }
}