using catering.Application.Managements.OfferManagment.Commands.AddProduct;
using catering.Application.Managements.OfferManagment.Commands.DeleteProductById;
using catering.Application.Managements.OfferManagment.Queries.GetAllProducts;
using catering.Application.Managements.OrderManagment.Queries.GetOrderIdFromCookies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
            int orderId = await mediator.Send(new GetOrderIdFromCookiesQuery());
            if (orderId != 0)
            {
                return RedirectToAction("Confirm", "Order");
            }
            var products = await mediator.Send(new GetAllProductsQuery());
            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await mediator.Send(createProductCommand);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            await mediator.Send(new DeleteProductByIdCommand(id));
            return Ok();
        }
    }
}
