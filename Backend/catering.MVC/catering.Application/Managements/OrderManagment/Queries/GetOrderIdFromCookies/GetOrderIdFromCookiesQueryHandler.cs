using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Queries.GetOrderIdFromCookies
{
    public class GetOrderIdFromCookiesQueryHandler : IRequestHandler<GetOrderIdFromCookiesQuery, int>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderIdFromCookiesQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<int> Handle(GetOrderIdFromCookiesQuery request, CancellationToken cancellationToken)
        {
            int orderId = orderRepository.GetOrderIdFromCookies();
            if(orderId == 0)
            {
                return 0;
            }
            return orderId;
        }
    }
}
