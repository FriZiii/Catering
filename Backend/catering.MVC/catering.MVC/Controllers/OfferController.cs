using catering.Application.DTO.Offer;
using catering.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await offerService.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if(!ModelState.IsValid)
            {
                return View(productDto);
            }
            await offerService.Create(productDto);
            return RedirectToAction("Index");
        }
    }
}
