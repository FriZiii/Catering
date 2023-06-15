using AutoMapper;
using catering.Application.Managements.CartManagement.Cart;
using catering.Application.Managements.OfferManagment;
using catering.Application.Managements.OrderManagment;
using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;
using catering.Domain.Entities.OrderEntities;

namespace catering.Application.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<CartItemModel, CartItemModelDto>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(
                 src => new Product{
                     Id = src.ProductID,
                 }));


            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Order.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id));

            CreateMap<OrderItemMealDto, OrderItemMeal>();

            CreateMap<OrderItemDateDto, OrderItemDate>();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Dates, opt => opt.MapFrom(src => src.Dates))
                .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => src.Meals.Select(m => new OrderItemMealDto { Meal = m.Meal })));

            CreateMap<OrderItemMeal, OrderItemMealDto>();

            CreateMap<OrderItemDate, OrderItemDateDto>();

        }
    }
}
