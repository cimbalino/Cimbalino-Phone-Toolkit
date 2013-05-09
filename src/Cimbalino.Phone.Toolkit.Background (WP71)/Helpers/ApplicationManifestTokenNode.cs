// ****************************************************************************
// <copyright file="ApplicationManifestTokenNode.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>26-12-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Xml.Serialization;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents a token in the application manifest.
    /// </summary>
    public class ApplicationManifestTokenNode
    {
        /// <summary>
        /// Gets or sets the token id.
        /// </summary>
        /// <value>The token id.</value>
        [XmlAttribute("TokenID")]
        public string TokenId { get; set; }

        /// <summary>
        /// Gets or sets the token task name.
        /// </summary>
        /// <value>The token task name.</value>
        [XmlAttribute]
        public string TaskName { get; set; }
    }
}