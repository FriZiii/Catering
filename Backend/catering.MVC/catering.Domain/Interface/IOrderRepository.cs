using catering.Domain.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Interface
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
    }
}
