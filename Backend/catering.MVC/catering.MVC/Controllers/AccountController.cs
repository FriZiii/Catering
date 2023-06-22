using catering.Application.Managements.AccountManagment.AccountDtos;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputDto registerInputDto)
        {
            return View();
        }
    }
}
