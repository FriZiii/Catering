using catering.Domain.Entities.User.AppUser;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.AccountManagment.Querries.GetDeliveryAdressByUserId
{
    public class GetDeliveryAdressByUserIdQuerryHandler : IRequestHandler<GetDeliveryAdressByUserIdQuerry, DeliveryAdress>
    {
        private readonly IAccountRepository accountRepository;

        public GetDeliveryAdressByUserIdQuerryHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<DeliveryAdress> Handle(GetDeliveryAdressByUserIdQuerry request, CancellationToken cancellationToken)
        {
            var userDeliveryAdress = await accountRepository.GetDeliveryAdressByUserId(request.UserId);
            return userDeliveryAdress;
        }
    }
}
