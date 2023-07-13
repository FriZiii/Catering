using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;

namespace catering.Domain.Interface.Repositories
{
    public interface ICartRepository
    {
        CartModel GetCart();
        void AddToCart(int productID);
        void Commit(CartModel cart);
        void DeleteFromCart(int productID);
        void DeleteCartFromCookies();
    }
}
