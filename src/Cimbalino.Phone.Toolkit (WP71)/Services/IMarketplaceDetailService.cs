// ****************************************************************************
// <copyright file="IMarketplaceDetailService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of showing marketplace information about an application.
    /// </summary>
    public interface IMarketplaceDetailService
    {
        /// <summary>
        /// Shows the marketplace information for the current application.
        /// </summary>
        void Show();

        /// <summary>
        /// Shows the marketplace information for the specified application content identifier.
        /// </summary>
        /// <param name="contentIdentifier">The application content identifier.</param>
        void Show(string contentIdentifier);
    }
}