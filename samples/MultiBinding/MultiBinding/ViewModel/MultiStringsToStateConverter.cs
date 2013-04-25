using System;
using System.Globalization;
using Cimbalino.Phone.Toolkit.Converters;

namespace MultiBinding.ViewModel
{
    public class MultiStringsToStateConverter : MultiValueConverterBase<int>
    {
        public override int Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
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

        public override object[] ConvertBack(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object[]
            {
                value == -1 || value == 0 || value == 1 ? null : "This is not empty",
                value == -1 || value == 0 || value == 2 ? null : "This is not empty"
            };
        }
    }
}