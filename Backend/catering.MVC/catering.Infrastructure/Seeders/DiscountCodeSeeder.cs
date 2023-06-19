using catering.Domain.Entities;
using catering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Infrastructure.Seeders
{
    public class DiscountCodeSeeder
    {
        private readonly StoreContext context;

        public DiscountCodeSeeder(StoreContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            if(await context.Database.CanConnectAsync())
            {
                if(!context.DiscountCodes.Any())
                {
                    DiscountCode june2022 = new DiscountCode()
                    {
                        Code = "june2022",
                        DiscountPercentage = 5,
                        Expiration = new DateTime(2023, 6, 30)
                    };
                    context.DiscountCodes.Add(june2022);

                    DiscountCode summer = new DiscountCode()
                    {
                        Code = "summer",
                        DiscountPercentage = 15,
                        Expiration = new DateTime(2023, 8, 31)
                    };
                    context.DiscountCodes.Add(summer);

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
