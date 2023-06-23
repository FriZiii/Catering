using catering.Domain.Entities.User.AppUser;
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

        public AccountRepository(StoreContext storeContext ,UserManager<AppUser> userManager)
        {
            this.storeContext = storeContext;
            this.userManager = userManager;
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
