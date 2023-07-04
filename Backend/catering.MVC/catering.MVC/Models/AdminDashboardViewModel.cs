using catering.Application.Managements.DiscountCodeManagment.Commands.CreateDiscountCode;
using catering.Application.Managements.OfferManagment.Commands.AddProduct;
using catering.Domain.Entities.OrderEntities;

namespace catering.MVC.Models
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Order> Orders { get; set; } = null!;

        public CreateProductCommand CreateProductCommand { get; set; } = null!;
        public CreateDiscountCodeCommand CreateDiscountCodeCommand { get; set; } = null!;
    }
}
