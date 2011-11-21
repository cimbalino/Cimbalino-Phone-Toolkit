// ****************************************************************************
// <copyright file="IShareLinkService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of sharing links over the social networks configured on the device
    /// </summary>
    public interface IShareLinkService
    {
        /// <summary>
        /// Shows a dialog that enables the user to share a link on the social networks of their choice.
        /// </summary>
        /// <param name="title">The title of the shared link.</param>
        /// <param name="message">The message that will accompany the shared link.</param>
        /// <param name="linkUrl">The URI of the link to be shared.</param>
        void Show(string title, string message, string linkUrl);

        /// <summary>
        /// Shows a dialog that enables the user to share a link on the social networks of their choice.
        /// </summary>
        /// <param name="title">The title of the shared link.</param>
        /// <param name="message">The message that will accompany the shared link.</param>
        /// <param name="linkUri">The URI of the link to be shared.</param>
        void Show(string title, string message, Uri linkUri);
    }
}