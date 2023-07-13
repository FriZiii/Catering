using catering.Domain.Entities.User.AppUser;
using catering.Domain.Entities.User.LoginInput;
using catering.Domain.Entities.User.RegisterInput;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace catering.Domain.Interface.Repositories
{
    public interface IAccountRepository
    {
        Task DeleteUserById(string id);
        IEnumerable<AppUser?> GetAllUsers();
        Task<AppUser> GetAppUserById(string userId);
        ClaimsPrincipal? GetCurrentUser();
        Task<SignInResult> LoginUser(LoginInput loginInput);
        Task LogoutUser();
        Task RegisterUser(AccountRegisterInput registerInput);
        Task UpdateDeliveryAdressByUserId(string userId, DeliveryAdressInput deliveryAdressInput);
    }
}
