using catering.Domain.Entities.OrderEntities;
using catering.Domain.Entities.User.AppUser;

namespace catering.Application.Managements.AccountManagment.AccountDtos
{
    public class CurrentUser
    {
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public IEnumerable<Order> Orders { get; set; } = default!;
        public IEnumerable<string> Roles { get; set; } = default!;
        public DeliveryAdress DeliveryAdress { get; set; } = default!;
        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}
