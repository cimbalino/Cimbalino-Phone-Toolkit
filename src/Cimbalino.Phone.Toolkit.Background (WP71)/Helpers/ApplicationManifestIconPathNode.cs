// ****************************************************************************
// <copyright file="ApplicationManifestIconPathNode.cs" company="Pedro Lamas">
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
    /// Represents the location of the app icon that is visible in the app list.
    /// </summary>
    public class ApplicationManifestIconPathNode
    {
        /// <summary>
        /// Gets or sets a value indicating whether the icon location is relative.
        /// </summary>
        /// <value>true if the icon location is relative; otherwise false.</value>
        [XmlAttribute]
        public bool IsRelative { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the icon is a resource.
        /// </summary>
        /// <value>true if the icon is a resource; otherwise false.</value>
        [XmlAttribute]
        public bool IsResource { get; set; }

        /// <summary>
        /// Gets or sets the icon location.
        /// </summary>
        /// <value>The icon location.</value>
        [XmlText]
        public string Value { get; set; }
    }
}