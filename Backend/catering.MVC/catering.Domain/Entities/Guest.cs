using catering.Domain.Entities.User.AppUser;

namespace catering.Domain.Entities
{
    public class Guest
    {
        public string Id { get; set; } = null!;
        public int DeliveryAdressId { get; set; }

        public UserDeliveryAdress DeliveryAdress { get; set; } = null!;
    }
}
