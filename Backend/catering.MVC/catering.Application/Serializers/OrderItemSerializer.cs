using catering.Application.Managements.OfferManagment.Queries.GetById;
using catering.Application.Managements.OrderManagment;
using MediatR;

namespace catering.Application.Serializers
{
    public class OrderItemSerializer
    {
        private readonly IMediator mediator;

        public OrderItemSerializer(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OrderItemDto> SerializePreDto(PreOrderItemDto preOrderItemDto)
        {
            return new OrderItemDto
            {
                Dates = DateSerializer.SerializeDates(preOrderItemDto.Dates),
                Meals = MealSerializer.SerializeMeals(preOrderItemDto.Meals),
                Product = await mediator.Send(new GetProductByIdQuerry(preOrderItemDto.ProductId)),
                Calories = int.Parse(preOrderItemDto.Calories),
                Price = mediator.Send(new GetProductByIdQuerry(preOrderItemDto.ProductId)).Result.Price * preOrderItemDto.Dates.Count * preOrderItemDto.Meals.Count,
            };
        }
    }
}
