using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;

namespace catering.Domain.Interface
{
    public interface ICartRepository
    {
        CartModel GetCart();
        void AddToCart(Product product);
        void Commit(CartModel cart);
    }
}
