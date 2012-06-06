// ****************************************************************************
// <copyright file="IApplicationSettingsService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>20-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.IO.IsolatedStorage;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application settings.
    /// </summary>
    public interface IApplicationSettingsService
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IsolatedStorageSettings"/> instance has changed.
        /// </summary>
        /// <value>true if this <see cref="IsolatedStorageSettings"/> instance has changed; otherwise, false.</value>
        bool IsDirty { get; }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter.</returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        T Get<T>(string key);

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="defaultValue">The default value to return if the key does not exist.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the specified default value.</returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        T Get<T>(string key, T defaultValue);

        /// <summary>
        /// Sets the value for the specified key. If the entry does not exist, a new one will be added
        /// </summary>
        /// <param name="key">The key whose value to set.</param>
        /// <param name="value">The value for the specified key.</param>
        /// <typeparam name="T">The type of value to set.</typeparam>
        void Set<T>(string key, T value);

        /// <summary>
        /// Removes the specified key and associated value.
        /// </summary>
        /// <param name="key">The key whose value to reset.</param>
        void Reset(string key);

        /// <summary>
        /// Saves this <see cref="IsolatedStorageSettings"/> instance.
        /// </summary>
        /// <exception cref="IsolatedStorageException">The <see cref="IsolatedStorageFile"/> does not have enough available free space.</exception>
        void Save();
    }
}