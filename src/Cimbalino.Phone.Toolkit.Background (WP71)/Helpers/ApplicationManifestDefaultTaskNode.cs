// ****************************************************************************
// <copyright file="ApplicationManifestDefaultTaskNode.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>23-07-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents a default task in the application manifest.
    /// </summary>
    public class ApplicationManifestDefaultTaskNode : ApplicationManifestTaskNodeBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the page to navigate.
        /// </summary>
        /// <value>The page to navigate.</value>
        public string NavigationPage { get; set; }

        #endregion
    }
}