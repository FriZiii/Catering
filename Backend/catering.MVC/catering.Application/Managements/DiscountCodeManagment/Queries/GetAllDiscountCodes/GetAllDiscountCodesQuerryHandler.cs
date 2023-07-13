using catering.Domain.Entities;
using catering.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.DiscountCodeManagment.Queries.GetAllDiscountCodes
{
    public class GetAllDiscountCodesQuerryHandler : IRequestHandler<GetAllDiscountCodesQuerry, IEnumerable<DiscountCode>>
    {
        private readonly IDiscountCodeRepository discountCodeRepository;

        public GetAllDiscountCodesQuerryHandler(IDiscountCodeRepository discountCodeRepository)
        {
            this.discountCodeRepository = discountCodeRepository;
        }
        public async Task<IEnumerable<DiscountCode>> Handle(GetAllDiscountCodesQuerry request, CancellationToken cancellationToken)
        {
            var discountCodes = await discountCodeRepository.GetAllDiscountCodes();
            return discountCodes;
        }
    }
}
