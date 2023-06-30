using catering.Application.Managements.AccountManagment.Querries.GetCurrentUser;
using catering.Application.Managements.OfferManagment.Commands.AddProduct;
using catering.Application.Managements.OfferManagment.Queries.GetAllProducts;
using catering.Application.Managements.OrderManagment.Queries.GetOrderByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class OfferController : Controller
    {
        private readonly IMediator mediator;

        public OfferController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var products = await mediator.Send(new GetAllProductsQuery());
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
