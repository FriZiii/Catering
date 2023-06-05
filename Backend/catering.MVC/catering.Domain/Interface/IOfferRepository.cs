using catering.Domain.Entities;

namespace catering.Domain.Interface
{
    public interface IOfferRepository
    {
        Task Create(Product product);
        Task<List<Product>> GetAll();
    }
}
