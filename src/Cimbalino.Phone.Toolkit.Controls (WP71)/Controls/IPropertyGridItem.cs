// ****************************************************************************
// <copyright file="IPropertyGridItem.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Controls
{
    /// <summary>
    /// Represents a <see cref="PropertyGrid"/> item.
    /// </summary>
    public interface IPropertyGridItem
    {
        /// <summary>
        /// Gets the category of the item.
        /// </summary>
        /// <value>The category of the item.</value>
        string Category { get; }

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the item is writable.
        /// </summary>
        /// <value>A value indicating whether the item is writable.</value>
        bool IsWritable { get; }

        /// <summary>
        /// Updates the item.
        /// </summary>
        void Update();
    }
}