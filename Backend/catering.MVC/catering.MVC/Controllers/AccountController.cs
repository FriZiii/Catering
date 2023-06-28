using catering.Application.Helpers;
using catering.Application.Managements.AccountManagment.Commands.Logout;
using catering.Application.Managements.AccountManagment.Commands.Register;
using catering.Application.Managements.AccountManagment.Querries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;
        private readonly ReturnUrlHelper returnUrlHelper;

        public AccountController(IMediator mediator, ReturnUrlHelper returnUrlHelper)
        {
            this.mediator = mediator;
            this.returnUrlHelper = returnUrlHelper;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var referer = Request.GetTypedHeaders().Referer;
            string returnUrl = returnUrlHelper.GetReturnUrl(referer?.ToString()!);
            if (!ModelState.IsValid)
            {
                return View(registerCommand);
            }
            else
            {
                await mediator.Send(registerCommand);
                return Redirect(returnUrl);
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
            string returnUrl = returnUrlHelper.GetReturnUrl(referer?.ToString()!);
            if (ModelState.IsValid)
            {
                var result = await mediator.Send(loginQuerry);

                if (result.Succeeded)
                {
                    return Redirect(returnUrl);
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
