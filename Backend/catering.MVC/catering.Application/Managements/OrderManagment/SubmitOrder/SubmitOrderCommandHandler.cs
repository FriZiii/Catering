using AutoMapper;
using catering.Application.Managements.OfferManagment.Queries.GetById;
using catering.Application.Managements.OrderManagment.PreSubmit;
using catering.Domain.Entities.OrderEntities;
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
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public SubmitOrderCommandHandler(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
        {
            List<OrderItem> orderItems = mapper.Map<List<OrderItemDto>, List<OrderItem>>(request);
            
            foreach (OrderItem item in orderItems)
            {
                item.Product = await mediator.Send(new GetByIdQuerry(item.ProductId));
                item.Price = item.Product.Price * item.Dates.Count * item.Meals.Count;
            }
            var newOrder = new Order(orderItems);
            return Unit.Value;
        }
    }
}
