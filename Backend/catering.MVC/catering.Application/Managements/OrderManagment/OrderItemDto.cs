using catering.Domain.Entities;

namespace catering.Application.Managements.OrderManagment
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string Calories { get; set; } = default!;
        public List<string> Meals { get; set; } = new List<string>();
        public List<string> Dates { get; set; } = new List<string>();
    }
}
