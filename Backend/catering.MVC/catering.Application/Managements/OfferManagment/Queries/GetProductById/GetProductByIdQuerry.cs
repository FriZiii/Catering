using catering.Domain.Entities;
using MediatR;

namespace catering.Application.Managements.OfferManagment.Queries.GetById
{
    public class GetProductByIdQuerry : IRequest<Product>
    {
        public int Id { get; }

        public GetProductByIdQuerry(int id)
        {
            Id = id;
        }
    }
}
