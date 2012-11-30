// ****************************************************************************
// <copyright file="IShareMediaService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of sharing media over the social networks configured on the device.
    /// </summary>
    public interface IShareMediaService
    {
        /// <summary>
        /// Shows a dialog that enables the user to share media on the social networks of their choice.
        /// </summary>
        /// <param name="filePath">The path to the media file to share.</param>
        void Show(string filePath);
    }
}