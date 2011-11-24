// ****************************************************************************
// <copyright file="IWebBrowserService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of using the webbrowser
    /// </summary>
    public interface IWebBrowserService
    {
        /// <summary>
        /// Launches the web browser application with the specified URL.
        /// </summary>
        /// <param name="url">The URL to which the web browser application will navigate when it is launched.</param>
        void Show(string url);

        /// <summary>
        /// Launches the web browser application with the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> to which the web browser application will navigate when it is launched.</param>
        void Show(Uri uri);
    }
}