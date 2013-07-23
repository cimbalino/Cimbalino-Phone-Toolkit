// ****************************************************************************
// <copyright file="MarketplaceAppCapabilitiesNode.cs" company="Pedro Lamas">
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

using System.Collections.Generic;
using System.Xml;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents the application capabilities information.
    /// </summary>
    public class MarketplaceAppCapabilitiesNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the application capabilities information.
        /// </summary>
        /// <value>The application capabilities information.</value>
        public MarketplaceAppCapabilityNode[] Capabilities { get; set; }

        /// <summary>
        /// Gets or sets the application hardware capabilities information.
        /// </summary>
        /// <value>The application hardware capabilities information.</value>
        public MarketplaceAppHwCapabilityNode[] HardwareCapabilities { get; set; }

        #endregion

        internal static MarketplaceAppCapabilitiesNode ParseXml(XmlReader reader)
        {
            var node = new MarketplaceAppCapabilitiesNode();

            var capabilities = new List<MarketplaceAppCapabilityNode>();
            var hardwareCapabilities = new List<MarketplaceAppHwCapabilityNode>();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "capability":
                        capabilities.Add(MarketplaceAppCapabilityNode.ParseXml(reader));
                        break;

                    case "hwCapability":
                        hardwareCapabilities.Add(MarketplaceAppHwCapabilityNode.ParseXml(reader));
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }

            node.Capabilities = capabilities.ToArray();
            node.HardwareCapabilities = hardwareCapabilities.ToArray();

            return node;
        }
    }
}