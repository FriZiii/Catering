using catering.Domain.Entities.OrderEntities;
using catering.Domain.Entities.User.AppUser;

namespace catering.MVC.Models
{
    public class UserDashboardViewModel
    {
        public DeliveryAdress DeliveryAdress { get; set; } = default!;
        public IEnumerable<Order> Orders { get; set; } = default!;

    }   
}
