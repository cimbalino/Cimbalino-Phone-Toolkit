// ****************************************************************************
// <copyright file="MapsDirectionsService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-12-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IMapsDirectionsService"/>.
    /// </summary>
    public class MapsDirectionsService : IMapsDirectionsService
    {
        /// <summary>
        /// Shows the Maps application with driving directions displayed for the specified ending location.
        /// </summary>
        /// <param name="endingLocation">The ending location for which driving directions are displayed.</param>
        /// <exception cref="InvalidOperationException">Start and End cannot both be invalid.</exception>
        public void Show(LabeledMapLocation endingLocation)
        {
            Show(null, endingLocation);
        }

        /// <summary>
        /// Shows the Maps application with driving directions displayed for the specified starting and ending locations.
        /// </summary>
        /// <param name="startingLocation">The starting location for which driving directions are displayed.</param>
        /// <param name="endingLocation">The ending location for which driving directions are displayed.</param>
        /// <exception cref="InvalidOperationException">Start and End cannot both be invalid.</exception>
        public void Show(LabeledMapLocation startingLocation, LabeledMapLocation endingLocation)
        {
#if WP8
            new MapsDirectionsTask()
#else
            new BingMapsDirectionsTask()
#endif
            {
                Start = startingLocation,
                End = endingLocation
            }.Show();
        }
    }
}