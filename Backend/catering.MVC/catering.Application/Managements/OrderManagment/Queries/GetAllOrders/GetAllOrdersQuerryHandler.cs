using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.Queries.GetAllOrders
{
    public class GetAllOrdersQuerryHandler : IRequestHandler<GetAllOrdersQuerry, IEnumerable<Order>>
    {
        private readonly IOrderRepository orderRepository;

        public GetAllOrdersQuerryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuerry request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetAllOrders();
            return orders;
        }
    }
}
