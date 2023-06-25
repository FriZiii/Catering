using AutoMapper;
using catering.Application.Managements.AccountManagment.AccountDtos;
using catering.Application.Managements.AccountManagment.Commands;
using catering.Application.Managements.CartManagement;
using catering.Application.Managements.OfferManagment;
using catering.Application.Managements.OrderManagment;
using catering.Application.Managements.OrderManagment.OrderDto;
using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;
using catering.Domain.Entities.OrderEntities;
using catering.Domain.Entities.User.AppUser;
using catering.Domain.Entities.User.LoginInput;
using catering.Domain.Entities.User.RegisterInput;
using System.Security.Claims;

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

            CreateMap<RegisterInputDto, AccountRegisterInput>()
              .ForMember(dest => dest.DeliveryAdress, opt => opt.MapFrom(src => new DeliveryAdressInput
              {
                  Adress1 = src.Adress1,
                  Adress2 = src.Adress2,
                  PostalCode = src.PostalCode,
                  State = src.State,
                  Country = src.Country,
                  PhoneNumber = src.PhoneNumber
              }));

            CreateMap<LoginInputDto, LoginInput>();

            CreateMap<ClaimsPrincipal, CurrentUser>()
                .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value))
                .ForMember(desc => desc.Email, opt => opt.MapFrom(src => src.FindFirst(c => c.Type == ClaimTypes.Email)!.Value))
                .ForMember(desc => desc.Roles, opt => opt.MapFrom(src => src.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value)));

            CreateMap<GuestAdressDto, UserDeliveryAdress>();
        }
    }
}
