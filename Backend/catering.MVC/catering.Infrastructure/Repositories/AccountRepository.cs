using catering.Domain.Entities.User.AppUser;
using catering.Domain.Entities.User.LoginInput;
using catering.Domain.Entities.User.RegisterInput;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace catering.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StoreContext storeContext;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountRepository(StoreContext storeContext ,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.storeContext = storeContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
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

            var deliveryAdress = new UserDeliveryAdress
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
                await storeContext.SaveChangesAsync();
            }
        }
    }
}
