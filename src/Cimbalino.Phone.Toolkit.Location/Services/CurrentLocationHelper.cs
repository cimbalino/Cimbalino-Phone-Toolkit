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

namespace Cimbalino.Phone.Toolkit.Services
{
    internal class CurrentLocationHelper : LocationServiceBase
    {
        private readonly Action<GeoCoordinate, Exception> _actionToExecute;

        public CurrentLocationHelper(Action<GeoCoordinate, Exception> actionToExecute)
        {
            _actionToExecute = actionToExecute;
        }

        public void GetCurrentLocation()
        {
            try
            {
                Start();

                CheckCurrentState();
            }
            catch (Exception ex)
            {
                Stop();

                _actionToExecute(null, ex);
            }
        }

        private void CheckCurrentState()
        {
            if (Permission == GeoPositionPermission.Denied)
            {
                throw new Exception("Access to the location service is denied.");
            }

            if (Status == GeoPositionStatus.Disabled)
            {
                throw new Exception("The location service is disabled or unsupported.");
            }
        }

        protected override void OnPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Stop();

            _actionToExecute(e.Position.Location, null);
        }

        protected override void OnStatusChanged(GeoPositionStatusChangedEventArgs e)
        {
            try
            {
                CheckCurrentState();
            }
            catch (Exception ex)
            {
                Stop();

                _actionToExecute(null, ex);
            }
        }
    }
}