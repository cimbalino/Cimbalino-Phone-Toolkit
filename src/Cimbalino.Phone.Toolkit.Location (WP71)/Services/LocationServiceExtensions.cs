// ****************************************************************************
// <copyright file="LocationServiceExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>24-04-2013</date>
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
    internal static class LocationServiceExtensions
    {
        public static GeoPositionAccuracy ToGeoPositionAccuracy(this LocationServiceAccuracy accuracy)
        {
            switch (accuracy)
            {
                case LocationServiceAccuracy.Default:
                    return GeoPositionAccuracy.Default;

                case LocationServiceAccuracy.High:
                    return GeoPositionAccuracy.High;

                default:
                    throw new ArgumentOutOfRangeException("accuracy");
            }
        }

        public static LocationServiceAccuracy ToLocationServiceAccuracy(this GeoPositionAccuracy positionAccuracy)
        {
            switch (positionAccuracy)
            {
                case GeoPositionAccuracy.Default:
                    return LocationServiceAccuracy.Default;

                case GeoPositionAccuracy.High:
                    return LocationServiceAccuracy.High;

                default:
                    throw new ArgumentOutOfRangeException("positionAccuracy");
            }
        }

        public static LocationServiceStatus ToLocationServiceStatus(this GeoPositionStatus positionStatus)
        {
            switch (positionStatus)
            {
                case GeoPositionStatus.Disabled:
                    return LocationServiceStatus.Disabled;

                case GeoPositionStatus.Ready:
                    return LocationServiceStatus.Ready;

                case GeoPositionStatus.Initializing:
                    return LocationServiceStatus.Initializing;

                case GeoPositionStatus.NoData:
                    return LocationServiceStatus.NoData;

                default:
                    throw new ArgumentOutOfRangeException("positionStatus");
            }
        }

        public static LocationServicePosition ToLocationServicePosition(this GeoPosition<GeoCoordinate> position)
        {
            var coordinate = position.Location;

            return new LocationServicePosition(
                position.Timestamp,
                coordinate.Latitude,
                coordinate.Longitude,
                coordinate.HorizontalAccuracy,
                coordinate.Altitude,
                null,
                coordinate.Course,
                coordinate.Speed);
        }

        public static LocationServicePositionChangedEventArgs ToLocationServicePositionChangedEventArgs(this GeoPositionChangedEventArgs<GeoCoordinate> eventArgs)
        {
            return new LocationServicePositionChangedEventArgs(eventArgs.Position.ToLocationServicePosition());
        }

        public static LocationServiceStatusChangedEventArgs ToLocationServiceStatusChangedEventArgs(this GeoPositionStatusChangedEventArgs eventArgs)
        {
            return new LocationServiceStatusChangedEventArgs(eventArgs.Status.ToLocationServiceStatus());
        }
    }
}