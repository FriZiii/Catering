using AutoMapper;
using catering.Domain.Entities;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OfferManagment.Queries.GetById
{
    public class GetByIdQuerryHandler : IRequestHandler<GetByIdQuerry, Product>
    {
        private readonly IMapper mapper;
        private readonly IOfferRepository offerRepository;

        public GetByIdQuerryHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            this.mapper = mapper;
            this.offerRepository = offerRepository;
        }

        public async Task<Product> Handle(GetByIdQuerry request, CancellationToken cancellationToken)
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
