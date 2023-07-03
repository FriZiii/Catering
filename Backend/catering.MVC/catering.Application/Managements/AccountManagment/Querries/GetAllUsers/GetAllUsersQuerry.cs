using catering.Domain.Entities.User.AppUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Querries.GetAllUsers
{
    public class GetAllUsersQuerry : IRequest<IEnumerable<AppUser>>
    {

    }
}
