using AutoMapper;
using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OrderManagment.SubmitOrder
{
    public class SubmitOrderCommandHandler : IRequestHandler<SubmitOrderCommand>
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;

        public SubmitOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
        {

            List<OrderItem> orderItems = mapper.Map<List<OrderItem>>(request.OrderItems);

            var newOrder = new Order()
            {
                OrderItems = orderItems,
                OrderDate = DateTime.Now,
                TotalPrice = orderItems.Select(c => c.Price).Sum(),
            };

            await orderRepository.AddOrder(newOrder);

            return Unit.Value;
        }
    }
}
