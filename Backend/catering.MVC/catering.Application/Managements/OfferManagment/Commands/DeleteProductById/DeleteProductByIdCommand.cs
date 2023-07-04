using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OfferManagment.Commands.DeleteProductById
{
    public class DeleteProductByIdCommand : IRequest
    {
        public DeleteProductByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
