// ****************************************************************************
// <copyright file="ApplicationBarCollection.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>03-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Windows;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// Represents a collection of <see cref="ApplicationBar" />.
    /// </summary>
    public class ApplicationBarCollection : DependencyObjectCollection<ApplicationBar>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarCollection" /> class.
        /// </summary>
        public ApplicationBarCollection()
        {
        }
    }
}