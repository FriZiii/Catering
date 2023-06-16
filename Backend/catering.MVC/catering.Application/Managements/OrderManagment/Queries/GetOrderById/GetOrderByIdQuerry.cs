using catering.Domain.Entities.OrderEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.Queries.GetOrderById
{
    public class GetOrderByIdQuerry : IRequest<Order>
    {
        public int Id { get; }

        public GetOrderByIdQuerry(int id)
        {
            Id = id;
        }
    }
}
