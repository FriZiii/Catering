using MediatR;

namespace catering.Application.Managements.OrderManagment.PreSubmit
{
    public class SubmitOrderCommand : List<OrderItemDto>, IRequest
    {
    }
}
