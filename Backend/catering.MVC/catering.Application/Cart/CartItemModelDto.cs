using catering.Domain.Entities;

namespace catering.Application.Cart
{
    public class CartItemModelDto
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
    }
}