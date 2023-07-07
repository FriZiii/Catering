using catering.Domain.Entities.User.AppUser;
using MediatR;

namespace catering.Application.Managements.AccountManagment.Querries.GetDeliveryAdressByUserId
{
    public class GetDeliveryAdressByUserIdQuerry : IRequest<DeliveryAdress>
    {
        public GetDeliveryAdressByUserIdQuerry(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
