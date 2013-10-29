// ****************************************************************************
// <copyright file="MapDownloaderService.cs" company="Pedro Lamas">
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

#if WP8
using Microsoft.Phone.Tasks;
#else
using System;
#endif

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IMapDownloaderService"/>.
    /// </summary>
    public class MapDownloaderService : IMapDownloaderService
    {
        /// <summary>
        /// Shows the Maps settings application.
        /// </summary>
        public void Show()
        {
#if WP8
            new MapDownloaderTask().Show();
#else
            throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
#endif
        }
    }
}