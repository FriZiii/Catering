using catering.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class OfferController : Controller
    {
        private readonly StoreContext context;

        public OfferController(StoreContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = context.Products.ToList(); //TODO: Refactor
            return View(products);
        }
    }
}
