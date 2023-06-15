using catering.Application.Managements.OrderManagment;

namespace catering.Application.Serializers
{
    public static class MealSerializer
    {
        public static ICollection<OrderItemMealDto> SerializeMeals(List<string> meals)
        {
            var result = new HashSet<OrderItemMealDto>();
            foreach (var meal in meals)
            {
                result.Add(new OrderItemMealDto()
                {
                    Meal = meal
                });
            }
            return result;
        }
    }
}
