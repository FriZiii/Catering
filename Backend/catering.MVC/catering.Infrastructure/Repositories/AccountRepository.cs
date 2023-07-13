using catering.Domain.Entities.User.AppUser;
using catering.Domain.Entities.User.LoginInput;
using catering.Domain.Entities.User.RegisterInput;
using catering.Domain.Interface.Repositories;
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
            var userToDelete = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(userToDelete!);
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            var users = userManager.Users.Include(u => u.DeliveryAdress).ToList();
            return users;
        }

        public async Task<AppUser> GetAppUserById(string userId)
        {
            var user = await userManager.Users
                .Include(u => u.DeliveryAdress)
                .Include(u => u.Orders).ThenInclude(o => o.OrderItems).ThenInclude(oi => oi.Dates)
                .Include(u => u.Orders).ThenInclude(o => o.OrderItems).ThenInclude(oi => oi.Meals)
                .Include(u=>u.Orders).ThenInclude(o=>o.OrderItems).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if(user is not null)
                return user;
            return null!;
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
            AppUser? singedUser = await userManager.FindByEmailAsync(loginInput.Email);
            if (singedUser is not null)
            {
                var result = await signInManager.PasswordSignInAsync(singedUser.UserName!, loginInput.Password, loginInput.RememberMe, false);
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

        public async Task UpdateDeliveryAdressByUserId(string userId, DeliveryAdressInput deliveryAdressInput)
        {
            var user = await userManager.Users
                .Include(u => u.DeliveryAdress)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var deliveryAdress = new DeliveryAdress
            {
                Adress1 = deliveryAdressInput.Adress1,
                Adress2 = deliveryAdressInput.Adress2,
                Country = deliveryAdressInput.Country,
                State = deliveryAdressInput.State,
                PostalCode = deliveryAdressInput.PostalCode,
                PhoneNumber = deliveryAdressInput.PhoneNumber,
            };

            user!.DeliveryAdress = deliveryAdress;
            await storeContext.SaveChangesAsync();
        }
    }
}
