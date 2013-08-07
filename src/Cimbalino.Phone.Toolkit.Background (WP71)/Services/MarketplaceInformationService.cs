// ****************************************************************************
// <copyright file="MarketplaceInformationService.cs" company="Pedro Lamas">
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
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Cimbalino.Phone.Toolkit.Helpers;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IMarketplaceInformationService"/>.
    /// </summary>
    public class MarketplaceInformationService : IMarketplaceInformationService
    {
        /// <summary>
        /// Retrieves marketplace information about the running application.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{MarketplaceAppNode, Exception}" /> to be called once the operation is finished.</param>
        public void GetAppInformation(Action<MarketplaceAppNode, Exception> resultAction)
        {
            GetAppInformation(ApplicationManifest.Current.App.ProductId, resultAction);
        }

        /// <summary>
        /// Retrieves marketplace information about the specified application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <param name="resultAction">The <see cref="Action{MarketplaceAppNode, Exception}" /> to be called once the operation is finished.</param>
        public void GetAppInformation(string productId, Action<MarketplaceAppNode, Exception> resultAction)
        {
            GetAppInformation(productId, CultureInfo.CurrentUICulture, resultAction);
        }

        /// <summary>
        /// Retrieves marketplace information about the specified application, using the specified <see cref="CultureInfo"/> for territory.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> for territory.</param>
        /// <param name="resultAction">The <see cref="Action{MarketplaceAppNode, Exception}" /> to be called once the operation is finished.</param>
        public void GetAppInformation(string productId, CultureInfo cultureInfo, Action<MarketplaceAppNode, Exception> resultAction)
        {
            try
            {
                var request = CreateWebRequest(productId, cultureInfo);

                request.BeginGetResponse(asyncResult =>
                {
                    try
                    {
                        resultAction(WebRequestEndGetResponse(asyncResult), null);
                    }
                    catch (Exception ex)
                    {
                        resultAction(null, ex);
                    }
                }, request);
            }
            catch (Exception ex)
            {
                resultAction(null, ex);
            }
        }

        /// <summary>
        /// Retrieves marketplace information about the running application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<MarketplaceAppNode> GetAppInformationAsync()
        {
            return GetAppInformationAsync(ApplicationManifest.Current.App.ProductId, CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Retrieves marketplace information about the running application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<MarketplaceAppNode> GetAppInformationAsync(string productId)
        {
            return GetAppInformationAsync(productId, CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Retrieves marketplace information about the running application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> for territory.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<MarketplaceAppNode> GetAppInformationAsync(string productId, CultureInfo cultureInfo)
        {
            var request = CreateWebRequest(productId, cultureInfo);

            return Task.Factory.FromAsync<MarketplaceAppNode>(request.BeginGetResponse, WebRequestEndGetResponse, request);
        }

        private WebRequest CreateWebRequest(string productId, CultureInfo cultureInfo)
        {
            var cultureInfoName = cultureInfo.Name;

#if WP8
            var url = string.Format("http://marketplaceedgeservice.windowsphone.com/v8/catalog/apps/{0}?os={1}&cc={2}&oc=&lang={3}​",
                productId,
                Environment.OSVersion.Version,
                cultureInfoName.Substring(cultureInfoName.Length - 2).ToUpperInvariant(),
                cultureInfoName);
#else
            var url = string.Format("http://marketplaceedgeservice.windowsphone.com/v3.2/{0}/apps/{1}?clientType=WinMobile%207.1&os={2}",
                cultureInfoName,
                productId,
                Environment.OSVersion.Version);
#endif
            return WebRequest.Create(url);
        }

        private MarketplaceAppNode WebRequestEndGetResponse(IAsyncResult asyncResult)
        {
            var request = (WebRequest)asyncResult.AsyncState;

            using (var response = (HttpWebResponse)request.EndGetResponse(asyncResult))
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException("Http Error: " + response.StatusCode);
                }

                using (var outputStream = response.GetResponseStream())
                {
                    using (var reader = XmlReader.Create(outputStream, new XmlReaderSettings { IgnoreWhitespace = true, IgnoreComments = true }))
                    {
                        return MarketplaceAppNode.ParseXml(reader);
                    }
                }
            }
        }
    }
}