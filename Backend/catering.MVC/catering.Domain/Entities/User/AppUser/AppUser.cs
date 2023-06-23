using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Domain.Entities.User.AppUser
{
    public class AppUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; } = default!;
        public int DeliveryAdressId { get; set; } = default!;

        public UserDeliveryAdress DeliveryAdress { get; set; } = default!;
    }
}
