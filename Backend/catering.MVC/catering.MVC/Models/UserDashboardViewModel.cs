using catering.Domain.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.MVC.Models
{
    public class UserDashboardViewModel
    {
        public IEnumerable<Order> Orders { get; set; } = default!;

    }   
}
