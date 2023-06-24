using AutoMapper;
using catering.Domain.Entities.User.LoginInput;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.AccountManagment.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand>
    {
        private readonly IMapper mapper;
        private readonly IAccountRepository accountRepository;

        public LoginCommandHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }

        public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginInput = mapper.Map<LoginInput>(request);
            var result = await accountRepository.LoginUser(loginInput);
            request.Result = result;
            return Unit.Value;
        }
    }
}
