// ****************************************************************************
// <copyright file="ArrayExtensions.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="System.Array"/> instances
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Determines whether the specified array is null or empty.
        /// </summary>
        /// <param name="array">The array to check.</param>
        /// <typeparam name="TSource">The type of the array to check.</typeparam>
        /// <returns>True if the array is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty<TSource>(this TSource[] array)
        {
            return array == null || array.Length == 0;
        }
    }
}