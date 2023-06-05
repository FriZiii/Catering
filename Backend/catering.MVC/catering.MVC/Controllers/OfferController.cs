using catering.Application.Services;
using catering.Domain.Entities;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
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
        public async Task<IActionResult> Create(Product product)
        {
            await offerService.Create(product);
            return RedirectToAction("Index");
        }
    }
}
