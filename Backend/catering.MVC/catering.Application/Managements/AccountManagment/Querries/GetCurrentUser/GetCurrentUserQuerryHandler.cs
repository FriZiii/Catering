using AutoMapper;
using catering.Application.Managements.AccountManagment.AccountDtos;
using catering.Domain.Entities.User.AppUser;
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
            ClaimsPrincipal? currentUserClaims = accountRepository.GetCurrentUser();
            AppUser? currentAppUser = await accountRepository.GetAppUserById(currentUserClaims!.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            if(currentAppUser is not null)
            {
                var currentUser = mapper.Map<CurrentUser>(currentUserClaims);
                currentUser.Orders = currentAppUser.Orders;
                currentUser.DeliveryAdress = currentAppUser.DeliveryAdress;
                currentUser.FirstName = currentAppUser.FirstName;
                currentUser.LastName = currentAppUser.LastName;
                currentUser.BirthDate = currentAppUser.BirthDate;

                return currentUser;
            }
            return null;
        }
    }
}
