using catering.Application.Helpers;
using catering.Application.Managements.AccountManagment.Commands.Logout;
using catering.Application.Managements.AccountManagment.Commands.Register;
using catering.Application.Managements.AccountManagment.Querries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace catering.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;
        private readonly ReturnUrl returnUrl;

        public AccountController(IMediator mediator, ReturnUrl returnUrl)
        {
            this.mediator = mediator;
            this.returnUrl = returnUrl;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var referer = Request.GetTypedHeaders().Referer;
            string url = returnUrl.GetReturnUrl(referer?.ToString()!);
            if (!ModelState.IsValid)
            {
                return View(registerCommand);
            }
            else
            {
                await mediator.Send(registerCommand);
                return Redirect(url);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginQuerry loginQuerry)
        {

            var referer = Request.GetTypedHeaders().Referer;
            string url = returnUrl.GetReturnUrl(referer?.ToString()!);
            if (ModelState.IsValid)
            {
                var result = await mediator.Send(loginQuerry);

                if (result.Succeeded)
                {
                    return Redirect(url);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(loginQuerry);
                }
            }
            else
            {
                return View(loginQuerry); ;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await mediator.Send(new LogoutCommand());
            return Redirect(returnUrl);
        }

    }
}
