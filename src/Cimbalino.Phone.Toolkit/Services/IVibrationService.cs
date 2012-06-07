// ****************************************************************************
// <copyright file="IVibrationService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of using device vibration capabilities.
    /// </summary>
    public interface IVibrationService
    {
        /// <summary>
        /// Vibrates the device for 200 milliseconds.
        /// </summary>
        void Start();

        /// <summary>
        /// Vibrates the device for the specified duration in milliseconds.
        /// </summary>
        /// <param name="duration">The duration in milliseconds to vibrate the device.</param>
        void Start(double duration);

        /// <summary>
        /// Vibrates the device for the specified duration in milliseconds.
        /// </summary>
        /// <param name="duration">The duration in milliseconds to vibrate the device.</param>
        void Start(TimeSpan duration);

        /// <summary>
        /// Stops vibrating the device.
        /// </summary>
        void Stop();
    }
}