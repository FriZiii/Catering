using catering.Domain.Entities.OrderEntities;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Queries.GetAllOrders
{
    public class GetAllOrdersQuerry : IRequest<IEnumerable<Order>>
    {

    }
}
