using catering.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly ICartRepository cartRepository;

        public AddProductCommandHandler(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            cartRepository.AddToCart(request.Id);
            return Unit.Value;
        }
    }
}
