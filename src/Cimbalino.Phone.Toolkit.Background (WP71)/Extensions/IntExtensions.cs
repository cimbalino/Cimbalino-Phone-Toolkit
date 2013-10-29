// ****************************************************************************
// <copyright file="IntExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>05-01-2012</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="int"/> instances.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Repeats the specified <see cref="Action"/> the number of times.
        /// </summary>
        /// <param name="input">The number of times to repeat the <see cref="Action"/>.</param>
        /// <param name="action">The <see cref="Action"/> to repeat.</param>
        public static void Times(this int input, Action action)
        {
            while (input-- > 0)
            {
                action();
            }
        }

        /// <summary>
        /// Repeats the specified <see cref="Action{Int32}"/> the number of times.
        /// </summary>
        /// <param name="input">The number of times to repeat the <see cref="Action{Int32}"/>.</param>
        /// <param name="action">The <see cref="Action{Int32}"/> to repeat.</param>
        public static void Times(this int input, Action<int> action)
        {
            var count = 0;

            while (count < input)
            {
                action(count);

                count++;
            }
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="first">The value of the first integer in the sequence.</param>
        /// <param name="count">The number of sequential integers to generate.</param>
        /// <returns>An <see cref="IEnumerable{Int32}"/> that contains a range of sequential integral numbers.</returns>
        public static IEnumerable<int> Range(this int first, int count)
        {
            return Enumerable.Range(first, count);
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="first">The value of the first integer in the sequence.</param>
        /// <param name="last">The value of the last integer in the sequence.</param>
        /// <returns>An <see cref="IEnumerable{Int32}"/> that contains a range of sequential integral numbers.</returns>
        public static IEnumerable<int> To(this int first, int last)
        {
            return first.Range(last - first + 1);
        }
    }
}