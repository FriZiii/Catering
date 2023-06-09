using AutoMapper;
using catering.Domain.Entities;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OfferManagment.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IMapper mapper;
        private readonly IOfferRepository offerRepository;

        public GetAllProductsQueryHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            this.mapper = mapper;
            this.offerRepository = offerRepository;
        }
        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await offerRepository.GetAll();

            return products;
        }
    }
}
