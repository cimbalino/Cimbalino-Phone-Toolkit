// ****************************************************************************
// <copyright file="IMarketplaceReviewService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>21-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of showing the marketplace review screen for an application.
    /// </summary>
    public interface IMarketplaceReviewService
    {
        /// <summary>
        /// Shows marketplace review screen for the current application.
        /// </summary>
        void Show();
    }
}