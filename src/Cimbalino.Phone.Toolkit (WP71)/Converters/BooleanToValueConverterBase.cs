// ****************************************************************************
// <copyright file="BooleanToValueConverterBase.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>26-04-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Windows.Data;

namespace Cimbalino.Phone.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> abstract implementation which converts a <see cref="bool"/> value to a value of the specified type.
    /// </summary>
    /// <typeparam name="T">The converter type.</typeparam>
    public abstract class BooleanToValueConverterBase<T> : IValueConverter
    {
        /// <summary>
        /// Gets or sets the value to return if true.
        /// </summary>
        /// <value>The  value to return if true.</value>
        public T TrueValue { get; set; }

        /// <summary>
        /// Gets or sets the value to return if false.
        /// </summary>
        /// <value>The  value to return if false.</value>
        public T FalseValue { get; set; }

        /// <summary>
        /// Converts a <see cref="bool"/> value to a a value of the specified type.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null && (bool)value ? TrueValue : FalseValue;
        }

        /// <summary>
        /// Converts a value from the specified type to a <see cref="bool"/> value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null && value.Equals(TrueValue);
        }
    }
}