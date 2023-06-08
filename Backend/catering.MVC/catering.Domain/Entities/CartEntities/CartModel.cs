using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.CartEntities
{
    public class CartModel
    {
        public List<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();

        public void AddProduct(int productID)
        {
            var cartItem = new CartItemModel()
            {
                Id = CartItems.Count,
                ProductID = productID,
            };
            CartItems.Add(cartItem);
        }

        public void RemoveProduct(CartItemModel cartItem)
        {
            CartItems.Remove(cartItem);
        }
    }
}
