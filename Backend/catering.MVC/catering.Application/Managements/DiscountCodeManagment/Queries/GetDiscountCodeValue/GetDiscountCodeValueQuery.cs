using catering.Domain.Entities;
using MediatR;

namespace catering.Application.Managements.DiscountCodeManagment.Queries.GetDiscountCodeValue
{
    public class GetDiscountCodeQuery :IRequest<DiscountCode>
    {
        public string Code { get; }
        public GetDiscountCodeQuery(string code)
        {
            Code = code.ToLower();
        }
    }
}
