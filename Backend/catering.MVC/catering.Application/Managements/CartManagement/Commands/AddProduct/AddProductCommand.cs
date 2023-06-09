using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Commands.AddProduct
{
    public class AddProductCommand : IRequest
    {
        public int Id { get; }

        public AddProductCommand(int id)
        {
            Id = id;
        }
    }
}
