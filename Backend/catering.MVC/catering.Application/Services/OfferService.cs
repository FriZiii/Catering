using catering.Domain.Entities;
using catering.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task Create(Product product)
        {
            product.SetImageName();
            await offerRepository.Create(product);
        }

        public async Task<List<Product>> GetAll()
        {
            return await offerRepository.GetAll(); 
        }
    }
}
