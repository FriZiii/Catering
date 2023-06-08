using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;
using catering.Domain.Interface;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace catering.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CartRepository(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void AddToCart(Product product)
        {
            var cart = GetCart();
            cart.AddProduct(product);
            Commit(cart);
        }

        public CartModel GetCart()
        {
            var httpContext = httpContextAccessor?.HttpContext;

            if (httpContext is null)
            {
                throw new InvalidOperationException("Cookies could not be accessed because HttpContext is null.");
            }

            var cookies = httpContext.Request.Cookies;

            if (cookies.TryGetValue("Cart", out var cartJson))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var cart = JsonSerializer.Deserialize<CartModel>(cartJson, options)!;

                return cart;
            }

            var newCart = new CartModel();
            return newCart;
        }

        public void Commit(CartModel cart)
        {
            var httpContext = httpContextAccessor?.HttpContext;

            if (httpContext is null)
            {
                throw new InvalidOperationException("Cookies could not be accessed because HttpContext is null.");
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var cartJson = JsonSerializer.Serialize(cart, options)!;
            httpContext.Response.Cookies.Append("Cart", cartJson);
        }
    }
}
