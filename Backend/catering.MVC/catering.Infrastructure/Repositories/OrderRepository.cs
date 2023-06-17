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

        public async Task DeleteOrderById(int id)
        {
            var orderToDelete = await context.Orders.Where(order => order.Id == id).FirstOrDefaultAsync();
            if (orderToDelete != null) 
            {
                context.Orders.Remove(orderToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderItemById(int id)
        {
            var orderItemToDelete = await context.OrderItems.Where(orderItem => orderItem.Id == id).FirstOrDefaultAsync();
            if(orderItemToDelete != null)
            {
                context.OrderItems.Remove(orderItemToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Order?> GetOrderById(int id)
            => await context.Orders
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Dates)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Meals)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(p => p.Id == id);
    }
}
