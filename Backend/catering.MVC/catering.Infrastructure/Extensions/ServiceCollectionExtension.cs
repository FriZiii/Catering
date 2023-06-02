using catering.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace catering.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YummyDB;Trusted_Connection=True"));
        }
    }
}
