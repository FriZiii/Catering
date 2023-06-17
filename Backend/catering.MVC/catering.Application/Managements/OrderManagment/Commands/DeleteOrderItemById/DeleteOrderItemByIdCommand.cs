using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.Commands.DeleteOrderItemById
{
    public class DeleteOrderItemByIdCommand : IRequest
    {
        public DeleteOrderItemByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
