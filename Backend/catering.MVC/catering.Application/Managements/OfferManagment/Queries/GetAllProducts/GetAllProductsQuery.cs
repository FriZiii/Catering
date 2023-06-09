using catering.Domain.Entities;
using MediatR;

namespace catering.Application.Managements.OfferManagment.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {

    }
}
