using catering.Domain.Entities;
using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace catering.Infrastructure.Repositories
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly StoreContext context;
        private readonly IOrderRepository orderRepository;

        public DiscountCodeRepository(StoreContext context, IOrderRepository orderRepository)
        {
            this.context = context;
            this.orderRepository = orderRepository;
        }

        public async Task<DiscountCode?> GetDiscountCodeByCode(string code)
           => await context.DiscountCodes.FirstOrDefaultAsync(c => c.Code == code);

        public async Task SetDiscountCodeToOrder(int orderId, DiscountCode discountCode)
        {
            Order? order = await orderRepository.GetOrderById(orderId);
            if(order is not null)
            {
                order.DiscountCode = discountCode;
                order.DiscountCodeId = discountCode.Id;
                await context.SaveChangesAsync();
            }
        }
    }
}
