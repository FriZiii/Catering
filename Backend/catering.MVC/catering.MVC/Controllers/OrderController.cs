using catering.Application.Managements.OrderManagment;
using catering.Application.Managements.OrderManagment.SubmitOrder;
using catering.Application.Serializers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace catering.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator mediator;
        private readonly PreDtoToDtoOrderItemSerialization preDtoSerializer;

        public OrderController(IMediator mediator, PreDtoToDtoOrderItemSerialization preDtoSerializer)
        {
            this.mediator = mediator;
            this.preDtoSerializer = preDtoSerializer;
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] List<PreOrderItemDto> preOrderItemDtos)
        {
            var orderItemDtos = preOrderItemDtos.Select(
                async item => await preDtoSerializer.Serialize(item)).Select(t => t.Result).ToList();

            await mediator.Send(new SubmitOrderCommand(orderItemDtos));
            return RedirectToAction("Index", "Offer");
        }
    }
}
