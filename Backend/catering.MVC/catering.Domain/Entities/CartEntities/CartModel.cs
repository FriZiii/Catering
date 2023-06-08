using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.CartEntities
{
    public class CartModel
    {
        public List<Product> CartProducts { get; set; }
        public CartModel()
        {
            CartProducts = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            CartProducts.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            CartProducts.Remove(product);
        }
    }
}
