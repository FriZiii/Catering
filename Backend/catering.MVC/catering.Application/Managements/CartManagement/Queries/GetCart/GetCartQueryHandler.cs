using AutoMapper;
using catering.Application.Managements.CartManagement.Cart;
using catering.Application.Managements.OfferManagment.Queries.GetById;
using catering.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Queries.GetCart
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartModelDto>
    {
        private readonly IMapper mapper;
        private readonly ICartRepository cartRepository;
        private readonly IMediator mediator;

        public GetCartQueryHandler(IMapper mapper, ICartRepository cartRepository, IMediator mediator)
        {
            this.mapper = mapper;
            this.cartRepository = cartRepository;
            this.mediator = mediator;
        }

        public async Task<CartModelDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cartItems = cartRepository.GetCart().CartItems;
            List<CartItemModelDto> cartItemModelDtos = mapper.Map<List<CartItemModelDto>>(cartItems);
            
            foreach(var itemDto in cartItemModelDtos)
            {
                var product = await mediator.Send(new GetByIdQuerry(itemDto.Product.Id));
                if(product is null)
                {
                    throw new InvalidOperationException("Missing product in cart");
                }

                itemDto.Product = product;
            }

            var cartDto = new CartModelDto()
            {
                CartItems = cartItemModelDtos
            };

            return cartDto;
        }
    }
}
