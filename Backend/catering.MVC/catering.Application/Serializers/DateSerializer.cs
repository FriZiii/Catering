using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Serializers
{
    public static class DateSerializer
    {
        public static HashSet<DateTime> SerializeDates(List<string> datesStrings)
        {
            HashSet<DateTime> dateSet = new HashSet<DateTime>();

            foreach (string dateString in datesStrings)
            {
                DateTime date = DateTime.ParseExact(dateString, "d/M/yyyy", CultureInfo.InvariantCulture);
                dateSet.Add(date);
            }
            
            return dateSet;
        }
    }
}
