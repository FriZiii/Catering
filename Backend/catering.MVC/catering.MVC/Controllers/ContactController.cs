using catering.Application.Managements.MessageManagement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMediator mediator;

        public ContactController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Submit(SendContactFormCommand sendContactFormCommand)
        {
            await mediator.Send(sendContactFormCommand);
            return RedirectToAction("Index");
        }
    }
}
