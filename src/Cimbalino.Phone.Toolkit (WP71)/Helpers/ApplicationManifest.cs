// ****************************************************************************
// <copyright file="ApplicationManifest.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>25-12-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Windows;
using System.Xml.Serialization;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents the contents of the application manifest.
    /// </summary>
#if WP8
    [XmlRoot("Deployment", Namespace = "http://schemas.microsoft.com/windowsphone/2012/deployment")]
#else
    [XmlRoot("Deployment", Namespace = "http://schemas.microsoft.com/windowsphone/2009/deployment")]
#endif
    public class ApplicationManifest
    {
        private const string AppManifestName = "WMAppManifest.xml";

        private static ApplicationManifest _current;

        /// <summary>
        /// Gets the current <see cref="ApplicationManifest"/> instance.
        /// </summary>
        /// <value>The current <see cref="ApplicationManifest"/> instance.</value>
        public static ApplicationManifest Current
        {
            get
            {
                if (_current == null)
                {
                    var xmlSerializer = new XmlSerializer(typeof(ApplicationManifest));

                    var appManifestResourceInfo = Application.GetResourceStream(new Uri(AppManifestName, UriKind.Relative));

                    using (var appManifestStream = appManifestResourceInfo.Stream)
                    {
                        _current = (ApplicationManifest)xmlSerializer.Deserialize(appManifestStream);
                    }
                }

                return _current;
            }
        }

        /// <summary>
        /// Gets or sets the version of the Windows Phone SDK or the runtime binaries of the platform. The default value is 8.0 for Windows Phone 8 and 7.1 for Windows Phone OS 7.1.
        /// </summary>
        /// <value>The version of the Windows Phone SDK or the runtime binaries of the platform.</value>
        [XmlAttribute]
        public string AppPlatformVersion { get; set; }

        /// <summary>
        /// Gets or sets the application default language.
        /// </summary>
        /// <value>The application default language.</value>
        [XmlElement(Namespace = "")]
        public ApplicationManifestLanguageNode DefaultLanguage { get; set; }

        /// <summary>
        /// Gets or sets the application supported languages.
        /// </summary>
        /// <value>The application supported languages.</value>
        [XmlArray("Languages", Namespace = ""), XmlArrayItem("Language")]
        public ApplicationManifestLanguageNode[] Languages { get; set; }

        /// <summary>
        /// Gets or sets the app detailed information.
        /// </summary>
        /// <value>The app detailed information.</value>
        [XmlElement(Namespace = "")]
        public ApplicationManifestAppNode App { get; set; }
    }
}
