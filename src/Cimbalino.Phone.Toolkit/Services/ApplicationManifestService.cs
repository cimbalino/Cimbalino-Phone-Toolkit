// ****************************************************************************
// <copyright file="ApplicationManifestService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-02-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Xml;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationManifestService"/>.
    /// </summary>
    public class ApplicationManifestService : IApplicationManifestService
    {
        private const string AppManifestName = "WMAppManifest.xml";
        private const string AppNodeName = "App";

        /// <summary>
        /// Gets the application author’s name.
        /// </summary>
        /// <value>The application author’s name.</value>
        public string Author
        {
            get
            {
                return GetAttribute("Author");
            }
        }

        /// <summary>
        /// Gets the application bit depth.
        /// </summary>
        /// <value>The application bit depth.</value>
        public int BitsPerPixel
        {
            get
            {
                int bitsPerPixel;

                if (!int.TryParse(GetAttribute("BitsPerPixel"), out bitsPerPixel))
                {
                    bitsPerPixel = 16;
                }

                return bitsPerPixel;
            }
        }

        /// <summary>
        /// Gets the description of the application.
        /// </summary>
        /// <value>The description of the application.</value>
        public string Description
        {
            get
            {
                return GetAttribute("Description");
            }
        }

        /// <summary>
        /// Gets the application genre.
        /// </summary>
        /// <value>The application genre.</value>
        public string Genre
        {
            get
            {
                return GetAttribute("Genre");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the application supports settings.
        /// </summary>
        /// <value>true if the application supports settings; otherwise, false.</value>
        public bool HasSettings
        {
            get
            {
                bool hasSettings;

                if (!bool.TryParse(GetAttribute("HasSettings"), out hasSettings))
                {
                    hasSettings = false;
                }

                return hasSettings;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the application is a beta application.
        /// </summary>
        /// <value>true if the application is a beta application; otherwise, false.</value>
        public bool IsBeta
        {
            get
            {
                bool isBeta;

                if (!bool.TryParse(GetAttribute("IsBeta"), out isBeta))
                {
                    isBeta = false;
                }

                return isBeta;
            }
        }

        /// <summary>
        /// Gets the application product ID.
        /// </summary>
        /// <value>The application product ID.</value>
        public Guid ProductID
        {
            get
            {
                Guid productID;

                if (!Guid.TryParse(GetAttribute("ProductID"), out productID))
                {
                    productID = Guid.Empty;
                }

                return productID;
            }
        }

        /// <summary>
        /// Gets the publisher of the application.
        /// </summary>
        /// <value>The publisher of the application.</value>
        public string Publisher
        {
            get
            {
                return GetAttribute("Publisher");
            }
        }

        /// <summary>
        /// Gets the application runtime type.
        /// </summary>
        /// <value>The application runtime type.</value>
        public string RuntimeType
        {
            get
            {
                return GetAttribute("RuntimeType");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the application has a single instance host.
        /// </summary>
        /// <value>
        /// true if the application has a single instance host; otherwise, false.
        /// </value>
        public bool SingleInstanceHost
        {
            get
            {
                bool singleInstanceHost;

                if (!bool.TryParse(GetAttribute("SingleInstanceHost"), out singleInstanceHost))
                {
                    singleInstanceHost = true;
                }

                return singleInstanceHost;
            }
        }

        /// <summary>
        /// Gets the title of the application that appears in the application list or Games Hub.
        /// </summary>
        /// <value>
        /// The title of the application that appears in the application list or Games Hub.
        /// </value>
        public string Title
        {
            get
            {
                return GetAttribute("Title");
            }
        }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <value>The application version.</value>
        public Version Version
        {
            get
            {
                Version version;

                if (!Version.TryParse(GetAttribute("Version"), out version))
                {
                    version = null;
                }

                return version;
            }
        }

        /// <summary>
        /// Gets the value for the specified attribute over the App element in the application manifest.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The specified attribute value.</returns>
        public string GetAttribute(string attributeName)
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