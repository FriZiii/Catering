using catering.Application.Offer;
using catering.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IOfferService offerService;

        public CartController(ICartService cartService, IOfferService offerService)
        {
            this.cartService = cartService;
            this.offerService = offerService;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await cartService.Get();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productID)
        {
            cartService.Add(productID);
            return RedirectToAction("Index", "Offer");
        }
    }
}
