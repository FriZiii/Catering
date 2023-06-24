using catering.Infrastructure.Extensions;
using catering.Application.Extensions;
using catering.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();

//Seeding products
var scope = app.Services.CreateScope();
var productSeeder = scope.ServiceProvider.GetRequiredService<ProductSeeder>();
await productSeeder.Seed();
var discountCodeSeeder = scope.ServiceProvider.GetRequiredService<DiscountCodeSeeder>();
await discountCodeSeeder.Seed();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
