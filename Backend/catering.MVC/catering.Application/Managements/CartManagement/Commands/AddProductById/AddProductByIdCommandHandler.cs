using catering.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Commands.AddProduct
{
    public class AddProductByIdCommandHandler : IRequestHandler<AddProductByIdCommand>
    {
        private readonly ICartRepository cartRepository;

        public AddProductByIdCommandHandler(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(AddProductByIdCommand request, CancellationToken cancellationToken)
        {
            cartRepository.AddToCart(request.Id);
            return Unit.Value;
        }
    }
}
