// ****************************************************************************
// <copyright file="EnumValueConverter.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>09-05-2012</date>
// <project>Cimbalino.Phone.Toolkit.Controls</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Windows.Data;

namespace Cimbalino.Phone.Toolkit.Controls
{
    /// <summary>
    /// An <see cref="IValueConverter"/> which converts a <see cref="Enum"/> value to a <see cref="string"/> value.
    /// </summary>
    public class EnumValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts an <see cref="Enum"/> value to a <see cref="string"/> value.
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
            return Enum.GetName(value.GetType(), value);
        }

        /// <summary>
        /// Converts a <see cref="string"/> value to an <see cref="Enum"/> value.
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
            return Enum.Parse(targetType, value.ToString(), false);
        }
    }
}