using AutoMapper;
using catering.Application.Managements.AccountManagment.AccountDtos;
using catering.Domain.Interface;
using MediatR;
using System.Security.Claims;

namespace catering.Application.Managements.AccountManagment.Querries.GetCurrentUser
{
    public class GetCurrentUserQuerryHandler : IRequestHandler<GetCurrentUserQuerry, CurrentUser>
    {
        private readonly IMapper mapper;
        private readonly IAccountRepository accountRepository;

        public GetCurrentUserQuerryHandler(IMapper mapper, IAccountRepository accountRepository)
        {
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }

        public async Task<CurrentUser?> Handle(GetCurrentUserQuerry request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? user = accountRepository.GetCurrentUser();
            if(user is not null)
            {
                var currentUser = mapper.Map<CurrentUser>(user);
                return currentUser;
            }
            return null;
        }
    }
}
