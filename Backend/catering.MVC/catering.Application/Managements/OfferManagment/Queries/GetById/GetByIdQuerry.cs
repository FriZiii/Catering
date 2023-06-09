using catering.Domain.Entities;
using MediatR;

namespace catering.Application.Managements.OfferManagment.Queries.GetById
{
    public class GetByIdQuerry : IRequest<Product>
    {
        public int Id { get; }

        public GetByIdQuerry(int id)
        {
            Id = id;
        }
    }
}
