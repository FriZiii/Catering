using AutoMapper;
using catering.Application.Offer;
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
        private readonly IMapper mapper;

        public OfferService(IOfferRepository offerRepository, IMapper mapper)
        {
            this.offerRepository = offerRepository;
            this.mapper = mapper;
        }

        public async Task Create(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);

            product.SetImageName();
            await offerRepository.Create(product);
        }

        public async Task<List<Product>> GetAll()
        {
            return await offerRepository.GetAll(); 
        }

        public async Task<Product?> GetById(int id)
        {
            return await offerRepository.GetById(id);
        }
    }
}
