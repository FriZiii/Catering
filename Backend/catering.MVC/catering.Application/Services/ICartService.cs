using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;

namespace catering.Application.Services
{
    public interface ICartService
    {
        void Add(Product product);
        CartModel Get();
    }
}
