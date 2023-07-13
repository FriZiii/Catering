using catering.Domain.Interface.Repositories;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Commands.DeleteOrderById
{
    public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand>
    {
        private readonly IOrderRepository orderRepository;
        public DeleteOrderByIdCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
        {
            await orderRepository.DeleteOrderById(request.Id);
            return Unit.Value;
        }
    }
}
