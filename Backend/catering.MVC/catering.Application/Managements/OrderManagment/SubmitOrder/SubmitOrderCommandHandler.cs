using catering.Application.Managements.OrderManagment.PreSubmit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OrderManagment.SubmitOrder
{
    public class SubmitOrderCommandHandler : IRequestHandler<SubmitOrderCommand>
    {
        public async Task<Unit> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
        {
            var x = request;
            return Unit.Value;
        }
    }
}
