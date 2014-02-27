// ****************************************************************************
// <copyright file="CurrentLocationHelper.cs" company="Pedro Lamas">
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

using System;
using System.Device.Location;
using System.Windows.Threading;

namespace Cimbalino.Phone.Toolkit.Services
{
    internal class CurrentLocationHelper : LocationServiceBase
    {
        private readonly TimeSpan _timeout;
        private readonly Action<LocationServicePosition, Exception> _actionToExecute;

        private DispatcherTimer _timer;
        private GeoPosition<GeoCoordinate> _lastPosition;
        private bool _ready;

        public CurrentLocationHelper(TimeSpan timeout, Action<LocationServicePosition, Exception> actionToExecute)
        {
            _timeout = timeout;
            _actionToExecute = actionToExecute;
        }

        public override void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();

                _timer.Tick -= TimerTick;

                _timer = null;
            }

            base.Stop();
        }

        protected override void OnPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            _lastPosition = e.Position;

            CheckForLocationAvailable();
        }

        protected override void OnStatusChanged(GeoPositionStatusChangedEventArgs e)
        {
            try
            {
                CheckCurrentState();

                _ready = e.Status == GeoPositionStatus.Ready;

                CheckForLocationAvailable();
            }
            catch (Exception ex)
            {
                Stop();

                _actionToExecute(null, ex);
            }
        }

        public void Start(GeoPositionAccuracy desiredAccuracy)
        {
            try
            {
                Start(desiredAccuracy, 0);

                CheckCurrentState();

                _timer = new DispatcherTimer()
                {
                    Interval = _timeout
                };

                _timer.Tick += TimerTick;

                _timer.Start();
            }
            catch (Exception ex)
            {
                Stop();

                _actionToExecute(null, ex);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            try
            {
                throw new TimeoutException();
            }
            catch (Exception ex)
            {
                Stop();

                _actionToExecute(null, ex);
            }
        }

        private void CheckCurrentState()
        {
            if (GeoCoordinateWatcher.Permission == GeoPositionPermission.Denied)
            {
                throw new Exception("Access to the location service is denied.");
            }

            if (GeoCoordinateWatcher.Status == GeoPositionStatus.Disabled)
            {
                throw new Exception("The location service is disabled or unsupported.");
            }
        }

        private void CheckForLocationAvailable()
        {
            if (_ready && _lastPosition != null)
            {
                Stop();

                _actionToExecute(_lastPosition.ToLocationServicePosition(), null);
            }
        }
    }
}