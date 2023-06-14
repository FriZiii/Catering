using catering.Domain.Entities;
using catering.Domain.Entities.OrderEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace catering.Infrastructure.Persistence
{
    public class StoreContext : DbContext
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
