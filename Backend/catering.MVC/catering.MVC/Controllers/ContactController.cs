using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class ContactController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
