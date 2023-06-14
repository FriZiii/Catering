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
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Calories { get; set; }
        public HashSet<DateTime> Dates { get; set; } = new HashSet<DateTime>();
        public HashSet<string> Meals { get; set; } = new HashSet<string>();


        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
