// ****************************************************************************
// <copyright file="IMapsDirectionsService.cs" company="Pedro Lamas">
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
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the Maps application, specifying a starting location or an ending location, or both, for which driving directions are displayed.
    /// </summary>
    public interface IMapsDirectionsService
    {
        /// <summary>
        /// Shows the Maps application with driving directions displayed for the specified ending location.
        /// </summary>
        /// <param name="endingLocation">The ending location for which driving directions are displayed.</param>
        /// <exception cref="InvalidOperationException">Start and End cannot both be invalid.</exception>
        void Show(LabeledMapLocation endingLocation);

        /// <summary>
        /// Shows the Maps application with driving directions displayed for the specified starting and ending locations.
        /// </summary>
        /// <param name="startingLocation">The starting location for which driving directions are displayed.</param>
        /// <param name="endingLocation">The ending location for which driving directions are displayed.</param>
        /// <exception cref="InvalidOperationException">Start and End cannot both be invalid.</exception>
        void Show(LabeledMapLocation startingLocation, LabeledMapLocation endingLocation);
    }
}