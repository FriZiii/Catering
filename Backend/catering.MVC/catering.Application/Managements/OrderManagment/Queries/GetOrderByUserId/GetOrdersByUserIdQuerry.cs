using catering.Domain.Entities.OrderEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.Queries.GetOrderByUserId
{
    public class GetOrdersByUserIdQuerry : IRequest<IEnumerable<Order>>
    {
        public GetOrdersByUserIdQuerry(string userID)
        {
            UserID = userID;
        }

        public string UserID { get; }
    }
}
