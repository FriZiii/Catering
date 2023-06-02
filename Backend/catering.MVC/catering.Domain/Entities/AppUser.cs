using catering.Domain.Entities.CartEntities;
using Microsoft.AspNetCore.Identity;

namespace catering.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public Cart Cart { get; set; } = new Cart();
    }
}
