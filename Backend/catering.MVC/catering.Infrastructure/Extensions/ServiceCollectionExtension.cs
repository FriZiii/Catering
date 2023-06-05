using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using catering.Infrastructure.Repositories;
using catering.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace catering.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevCon")));

            services.AddScoped<ProductSeeder>();
            services.AddScoped<IOfferRepository, OfferRepository>();
        }
    }
}
