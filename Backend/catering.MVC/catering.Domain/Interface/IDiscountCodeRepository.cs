using catering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Interface
{
    public interface IDiscountCodeRepository
    {
        Task<DiscountCode?> GetDiscountCodeByCode(string code);
    }
}
