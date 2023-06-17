using catering.Application.Managements.CartManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Queries.GetCart
{
    public class GetCartQuery : IRequest<CartModelDto>
    {

    }
}
