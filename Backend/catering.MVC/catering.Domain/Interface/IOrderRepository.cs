using catering.Domain.Entities.OrderEntities;
using catering.Domain.Entities.User.AppUser;
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
        Task AddGuestToOrder(DeliveryAdress deliveryAdress, int orderId);
        Task<IEnumerable<Order>> GetAllOrders();
        Task ConfirmOrder(int orderId);
        Task MarkAsPaid(int orderId);
    }
}
