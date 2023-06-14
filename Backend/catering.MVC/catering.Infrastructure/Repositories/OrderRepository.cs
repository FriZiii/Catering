using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;

namespace catering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;

        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task AddOrder(Order order)
        {
            context.Add(order);
            await context.SaveChangesAsync();
        }
    }
}
