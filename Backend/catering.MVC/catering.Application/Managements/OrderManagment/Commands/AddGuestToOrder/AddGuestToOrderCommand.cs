using catering.Application.Managements.OrderManagment.OrderDto;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Commands.AddGuestToOrder
{
    public class AddGuestToOrderCommand : IRequest
    {
        public AddGuestToOrderCommand(int orderId, GuestAdressDto guestAdressDto)
        {
            OrderId = orderId;
            GuestAdressDto = guestAdressDto;
        }

        public int OrderId { get; }
        public GuestAdressDto GuestAdressDto { get; }
    }
}
