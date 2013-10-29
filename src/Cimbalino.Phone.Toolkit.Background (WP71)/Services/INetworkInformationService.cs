// ****************************************************************************
// <copyright file="INetworkInformationService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>24-05-2013</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Microsoft.Phone.Net.NetworkInformation;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of providing network information for a specific Windows Phone device.
    /// </summary>
    public interface INetworkInformationService
    {
        /// <summary>
        /// Occurs when the availability of the network changes.
        /// </summary>
        event EventHandler<NetworkNotificationEventArgs> NetworkAvailabilityChanged;

        /// <summary>
        /// Gets the name of the cellular mobile operator.
        /// </summary>
        /// <value>The name of the cellular mobile operator.</value>
        string CellularMobileOperator { get; }

        /// <summary>
        /// Gets a value indicating whether the network is cellular data enabled.
        /// </summary>
        /// <value>true if the network is cellular data enabled; otherwise, false.</value>
        bool IsCellularDataEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the network allows data roaming.
        /// </summary>
        /// <value>true if the network allows data roaming; otherwise, false.</value>
        bool IsCellularDataRoamingEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the network is available.
        /// </summary>
        /// <value>true if the network is available; otherwise, false.</value>
        bool IsNetworkAvailable { get; }

        /// <summary>
        /// Gets a value indicating whether the network is Wi-Fi enabled.
        /// </summary>
        /// <value>true if the network is Wi-Fi enabled; otherwise, false.</value>
        bool IsWiFiEnabled { get; }
    }
}