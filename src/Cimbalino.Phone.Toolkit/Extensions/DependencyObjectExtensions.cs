// ****************************************************************************
// <copyright file="DependencyObjectExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>11-05-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="DependencyObject"/> instances.
    /// </summary>
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Returns an object's parent object in the visual tree.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The parent object of the <paramref name="dependencyObject"/> object in the visual tree.</returns>
        public static DependencyObject GetVisualParent(this DependencyObject dependencyObject)
        {
            return VisualTreeHelper.GetParent(dependencyObject);
        }

        /// <summary>
        /// Returns the ancentor object of the <paramref name="dependencyObject"/> object in the visual tree with the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the visual ancestor.</typeparam>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The ancentor object of the <paramref name="dependencyObject"/> object in the visual tree with the specified type.</returns>
        public static T GetVisualAncestor<T>(this DependencyObject dependencyObject)
            where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            while (parent != null)
            {
                if (parent is T)
                {
                    return (T)parent;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }

        /// <summary>
        /// Retrieves all the visual children of a dependency object.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The visual children of the dependency object.</returns>
        public static IEnumerable<DependencyObject> GetVisualChilds(this DependencyObject dependencyObject)
        {
            var childCount = VisualTreeHelper.GetChildrenCount(dependencyObject);

            for (var childIndex = 0; childIndex < childCount; childIndex++)
            {
                yield return VisualTreeHelper.GetChild(dependencyObject, childIndex);
            }
        }

        /// <summary>
        /// Retrieves all the visual children of a dependency object with the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the visual children.</typeparam>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The visual children of the dependency object with the specified type.</returns>
        public static IEnumerable<T> GetVisualChilds<T>(this DependencyObject dependencyObject)
            where T : DependencyObject
        {
            return dependencyObject.GetVisualChilds()
                .OfType<T>();
        }

        /// <summary>
        /// Retrieves all the visual descendants of a dependency object.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The visual descendantes of the dependency object.</returns>
        public static IEnumerable<DependencyObject> GetVisualDescendents(this DependencyObject dependencyObject)
        {
            return dependencyObject.GetVisualChilds()
                .Descendants(x => x.GetVisualDescendents());
        }

        /// <summary>
        /// Retrieves all the visual descendants of a dependency object with the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the visual descendants.</typeparam>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The visual descendantes of the dependency object with the specified type.</returns>
        public static IEnumerable<T> GetVisualDescendents<T>(this DependencyObject dependencyObject)
            where T : DependencyObject
        {
            return dependencyObject.GetVisualChilds<T>()
                .Descendants(x => x.GetVisualDescendents<T>());
        }
    }
}