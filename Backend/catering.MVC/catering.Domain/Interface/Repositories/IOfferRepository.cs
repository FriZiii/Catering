using catering.Domain.Entities;

namespace catering.Domain.Interface.Repositories
{
    public interface IOfferRepository
    {
        Task Create(Product product);
        Task<List<Product>> GetAll();
        Task<Product?> GetByName(string name);
        Task<Product?> GetById(int id);
        Task DeleteById(int id);
    }
}
