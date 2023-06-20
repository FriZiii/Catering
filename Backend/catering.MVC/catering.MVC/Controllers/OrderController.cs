﻿using catering.Application.Managements.DiscountCodeManagment.Queries.GetDiscountCodeValue;
using catering.Application.Managements.OrderManagment;
using catering.Application.Managements.OrderManagment.Commands.DeleteOrderById;
using catering.Application.Managements.OrderManagment.Commands.DeleteOrderItemById;
using catering.Application.Managements.OrderManagment.Queries.GetOrderById;
using catering.Application.Managements.OrderManagment.SubmitOrder;
using catering.Application.Serializers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator mediator;
        private readonly OrderItemSerializer orderItemSerializer;

        public OrderController(IMediator mediator, OrderItemSerializer orderItemSerializer)
        {
            this.mediator = mediator;
            this.orderItemSerializer = orderItemSerializer;
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] List<PreOrderItemDto> preOrderItemDtos)
        {
            var submitOrderCommand = new SubmitOrderCommand(preOrderItemDtos
                .Select(async item => await orderItemSerializer.SerializePreDto(item))
                .Select(t => t.Result)
                .ToList());

            await mediator.Send(submitOrderCommand);

            return Ok(submitOrderCommand.OrderId.ToString());
        }

        public async Task<IActionResult> Confirm()
        {
            if (Request.Cookies.TryGetValue("orderId", out string? orderIdCookie) && int.TryParse(orderIdCookie, out int orderId))
            {
                var order = await mediator.Send(new GetOrderByIdQuerry(orderId));
                if (order.OrderItems.Any())
                {
                    return View(order);
                }
                else
                {
                    await mediator.Send(new DeleteOrderByIdCommand(orderId));
                    return RedirectToAction("Index", "Cart");
                }
            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> DeleteOrderItem(int orderItemId)
        {
            await mediator.Send(new DeleteOrderItemByIdCommand(orderItemId));
            return RedirectToAction("Confirm");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await mediator.Send(new DeleteOrderByIdCommand(orderId));
            return RedirectToAction("Index","Cart");
        }

        public async Task<IActionResult> ApplyDiscountCode(string discountCode)
        {
            var discount = await mediator.Send(new GetDiscountCodeQuery(discountCode));
            return RedirectToAction("Confirm");
        }
    }
}