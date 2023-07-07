using catering.Application.Managements.AccountManagment.Querries.GetCurrentUser;
using catering.Application.Managements.OrderManagment.Queries.GetOrderByUserId;
using catering.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class UserDashboardController : Controller
    {
        private readonly IMediator mediator;

        public UserDashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await mediator.Send(new GetCurrentUserQuerry());

            var userDashboardViewModel = new UserDashboardViewModel()
            {
                DeliveryAdress = user!.DeliveryAdress,
                Orders = await mediator.Send(new GetOrdersByUserIdQuerry(user!.Id)),
            };

            return View(userDashboardViewModel);
        }
    }
}
