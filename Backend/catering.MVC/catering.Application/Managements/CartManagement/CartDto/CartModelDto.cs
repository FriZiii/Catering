using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Cart
{
    public class CartModelDto
    {
        public List<CartItemModelDto> CartItems { get; set; } = default!;
    }
}
