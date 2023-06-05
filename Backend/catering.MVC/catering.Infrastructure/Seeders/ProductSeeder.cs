using catering.Domain.Entities;
using catering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Infrastructure.Seeders
{
    public class ProductSeeder
    {
        private readonly StoreContext context;

        public ProductSeeder(StoreContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Products.Any())
                {
                    Product meatDiet = new Product()
                    {
                        Name = "Meat Diet",
                        Price = 100,
                        Description = @"Are you ready to embark on a culinary adventure that will tantalize your senses and satisfy your deepest cravings?
                                        Look no further than our mouthwatering meat diet,
                                        designed specifically for those who appreciate the delectable flavors and robust textures that only meat can provide. 
                                        Indulge in a world of succulent, juicy cuts that will leave you longing for more.",
                        ImageName = "meat-diet.jpg"
                    };
                    context.Products.Add(meatDiet);

                    Product veganDiet = new Product()
                    {
                        Name = "Vegan Diet",
                        Price = 80,
                        Description = @"Are you prepared to embark on a gastronomic journey that will awaken your taste buds and fulfill your cravings? 
                                        Look no further than our tantalizing vegan diet, 
                                        meticulously crafted for those who appreciate the exquisite flavors and diverse textures that only plant-based ingredients can offer. 
                                        Immerse yourself in a realm of vibrant, 
                                        nutrient-rich creations that will leave you yearning for every bite.",
                        ImageName = "vegan-diet.jpg"
                    };
                    context.Products.Add(veganDiet);

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
