// ****************************************************************************
// <copyright file="ApplicationManifestService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-02-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Cimbalino.Phone.Toolkit.Helpers;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationManifestService"/>.
    /// </summary>
    public class ApplicationManifestService : IApplicationManifestService
    {
        /// <summary>
        /// Gets the application manifest for the active app.
        /// </summary>
        /// <returns>The application manifest for the active app.</returns>
        public ApplicationManifest GetApplicationManifest()
        {
            return ApplicationManifest.Current;
        }
    }
}