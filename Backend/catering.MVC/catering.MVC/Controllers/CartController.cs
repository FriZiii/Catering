using catering.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await cartService.Get();
            return View(cart);
        }

        public IActionResult Delete(int cartItemID)
        {
            cartService.Delete(cartItemID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(int productID)
        {
            cartService.Add(productID);
            return RedirectToAction("Index", "Offer");
        }
    }
}
