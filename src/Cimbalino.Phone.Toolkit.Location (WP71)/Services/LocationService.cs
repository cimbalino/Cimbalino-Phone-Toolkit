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
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILocationService"/>.
    /// </summary>
    public class LocationService : LocationServiceBase, ILocationService
    {
        private static GeoPosition<GeoCoordinate> _position;

        private DispatcherTimer _timer;
        private double _movementThreshold;
        private int _reportInterval;

        /// <summary>
        /// Occurs when the location service detects a change in position.
        /// </summary>
        public event EventHandler<LocationServicePositionChangedEventArgs> PositionChanged;

        /// <summary>
        /// Occurs when the status of the location service changes.
        /// </summary>
        public event EventHandler<LocationServiceStatusChangedEventArgs> StatusChanged;

        #region Properties

        /// <summary>
        /// Gets the accuracy level at which the location service provides location updates.
        /// </summary>
        /// <value>The accuracy level at which the location service provides location updates.</value>
        public LocationServiceAccuracy DesiredAccuracy
        {
            get
            {
                return GeoCoordinateWatcher.DesiredAccuracy.ToLocationServiceAccuracy();
            }
        }

        /// <summary>
        /// Gets the desired accuracy in meters for data returned from the location service.
        /// </summary>
        /// <value>The desired accuracy in meters for data returned from the location service.</value>
        public int? DesiredAccuracyInMeters
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the status that indicates the ability of the location service to provide location updates.
        /// </summary>
        /// <value>The status that indicates the ability of the location service to provide location updates.</value>
        public LocationServiceStatus Status
        {
            get
            {
                var tempWatcher = GeoCoordinateWatcher ?? new GeoCoordinateWatcher();

                if (tempWatcher.Status == GeoPositionStatus.Disabled && tempWatcher.Permission != GeoPositionPermission.Denied)
                {
                    return LocationServiceStatus.NotAvailable;
                }

                return tempWatcher.Status.ToLocationServiceStatus();
            }
        }

        /// <summary>
        /// Gets or sets the distance of movement, in meters, relative to the coordinate from the last <see cref="ILocationService.PositionChanged"/> event, that is required for the location service to raise a <see cref="ILocationService.PositionChanged"/> event.
        /// </summary>
        /// <value>The distance of movement, in meters, relative to the coordinate from the last <see cref="ILocationService.PositionChanged"/> event, that is required for the location service to raise a <see cref="ILocationService.PositionChanged"/> event.</value>
        public double MovementThreshold
        {
            get
            {
                return _movementThreshold;
            }
            set
            {
                _movementThreshold = value;

                if (GeoCoordinateWatcher != null)
                {
                    GeoCoordinateWatcher.MovementThreshold = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the requested minimum time interval between location updates, in milliseconds. If your application requires updates infrequently, set this value so that the location provider can conserve power by calculating location only when needed.
        /// </summary>
        /// <value>The requested minimum time interval between location updates, in milliseconds.</value>
        public int ReportInterval
        {
            get
            {
                return _reportInterval;
            }
            set
            {
                _reportInterval = value;

                if (_timer != null)
                {
                    _timer.Interval = TimeSpan.FromTicks(value);

                    if (value != 0)
                    {
                        if (!_timer.IsEnabled)
                        {
                            _timer.Start();
                        }
                    }
                    else if (_timer.IsEnabled)
                    {
                        _timer.Stop();
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        public void Start()
        {
            Start(LocationServiceAccuracy.Default);
        }

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        public void Start(LocationServiceAccuracy desiredAccuracy)
        {
            Start(desiredAccuracy.ToGeoPositionAccuracy(), _movementThreshold);

            _timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(_reportInterval)
            };

            _timer.Tick += ReportTimerTick;

            if (_reportInterval != 0)
            {
                _timer.Start();
            }
        }

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        /// <param name="desiredAccuracyInMeters">The desired accuracy in meters for data returned from the location service.</param>
        public void Start(int desiredAccuracyInMeters)
        {
            throw new NotSupportedException("Not supported in Windows Phone 7.x");
        }

        /// <summary>
        /// Stops the acquisition of data from the location service.
        /// </summary>
        public override void Stop()
        {
            _timer.Stop();

            _timer.Tick -= ReportTimerTick;

            _timer = null;

            base.Stop();
        }

        /// <summary>
        /// Processed the watcher <see cref="GeoCoordinateWatcher.PositionChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="GeoPositionChangedEventArgs{GeoCoordinate}" /> instance containing the event data.</param>
        protected override void OnPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            _position = e.Position;

            if (_reportInterval == 0)
            {
                RaisePositionChangedEvent();
            }
        }

        /// <summary>
        /// Processes the watcher <see cref="GeoCoordinateWatcher.StatusChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="GeoPositionStatusChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnStatusChanged(GeoPositionStatusChangedEventArgs e)
        {
            var eventHandler = StatusChanged;

            if (eventHandler != null)
            {
                eventHandler(this, e.ToLocationServiceStatusChangedEventArgs());
            }
        }

        /// <summary>
        /// Retrieves the current location.
        /// </summary>
        /// <param name="locationResult">The current location.</param>
        public void GetPosition(Action<LocationServicePosition, Exception> locationResult)
        {
            new CurrentLocationHelper(TimeSpan.FromSeconds(10), locationResult).Start(GeoPositionAccuracy.Default);
        }

        /// <summary>
        /// Retrieves the current location.
        /// </summary>
        /// <param name="maximumAge">The maximum acceptable age of cached location data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="locationResult">The current location.</param>
        public void GetPosition(TimeSpan maximumAge, TimeSpan timeout, Action<LocationServicePosition, Exception> locationResult)
        {
            var position = LastPosition;

            if (position != null && position.Timestamp.Add(maximumAge) > DateTimeOffset.Now)
            {
                locationResult(position.ToLocationServicePosition(), null);
            }
            else
            {
                new CurrentLocationHelper(timeout, locationResult).Start(GeoPositionAccuracy.Default);
            }
        }

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<LocationServicePosition> GetPositionAsync()
        {
            var taskCompletionsSource = new TaskCompletionSource<LocationServicePosition>();

            GetPosition((p, e) =>
            {
                if (p != null)
                {
                    taskCompletionsSource.SetResult(p);
                }
                else
                {
                    taskCompletionsSource.SetException(e);
                }
            });

            return taskCompletionsSource.Task;
        }

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <param name="maximumAge">The maximum acceptable age of cached location data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<LocationServicePosition> GetPositionAsync(TimeSpan maximumAge, TimeSpan timeout)
        {
            var taskCompletionsSource = new TaskCompletionSource<LocationServicePosition>();

            GetPosition(maximumAge, timeout, (p, e) =>
            {
                if (p != null)
                {
                    taskCompletionsSource.SetResult(p);
                }
                else
                {
                    taskCompletionsSource.SetException(e);
                }
            });

            return taskCompletionsSource.Task;
        }

        private void ReportTimerTick(object sender, EventArgs e)
        {
            RaisePositionChangedEvent();
        }

        private void RaisePositionChangedEvent()
        {
            var eventHandler = PositionChanged;
            var position = _position;

            if (eventHandler != null && position != null)
            {
                _position = null;

                var locationServicePosition = position.ToLocationServicePosition();

                eventHandler(this, new LocationServicePositionChangedEventArgs(locationServicePosition));
            }
        }
    }
}