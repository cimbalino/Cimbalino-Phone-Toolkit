// ****************************************************************************
// <copyright file="IDeviceExtendedPropertiesService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>24-11-2011</date>
// <project>Cimbalino.Phone.Toolkit.DeviceInfo</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of obtaining extended information about the device on which it is running.
    /// </summary>
    public interface IDeviceExtendedPropertiesService
    {
        /// <summary>
        /// Gets the unique hash for the device.
        /// </summary>
        /// <value>The unique hash for the device.</value>
        /// <remarks>This value will be constant across all applications and will not change if the phone is updated with a new version of the operating system. Applications should not use this to identify users because the device ID will remain unchanged even if ownership of the device is transferred.</remarks>
        byte[] DeviceUniqueId { get; }

        /// <summary>
        /// Gets the value associated with the specified property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The value for the specified property name.</returns>
        /// <typeparam name="T">The return type.</typeparam>
        T GetDeviceProperty<T>(string propertyName);
    }
}