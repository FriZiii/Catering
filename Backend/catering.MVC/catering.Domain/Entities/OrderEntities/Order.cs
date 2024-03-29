﻿using catering.Domain.Entities.User.AppUser;

namespace catering.Domain.Entities.OrderEntities
{
    public class Order
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public string? GuestId { get; set; }
        public int? DiscountCodeId { get; set; } = null;

        public decimal TotalPriceBeforeDiscount { get; set; }
        public decimal TotalPriceAfterDiscount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Confirmed { get; set; } = false;
        public bool Paid { get; set; } = false;

        public AppUser? AppUser { get; set; } = null!;
        public Guest? Guest { get; set; } = null!;
        public DiscountCode? DiscountCode { get; set; } = null!;
        public List<OrderItem> OrderItems { get; set; } = null!;
    }
}
