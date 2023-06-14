using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.OrderEntities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Calories { get; set; }

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public ICollection<OrderItemDate> Dates { get; set; } = new HashSet<OrderItemDate>();
        public ICollection<OrderItemMeal> Meals { get; set; } = new HashSet<OrderItemMeal>();
    }
}
