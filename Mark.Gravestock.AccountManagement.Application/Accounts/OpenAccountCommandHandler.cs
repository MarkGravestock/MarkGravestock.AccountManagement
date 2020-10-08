using System;
using System.Threading;
using System.Threading.Tasks;
using Mark.Gravestock.AccountManagement.Application.Core;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Mark.Gravestock.AccountManagement.Domain.Customer;
using NodaMoney;

namespace Mark.Gravestock.AccountManagement.Application.Accounts
{
    internal class OpenAccountCommandHandler : ICommandHandler<OpenAccountCommand, Guid>
    {
        private readonly IAccountRepository accountRepository;

        public OpenAccountCommandHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        
        public async Task<Guid> Handle(OpenAccountCommand request, CancellationToken cancellationToken)
        {
            var newAccount = Account.Open(new CustomerId(request.CustomerId), Money.PoundSterling(request.InitialBalance));

            await accountRepository.SaveAsync(newAccount);

            return newAccount.Id;
        }
    }
}