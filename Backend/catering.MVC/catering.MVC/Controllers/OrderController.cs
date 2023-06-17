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

        [HttpPost]
        public async Task<IActionResult> Confirm([FromForm] int orderId)
        {
            var order = await mediator.Send(new GetOrderByIdQuerry(orderId));
            return View(order);
        }
    }
}
