// ****************************************************************************
// <copyright file="IApplicationManifestService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-02-2012</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Cimbalino.Phone.Toolkit.Helpers;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of reading from the application manifest.
    /// </summary>
    public interface IApplicationManifestService
    {
        /// <summary>
        /// Gets the application manifest for the active app.
        /// </summary>
        /// <returns>The application manifest for the active app.</returns>
        ApplicationManifest GetApplicationManifest();
    }
}