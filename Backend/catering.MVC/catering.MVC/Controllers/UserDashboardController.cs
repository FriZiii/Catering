using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class UserDashboardController : Controller
    {
        public UserDashboardController()
        {
            
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
