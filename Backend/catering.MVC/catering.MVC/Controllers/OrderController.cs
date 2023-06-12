using AutoMapper;
using catering.Application.Managements.OrderManagment;
using catering.Application.Managements.OrderManagment.PreSubmit;
using catering.Application.Managements.OrderManagment.SubmitOrder;
using catering.Domain.Entities.OrderEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace catering.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public IActionResult Submit([FromBody] SubmitOrderCommand submitCommand)
        {
            mediator.Send(submitCommand);
            return RedirectToAction("Index", "Offer");
        }
    }
}
