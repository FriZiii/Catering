using catering.Application.Managements.OrderManagment;
using System.Globalization;

namespace catering.Application.Serializers
{
    public static class DateSerializer
    {
        public static ICollection<OrderItemDateDto> SerializeDates(List<string> dateStrings)
        {
            var result = new HashSet<OrderItemDateDto>();
            foreach (var date in dateStrings)
            {
                result.Add(new OrderItemDateDto()
                {
                    Date = DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture)
                });
            }
            return result;
        }
    }
}
