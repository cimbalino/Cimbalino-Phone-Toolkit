// ****************************************************************************
// <copyright file="BingMapsDirectionsService.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IBingMapsDirectionsService"/>.
    /// </summary>
    public class BingMapsDirectionsService : IBingMapsDirectionsService
    {
        /// <summary>
        /// Shows the Bing Maps application with driving directions displayed for the specified ending location.
        /// </summary>
        /// <param name="endingLocation">The ending location for which driving directions are displayed.</param>
        public void Show(LabeledMapLocation endingLocation)
        {
            Show(null, endingLocation);
        }

        /// <summary>
        /// Shows the Bing Maps application with driving directions displayed for the specified starting and ending locations.
        /// </summary>
        /// <param name="startingLocation">The starting location for which driving directions are displayed.</param>
        /// <param name="endingLocation">The ending location for which driving directions are displayed.</param>
        public void Show(LabeledMapLocation startingLocation, LabeledMapLocation endingLocation)
        {
            new BingMapsDirectionsTask()
            {
                Start = startingLocation,
                End = endingLocation
            }.Show();
        }
    }
}