using catering.Application.Managements.CartManagement.Commands.AddProduct;
using catering.Application.Managements.CartManagement.Commands.DeleteProduct;
using catering.Application.Managements.CartManagement.Queries.GetCart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IMediator mediator;

        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await mediator.Send(new GetCartQuery());
            return View(cart);
        }

        public async Task<IActionResult> Delete(int cartItemID)
        {
            await mediator.Send(new DeleteCartProductByIdCommand(cartItemID));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productID)
        {
            await mediator.Send(new AddProductByIdCommand(productID));
            return RedirectToAction("Index", "Offer");
        }
    }
}
