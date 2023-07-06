using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Commands.MarkAsPaid
{
    public class MarkAsPaidCommandHandler : IRequestHandler<MarkAsPaidCommand>
    {
        private readonly IOrderRepository orderRepository;

        public MarkAsPaidCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(MarkAsPaidCommand request, CancellationToken cancellationToken)
        {
            await orderRepository.MarkAsPaid(request.OrderId);
            return Unit.Value;
        }
    }
}
