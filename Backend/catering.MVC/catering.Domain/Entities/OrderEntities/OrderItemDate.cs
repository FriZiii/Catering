using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.OrderEntities
{
    public class OrderItemDate
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public DateTime Date { get; set; }
        public OrderItem OrderItem { get; set; } = null!;
    }
}
