using catering.Domain.Entities;
using catering.Domain.Entities.OrderEntities;
using catering.Domain.Entities.User.AppUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace catering.Infrastructure.Persistence
{
    public class StoreContext : IdentityDbContext<AppUser>
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItemDate> OrderItemsDates { get; set; } = null!;
        public DbSet<OrderItemMeal> OrderItemMeals { get; set; } = null!;
        public DbSet<DiscountCode> DiscountCodes { get; set; } = null!;
        public DbSet<DeliveryAdress> DeliveryAddresses { get; set; } = null!;
        public DbSet<Guest> Guests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
