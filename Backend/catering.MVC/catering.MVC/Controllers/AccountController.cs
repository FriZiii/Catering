﻿using catering.Application.Managements.AccountManagment.Commands.Login;
using catering.Application.Managements.AccountManagment.Commands.Logout;
using catering.Application.Managements.AccountManagment.Commands.Register;
using catering.Domain.Entities.User.AppUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web;

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

            var referer = Request.GetTypedHeaders().Referer;
            string returnUrl = referer?.ToString()!;

            if (!string.IsNullOrEmpty(returnUrl))
            {
                Uri uri = new Uri(returnUrl);
                string decodedReturnUrl;
                if (uri.Query.Contains('?'))
                {
                    decodedReturnUrl = HttpUtility.UrlDecode(uri.Query.TrimStart('?')).Replace("returnUrl=", "");
                }
                else
                {
                    decodedReturnUrl = uri.LocalPath;
                }

                return Redirect(decodedReturnUrl);
            }
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

            var referer = Request.GetTypedHeaders().Referer;
            string returnUrl = referer?.ToString()!;

            if (!string.IsNullOrEmpty(returnUrl))
            {
                Uri uri = new Uri(returnUrl);
                string decodedReturnUrl;
                if (uri.Query.Contains('?'))
                {
                    decodedReturnUrl = HttpUtility.UrlDecode(uri.Query.TrimStart('?')).Replace("returnUrl=", "");
                }
                else
                {
                    decodedReturnUrl = uri.LocalPath;
                }

              return Redirect(decodedReturnUrl);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await mediator.Send(new LogoutCommand());
            return RedirectToAction("Index", "Home");
        }

    }
}
