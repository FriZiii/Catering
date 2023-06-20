using catering.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.DiscountCodeManagment.Commands.ApplyDiscountCode
{
    public class ApplyDiscountCodeCommand : IRequest
    {
        public int OrderId { get; }
        public DiscountCode DiscountCode { get; }
        public ApplyDiscountCodeCommand(int orderId, DiscountCode discountCode)
        {
            OrderId = orderId;
            DiscountCode = discountCode;
        }
    }
}
