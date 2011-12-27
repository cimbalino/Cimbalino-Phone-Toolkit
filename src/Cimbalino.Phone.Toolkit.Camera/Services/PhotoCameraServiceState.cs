// ****************************************************************************
// <copyright file="PhotoCameraServiceState.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>27-12-2011</date>
// <project>Cimbalino.Phone.Toolkit.Camera</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Describes the current state of <see cref="IPhotoCameraService"/>.
    /// </summary>
    public enum PhotoCameraServiceState
    {
        /// <summary>
        /// The <see cref="IPhotoCameraService"/> is stopped.
        /// </summary>
        Stopped,

        /// <summary>
        /// The <see cref="IPhotoCameraService"/> is starting.
        /// </summary>
        Starting,

        /// <summary>
        /// The <see cref="IPhotoCameraService"/> is started.
        /// </summary>
        Started
    }
}