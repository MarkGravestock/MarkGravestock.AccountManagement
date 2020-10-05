using System;

namespace Mark.Gravestock.AccountManagement.Domain.Core
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(string message) : base(message)
        {
        }
    }
}