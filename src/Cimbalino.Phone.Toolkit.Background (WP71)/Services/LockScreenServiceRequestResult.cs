// ****************************************************************************
// <copyright file="LockScreenServiceRequestResult.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>15-08-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Indicates if the app was successfully or unsuccessfully set as the lock screen background provider.
    /// </summary>
    public enum LockScreenServiceRequestResult
    {
        /// <summary>
        /// The app was not set as the lock screen background provider.
        /// </summary>
        Denied,

        /// <summary>
        /// The app was set as the lock screen background provider.
        /// </summary>
        Granted
    }
}