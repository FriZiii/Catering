using catering.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Commands.Logout
{
    public class LogoutCommandHanlder : IRequestHandler<LogoutCommand>
    {
        private readonly IAccountRepository accountRepository;

        public LogoutCommandHanlder(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await accountRepository.LogoutUser();
            return Unit.Value;
        }
    }
}
