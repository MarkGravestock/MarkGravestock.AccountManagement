namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public class Account
    {
        public Account(AccountId accountId, CustomerId customerId)
        {
            Id = accountId;
            CustomerId = customerId;
        }

        public CustomerId CustomerId { get; }

        public AccountId Id { get; }

        public static Account CreateFor(CustomerId customerId)
        {
            return new Account(AccountId.Create(), customerId);
        }
    }
}