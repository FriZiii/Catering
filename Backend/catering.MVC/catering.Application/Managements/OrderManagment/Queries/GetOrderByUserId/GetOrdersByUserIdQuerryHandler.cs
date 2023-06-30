using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.Queries.GetOrderByUserId
{
    public class GetOrdersByUserIdQuerryHandler : IRequestHandler<GetOrdersByUserIdQuerry, IEnumerable<Order>>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrdersByUserIdQuerryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public Task<IEnumerable<Order>> Handle(GetOrdersByUserIdQuerry request, CancellationToken cancellationToken)
        {
            if(request.UserID is not null)
            {
                var userOrders = orderRepository.GetOrdersByUserId(request.UserID);
                return userOrders;
            }
            return null!;
        }
    }
}
