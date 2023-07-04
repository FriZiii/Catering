using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.DiscountCodeManagment
{
    public class DiscountCodeDto
    {
        public string Code { get; set; } = default!;
        public int DiscountPercentage { get; set; }
        public DateTime Expiration { get; set; }
    }
}
