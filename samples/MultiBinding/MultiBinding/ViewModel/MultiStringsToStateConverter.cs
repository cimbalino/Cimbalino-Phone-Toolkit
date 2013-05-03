using System;
using System.Globalization;
using Cimbalino.Phone.Toolkit.Converters;

namespace MultiBinding.ViewModel
{
    public class MultiStringsToStateConverter : MultiValueConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var text1 = (string)values[0];
            var text2 = (string)values[1];

            if (string.IsNullOrEmpty(text1))
            {
                if (string.IsNullOrEmpty(text2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (string.IsNullOrEmpty(text2))
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public override object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intValue = (int)value;
            
            return new object[]
            {
                intValue == -1 || intValue == 0 || intValue == 1 ? null : "This is not empty",
                intValue == -1 || intValue == 0 || intValue == 2 ? null : "This is not empty"
            };
        }
    }
}