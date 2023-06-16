using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Queries.GetOrderById
{
    public class GetOrderByIdQuerryHandler : IRequestHandler<GetOrderByIdQuerry, Order>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderByIdQuerryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuerry request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetOrderById(request.Id);

            return order!;
        }
    }
}
