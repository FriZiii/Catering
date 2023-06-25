using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
