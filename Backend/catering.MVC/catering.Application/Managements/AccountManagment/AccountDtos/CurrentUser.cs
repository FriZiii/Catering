using catering.Domain.Entities.OrderEntities;

namespace catering.Application.Managements.AccountManagment.AccountDtos
{
    public class CurrentUser
    {
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public IEnumerable<Order> Orders { get; set; } = default!;
        public IEnumerable<string> Roles { get; set; } = default!;
        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}
