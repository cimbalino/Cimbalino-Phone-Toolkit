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
    /// Base class for device location capabilities
    /// </summary>
    public abstract class LocationServiceBase
    {
        /// <summary>
        /// The default <see cref="GeoPositionAccuracy"/>.
        /// </summary>
        protected const GeoPositionAccuracy DefaultGeoPositionAccuracy = GeoPositionAccuracy.Default;

        /// <summary>
        /// The default movement threshold
        /// </summary>
        protected const double DefaultMovementThreshold = 20;

        private GeoCoordinateWatcher _watcher;

        /// <summary>
        /// Gets the state of the <see cref="ILocationService"/>.
        /// </summary>
        /// <value>Returns a <see cref="LocationServiceState"/> enumeration indication the state of the <see cref="ILocationService"/>.</value>
        public LocationServiceState State { get; private set; }

        /// <summary>
        /// Gets the application’s level of access to the location service.
        /// </summary>
        /// <value>The application’s level of access to the location service.</value>
        public GeoPositionPermission Permission
        {
            get
            {
                return _watcher.Permission;
            }
        }

        /// <summary>
        /// Gets the status of the location service.
        /// </summary>
        /// <value>The status of the location service.</value>
        public GeoPositionStatus Status
        {
            get
            {
                return _watcher.Status;
            }
        }

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        public void Start()
        {
            Start(DefaultGeoPositionAccuracy, DefaultMovementThreshold);
        }

        /// <summary>
        /// Starts the acquisition of data from the location service, using the specified accuracy.
        /// </summary>
        /// <param name="accuracy">The desired accuracy.</param>
        public void Start(GeoPositionAccuracy accuracy)
        {
            Start(accuracy, DefaultMovementThreshold);
        }

        /// <summary>
        /// Starts the acquisition of data from the location service, using the specified accuracy and movement threshold.
        /// </summary>
        /// <param name="accuracy">The desired accuracy.</param>
        /// <param name="movementThreshold">The minimum distance that must be travelled between successive <see cref="E:PositionChanged" /> events.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "The class will be disposed in another matter")]
        public void Start(GeoPositionAccuracy accuracy, double movementThreshold)
        {
            if (_watcher != null)
            {
                return;
            }

            _watcher = new GeoCoordinateWatcher(accuracy)
            {
                MovementThreshold = movementThreshold
            };

            _watcher.PositionChanged += Watcher_PositionChanged;
            _watcher.StatusChanged += Watcher_StatusChanged;

            _watcher.Start();

            State = LocationServiceState.Started;
        }

        /// <summary>
        /// Stops the acquisition of data from the location service.
        /// </summary>
        public void Stop()
        {
            if (_watcher == null)
            {
                return;
            }

            _watcher.Stop();

            _watcher.PositionChanged -= Watcher_PositionChanged;
            _watcher.StatusChanged -= Watcher_StatusChanged;

            _watcher.Dispose();
            _watcher = null;

            State = LocationServiceState.Stopped;
        }

        /// <summary>
        /// Processed the watcher <see cref="E:PositionChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="GeoPositionChangedEventArgs{GeoCoordinate}" /> instance containing the event data.</param>
        protected abstract void OnPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e);

        /// <summary>
        /// Processes the watcher <see cref="E:StatusChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Device.Location.GeoPositionStatusChangedEventArgs" /> instance containing the event data.</param>
        protected abstract void OnStatusChanged(GeoPositionStatusChangedEventArgs e);

        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            OnPositionChanged(e);
        }

        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            OnStatusChanged(e);
        }
    }
}