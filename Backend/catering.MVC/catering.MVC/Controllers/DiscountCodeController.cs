using catering.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class DiscountCodeController : Controller
    {
        private readonly IMediator mediator;

        public DiscountCodeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Create(AdminDashboardViewModel adminDashboardViewModel)
        {
            await mediator.Send(adminDashboardViewModel.CreateDiscountCodeCommand);
            return Ok();
        }
    }
}
