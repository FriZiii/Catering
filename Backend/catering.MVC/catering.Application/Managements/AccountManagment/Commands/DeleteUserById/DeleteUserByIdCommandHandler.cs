using catering.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Commands.DeleteUserById
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand>
    {
        private readonly IAccountRepository accountRepository;

        public DeleteUserByIdCommandHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<Unit> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            await accountRepository.DeleteUserById(request.Id);

            return Unit.Value;
        }
    }
}
