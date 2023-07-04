using catering.Application.Managements.AccountManagment.Querries.GetCurrentUser;
using catering.Application.Managements.OfferManagment.Commands.AddProduct;
using catering.Application.Managements.OfferManagment.Commands.DeleteProductById;
using catering.Application.Managements.OfferManagment.Queries.GetAllProducts;
using catering.Application.Managements.OrderManagment.Queries.GetOrderByUserId;
using catering.MVC.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AdminDashboardViewModel adminDashboardViewModel)
        {
            await mediator.Send(adminDashboardViewModel.CreateProductCommand);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            await mediator.Send(new DeleteProductByIdCommand(id));
            return Ok();
        }
    }
}
