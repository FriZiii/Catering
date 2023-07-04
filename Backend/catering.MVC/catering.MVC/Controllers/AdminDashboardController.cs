using catering.Application.Managements.OrderManagment.Queries.GetAllOrders;
using catering.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IMediator mediator;

        public AdminDashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var orders = await mediator.Send(new GetAllOrdersQuerry());

            var dashboardViewModel = new AdminDashboardViewModel()
            {
                Orders = orders,
            };

            return View(dashboardViewModel);
        }
    }
}
