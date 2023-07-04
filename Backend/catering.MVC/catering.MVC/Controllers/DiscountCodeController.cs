using catering.Application.Managements.DiscountCodeManagment.Commands.DeleteDiscountCodeById;
using catering.Application.Managements.DiscountCodeManagment.Queries.GetAllDiscountCodes;
using catering.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class DiscountCodeController : Controller
    {
        private readonly IMediator mediator;

        public DiscountCodeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminDashboardViewModel adminDashboardViewModel)
        {
            await mediator.Send(adminDashboardViewModel.CreateDiscountCodeCommand);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            await mediator.Send(new DeleteDiscountCodeByIdCommand(id));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var discounts = await mediator.Send(new GetAllDiscountCodesQuerry());
            return Ok(discounts); 
        }
    }
}
