using AutoMapper;
using catering.Domain.Entities;
using catering.Domain.Interface.Repositories;
using MediatR;

namespace catering.Application.Managements.OfferManagment.Queries.GetById
{
    public class GetProductByIdQuerryHandler : IRequestHandler<GetProductByIdQuerry, Product>
    {
        private readonly IMapper mapper;
        private readonly IOfferRepository offerRepository;

        public GetProductByIdQuerryHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            this.mapper = mapper;
            this.offerRepository = offerRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuerry request, CancellationToken cancellationToken)
        {
            var product = await offerRepository.GetById(request.Id);
            if (product is null)
            {
                throw new InvalidOperationException($"There is no product with id {request.Id}");
            }
            return product;
        }
    }
}
