using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class AdminDashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
