// ****************************************************************************
// <copyright file="ResolutionAwareUriConverter.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>02-12-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
#if WP8
using System.IO;
using System.Windows;
#endif
using System.Windows.Data;

namespace Cimbalino.Phone.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> which converts a <see cref="Uri"/> value to a resolution aware <see cref="Uri"/>.
    /// </summary>
    public class ResolutionAwareUriConverter : IValueConverter
    {
#if WP8
        private static readonly string _resolutionSuffix;

        static ResolutionAwareUriConverter()
        {
            switch (Application.Current.Host.Content.ScaleFactor)
            {
                case 100:
                    _resolutionSuffix = ".Screen-WVGA";
                    break;
                case 150:
                    _resolutionSuffix = ".Screen-720p";
                    break;
                case 160:
                    _resolutionSuffix = ".Screen-WXGA";
                    break;
            }
        }
#endif

        /// <summary>
        /// Gets or sets a value indicating whether to check if the converted <see cref="Uri"/> exists.
        /// </summary>
        /// <value>true if the returned <see cref="Uri"/> has to exist; otherwise, false.</value>
        public bool CheckIfUriExists { get; set; }

        /// <summary>
        /// Converts a <see cref="Uri"/> value to a resolution aware <see cref="Uri"/> value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
#if WP8
            if (value == null || string.IsNullOrEmpty(_resolutionSuffix))
            {
                return value;
            }

            var iconUrl = value.ToString().TrimStart('/');

            if (iconUrl.Length > 0)
            {
                var resolutionAwareIconUrl = Path.ChangeExtension(iconUrl, _resolutionSuffix + Path.GetExtension(iconUrl));
                var resolutionAwareIconUri = new Uri(resolutionAwareIconUrl, UriKind.Relative);

                if (CheckIfUriExists)
                {
                    var resouceStreamResult = Application.GetResourceStream(resolutionAwareIconUri);

                    if (resouceStreamResult != null && resouceStreamResult.Stream != null)
                    {
                        resouceStreamResult.Stream.Dispose();

                        return resolutionAwareIconUri;
                    }
                }
                else
                {
                    return resolutionAwareIconUri;
                }
            }

            return value;
#else
            return value;
#endif
        }

        /// <summary>
        /// Converts a resolution aware <see cref="Uri"/> value to a <see cref="Uri"/> value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}