using catering.Application.Managements.OrderManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Serializers
{
    public static class MealSerialization
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
