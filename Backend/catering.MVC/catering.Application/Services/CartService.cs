using AutoMapper;
using catering.Application.Cart;
using catering.Domain.Interface;

namespace catering.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IMapper mapper;
        private readonly ICartRepository cartRepository;
        private readonly IOfferRepository offerRepository;

        public CartService(IMapper mapper, ICartRepository cartRepository, IOfferRepository offerRepository)
        {
            this.mapper = mapper;
            this.cartRepository = cartRepository;
            this.offerRepository = offerRepository;
        }

        public void Add(int productID)
        {
            cartRepository.AddToCart(productID);
        }

        public async Task<CartModelDto> Get()
        {
            var cart = cartRepository.GetCart().CartItems;
            List<CartItemModelDto> cartItemsDto = new List<CartItemModelDto>();
            foreach (var item in cart)
            {
                cartItemsDto.Add(new CartItemModelDto()
                {
                    Id = cartItemsDto.Count,
                    Product = await offerRepository.GetById(item.ProductID)
                });
            }
            var cartDto = new CartModelDto()
            {
                CartItems = cartItemsDto
            };

            return cartDto;
        }
    }
}
