using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace catering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;

        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<int> AddOrder(Order order)
        {
            context.Add(order);
            await context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<Order?> GetOrderById(int id)
            => await context.Orders.FirstOrDefaultAsync(p => p.Id == id);
    }
}
