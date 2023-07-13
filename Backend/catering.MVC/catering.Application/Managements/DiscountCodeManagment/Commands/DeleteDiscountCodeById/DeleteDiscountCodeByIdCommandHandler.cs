using catering.Domain.Interface.Repositories;
using MediatR;

namespace catering.Application.Managements.DiscountCodeManagment.Commands.DeleteDiscountCodeById
{
    public class DeleteDiscountCodeByIdCommandHandler : IRequestHandler<DeleteDiscountCodeByIdCommand>
    {
        private readonly IDiscountCodeRepository discountCodeRepository;

        public DeleteDiscountCodeByIdCommandHandler(IDiscountCodeRepository discountCodeRepository)
        {
            this.discountCodeRepository = discountCodeRepository;
        }
        public async Task<Unit> Handle(DeleteDiscountCodeByIdCommand request, CancellationToken cancellationToken)
        {
            await discountCodeRepository.DeleteDiscountCodeById(request.Id);
            return Unit.Value;
        }
    }
}
