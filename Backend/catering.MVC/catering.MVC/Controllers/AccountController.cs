using catering.Application.Managements.AccountManagment.Commands.Login;
using catering.Application.Managements.AccountManagment.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            await mediator.Send(loginCommand);

            if (loginCommand.Result.Succeeded)
            {
                await Console.Out.WriteLineAsync("Logged in");
            }
            else
            {
                Console.Out.WriteLine(loginCommand.Result);
            }
            return View(loginCommand);
        }
    }
}
