using catering.Application.DTO.Offer;
using catering.Domain.Entities;

namespace catering.Application.Services
{
    public interface IOfferService
    {
        Task Create(ProductDto productDto);
        Task<Product?> GetById(int id);
        Task<List<Product>> GetAll();
    }
}