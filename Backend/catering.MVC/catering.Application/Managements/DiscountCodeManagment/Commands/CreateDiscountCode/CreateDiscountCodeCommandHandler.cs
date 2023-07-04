using AutoMapper;
using catering.Domain.Entities;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.DiscountCodeManagment.Commands.CreateDiscountCode
{
    public class CreateDiscountCodeCommandHandler : IRequestHandler<CreateDiscountCodeCommand>
    {
        private readonly IDiscountCodeRepository discountCodeRepository;
        private readonly IMapper mapper;

        public CreateDiscountCodeCommandHandler(IDiscountCodeRepository discountCodeRepository, IMapper mapper)
        {
            this.discountCodeRepository = discountCodeRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateDiscountCodeCommand request, CancellationToken cancellationToken)
        {
            var discountCode = mapper.Map<DiscountCode>(request);
            await discountCodeRepository.CreateDiscountCode(discountCode);

            return Unit.Value;
        }
    }
}
