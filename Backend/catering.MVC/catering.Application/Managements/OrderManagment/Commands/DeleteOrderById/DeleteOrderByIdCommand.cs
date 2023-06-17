using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.Commands.DeleteOrderById
{
    public class DeleteOrderByIdCommand : IRequest
    {
        public DeleteOrderByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
