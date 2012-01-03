// ****************************************************************************
// <copyright file="ILocationService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit.Location</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Device.Location;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the device location capabilities
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Occurs when the location service detects a change in position.
        /// </summary>
        event EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>> PositionChanged;

        /// <summary>
        /// Occurs when the status of the location service changes.
        /// </summary>
        event EventHandler<GeoPositionStatusChangedEventArgs> StatusChanged;

        /// <summary>
        /// Gets the state of the <see cref="ILocationService"/>.
        /// </summary>
        /// <value>Returns a <see cref="LocationServiceState"/> enumeration indication the state of the <see cref="ILocationService"/>.</value>
        LocationServiceState State { get; }

        /// <summary>
        /// Gets the application’s level of access to the location service.
        /// </summary>
        /// <value>The application’s level of access to the location service.</value>
        GeoPositionPermission Permission { get; }

        /// <summary>
        /// Gets the status of the location service.
        /// </summary>
        /// <value>The status of the location service.</value>
        GeoPositionStatus Status { get; }

        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <param name="locationResult">The location request result.</param>
        void GetCurrentLocation(Action<GeoCoordinate, Exception> locationResult);

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts the acquisition of data from the location service, using the specified <see cref="DesiredAccuracy"/>.
        /// </summary>
        /// <param name="accuracy">The <see cref="DesiredAccuracy"/>.</param>
        void Start(GeoPositionAccuracy accuracy);

        /// <summary>
        /// Starts the acquisition of data from the location service, using the specified <see cref="DesiredAccuracy"/> and movement threshold.
        /// </summary>
        /// <param name="accuracy">The <see cref="DesiredAccuracy"/>.</param>
        /// <param name="movementThreshold">The minimum distance that must be travelled between successive <see cref="PositionChanged"/> events.</param>
        void Start(GeoPositionAccuracy accuracy, double movementThreshold);

        /// <summary>
        /// Stops the acquisition of data from the location service.
        /// </summary>
        void Stop();
    }
}