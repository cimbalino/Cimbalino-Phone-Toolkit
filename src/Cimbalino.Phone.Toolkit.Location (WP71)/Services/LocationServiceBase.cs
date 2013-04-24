// ****************************************************************************
// <copyright file="LocationServiceBase.cs" company="Pedro Lamas">
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

using System.Device.Location;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Base class for device location capabilities.
    /// </summary>
    public abstract class LocationServiceBase
    {
        /// <summary>
        /// Gets the <see cref="GeoCoordinateWatcher"/> instance.
        /// </summary>
        /// <value>The <see cref="GeoCoordinateWatcher"/> instance.</value>
        protected GeoCoordinateWatcher GeoCoordinateWatcher { get; private set; }

        /// <summary>
        /// Gets the last reported position.
        /// </summary>
        /// <value>The last reported position.</value>
        protected static GeoPosition<GeoCoordinate> LastPosition { get; private set; }

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <param name="movementThreshold">The minimum distance that must be travelled between successive position changes.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "The class will be disposed in another matter")]
        protected void Start(GeoPositionAccuracy desiredAccuracy, double movementThreshold)
        {
            if (GeoCoordinateWatcher != null)
            {
                return;
            }

            GeoCoordinateWatcher = new GeoCoordinateWatcher(desiredAccuracy)
            {
                MovementThreshold = movementThreshold
            };

            GeoCoordinateWatcher.PositionChanged += GeoCoordinateWatcherPositionChanged;
            GeoCoordinateWatcher.StatusChanged += GeoCoordinateWatcherStatusChanged;

            GeoCoordinateWatcher.Start();
        }

        /// <summary>
        /// Stops the acquisition of data from the location service.
        /// </summary>
        public virtual void Stop()
        {
            if (GeoCoordinateWatcher == null)
            {
                return;
            }

            GeoCoordinateWatcher.Stop();

            GeoCoordinateWatcher.PositionChanged -= GeoCoordinateWatcherPositionChanged;
            GeoCoordinateWatcher.StatusChanged -= GeoCoordinateWatcherStatusChanged;

            GeoCoordinateWatcher.Dispose();
            GeoCoordinateWatcher = null;
        }

        /// <summary>
        /// Invoked when the location service detects a change in position.
        /// </summary>
        /// <param name="e">The <see cref="GeoPositionChangedEventArgs{GeoCoordinate}" /> instance containing the event data.</param>
        protected abstract void OnPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e);

        /// <summary>
        /// Invoked when the status of the location service changes.
        /// </summary>
        /// <param name="e">The <see cref="GeoPositionStatusChangedEventArgs" /> instance containing the event data.</param>
        protected abstract void OnStatusChanged(GeoPositionStatusChangedEventArgs e);

        private void GeoCoordinateWatcherPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            LastPosition = e.Position;

            OnPositionChanged(e);
        }

        private void GeoCoordinateWatcherStatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            OnStatusChanged(e);
        }
    }
}