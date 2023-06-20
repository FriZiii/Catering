using catering.Domain.Entities;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.DiscountCodeManagment.Queries.GetDiscountCodeValue
{
    public class GetDiscountCodeQueryHandler : IRequestHandler<GetDiscountCodeQuery, DiscountCode>
    {
        private readonly IDiscountCodeRepository discountCodeRepository;

        public GetDiscountCodeQueryHandler(IDiscountCodeRepository discountCodeRepository)
        {
            this.discountCodeRepository = discountCodeRepository;
        }

        public async Task<DiscountCode> Handle(GetDiscountCodeQuery request, CancellationToken cancellationToken)
        {
            DiscountCode? discountCode = await discountCodeRepository.GetDiscountCodeByCode(request.Code);
            if (discountCode == null || discountCode.Expiration < DateTime.Now)
            {
                return null!;
            }

            return discountCode;
        }
    }
}
