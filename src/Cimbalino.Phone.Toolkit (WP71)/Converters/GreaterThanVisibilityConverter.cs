using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cimbalino.Phone.Toolkit.Converters
{
    public class GreaterThanVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return Visibility.Collapsed;
            }

            var compareTo = int.Parse((string) parameter);
            var compareWith = int.Parse((string) value);

            return compareWith > compareTo ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}