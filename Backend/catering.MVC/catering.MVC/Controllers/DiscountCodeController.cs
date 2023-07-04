using catering.Application.Managements.DiscountCodeManagment.Commands.DeleteDiscountCodeById;
using catering.Application.Managements.DiscountCodeManagment.Queries.GetAllDiscountCodes;
using catering.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(AdminDashboardViewModel adminDashboardViewModel)
        {
            await mediator.Send(adminDashboardViewModel.CreateDiscountCodeCommand);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await mediator.Send(new DeleteDiscountCodeByIdCommand(id));
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var discounts = await mediator.Send(new GetAllDiscountCodesQuerry());
            return Ok(discounts); 
        }
    }
}
