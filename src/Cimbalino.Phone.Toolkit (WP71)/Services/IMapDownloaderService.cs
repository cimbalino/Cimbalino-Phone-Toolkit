// ****************************************************************************
// <copyright file="IMapDownloaderService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the Maps settings application. Use this to allow users to download map data for offline use.
    /// </summary>
    public interface IMapDownloaderService
    {
        /// <summary>
        /// Shows the Maps settings application.
        /// </summary>
        void Show();
    }
}