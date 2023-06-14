using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment
{
    public class PreOrderItemDto
    {
        public int ProductId { get; set; }
        public string Calories { get; set; } = default!;
        public List<string> Meals { get; set; } = new List<string>();
        public List<string> Dates { get; set; } = new List<string>();
    }
}
