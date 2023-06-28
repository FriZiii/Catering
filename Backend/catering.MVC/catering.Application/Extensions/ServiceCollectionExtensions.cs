using catering.Application.Helpers;
using catering.Application.Managements.OfferManagment.Commands.AddProduct;
using catering.Application.Managements.OfferManagment.Commands.CreateProduct;
using catering.Application.Mappings;
using catering.Application.Serializers;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace catering.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateProductCommand));

            services.AddAutoMapper(typeof(MappingsProfile));

            services.AddScoped<OrderItemSerializer>();

            services.AddScoped<ReturnUrlHelper>();

            services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
