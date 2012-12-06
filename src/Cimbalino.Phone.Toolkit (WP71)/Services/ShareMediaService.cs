// ****************************************************************************
// <copyright file="ShareMediaService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>30-12-2012</date>
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
    /// Represents an implementation of the <see cref="IShareMediaService"/>.
    /// </summary>
    public class ShareMediaService : IShareMediaService
    {
        /// <summary>
        /// Shows a dialog that enables the user to share media on the social networks of their choice.
        /// </summary>
        /// <param name="filePath">The path to the media file to share.</param>
        public void Show(string filePath)
        {
#if WP8
            new ShareMediaTask()
            {
                FilePath = filePath
            }.Show();
#else
            throw new NotSupportedException("This service is not supported in WP7");
#endif
        }
    }
}