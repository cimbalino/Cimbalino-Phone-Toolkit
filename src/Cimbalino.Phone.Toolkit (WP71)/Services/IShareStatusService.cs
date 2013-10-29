// ****************************************************************************
// <copyright file="IShareStatusService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>26-12-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching a dialog that enables the user to share a status message on the social networks of their choice.
    /// </summary>
    public interface IShareStatusService
    {
        /// <summary>
        /// Causes the sharing dialog to be displayed to the user.
        /// </summary>
        /// <param name="status">The status message to be shared.</param>
        void Show(string status);
    }
}