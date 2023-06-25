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
        Task<int> AddOrder(Order order);
        Task DeleteOrderById(int id);
        Task DeleteOrderItemById(int id);
        Task<Order?> GetOrderById(int id);
        void RemoveOrderIdFromCookies();
        int GetOrderIdFromCookies();
        Task AddUserToOrder(string userId, int orderId);
    }
}
