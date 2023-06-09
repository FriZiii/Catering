using AutoMapper;
using catering.Domain.Entities;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.OfferManagment.Commands.AddProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMapper mapper;
        private readonly IOfferRepository offerRepository;

        public CreateProductCommandHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            this.mapper = mapper;
            this.offerRepository = offerRepository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);

            product.SetImageName();
            await offerRepository.Create(product);

            return Unit.Value;
        }
    }
}
