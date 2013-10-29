// ****************************************************************************
// <copyright file="IUserExtendedPropertiesService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>24-11-2011</date>
// <project>Cimbalino.Phone.Toolkit.UserInfo</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of obtaining an anonymous identifier for the user of the device.
    /// </summary>
    public interface IUserExtendedPropertiesService
    {
        /// <summary>
        /// Gets the anonymous user ID.
        /// </summary>
        /// <value>The anonymous user ID.</value>
        string AnonymousUserID { get; }

        /// <summary>
        /// Gets the value associated with the specified property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The value for the specified property name.</returns>
        /// <typeparam name="T">The return type.</typeparam>
        T GetPropertyValue<T>(string propertyName);
    }
}