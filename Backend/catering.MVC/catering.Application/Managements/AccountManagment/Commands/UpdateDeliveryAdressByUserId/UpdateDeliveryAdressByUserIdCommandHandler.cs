using AutoMapper;
using catering.Domain.Entities.User.RegisterInput;
using catering.Domain.Interface.Repositories;
using MediatR;

namespace catering.Application.Managements.AccountManagment.Commands.UpdateDeliveryAdressByUserId
{
    public class UpdateDeliveryAdressByUserIdCommandHandler : IRequestHandler<UpdateDeliveryAdressByUserIdCommand>
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;

        public UpdateDeliveryAdressByUserIdCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateDeliveryAdressByUserIdCommand request, CancellationToken cancellationToken)
        {
            var deliveryAdressInput = mapper.Map<DeliveryAdressInput>(request.DeliveryAdressInputDto);
            await accountRepository.UpdateDeliveryAdressByUserId(request.UserId, deliveryAdressInput);
            return Unit.Value;
        }
    }
}
