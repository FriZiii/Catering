using catering.Application.Managements.CartManagement;

namespace catering.Application.Managements.CartManagement
{
    public class CartModelDto
    {
        public List<CartItemModelDto> CartItems { get; set; } = default!;
    }
}
