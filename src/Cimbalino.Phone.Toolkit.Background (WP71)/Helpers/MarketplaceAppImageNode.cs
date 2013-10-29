// ****************************************************************************
// <copyright file="MarketplaceAppImageNode.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>20-07-2013</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Xml;
using Cimbalino.Phone.Toolkit.Extensions;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents an application image information.
    /// </summary>
    public class MarketplaceAppImageNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the application image identifier.
        /// </summary>
        /// <value>The application image identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the application image orientation.
        /// </summary>
        /// <value>The application image orientation.</value>
        public int? Orientation { get; set; }

        #endregion

        internal static MarketplaceAppImageNode ParseXml(XmlReader reader)
        {
            var node = new MarketplaceAppImageNode();

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

                        case "orientation":
                            node.Orientation = reader.ReadElementContentAsInt();
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