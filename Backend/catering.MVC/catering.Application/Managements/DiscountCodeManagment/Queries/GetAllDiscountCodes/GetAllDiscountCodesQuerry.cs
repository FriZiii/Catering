using catering.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.DiscountCodeManagment.Queries.GetAllDiscountCodes
{
    public class GetAllDiscountCodesQuerry : IRequest<IEnumerable<DiscountCode>>
    {

    }
}
