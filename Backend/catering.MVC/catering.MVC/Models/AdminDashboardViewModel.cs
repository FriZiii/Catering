using catering.Application.Managements.DiscountCodeManagment.Commands.CreateDiscountCode;
using catering.Application.Managements.OfferManagment;
using catering.Application.Managements.OfferManagment.Commands.AddProduct;
using catering.Domain.Entities;
using catering.Domain.Entities.OrderEntities;
using catering.Domain.Entities.User.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.MVC.Models
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Product> Products { get; set; } = null!;
        public IEnumerable<Order> Orders { get; set; } = null!;
        public IEnumerable<DiscountCode> Discounts { get; set; } = null!;
        public IEnumerable<AppUser> Users { get; set; } = null!;

        public CreateProductCommand CreateProductCommand { get; set; } = null!;
        public CreateDiscountCodeCommand CreateDiscountCodeCommand { get; set; } = null!;
    }
}
