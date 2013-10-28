// ****************************************************************************
// <copyright file="MarketplaceAppNode.cs" company="Pedro Lamas">
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
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Cimbalino.Phone.Toolkit.Extensions;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents the contents of the application information from the marketplace.
    /// </summary>
    public class MarketplaceAppNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the application is updated.
        /// </summary>
        /// <value>true if the application is updated; otherwise false.</value>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the application title.
        /// </summary>
        /// <value>The application title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>The application identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the application content information.
        /// </summary>
        /// <value>The application content information.</value>
        public MarketplaceAppContentNode Content { get; set; }

        /// <summary>
        /// Gets or sets the application content iap count.
        /// </summary>
        /// <value>The application content iap count.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public int? IapCount { get; set; }

        /// <summary>
        /// Gets or sets the application sort title.
        /// </summary>
        /// <value>The application sort title.</value>
        public string SortTitle { get; set; }

        /// <summary>
        /// Gets or sets the application release date.
        /// </summary>
        /// <value>The application release date.</value>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the application visibility state.
        /// </summary>
        /// <value>The application visibility state.</value>
        public string VisibilityStatus { get; set; }

        /// <summary>
        /// Gets or sets the application publisher.
        /// </summary>
        /// <value>The application publisher.</value>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the application average user rating.
        /// </summary>
        /// <value>The application average user rating.</value>
        public double? AverageUserRating { get; set; }

        /// <summary>
        /// Gets or sets the application user rating count.
        /// </summary>
        /// <value>The application user rating count.</value>
        public int? UserRatingCount { get; set; }

        /// <summary>
        /// Gets or sets the application image.
        /// </summary>
        /// <value>The application image.</value>
        public MarketplaceAppImageNode Image { get; set; }

        /// <summary>
        /// Gets or sets the application screenshots.
        /// </summary>
        /// <value>The application screenshots.</value>
        public MarketplaceAppImageNode[] Screenshots { get; set; }

        /// <summary>
        /// Gets or sets the application categories.
        /// </summary>
        /// <value>The application categories.</value>
        public MarketplaceAppCategoryNode[] Categories { get; set; }

        /// <summary>
        /// Gets or sets the application tags.
        /// </summary>
        /// <value>The application tags.</value>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the application tax string.
        /// </summary>
        /// <value>The application tax string.</value>
        public string TaxString { get; set; }

        /// <summary>
        /// Gets or sets the application background image.
        /// </summary>
        /// <value>The application background image.</value>
        public MarketplaceAppImageNode BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the application available offers.
        /// </summary>
        /// <value>The application available offers.</value>
        public MarketplaceAppOfferNode[] Offers { get; set; }

        /// <summary>
        /// Gets or sets the application publisher identifier.
        /// </summary>
        /// <value>The application publisher identifier.</value>
        public string PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the application publisher unique identifier.
        /// </summary>
        /// <value>The application publisher unique identifier.</value>
        public string PublisherGuid { get; set; }

        /// <summary>
        /// Gets or sets the application entry information.
        /// </summary>
        /// <value>The application entry information.</value>
        public MarketplaceAppEntryNode Entry { get; set; }

        #endregion

        internal static MarketplaceAppNode ParseXml(XmlReader reader)
        {
            var node = new MarketplaceAppNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "a:updated":
                        node.Updated = reader.ReadElementContentAsDateTime();
                        break;

                    case "a:title":
                        node.Title = reader.ReadElementContentAsString();
                        break;

                    case "a:id":
                        node.Id = reader.ReadElementContentAsUrn();
                        break;

                    case "a:content":
                        node.Content = MarketplaceAppContentNode.ParseXml(reader);
                        break;

                    case "iapCount":
                        node.IapCount = reader.ReadElementContentAsInt();
                        break;

                    case "sortTitle":
                        node.SortTitle = reader.ReadElementContentAsString();
                        break;

                    case "releaseDate":
                        node.ReleaseDate = reader.ReadElementContentAsDateTime();
                        break;

                    case "visibilityStatus":
                        node.VisibilityStatus = reader.ReadElementContentAsString();
                        break;

                    case "publisher":
                        node.Publisher = reader.ReadElementContentAsString();
                        break;

                    case "averageUserRating":
                        node.AverageUserRating = reader.ReadElementContentAsDouble();
                        break;

                    case "userRatingCount":
                        node.UserRatingCount = reader.ReadElementContentAsInt();
                        break;

                    case "image":
                        node.Image = MarketplaceAppImageNode.ParseXml(reader);
                        break;

                    case "screenshots":
                        node.Screenshots = reader.ReadElementContentAsArray(MarketplaceAppImageNode.ParseXml);
                        break;

                    case "categories":
                        node.Categories = reader.ReadElementContentAsArray(MarketplaceAppCategoryNode.ParseXml);
                        break;

                    case "tags":
                        node.Tags = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "taxString":
                        node.TaxString = reader.ReadElementContentAsString();
                        break;

                    case "backgroundImage":
                        node.BackgroundImage = MarketplaceAppImageNode.ParseXml(reader);
                        break;

                    case "offers":
                        node.Offers = reader.ReadElementContentAsArray(MarketplaceAppOfferNode.ParseXml);
                        break;

                    case "publisherId":
                        node.PublisherId = reader.ReadElementContentAsString();
                        break;

                    case "publisherGuid":
                        node.PublisherGuid = reader.ReadElementContentAsUrn();
                        break;

                    case "a:entry":
                        node.Entry = MarketplaceAppEntryNode.ParseXml(reader);
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