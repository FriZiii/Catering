using AutoMapper;
using catering.Application.Cart;
using catering.Application.Offer;
using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;
using catering.Domain.Interface;

namespace catering.Application.Mappings
{
    public class MappingsProfile : Profile
    {
        private readonly IOfferRepository? offerRepository;

        public MappingsProfile()
        { 
        }

        public MappingsProfile(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;

            CreateMap<ProductDto, Product>();

            CreateMap<CartItemModel, CartItemModelDto>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => offerRepository.GetById(src.ProductID).Result));
        }
    }
}
