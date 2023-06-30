using AutoMapper;
using catering.Application.Managements.AccountManagment.AccountDtos;
using catering.Application.Managements.OrderManagment.Queries.GetOrderByUserId;
using catering.Domain.Interface;
using MediatR;
using System.Security.Claims;

namespace catering.Application.Managements.AccountManagment.Querries.GetCurrentUser
{
    public class GetCurrentUserQuerryHandler : IRequestHandler<GetCurrentUserQuerry, CurrentUser>
    {
        private readonly IMapper mapper;
        private readonly IAccountRepository accountRepository;
        private readonly IMediator mediator;

        public GetCurrentUserQuerryHandler(IMapper mapper, IAccountRepository accountRepository, IMediator mediator)
        {
            this.mapper = mapper;
            this.accountRepository = accountRepository;
            this.mediator = mediator;
        }

        public async Task<CurrentUser?> Handle(GetCurrentUserQuerry request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? user = accountRepository.GetCurrentUser();
            if(user is not null)
            {
                var currentUser = mapper.Map<CurrentUser>(user);
                currentUser.Orders = await mediator.Send(new GetOrdersByUserIdQuerry(currentUser.Id));
                return currentUser;
            }
            return null;
        }
    }
}
