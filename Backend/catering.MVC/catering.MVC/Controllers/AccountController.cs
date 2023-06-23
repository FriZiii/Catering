using catering.Application.Managements.AccountManagment.AccountDtos;
using catering.Application.Managements.AccountManagment.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace catering.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            if (!ModelState.IsValid)
            {
                return View(registerCommand);
            }
            await mediator.Send(registerCommand);
            return View();
        }
    }
}
