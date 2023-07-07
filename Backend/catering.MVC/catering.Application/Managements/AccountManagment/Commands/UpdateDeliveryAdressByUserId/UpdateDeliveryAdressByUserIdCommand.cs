using catering.Application.Managements.AccountManagment.AccountDtos;
using MediatR;

namespace catering.Application.Managements.AccountManagment.Commands.UpdateDeliveryAdressByUserId
{
    public class UpdateDeliveryAdressByUserIdCommand : IRequest
    {
        public UpdateDeliveryAdressByUserIdCommand(string userId, DeliveryAdressInputDto deliveryAdressInputDto)
        {
            UserId = userId;
            DeliveryAdressInputDto = deliveryAdressInputDto;
        }

        public string UserId { get; }
        public DeliveryAdressInputDto DeliveryAdressInputDto { get; }
    }
}
