// ****************************************************************************
// <copyright file="IMarketplaceInformationService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>20-07-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Globalization;
using System.Threading.Tasks;
using Cimbalino.Phone.Toolkit.Helpers;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of retrieving marketplace information about an application.
    /// </summary>
    public interface IMarketplaceInformationService
    {
        /// <summary>
        /// Retrieves marketplace information about the running application.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{MarketplaceAppNode, Exception}" /> to be called once the operation is finished.</param>
        void GetAppInformation(Action<MarketplaceAppNode, Exception> resultAction);

        /// <summary>
        /// Retrieves marketplace information about the specified application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <param name="resultAction">The <see cref="Action{MarketplaceAppNode, Exception}" /> to be called once the operation is finished.</param>
        void GetAppInformation(string productId, Action<MarketplaceAppNode, Exception> resultAction);

        /// <summary>
        /// Retrieves marketplace information about the specified application, using the specified <see cref="CultureInfo"/> for territory.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> for territory.</param>
        /// <param name="resultAction">The <see cref="Action{MarketplaceAppNode, Exception}" /> to be called once the operation is finished.</param>
        void GetAppInformation(string productId, CultureInfo cultureInfo, Action<MarketplaceAppNode, Exception> resultAction);

        /// <summary>
        /// Retrieves marketplace information about the running application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<MarketplaceAppNode> GetAppInformationAsync();

        /// <summary>
        /// Retrieves marketplace information about the running application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<MarketplaceAppNode> GetAppInformationAsync(string productId);

        /// <summary>
        /// Retrieves marketplace information about the running application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> for territory.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<MarketplaceAppNode> GetAppInformationAsync(string productId, CultureInfo cultureInfo);
    }
}