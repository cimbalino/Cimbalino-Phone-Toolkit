// ****************************************************************************
// <copyright file="MarketplaceAppCategoryNode.cs" company="Pedro Lamas">
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
    /// Represents an application category information.
    /// </summary>
    public class MarketplaceAppCategoryNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the application category identifier.
        /// </summary>
        /// <value>The application category identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the application category title.
        /// </summary>
        /// <value>The application category title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if this is a root category.
        /// </summary>
        /// <value>true if this is a root category; otherwise, false.</value>
        public bool? IsRoot { get; set; }

        /// <summary>
        /// Gets or sets the application category parent category identifier.
        /// </summary>
        /// <value>The application category parent category identifier.</value>
        public string ParentId { get; set; }

        #endregion

        internal static MarketplaceAppCategoryNode ParseXml(XmlReader reader)
        {
            var node = new MarketplaceAppCategoryNode();

            if (reader.IsEmptyElement)
            {
                reader.Skip();
            }
            else
            {
                reader.ReadStartElement();

                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    switch (reader.LocalName)
                    {
                        case "id":
                            node.Id = reader.ReadElementContentAsUrn();
                            break;

                        case "title":
                            node.Title = reader.ReadElementContentAsString();
                            break;

                        case "isRoot":
                            node.IsRoot = string.Equals(reader.ReadElementContentAsString(), bool.TrueString, StringComparison.InvariantCultureIgnoreCase);
                            break;

                        case "parentId":
                            node.ParentId = reader.ReadElementContentAsString();
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }

                reader.ReadEndElement();
            }

            return node;
        }
    }
}