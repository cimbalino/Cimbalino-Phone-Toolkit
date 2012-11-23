// ****************************************************************************
// <copyright file="ShareStatusService.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IShareStatusService"/>.
    /// </summary>
    public class ShareStatusService : IShareStatusService
    {
        /// <summary>
        /// Causes the sharing dialog to be displayed to the user.
        /// </summary>
        /// <param name="status">The status message to be shared.</param>
        public void Show(string status)
        {
            new ShareStatusTask()
            {
                Status = status
            }.Show();
        }
    }
}