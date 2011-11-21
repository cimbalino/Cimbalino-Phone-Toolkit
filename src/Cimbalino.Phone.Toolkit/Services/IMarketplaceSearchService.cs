// ****************************************************************************
// <copyright file="IMarketplaceSearchService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of making searches over the marketplace
    /// </summary>
    public interface IMarketplaceSearchService
    {
        /// <summary>
        /// Shows the marketplace search results for the specified search terms.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        void Show(string searchTerms);
    }
}