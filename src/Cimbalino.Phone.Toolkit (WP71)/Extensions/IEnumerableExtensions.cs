// ****************************************************************************
// <copyright file="IEnumerableExtensions.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="IEnumerable{TResult}"/> instances.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Applies the specified <see cref="Action{TResult}"/> to the enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="action">The action to apply.</param>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static void Apply<TResult>(this IEnumerable<TResult> source, Action<TResult> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Applies the specified <see cref="T:Action{TResult, int}"/> to the enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="action">The action to apply.</param>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static void Apply<TResult>(this IEnumerable<TResult> source, Action<TResult, int> action)
        {
            var index = 0;

            foreach (var item in source)
            {
                action(item, index);

                index++;
            }
        }

        /// <summary>
        /// Returns a collection of the decendant elements for this enumerable, using the specified <see cref="T:Func{TResult, IEnumerable{TResult}}"/> function.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="descendBy">The function to use for descending.</param>
        /// <returns>All the descendant items.</returns>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static IEnumerable<TResult> Descendants<TResult>(this IEnumerable<TResult> source, Func<TResult, IEnumerable<TResult>> descendBy)
        {
            foreach (var value in source)
            {
                yield return value;

                foreach (var child in descendBy(value).Descendants<TResult>(descendBy))
                {
                    yield return child;
                }
            }
        }

        /// <summary>
        /// Creates an <see cref="ObservableCollection{TResult}"/> from this enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <returns>An <see cref="ObservableCollection{TResult}"/> that contains the elements from the input sequence.</returns>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static ObservableCollection<TResult> ToObservableCollection<TResult>(this IEnumerable<TResult> source)
        {
            return new ObservableCollection<TResult>(source);
        }

        /// <summary>
        /// Produces a sequence containing the current elements along with the specified element.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="element">A <typeparamref name="TResult"/> element to include in the sequence.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that contains the current elements along with the specified element.</returns>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static IEnumerable<TResult> Concat<TResult>(this IEnumerable<TResult> source, TResult element)
        {
            foreach (var value in source)
            {
                yield return value;
            }

            yield return element;
        }
    }
}