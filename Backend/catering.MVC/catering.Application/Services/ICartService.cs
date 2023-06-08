using catering.Application.Cart;

namespace catering.Application.Services
{
    public interface ICartService
    {
        void Add(int productID);
        Task<CartModelDto> Get();
    }
}
