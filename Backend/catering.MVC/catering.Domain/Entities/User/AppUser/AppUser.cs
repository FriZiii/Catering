﻿using Microsoft.AspNetCore.Identity;

namespace catering.Domain.Entities.User.AppUser
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; } = default!;
        public int DeliveryAdressId { get; set; } = default!;

        public UserDeliveryAdress DeliveryAdress { get; set; } = default!;
    }
}
