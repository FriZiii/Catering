using catering.Domain.Entities;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Infrastructure.Repositories
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly StoreContext context;

        public DiscountCodeRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<DiscountCode?> GetDiscountCodeByCode(string code)
           => await context.DiscountCodes.FirstOrDefaultAsync(c => c.Code == code);
    }
}
