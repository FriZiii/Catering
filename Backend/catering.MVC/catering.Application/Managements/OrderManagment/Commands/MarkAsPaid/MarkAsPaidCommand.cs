using MediatR;

namespace catering.Application.Managements.OrderManagment.Commands.MarkAsPaid
{
    public class MarkAsPaidCommand : IRequest
    {
        public MarkAsPaidCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
