using catering.Domain.Entities.User.AppUser;
using catering.Domain.Entities.User.LoginInput;
using catering.Domain.Entities.User.RegisterInput;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace catering.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StoreContext storeContext;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountRepository(StoreContext storeContext, 
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.storeContext = storeContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task DeleteUserById(string id)
        {
            var userToDelete = await userManager.Users.FirstAsync(u => u.Id == id);
            await userManager.DeleteAsync(userToDelete);
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            var users = userManager.Users.Include(u => u.DeliveryAdress).ToList();
            return users;
        }

        public ClaimsPrincipal? GetCurrentUser()
        {
            var user = httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("Context user is not present");
            }

            if (user.Identity is null || !user.Identity.IsAuthenticated)
            {
                return null;
            }
            return user;
        }

        public async Task<SignInResult> LoginUser(LoginInput loginInput)
        {
            AppUser? singedUser = await  userManager.FindByEmailAsync(loginInput.Email);
            if (singedUser is not null)
            {
                var result = await signInManager.PasswordSignInAsync(singedUser.UserName!, loginInput.Password, false, false);
                return result;
            }

            return SignInResult.Failed;
        }

        public async Task LogoutUser()
        {
            await signInManager.SignOutAsync();
        }

        public async Task RegisterUser(AccountRegisterInput registerInput)
        {

            var deliveryAdress = new DeliveryAdress
            {
                Adress1 = registerInput.DeliveryAdress.Adress1,
                Adress2 = registerInput.DeliveryAdress.Adress2,
                Country = registerInput.DeliveryAdress.Country,
                State = registerInput.DeliveryAdress.State,
                PostalCode = registerInput.DeliveryAdress.PostalCode,
                PhoneNumber = registerInput.DeliveryAdress.PhoneNumber,
            };

            var user = new AppUser()
            {
                UserName = registerInput.FirstName,
                Email = registerInput.Email,
                FirstName = registerInput.FirstName,
                LastName = registerInput.LastName,
                BirthDate = registerInput.BirthDate,
                DeliveryAdress = deliveryAdress
            };

            var result = await userManager.CreateAsync(user, registerInput.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                await storeContext.SaveChangesAsync();
            }
        }
    }
}
