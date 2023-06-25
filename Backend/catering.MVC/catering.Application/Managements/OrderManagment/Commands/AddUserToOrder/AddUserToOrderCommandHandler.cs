using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Commands.AddUserToOrder
{
    public class AddUserToOrderCommandHandler : IRequestHandler<AddUserToOrderCommand>
    {
        private readonly IOrderRepository orderRepository;

        public AddUserToOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(AddUserToOrderCommand request, CancellationToken cancellationToken)
        {
            await orderRepository.AddUserToOrder(request.CurrentUser.Id, request.OrderId);
            return Unit.Value;
        }
    }
}
