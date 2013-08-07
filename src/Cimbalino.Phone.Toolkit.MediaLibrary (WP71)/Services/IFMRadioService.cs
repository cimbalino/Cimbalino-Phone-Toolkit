// ****************************************************************************
// <copyright file="IFMRadioService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-08-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Microsoft.Devices.Radio;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the device FM radio.
    /// </summary>
    public interface IFMRadioService
    {
        /// <summary>
        /// Gets a value indicating whether the FM radio is available.
        /// </summary>
        /// <value>true if the FM radio is available; otherwise, false.</value>
        bool IsAvailable { get; }

        /// <summary>
        /// Gets or sets the FM radio frequency region information.
        /// </summary>
        /// <value>The FM radio frequency region information.</value>
        RadioRegion CurrentRegion { get; set; }

        /// <summary>
        /// Gets or sets the FM radio frequency.
        /// </summary>
        /// <value>The FM radio frequency.</value>
        double Frequency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the FM radio power is on or off.
        /// </summary>
        /// <value>true if the FM radio power in on; otherwise, false.</value>
        bool IsRadioPowerOn { get; set; }

        /// <summary>
        /// Gets the received signal strength indicator (RSSI) value for the currently tuned frequency.
        /// </summary>
        /// <value>The received signal strength indicator (RSSI) value for the currently tuned frequency.</value>
        double SignalStrength { get; }

        /// <summary>
        /// Power on the FM radio.
        /// </summary>
        void PowerOn();

        /// <summary>
        /// Power off the FM radio.
        /// </summary>
        void PowerOff();
    }
}