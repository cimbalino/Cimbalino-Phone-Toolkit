// ****************************************************************************
// <copyright file="ICollectionExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>01-12-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Collections.Generic;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="ICollection{TSource}"/> instances.
    /// </summary>
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Determines whether the specified <see cref="ICollection{TSource}"/> is empty.
        /// </summary>
        /// <param name="collection">The <see cref="ICollection{TSource}"/> to check.</param>
        /// <typeparam name="TSource">The collection items type.</typeparam>
        /// <returns>True if the collection is empty; otherwise, false.</returns>
        public static bool IsEmpty<TSource>(this ICollection<TSource> collection)
        {
            return collection.Count == 0;
        }
    }
}