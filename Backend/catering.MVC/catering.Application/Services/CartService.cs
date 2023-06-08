using AutoMapper;
using catering.Application.DTO.Cart;
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

        public void Delete(int productID)
        {
            cartRepository.Delete(productID);
        }

        public async Task<CartModelDto> Get()
        {
            var cart = cartRepository.GetCart().CartItems;
            List<CartItemModelDto> cartItemsDto = mapper.Map<List<CartItemModelDto>>(cart);
            foreach (var itemDto in cartItemsDto)
            {
                if(itemDto.Product is not null)
                {
                    var product = await offerRepository.GetById(itemDto.Product.Id);
                    if(product is null)
                    {
                        throw new InvalidOperationException("Missing product in cart");
                    }
                    itemDto.Product = product;
                }
            }

            var cartDto = new CartModelDto()
            {
                CartItems = cartItemsDto
            };

            return cartDto;
        }
    }
}
