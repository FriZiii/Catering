using catering.Application.Managements.OfferManagment.Queries.GetById;
using catering.Application.Managements.OrderManagment;
using catering.Domain.Entities.OrderEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Serializers
{
    public class PreDtoToDtoOrderItemSerialization
    {
        private readonly IMediator mediator;

        public PreDtoToDtoOrderItemSerialization(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<OrderItemDto> Serialize(PreOrderItemDto preOrderItemDto)
        {
            return new OrderItemDto
            {
                Dates = DateSerialization.SerializeDates(preOrderItemDto.Dates),
                Meals = MealSerialization.SerializeMeals(preOrderItemDto.Meals),
                Product = await mediator.Send(new GetByIdQuerry(preOrderItemDto.ProductId)),
                Calories = int.Parse(preOrderItemDto.Calories),
                Price = mediator.Send(new GetByIdQuerry(preOrderItemDto.ProductId)).Result.Price * preOrderItemDto.Dates.Count * preOrderItemDto.Meals.Count,
            };
        }
    }
}
