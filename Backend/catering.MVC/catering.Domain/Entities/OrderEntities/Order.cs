using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.OrderEntities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderItem> OrderItems { get; set; } = null!;
        public Order(List<OrderItem> orderItems)
        {
            OrderItems = orderItems;
            OrderDate = DateTime.Now;
            TotalPrice = orderItems.Sum(i => i.Price);
        }
    }
}
