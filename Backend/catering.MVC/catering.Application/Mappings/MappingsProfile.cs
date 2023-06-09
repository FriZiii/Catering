using AutoMapper;
using catering.Application.DTO.Cart;
using catering.Application.DTO.Offer;
using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;
using catering.Domain.Interface;

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
        }
    }
}
