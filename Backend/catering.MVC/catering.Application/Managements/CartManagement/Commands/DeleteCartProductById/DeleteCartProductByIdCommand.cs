﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Commands.DeleteProduct
{
    public class DeleteCartProductByIdCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCartProductByIdCommand(int id)
        {
            Id = id;
        }
    }
}
