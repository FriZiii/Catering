using catering.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.CartManagement.Commands.DeleteProduct
{
    public class DeleteCartProductByIdCommandHandler : IRequestHandler<DeleteCartProductByIdCommand>
    {
        private readonly ICartRepository cartRepository;

        public DeleteCartProductByIdCommandHandler(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(DeleteCartProductByIdCommand request, CancellationToken cancellationToken)
        {
            cartRepository.DeleteFromCart(request.Id);

            return Unit.Value;
        }
    }
}
