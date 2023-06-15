using catering.Application.Managements.OrderManagment;
using catering.Application.Managements.OrderManagment.SubmitOrder;
using catering.Application.Serializers;
using catering.Domain.Interface;
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

            var orderId = submitOrderCommand.OrderId;

            return RedirectToAction("Index", "Offer");
        }
    }
}
