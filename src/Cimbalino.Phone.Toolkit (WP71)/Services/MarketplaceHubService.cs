// ****************************************************************************
// <copyright file="MarketplaceHubService.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of showing the marketplace hub.
    /// </summary>
    public class MarketplaceHubService : IMarketplaceHubService
    {
        /// <summary>
        /// Shows the marketplace hub.
        /// </summary>
        public void Show()
        {
            new MarketplaceHubTask().Show();
        }
    }
}