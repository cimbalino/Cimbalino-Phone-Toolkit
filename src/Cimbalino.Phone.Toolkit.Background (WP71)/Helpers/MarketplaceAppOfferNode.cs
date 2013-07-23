// ****************************************************************************
// <copyright file="MarketplaceAppOfferNode.cs" company="Pedro Lamas">
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
using System.Xml;
using Cimbalino.Phone.Toolkit.Extensions;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents the contents of the application offer information from the marketplace.
    /// </summary>
    public class MarketplaceAppOfferNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        /// <value>The offer identifier.</value>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the offer media instance identifier.
        /// </summary>
        /// <value>The offer media instance identifier.</value>
        public string MediaInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the offer client types.
        /// </summary>
        /// <value>The offer client types.</value>
        public string[] ClientTypes { get; set; }

        /// <summary>
        /// Gets or sets the offer payment types.
        /// </summary>
        /// <value>The offer payment types.</value>
        public string[] PaymentTypes { get; set; }

        /// <summary>
        /// Gets or sets the offer store.
        /// </summary>
        /// <value>The offer store.</value>
        public string Store { get; set; }

        /// <summary>
        /// Gets or sets the offer price.
        /// </summary>
        /// <value>The offer price.</value>
        public double? Price { get; set; }

        /// <summary>
        /// Gets or sets the offer display price.
        /// </summary>
        /// <value>The offer display price.</value>
        public string DisplayPrice { get; set; }

        /// <summary>
        /// Gets or sets the offer price currency code.
        /// </summary>
        /// <value>The offer price currency code.</value>
        public string PriceCurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the offer license right.
        /// </summary>
        /// <value>The offer license right.</value>
        public string LicenseRight { get; set; }

        /// <summary>
        /// Gets or sets the offer expiration.
        /// </summary>
        /// <value>The offer expiration.</value>
        public DateTime? Expiration { get; set; }

        #endregion

        internal static MarketplaceAppOfferNode ParseXml(XmlReader reader)
        {
            var node = new MarketplaceAppOfferNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.LocalName)
                {
                    case "offerId":
                        node.OfferId = reader.ReadElementContentAsUrn();
                        break;

                    case "mediaInstanceId":
                        node.MediaInstanceId = reader.ReadElementContentAsUrn();
                        break;

                    case "clientTypes":
                        node.ClientTypes = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "paymentTypes":
                        node.PaymentTypes = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "store":
                        node.Store = reader.ReadElementContentAsString();
                        break;

                    case "price":
                        node.Price = reader.ReadElementContentAsDouble();
                        break;

                    case "displayPrice":
                        node.DisplayPrice = reader.ReadElementContentAsString();
                        break;

                    case "priceCurrencyCode":
                        node.PriceCurrencyCode = reader.ReadElementContentAsString();
                        break;

                    case "licenseRight":
                        node.LicenseRight = reader.ReadElementContentAsString();
                        break;

                    case "expiration":
                        node.Expiration = reader.ReadElementContentAsDateTime();
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.ReadEndElement();

            return node;
        }
    }
}