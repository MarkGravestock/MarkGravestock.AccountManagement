using System.Threading;
using System.Threading.Tasks;
using Mark.Gravestock.AccountManagement.Application.Core;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Optional;

namespace Mark.Gravestock.AccountManagement.Application.Accounts
{
    internal class GetAccountQueryHandler : IQueryHandler<GetAccountQuery, Option<Account>>
    {
        private readonly IAccountRepository accountRepository;

        public GetAccountQueryHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<Option<Account>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            return await accountRepository.GetAsync(new AccountId(request.AccountId));
        }
    }
}