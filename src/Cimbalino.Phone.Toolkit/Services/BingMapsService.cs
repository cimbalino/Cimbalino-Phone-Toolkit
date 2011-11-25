// ****************************************************************************
// <copyright file="BingMapsService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>24-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Device.Location;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IBingMapsService"/>.
    /// </summary>
    public class BingMapsService : IBingMapsService
    {
        /// <summary>
        /// Shows the Bing Maps application centered on the user's current location.
        /// </summary>
        public void Show()
        {
            new BingMapsTask().Show();
        }

        /// <summary>
        /// Shows the Bing Maps application centered on the user's current location, with the specified initial zoom level.
        /// </summary>
        /// <param name="zoomLevel">The initial zoom level of the map.</param>
        public void Show(double zoomLevel)
        {
            Show(null, null, zoomLevel);
        }

        /// <summary>
        /// Shows the Bing Maps application centered on the specified location.
        /// </summary>
        /// <param name="center">The location that will be used as the center point for the map.</param>
        public void Show(GeoCoordinate center)
        {
            new BingMapsTask()
            {
                Center = center,
            }.Show();
        }

        /// <summary>
        /// Shows the Bing Maps application centered on the specified location, with the specified initial zoom level.
        /// </summary>
        /// <param name="center">The location that will be used as the center point for the map.</param>
        /// <param name="zoomLevel">The initial zoom level of the map.</param>
        public void Show(GeoCoordinate center, double zoomLevel)
        {
            Show(center, null, zoomLevel);
        }

        /// <summary>
        /// Shows the Bing Maps application centered on the current user location, with locations matching the specified search term tagged on the map.
        /// </summary>
        /// <param name="searchTerm">The search term that is used to find and tag locations on the map.</param>
        public void Show(string searchTerm)
        {
            new BingMapsTask()
            {
                SearchTerm = searchTerm,
            }.Show();
        }

        /// <summary>
        /// Shows the Bing Maps application centered on the current user location, with locations matching the search term tagged on the map, and the specified initial zoom level.
        /// </summary>
        /// <param name="searchTerm">The search term that is used to find and tag locations on the map.</param>
        /// <param name="zoomLevel">The initial zoom level of the map.</param>
        public void Show(string searchTerm, double zoomLevel)
        {
            Show(null, searchTerm, zoomLevel);
        }

        /// <summary>
        /// Shows the Bing Maps application centered on the specified location, with locations matching the search term tagged on the map, and the specified initial zoom level.
        /// </summary>
        /// <param name="center">The location that will be used as the center point for the map.</param>
        /// <param name="searchTerm">The search term that is used to find and tag locations on the map.</param>
        /// <param name="zoomLevel">The initial zoom level of the map.</param>
        public void Show(GeoCoordinate center, string searchTerm, double zoomLevel)
        {
            new BingMapsTask()
            {
                Center = center,
                SearchTerm = searchTerm,
                ZoomLevel = zoomLevel
            }.Show();
        }
    }
}