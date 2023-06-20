using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace catering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderRepository(StoreContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
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
                .Include(o => o.DiscountCode)
                .FirstOrDefaultAsync(p => p.Id == id);

        public int GetOrderIdFromCookies()
        {
            var httpContext = httpContextAccessor?.HttpContext;

            if (httpContext is null)
            {
                throw new InvalidOperationException("Cookies could not be accessed because HttpContext is null.");
            }

            var cookies = httpContext.Request.Cookies;  

            if(cookies.TryGetValue("orderId", out var orderIdCookie))
            {
                if(int.TryParse(orderIdCookie, out int orderId))
                {
                    return orderId;
                }    
            }
            return 0;
        }
    }
}
