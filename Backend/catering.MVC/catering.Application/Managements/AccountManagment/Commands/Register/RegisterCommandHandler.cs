using AutoMapper;
using catering.Domain.Entities.User.RegisterInput;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.AccountManagment.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IMapper mapper;
        private readonly IAccountRepository accountRepository;

        public RegisterCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerInput = mapper.Map<AccountRegisterInput>(request);
            await accountRepository.RegisterUser(registerInput);
            return Unit.Value;
        }
    }
}
