using catering.Application.Managements.DiscountCodeManagment.Commands.CreateDiscountCode;
using catering.Application.Managements.DiscountCodeManagment.Commands.DeleteDiscountCodeById;
using catering.Application.Managements.DiscountCodeManagment.Queries.GetAllDiscountCodes;
using catering.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task<IActionResult> Create(CreateDiscountCodeCommand createDiscountCodeCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await mediator.Send(createDiscountCodeCommand);
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
