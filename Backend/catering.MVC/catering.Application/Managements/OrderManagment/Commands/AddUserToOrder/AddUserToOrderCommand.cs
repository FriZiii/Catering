using catering.Application.Managements.AccountManagment.AccountDtos;
using catering.Domain.Entities.OrderEntities;
using MediatR;

namespace catering.Application.Managements.OrderManagment.Commands.AddUserToOrder
{
    public class AddUserToOrderCommand : IRequest
    {
        public CurrentUser CurrentUser { get; }
        public int OrderId { get; }

        public AddUserToOrderCommand(CurrentUser currentUser, int orderId)
        {
            CurrentUser = currentUser;
            OrderId = orderId;
        }
    }
}
