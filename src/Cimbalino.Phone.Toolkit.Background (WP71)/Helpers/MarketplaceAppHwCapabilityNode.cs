// ****************************************************************************
// <copyright file="MarketplaceAppHwCapabilityNode.cs" company="Pedro Lamas">
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
    /// Represents an application hardware capability information.
    /// </summary>
    public class MarketplaceAppHwCapabilityNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the application hardware capability requirement type.
        /// </summary>
        /// <value>The application hardware capability requirement type.</value>
        public string RequirementType { get; set; }

        /// <summary>
        /// Gets or sets the application hardware capability identifier.
        /// </summary>
        /// <value>The application hardware capability identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the application hardware capability title.
        /// </summary>
        /// <value>The application hardware capability title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the application hardware capability is required.
        /// </summary>
        /// <value>true if the application hardware capability is required; otherwise, false.</value>
        public bool? Required { get; set; }

        #endregion

        internal static MarketplaceAppHwCapabilityNode ParseXml(XmlReader reader)
        {
            var node = new MarketplaceAppHwCapabilityNode();

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
                        case "requirementType":
                            node.RequirementType = reader.ReadElementContentAsString();
                            break;

                        case "id":
                            node.Id = reader.ReadElementContentAsString();
                            break;

                        case "string":
                            node.Title = reader.ReadElementContentAsString();
                            break;

                        case "required":
                            node.Required = reader.ReadElementContentAsBoolean();
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