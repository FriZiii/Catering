using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Commands.AddProduct
{
    public class AddProductByIdCommand : IRequest
    {
        public int Id { get; }

        public AddProductByIdCommand(int id)
        {
            Id = id;
        }
    }
}
