using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AirportUI.ValueConverters
{
    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return new DateTimeOffset((DateTime)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset sourceTime = (DateTimeOffset)value;
            return sourceTime.DateTime;
        }
    }
}
