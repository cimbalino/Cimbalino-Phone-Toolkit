// ****************************************************************************
// <copyright file="IConnectionSettingsService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of launching a Settings dialog that allows the user to change the device's network connection settings.
    /// </summary>
    public interface IConnectionSettingsService
    {
        /// <summary>
        /// Shows the network connection Settings dialog for the specified <see cref="ConnectionSettingsType"/>.
        /// </summary>
        /// <param name="connectionSettingsType">The type of network connection settings that will be displayed.</param>
        void Show(ConnectionSettingsType connectionSettingsType);
    }
}