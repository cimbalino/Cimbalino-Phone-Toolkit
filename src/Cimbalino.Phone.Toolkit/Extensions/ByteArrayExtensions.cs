// ****************************************************************************
// <copyright file="ByteArrayExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Text;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="byte"/> array instances.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent <see cref="string"/> representation encoded with base 64 digits.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <returns>The string representation, in base 64, of the contents of <paramref name="input"/>.</returns>
        public static string ToBase64String(this byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent <see cref="string"/> representation, using the specified <see cref="Encoding"/>.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="encoding">The <see cref="Encoding"/> to use for encoding the characters.</param>
        /// <returns>The string representation, of the contents of <paramref name="input"/>.</returns>
        public static string ToString(this byte[] input, Encoding encoding)
        {
            return encoding.GetString(input, 0, input.Length);
        }
    }
}