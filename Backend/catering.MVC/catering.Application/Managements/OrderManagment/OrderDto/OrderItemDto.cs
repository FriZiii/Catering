using catering.Domain.Entities;
using catering.Domain.Entities.OrderEntities;

namespace catering.Application.Managements.OrderManagment
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Calories { get; set; }

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public ICollection<OrderItemDateDto> Dates { get; set; } = new HashSet<OrderItemDateDto>();
        public ICollection<OrderItemMealDto> Meals { get; set; } = new HashSet<OrderItemMealDto>();

    }
}
