using catering.Application.Managements.AccountManagment.AccountDtos;
using catering.Application.Managements.AccountManagment.Commands.UpdateDeliveryAdressByUserId;
using catering.Application.Managements.AccountManagment.Querries.GetCurrentUser;
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
            var currentUser = await mediator.Send(new GetCurrentUserQuerry());

            var userDashboardViewModel = new UserDashboardViewModel()
            {
                CurrentUser = currentUser!
            };

            return View(userDashboardViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateDeliveryAdress(DeliveryAdressInputDto deliveryAdressInputDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await mediator.Send(new GetCurrentUserQuerry());
            await mediator.Send(new UpdateDeliveryAdressByUserIdCommand(user!.Id, deliveryAdressInputDto));
            return Ok();
        }
    }
}
