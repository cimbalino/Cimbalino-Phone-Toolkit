using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cimbalino.Phone.Toolkit.Converters
{
    public class EnumToBooleanBaseConverter<TEnum> : IValueConverter where TEnum : struct
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            // Convert parameter from string to enum if needed.
            TEnum enumValue;
            if (parameter is string &&
#if !WP8
                EnumTryParse((string)parameter, out enumValue))
#else
                Enum.TryParse((string)parameter, true, out enumValue))
#endif
                
            {
                parameter = enumValue;
            }
            // Return true if value matches parameter.
            return Equals(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            // If value is true, then return the enum value corresponding to parameter.
            if (Equals(value, true))
            {
                // Convert parameter from string to enum if needed.
                TEnum enumValue;
                if (parameter is string &&
#if !WP8
                    EnumTryParse((string)parameter, out enumValue))
#else
                    Enum.TryParse((string)parameter, true, out enumValue))
#endif
                {
                    parameter = enumValue;
                }
                return parameter;
            }
            // Otherwise, return UnsetValue, which is ignored by bindings.
            return DependencyProperty.UnsetValue;
        }

        private bool EnumTryParse(string value, out TEnum enumValue) 
        {
            try
            {
                var item = (TEnum)Enum.Parse(typeof(TEnum), value.Trim(), true);
                enumValue = item;
                return true;
            }
            catch
            {
            }
            enumValue = default(TEnum);
            return false;
        }
    }
}