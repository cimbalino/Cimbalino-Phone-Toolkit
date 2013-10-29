// ****************************************************************************
// <copyright file="NetworkInformationService.cs" company="Pedro Lamas">
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
    /// Represents an implementation of the <see cref="INetworkInformationService"/>.
    /// </summary>
    public class NetworkInformationService : INetworkInformationService
    {
        /// <summary>
        /// Occurs when the availability of the network changes.
        /// </summary>
        public event EventHandler<NetworkNotificationEventArgs> NetworkAvailabilityChanged
        {
            add
            {
                DeviceNetworkInformation.NetworkAvailabilityChanged += value;
            }
            remove
            {
                DeviceNetworkInformation.NetworkAvailabilityChanged -= value;
            }
        }

        /// <summary>
        /// Gets the name of the cellular mobile operator.
        /// </summary>
        /// <value>The name of the cellular mobile operator.</value>
        public string CellularMobileOperator
        {
            get
            {
                return DeviceNetworkInformation.CellularMobileOperator;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the network is cellular data enabled.
        /// </summary>
        /// <value>true if the network is cellular data enabled; otherwise, false.</value>
        public bool IsCellularDataEnabled
        {
            get
            {
                return DeviceNetworkInformation.IsCellularDataEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the network allows data roaming.
        /// </summary>
        /// <value>true if the network allows data roaming; otherwise, false.</value>
        public bool IsCellularDataRoamingEnabled
        {
            get
            {
                return DeviceNetworkInformation.IsCellularDataRoamingEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the network is available.
        /// </summary>
        /// <value>true if the network is available; otherwise, false.</value>
        public bool IsNetworkAvailable
        {
            get
            {
                return DeviceNetworkInformation.IsNetworkAvailable;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the network is Wi-Fi enabled.
        /// </summary>
        /// <value>true if the network is Wi-Fi enabled; otherwise, false.</value>
        public bool IsWiFiEnabled
        {
            get
            {
                return DeviceNetworkInformation.IsWiFiEnabled;
            }
        }
    }
}