// ****************************************************************************
// <copyright file="ConnectionSettingsService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>25-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IConnectionSettingsService"/>.
    /// </summary>
    public class ConnectionSettingsService : IConnectionSettingsService
    {
        /// <summary>
        /// Shows the network connection Settings dialog for the specified <see cref="ConnectionSettingsType" />.
        /// </summary>
        /// <param name="connectionSettingsType">The type of network connection settings that will be displayed.</param>
        public void Show(ConnectionSettingsType connectionSettingsType)
        {
            new ConnectionSettingsTask()
            {
                ConnectionSettingsType = connectionSettingsType
            }.Show();
        }
    }
}