using catering.Domain.Interface.Services;
using MediatR;

namespace catering.Application.Managements.MessageManagement
{
    public class SendContactFormCommandHandler : IRequestHandler<SendContactFormCommand>
    {
        private readonly IEmailService emailService;

        public SendContactFormCommandHandler(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        public Task<Unit> Handle(SendContactFormCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
