using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.OrderEntities
{
    public class OrderItem
    {
        public string Calories { get; set; }
        public List<string> Meals { get; set; }
        public List<string> Dates { get; set; }
        public OrderItem()
        {
            Meals = new List<string>();
        }
    }
}
