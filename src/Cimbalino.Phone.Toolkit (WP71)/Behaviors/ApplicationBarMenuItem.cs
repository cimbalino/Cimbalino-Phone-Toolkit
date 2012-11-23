// ****************************************************************************
// <copyright file="ApplicationBarMenuItem.cs" company="Pedro Lamas">
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
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// An item that can be added to the menu of an <see cref="Microsoft.Phone.Shell.ApplicationBar"/>.
    /// </summary>
    public class ApplicationBarMenuItem : ApplicationBarItemBase<IApplicationBarMenuItem>, IApplicationBarMenuItem
    {
        /// <summary>
        /// Occurs when a <see cref="ApplicationBarMenuItem"/> is clicked.
        /// </summary>
        public override event EventHandler Click
        {
            add
            {
                base.Click += value;
            }
            remove
            {
                base.Click -= value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarMenuItem" /> class.
        /// </summary>
        public ApplicationBarMenuItem()
            : base(new Microsoft.Phone.Shell.ApplicationBarMenuItem())
        {
        }
    }
}