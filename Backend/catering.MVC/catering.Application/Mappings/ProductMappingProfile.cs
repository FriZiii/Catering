using AutoMapper;
using catering.Application.Offer;
using catering.Domain.Entities;

namespace catering.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
