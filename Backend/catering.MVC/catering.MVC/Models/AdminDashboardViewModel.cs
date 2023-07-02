using catering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.MVC.Models
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Product> Products { get; set; } = null!;
    }
}
