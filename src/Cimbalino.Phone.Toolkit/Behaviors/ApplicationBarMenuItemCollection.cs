// ****************************************************************************
// <copyright file="ApplicationBarMenuItemCollection.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// Represents a collection of <see cref="IApplicationBarMenuItem" />
    /// </summary>
    public class ApplicationBarMenuItemCollection : ApplicationBarItemCollectionBase<IApplicationBarMenuItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarMenuItemCollection" /> class.
        /// </summary>
        /// <param name="itemsList">The items list.</param>
        public ApplicationBarMenuItemCollection(System.Collections.IList itemsList)
            : base(itemsList)
        {
        }
    }
}