// ****************************************************************************
// <copyright file="ApplicationManifest.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Xml;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents an ApplicationManifest helper class
    /// </summary>
    public class ApplicationManifest
    {
        private const string AppManifestName = "WMAppManifest.xml";
        private const string AppNodeName = "App";

        #region Properties

        /// <summary>
        /// Gets the Author attribute value the application manifest.
        /// </summary>
        /// <value>The Author attribute value.</value>
        public static string Author
        {
            get
            {
                return GetAttribute("Author");
            }
        }

        /// <summary>
        /// Gets the Description attribute value the application manifest.
        /// </summary>
        /// <value>The Description attribute value.</value>
        public static string Description
        {
            get
            {
                return GetAttribute("Description");
            }
        }

        /// <summary>
        /// Gets the ProductId attribute value the application manifest.
        /// </summary>
        /// <value>The ProductId attribute value.</value>
        public static string ProductID
        {
            get
            {
                return GetAttribute("ProductID");
            }
        }

        /// <summary>
        /// Gets the Publisher attribute value the application manifest.
        /// </summary>
        /// <value>The Publisher attribute value.</value>
        public static string Publisher
        {
            get
            {
                return GetAttribute("Publisher");
            }
        }

        /// <summary>
        /// Gets the Title attribute value the application manifest.
        /// </summary>
        /// <value>The Title attribute value.</value>
        public static string Title
        {
            get
            {
                return GetAttribute("Title");
            }
        }

        /// <summary>
        /// Gets the Version attribute value the application manifest.
        /// </summary>
        /// <value>The Version attribute value.</value>
        public static string Version
        {
            get
            {
                return GetAttribute("Version");
            }
        }

        #endregion

        /// <summary>
        /// Gets the value for the specified attribute over the App element in the application manifest.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The specified attribute value.</returns>
        public static string GetAttribute(string attributeName)
        {
            try
            {
                var xmlReaderSettings = new XmlReaderSettings
                {
                    XmlResolver = new XmlXapResolver()
                };

                using (var xmlReader = XmlReader.Create(AppManifestName, xmlReaderSettings))
                {
                    xmlReader.ReadToDescendant(AppNodeName);

                    if (!xmlReader.IsStartElement())
                    {
                        throw new FormatException(AppManifestName + " is missing " + AppNodeName);
                    }

                    return xmlReader.GetAttribute(attributeName);
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}