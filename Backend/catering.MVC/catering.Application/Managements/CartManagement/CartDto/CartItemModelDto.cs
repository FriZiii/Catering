using catering.Domain.Entities;

namespace catering.Application.Managements.CartManagement.Cart
{
    public class CartItemModelDto
    {
        public int Id { get; set; }
        public Product Product { get; set; } = new Product();
    }
}