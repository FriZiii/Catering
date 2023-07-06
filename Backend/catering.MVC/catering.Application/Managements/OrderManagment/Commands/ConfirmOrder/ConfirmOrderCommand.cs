using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.Commands.ConfirmOrder
{
    public class ConfirmOrderCommand : IRequest
    {
        public ConfirmOrderCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
