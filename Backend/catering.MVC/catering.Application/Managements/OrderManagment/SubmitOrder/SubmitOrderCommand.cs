using MediatR;

namespace catering.Application.Managements.OrderManagment.SubmitOrder
{
    public class SubmitOrderCommand :IRequest
    {
        public List<OrderItemDto> OrderItems { get; set; } = default!;
        public SubmitOrderCommand(List<OrderItemDto> orderItems)
        {
            OrderItems = orderItems;
        }
    }
}
