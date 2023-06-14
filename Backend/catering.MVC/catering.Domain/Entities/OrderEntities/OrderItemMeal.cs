using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.OrderEntities
{
    public class OrderItemMeal
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public string Meal { get; set; }
        public OrderItem OrderItem { get; set; } = null!;
    }
}
