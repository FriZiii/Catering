using catering.Application.Mappings;
using catering.Application.Offer;
using catering.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace catering.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<ICartService, CartService>();

            services.AddAutoMapper(typeof(MappingsProfile));

            services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
