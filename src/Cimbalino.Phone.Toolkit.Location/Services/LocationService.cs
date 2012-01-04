// ****************************************************************************
// <copyright file="LocationService.cs" company="Pedro Lamas">
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
    /// Represents an implementation of the <see cref="ILocationService"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
        Justification = "This class will be disposed in another matter")]
    public class LocationService : LocationServiceBase, ILocationService
    {
        /// <summary>
        /// Occurs when the location service detects a change in position.
        /// </summary>
        public event EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>> PositionChanged;

        /// <summary>
        /// Occurs when the status of the location service changes.
        /// </summary>
        public event EventHandler<GeoPositionStatusChangedEventArgs> StatusChanged;

        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <param name="locationResult">The <see cref="Action{GeoCoordinate, Exception}" /> to be called once the operation is finished.</param>
        public void GetCurrentLocation(Action<GeoCoordinate, Exception> locationResult)
        {
            new CurrentLocationHelper(locationResult).GetCurrentLocation(DefaultGeoPositionAccuracy);
        }

        /// <summary>
        /// Gets the current location, using the specified accuracy.
        /// </summary>
        /// <param name="accuracy">The desired accuracy.</param>
        /// <param name="locationResult">The <see cref="Action{GeoCoordinate, Exception}" /> to be called once the operation is finished.</param>
        public void GetCurrentLocation(GeoPositionAccuracy accuracy, Action<GeoCoordinate, Exception> locationResult)
        {
            new CurrentLocationHelper(locationResult).GetCurrentLocation(accuracy);
        }

        /// <summary>
        /// Raises the <see cref="E:PositionChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="GeoPositionChangedEventArgs{GeoCoordinate}" /> instance containing the event data.</param>
        protected override void OnPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var eventHandler = PositionChanged;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:StatusChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Device.Location.GeoPositionStatusChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnStatusChanged(GeoPositionStatusChangedEventArgs e)
        {
            var eventHandler = StatusChanged;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
}