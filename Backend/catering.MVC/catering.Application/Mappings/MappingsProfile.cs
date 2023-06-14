using AutoMapper;
using catering.Application.Managements.CartManagement.Cart;
using catering.Application.Managements.OfferManagment;
using catering.Application.Managements.OfferManagment.Queries.GetById;
using catering.Application.Managements.OrderManagment;
using catering.Application.Managements.OrderManagment.PreSubmit;
using catering.Application.Serializers;
using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;
using catering.Domain.Entities.OrderEntities;
using catering.Domain.Interface;
using MediatR;

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
                .ForMember(dest => dest.Calories, opt => opt.MapFrom(src => int.Parse(src.Calories)))
                .ForMember(dest => dest.Dates, opt => opt.MapFrom(src => DateSerializer.SerializeDates(src.Dates)))
                .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => new HashSet<string>(src.Meals)));
        }
    }
}
