using System.Threading.Tasks;
using Optional;

namespace Mark.Gravestock.AccountManagement.Domain.Accounts
{
    public interface IAccountRepository
    {
        Task SaveAsync(Account account);
        Task<Option<Account>> GetAsync(AccountId accountId);
    }
}