// ****************************************************************************
// <copyright file="IScreenInfoService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>30-11-2012</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of retrieving device resolution information.
    /// </summary>
    public interface IScreenInfoService
    {
        /// <summary>
        /// Gets a value indicating the device scale factor.
        /// </summary>
        /// <value>The device scale factor.</value>
        int ScaleFactor { get; }

        /// <summary>
        /// Gets the device resolution.
        /// </summary>
        /// <value>Returns a <see cref="ScreenInfoServiceResolution"/> enumeration indicating the device resolution.</value>
        ScreenInfoServiceResolution Resolution { get; }
    }
}