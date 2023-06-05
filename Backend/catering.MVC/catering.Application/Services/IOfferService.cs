using catering.Domain.Entities;

namespace catering.Application.Services
{
    public interface IOfferService
    {
        Task Create(Product product);
        Task<List<Product>> GetAll();
    }
}