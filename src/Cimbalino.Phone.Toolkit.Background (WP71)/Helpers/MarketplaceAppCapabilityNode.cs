// ****************************************************************************
// <copyright file="MarketplaceAppCapabilityNode.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents an application capability information.
    /// </summary>
    public class MarketplaceAppCapabilityNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the application capability identifier.
        /// </summary>
        /// <value>The application capability identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the application capability title.
        /// </summary>
        /// <value>The application capability title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the application capability disclosure state.
        /// </summary>
        /// <value>The application capability disclosure state.</value>
        public string Disclosure { get; set; }

        #endregion

        internal static MarketplaceAppCapabilityNode ParseXml(XmlReader reader)
        {
            var node = new MarketplaceAppCapabilityNode();

            if (reader.IsEmptyElement)
            {
                reader.Skip();
            }
            else
            {
                reader.ReadStartElement();

                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    switch (reader.Name)
                    {
                        case "id":
                            node.Id = reader.ReadElementContentAsString();
                            break;

                        case "string":
                            node.Title = reader.ReadElementContentAsString();
                            break;

                        case "disclosure":
                            node.Disclosure = reader.ReadElementContentAsString();
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