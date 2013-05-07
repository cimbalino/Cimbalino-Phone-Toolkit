// ****************************************************************************
// <copyright file="ApplicationManifestTaskNode.cs" company="Pedro Lamas">
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
    /// Represents a task in the application manifest.
    /// </summary>
    public class ApplicationManifestTaskNode
    {
        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        /// <value>The name of the task.</value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the page to navigate.
        /// </summary>
        /// <value>The page to navigate.</value>
        [XmlAttribute]
        public string NavigationPage { get; set; }
    }
}