using catering.Application.Managements.AccountManagment.Querries.Login;
using catering.Domain.Entities.OrderEntities;

namespace catering.MVC.Models
{
	public class ConfirmViewModel
	{
		public LoginQuerry LoginQuerry { get; set; } = null!;
		public Order Order { get; set; } = null!;
    }
}
