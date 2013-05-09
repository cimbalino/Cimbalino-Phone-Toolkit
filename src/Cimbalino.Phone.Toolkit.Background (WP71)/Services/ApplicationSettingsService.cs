// ****************************************************************************
// <copyright file="ApplicationSettingsService.cs" company="Pedro Lamas">
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

using System.Collections.Generic;
using System.IO.IsolatedStorage;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationSettingsService"/>.
    /// </summary>
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        private readonly IsolatedStorageSettings _settings;

        /// <summary>
        /// Gets a value indicating whether this <see cref="IsolatedStorageSettings" /> instance has changed.
        /// </summary>
        /// <value>
        /// true if this <see cref="IsolatedStorageSettings" /> instance has changed; otherwise, false.
        /// </value>
        public bool IsDirty { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSettingsService" /> class.
        /// </summary>
        public ApplicationSettingsService()
        {
            _settings = IsolatedStorageSettings.ApplicationSettings;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// The value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter.
        /// </returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        public T Get<T>(string key)
        {
            return Get(key, default(T));
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="defaultValue">The default value to return if the key does not exist.</param>
        /// <returns>
        /// The value associated with the specified key, if the key is found; otherwise, the specified default value.
        /// </returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        public T Get<T>(string key, T defaultValue)
        {
            if (_settings.Contains(key))
            {
                return (T)_settings[key];
            }

            return defaultValue;
        }

        /// <summary>
        /// Sets the value for the specified key. If the entry does not exist, a new one will be added.
        /// </summary>
        /// <param name="key">The key whose value to set.</param>
        /// <param name="value">The value for the specified key.</param>
        /// <typeparam name="T">The type of value to set.</typeparam>
        public void Set<T>(string key, T value)
        {
            if (_settings.Contains(key))
            {
                if (!EqualityComparer<T>.Default.Equals((T)_settings[key], value))
                {
                    _settings[key] = value;

                    IsDirty = true;
                }
            }
            else
            {
                _settings.Add(key, value);

                IsDirty = true;
            }
        }

        /// <summary>
        /// Removes the specified key and associated value.
        /// </summary>
        /// <param name="key">The key whose value to reset.</param>
        public void Reset(string key)
        {
            if (_settings.Contains(key))
            {
                _settings.Remove(key);

                IsDirty = true;
            }
        }

        /// <summary>
        /// Saves this <see cref="IsolatedStorageSettings" /> instance.
        /// </summary>
        /// <exception cref="IsolatedStorageException">The <see cref="IsolatedStorageFile"/> does not have enough available free space.</exception>
        public void Save()
        {
            if (IsDirty)
            {
                _settings.Save();

                IsDirty = false;
            }
        }
    }
}