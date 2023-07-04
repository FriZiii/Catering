using catering.Application.Managements.AccountManagment.Commands.DeleteUserById;
using catering.Application.Managements.AccountManagment.Querries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace catering.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await mediator.Send(new GetAllUsersQuerry());
            return Ok(users);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById(string id)
        {
            await mediator.Send(new DeleteUserByIdCommand(id));
            return Ok();
        }
    }
}
