using catering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Interface.Repositories
{
    public interface IDiscountCodeRepository
    {
        Task CreateDiscountCode(DiscountCode discountCode);
        Task DeleteDiscountCodeById(int id);
        Task<IEnumerable<DiscountCode>> GetAllDiscountCodes();
        Task<DiscountCode?> GetDiscountCodeByCode(string code);
        Task SetDiscountCodeToOrder(int orderId, DiscountCode discountCode);
    }
}
