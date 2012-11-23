// ****************************************************************************
// <copyright file="LocationServiceState.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>03-01-2012</date>
// <project>Cimbalino.Phone.Toolkit.Location</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Describes the current state of <see cref="ILocationService"/>.
    /// </summary>
    public enum LocationServiceState
    {
        /// <summary>
        /// The <see cref="ILocationService"/> is stopped.
        /// </summary>
        Stopped,

        /// <summary>
        /// The <see cref="ILocationService"/> is started.
        /// </summary>
        Started
    }
}