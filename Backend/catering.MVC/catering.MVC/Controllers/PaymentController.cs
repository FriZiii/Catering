using catering.Application.Managements.OrderManagment.Commands.MarkAsPaid;
using catering.Application.Managements.OrderManagment.Queries.GetOrderIdFromCookies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Paid()
        {
            int orderId = await mediator.Send(new GetOrderIdFromCookiesQuery());
            await mediator.Send(new MarkAsPaidCommand(orderId));
            return Ok();
        }
    }
}
