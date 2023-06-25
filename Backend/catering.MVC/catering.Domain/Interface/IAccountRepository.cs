using catering.Domain.Entities.User.LoginInput;
using catering.Domain.Entities.User.RegisterInput;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Interface
{
    public interface IAccountRepository
    {
        ClaimsPrincipal? GetCurrentUser();
        Task<SignInResult> LoginUser(LoginInput loginInput);
        Task LogoutUser();
        Task RegisterUser(AccountRegisterInput registerInput);
    }
}
