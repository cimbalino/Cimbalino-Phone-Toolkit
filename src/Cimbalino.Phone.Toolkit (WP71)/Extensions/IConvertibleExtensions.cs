// ****************************************************************************
// <copyright file="IConvertibleExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>23-01-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Globalization;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="IConvertible"/> instances.
    /// </summary>
    [CLSCompliant(false)]
    public static class IConvertibleExtensions
    {
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation, using an <see cref="CultureInfo.InvariantCulture"/>.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public static string ToStringInvariantCulture(this IConvertible input)
        {
            return input.ToString(CultureInfo.InvariantCulture);
        }
    }
}