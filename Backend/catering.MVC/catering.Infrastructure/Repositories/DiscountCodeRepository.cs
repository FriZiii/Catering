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

        public async Task CreateDiscountCode(DiscountCode discountCode)
        {
            await context.DiscountCodes.AddAsync(discountCode);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDiscountCodeById(int id)
        {
            var discountCodeToDelete = await context.DiscountCodes.FirstAsync(d => d.Id == id);
            context.DiscountCodes.Remove(discountCodeToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DiscountCode>> GetAllDiscountCodes()
            => await context.DiscountCodes.ToListAsync();

        public async Task<DiscountCode?> GetDiscountCodeByCode(string code)
           => await context.DiscountCodes.FirstOrDefaultAsync(c => c.Code == code);

        public async Task SetDiscountCodeToOrder(int orderId, DiscountCode discountCode)
        {
            Order? order = await orderRepository.GetOrderById(orderId);
            if(order is not null)
            {
                order.DiscountCode = discountCode;
                order.DiscountCodeId = discountCode.Id;
                order.TotalPriceAfterDiscount = order.TotalPriceBeforeDiscount - ((order.TotalPriceBeforeDiscount * order.DiscountCode.DiscountPercentage) / 100);
                await context.SaveChangesAsync();
            }
        }
    }
}
