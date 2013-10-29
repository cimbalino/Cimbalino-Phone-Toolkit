// ****************************************************************************
// <copyright file="MarketplaceAppContentNode.cs" company="Pedro Lamas">
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
    /// Represents an application content information.
    /// </summary>
    public class MarketplaceAppContentNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the application content information type.
        /// </summary>
        /// <value>The application content information type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the application content information text.
        /// </summary>
        /// <value>The application content information text.</value>
        public string Text { get; set; }

        #endregion

        internal static MarketplaceAppContentNode ParseXml(XmlReader reader)
        {
            return new MarketplaceAppContentNode
            {
                Type = reader.GetAttribute("type"),
                Text = reader.ReadElementContentAsString()
            };
        }
    }
}