using catering.Domain.Entities.User.AppUser;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using catering.Infrastructure.Repositories;
using catering.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace catering.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<StoreContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ProductSeeder>();
            services.AddScoped<DiscountCodeSeeder>();

            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDiscountCodeRepository, DiscountCodeRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<UserManager<AppUser>>();

            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevCon")));

            services.Configure<IdentityOptions>(options =>
            {
                // Remove password requirements
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 1; // Set minimum password length
            });
        }
    }
}
