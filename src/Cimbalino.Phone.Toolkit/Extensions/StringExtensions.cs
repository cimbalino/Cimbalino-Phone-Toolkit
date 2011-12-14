// ****************************************************************************
// <copyright file="StringExtensions.cs" company="Pedro Lamas">
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
using System.Globalization;
using System.Text;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="string"/> instances.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the current string is null or an <see cref="String.Empty"/> string.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <returns>true if the current string is null or an <see cref="String.Empty"/> string; otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// Determines whether the current string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <returns>true if the current string is null, empty, or consists only of white-space characters; otherwise, false.</returns>
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Encodes all the characters in the string into a sequence of UTF8 bytes.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <returns>A byte array containing the results of encoding the set of characters.</returns>
        public static byte[] GetBytes(this string input)
        {
            return input.GetBytes(Encoding.UTF8);
        }

        /// <summary>
        /// Encodes all the characters in the string into a sequence of bytes, using the specified <see cref="Encoding"/>.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="encoding">The <see cref="Encoding"/> to use for encoding the characters.</param>
        /// <returns>A byte array containing the results of encoding the set of characters.</returns>
        public static byte[] GetBytes(this string input, Encoding encoding)
        {
            return encoding.GetBytes(input);
        }

        /// <summary>
        /// Converts the string, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <returns>An array of 8-bit unsigned integers that is equivalent to the string</returns>
        public static byte[] FromBase64String(this string input)
        {
            return Convert.FromBase64String(input);
        }

        /// <summary>
        /// Replaces one or more format items in the string with the string representation of a specified object.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of the string in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// Replaces one or more format items in the string with the string representation of a specified object, using an <see cref="CultureInfo.InvariantCulture"/>.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of the string in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatInvariantCulture(this string format, params object[] args)
        {
            return format.Format(CultureInfo.InvariantCulture, args);
        }

        /// <summary>
        /// Replaces one or more format items in the string with the string representation of a specified object, using the specified <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> to use when formating the string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of the string in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string Format(this string format, CultureInfo cultureInfo, params object[] args)
        {
            return string.Format(cultureInfo, format, args);
        }

        /// <summary>
        /// Returns a new string containing the specified number of characters from the left side of the current string.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in the string, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the left side of the string.</returns>
        public static string Left(this string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }

            return input.Substring(0, length);
        }

        /// <summary>
        /// Returns a new string containing the specified number of characters from the right side of the current string.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in the string, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the right side of the string.</returns>
        public static string Right(this string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }

            return input.Substring(input.Length - length, length);
        }

        /// <summary>
        /// Returns a new string in which a specified number of characters from the left side of the current string are deleted.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to remove. If greater than or equal to the number of characters in the string, an empty string is returned.</param>
        /// <returns>Returns a string in which a specified number of characters from the left side of the current string where deleted.</returns>
        public static string RemoveLeft(this string input, int length)
        {
            if (input.Length <= length)
            {
                return string.Empty;
            }

            return input.Substring(length);
        }

        /// <summary>
        /// Returns a new string in which a specified number of characters from the right side of the current string are deleted.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to remove. If greater than or equal to the number of characters in the string, an empty string is returned.</param>
        /// <returns>Returns a string in which a specified number of characters from the right side of the current string where deleted.</returns>
        public static string RemoveRight(this string input, int length)
        {
            if (input.Length <= length)
            {
                return string.Empty;
            }

            return input.Substring(0, input.Length - length);
        }
    }
}