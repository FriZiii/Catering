using catering.Domain.Entities.User.AppUser;
using catering.Domain.Interface;
using MediatR;

namespace catering.Application.Managements.AccountManagment.Querries.GetAllUsers
{
    public class GetAllUsersQuerryHandler : IRequestHandler<GetAllUsersQuerry, IEnumerable<AppUser>>
    {
        private readonly IAccountRepository accountRepository;

        public GetAllUsersQuerryHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<IEnumerable<AppUser>> Handle(GetAllUsersQuerry request, CancellationToken cancellationToken)
        {
            var users = accountRepository.GetAllUsers();
            return users;
        }
    }
}
