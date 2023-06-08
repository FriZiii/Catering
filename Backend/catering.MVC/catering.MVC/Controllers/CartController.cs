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

        public IActionResult Index()
        {
            var cart = cartService.Get();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productID)
        {
            var product = await offerService.GetById(productID);
            if (product == null)
            {
                return NotFound();
            }
            cartService.Add(product);
            var currentCart = cartService.Get();
            return RedirectToAction("Index", "Offer");
        }
    }
}
