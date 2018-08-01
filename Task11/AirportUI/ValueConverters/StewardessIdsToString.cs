using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace AirportUI.ValueConverters
{
    public class StewardessIdsToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var target = (IEnumerable<long>)value;
            return string.Join(",", target);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.ToString().Split(',').Select(item => long.Parse(item));
        }
    }
}
