using catering.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.Commands.DeleteOrderItemById
{
    public class DeleteOrderItemByIdCommandHandler : IRequestHandler<DeleteOrderItemByIdCommand>
    {
        private readonly IOrderRepository orderRepository;

        public DeleteOrderItemByIdCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteOrderItemByIdCommand request, CancellationToken cancellationToken)
        {
            await orderRepository.DeleteOrderItemById(request.Id);
            return Unit.Value;
        }
    }
}
