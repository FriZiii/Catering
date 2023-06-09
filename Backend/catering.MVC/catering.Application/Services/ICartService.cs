using catering.Application.DTO.Cart;

namespace catering.Application.Services
{
    public interface ICartService
    {
        void Add(int productID);
        void Delete(int productID);
        Task<CartModelDto> Get();
    }
}
