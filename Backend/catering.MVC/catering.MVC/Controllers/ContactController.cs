using catering.Application.Managements.MessageManagement.MessageDto;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class ContactController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Submit(MessageDto messageDto)
        {
            return RedirectToAction("Index");
        }
    }
}
