using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
