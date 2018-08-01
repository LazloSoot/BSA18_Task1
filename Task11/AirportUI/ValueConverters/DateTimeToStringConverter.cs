using System;
using Windows.UI.Xaml.Data;

namespace AirportUI.ValueConverters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime targetTime = (DateTime)value;
            return targetTime.ToString("dd.MM.yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTime resultTime = DateTime.Parse(value.ToString());
            return resultTime;
        }
    }
}
