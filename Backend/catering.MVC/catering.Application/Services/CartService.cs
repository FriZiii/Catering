using AutoMapper;
using catering.Application.Offer;
using catering.Domain.Entities;
using catering.Domain.Entities.CartEntities;
using catering.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IMapper mapper;
        private readonly ICartRepository cartRepository;

        public CartService(IMapper mapper, ICartRepository cartRepository)
        {
            this.mapper = mapper;
            this.cartRepository = cartRepository;
        }

        public void Add(Product product)
        {
            cartRepository.AddToCart(product);
        }

        public CartModel Get()
        {
            return cartRepository.GetCart();
        }
    }
}
