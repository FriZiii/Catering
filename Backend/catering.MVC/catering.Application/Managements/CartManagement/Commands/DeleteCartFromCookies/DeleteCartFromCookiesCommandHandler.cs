using catering.Domain.Interface.Repositories;
using MediatR;

namespace catering.Application.Managements.CartManagement.Commands.DeleteCartFromCookies
{
    public class DeleteCartFromCookiesCommandHandler : IRequestHandler<DeleteCartFromCookiesCommand>
    {
        private readonly ICartRepository cartRepository;

        public DeleteCartFromCookiesCommandHandler(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public async Task<Unit> Handle(DeleteCartFromCookiesCommand request, CancellationToken cancellationToken)
        {
            cartRepository.DeleteCartFromCookies();
            return Unit.Value;
        }
    }
}
