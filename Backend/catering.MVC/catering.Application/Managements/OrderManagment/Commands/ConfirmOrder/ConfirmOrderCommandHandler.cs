using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Commands.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand>
    {
        private readonly IOrderRepository orderRepository;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            await orderRepository.ConfirmOrder(request.OrderId);
            return Unit.Value;
        }
    }
}
