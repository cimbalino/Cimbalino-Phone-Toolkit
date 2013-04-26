// ****************************************************************************
// <copyright file="UserExtendedPropertiesService.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Info;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IUserExtendedPropertiesService"/>.
    /// </summary>
    public class UserExtendedPropertiesService : IUserExtendedPropertiesService
    {
        /// <summary>
        /// Gets the anonymous user ID.
        /// </summary>
        /// <value>The anonymous user ID.</value>
        public string AnonymousUserID
        {
            get
            {
                var anid = GetPropertyValue<string>(
#if WP8
                    "ANID2"
#else
                    "ANID"
#endif
                    );

                if (anid.Length >= 34)
                {
                    return anid.Substring(2, 32);
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the value associated with the specified property name.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The value for the specified property name.</returns>
        /// <typeparam name="T">The return type.</typeparam>
        public T GetPropertyValue<T>(string propertyName)
        {
            object value;

            if (UserExtendedProperties.TryGetValue(propertyName, out value))
            {
                return (T)value;
            }

            return default(T);
        }
    }
}