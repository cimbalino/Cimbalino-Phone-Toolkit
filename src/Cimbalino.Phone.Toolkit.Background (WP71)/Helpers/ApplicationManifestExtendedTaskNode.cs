// ****************************************************************************
// <copyright file="ApplicationManifestExtendedTaskNode.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents an extended task in the application manifest.
    /// </summary>
    public class ApplicationManifestExtendedTaskNode : ApplicationManifestTaskNodeBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the list of background service agents.
        /// </summary>
        /// <value>The list of background service agents.</value>
        public ApplicationManifestBackgroundServiceAgentNode[] BackgroundServiceAgents { get; set; }

        #endregion
    }
}