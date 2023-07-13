using catering.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.OfferManagment.Commands.DeleteProductById
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand>
    {
        private readonly IOfferRepository offerRepository;

        public DeleteProductByIdCommandHandler(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task<Unit> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            await offerRepository.DeleteById(request.Id);
            return Unit.Value;
        }
    }
}
