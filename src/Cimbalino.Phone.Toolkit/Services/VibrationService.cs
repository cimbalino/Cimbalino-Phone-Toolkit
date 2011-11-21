// ****************************************************************************
// <copyright file="VibrationService.cs" company="Pedro Lamas">
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
using Microsoft.Devices;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IVibrationService"/>.
    /// </summary>
    public class VibrationService : IVibrationService
    {
        /// <summary>
        /// Vibrates the device for 200 milliseconds.
        /// </summary>
        public void Start()
        {
            Start(200);
        }

        /// <summary>
        /// Vibrates the device for the specified duration in milliseconds.
        /// </summary>
        /// <param name="duration">The duration in milliseconds to vibrate the device.</param>
        public void Start(double duration)
        {
            Start(TimeSpan.FromMilliseconds(duration));
        }

        /// <summary>
        /// Vibrates the device for the specified duration in milliseconds.
        /// </summary>
        /// <param name="duration">The duration in milliseconds to vibrate the device.</param>
        public void Start(TimeSpan duration)
        {
            VibrateController.Default.Start(duration);
        }

        /// <summary>
        /// Stops vibrating the device.
        /// </summary>
        public void Stop()
        {
            VibrateController.Default.Stop();
        }
    }
}