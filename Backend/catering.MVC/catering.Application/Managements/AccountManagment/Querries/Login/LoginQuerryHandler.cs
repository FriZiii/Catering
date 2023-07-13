using AutoMapper;
using catering.Domain.Entities.User.LoginInput;
using catering.Domain.Interface.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Querries.Login
{
    public class LoginQuerryHandler : IRequestHandler<LoginQuerry, SignInResult>
    {
        private readonly IMapper mapper;
        private readonly IAccountRepository accountRepository;

        public LoginQuerryHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }

        public async Task<SignInResult> Handle(LoginQuerry request, CancellationToken cancellationToken)
        {
            var loginInput = mapper.Map<LoginInput>(request);
            var result = await accountRepository.LoginUser(loginInput);
            return result;
        }
    }
}
