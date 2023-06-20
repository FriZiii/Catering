using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.DiscountCodeManagment.Commands.ApplyDiscountCode
{
    public class ApplyDiscountCodeCommandHandler : IRequestHandler<ApplyDiscountCodeCommand>
    {
        private readonly IDiscountCodeRepository discountCodeRepository;

        public ApplyDiscountCodeCommandHandler(IDiscountCodeRepository discountCodeRepository)
        {
            this.discountCodeRepository = discountCodeRepository;
        }

        public async Task<Unit> Handle(ApplyDiscountCodeCommand request, CancellationToken cancellationToken)
        {
            if (request.DiscountCode is not null)
            {
                await discountCodeRepository.SetDiscountCodeToOrder(request.OrderId, request.DiscountCode);
            }
            return Unit.Value;
        }
    }
}
