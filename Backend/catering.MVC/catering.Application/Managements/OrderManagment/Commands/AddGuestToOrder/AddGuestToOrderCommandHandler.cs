using AutoMapper;
using catering.Domain.Entities.User.AppUser;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Commands.AddGuestToOrder
{
    public class AddGuestToOrderCommandHandler : IRequestHandler<AddGuestToOrderCommand>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public AddGuestToOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(AddGuestToOrderCommand request, CancellationToken cancellationToken)
        {
            var deliveryAdress = mapper.Map<DeliveryAdress>(request.GuestAdressDto);
            await orderRepository.AddGuestToOrder(deliveryAdress, request.OrderId);
            return Unit.Value;
        }
    }
}
