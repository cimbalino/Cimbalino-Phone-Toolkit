// ****************************************************************************
// <copyright file="IBingMapsService.cs" company="Pedro Lamas">
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

using System;
using System.Device.Location;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the Bing Maps application, specifying optional center location, search term, and initial zoom values.
    /// </summary>
    public interface IBingMapsService
    {
        /// <summary>
        /// Shows the Bing Maps application centered on the user's current location.
        /// </summary>
        /// <exception cref="InvalidOperationException">Center and SearchTerm cannot both be empty.</exception>
        void Show();

        /// <summary>
        /// Shows the Bing Maps application centered on the user's current location, with the specified initial zoom level.
        /// </summary>
        /// <param name="zoomLevel">The initial zoom level of the map.</param>
        /// <exception cref="InvalidOperationException">Center and SearchTerm cannot both be empty.</exception>
        void Show(double zoomLevel);

        /// <summary>
        /// Shows the Bing Maps application centered on the specified location.
        /// </summary>
        /// <param name="center">The location that will be used as the center point for the map.</param>
        /// <exception cref="InvalidOperationException">Center and SearchTerm cannot both be empty.</exception>
        void Show(GeoCoordinate center);

        /// <summary>
        /// Shows the Bing Maps application centered on the specified location, with the specified initial zoom level.
        /// </summary>
        /// <param name="center">The location that will be used as the center point for the map.</param>
        /// <param name="zoomLevel">The initial zoom level of the map.</param>
        /// <exception cref="InvalidOperationException">Center and SearchTerm cannot both be empty.</exception>
        void Show(GeoCoordinate center, double zoomLevel);

        /// <summary>
        /// Shows the Bing Maps application centered on the current user location, with locations matching the specified search term tagged on the map.
        /// </summary>
        /// <param name="searchTerm">The search term that is used to find and tag locations on the map.</param>
        /// <exception cref="InvalidOperationException">Center and SearchTerm cannot both be empty.</exception>
        void Show(string searchTerm);

        /// <summary>
        /// Shows the Bing Maps application centered on the current user location, with locations matching the search term tagged on the map, and the specified initial zoom level.
        /// </summary>
        /// <param name="searchTerm">The search term that is used to find and tag locations on the map.</param>
        /// <param name="zoomLevel">The initial zoom level of the map.</param>
        /// <exception cref="InvalidOperationException">Center and SearchTerm cannot both be empty.</exception>
        void Show(string searchTerm, double zoomLevel);

        /// <summary>
        /// Shows the Bing Maps application centered on the specified location, with locations matching the search term tagged on the map, and the specified initial zoom level.
        /// </summary>
        /// <param name="center">The location that will be used as the center point for the map.</param>
        /// <param name="searchTerm">The search term that is used to find and tag locations on the map.</param>
        /// <param name="zoomLevel">The initial zoom level of the map.</param>
        /// <exception cref="InvalidOperationException">Center and SearchTerm cannot both be empty.</exception>
        void Show(GeoCoordinate center, string searchTerm, double zoomLevel);
    }
}