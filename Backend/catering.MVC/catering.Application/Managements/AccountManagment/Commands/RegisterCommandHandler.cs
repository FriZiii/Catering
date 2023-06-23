using AutoMapper;
using catering.Domain.Entities.User.RegisterInput;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IMapper mapper;

        public RegisterCommandHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerInput = mapper.Map<AccountRegisterInput>(request);
            return Unit.Task;
        }
    }
}
