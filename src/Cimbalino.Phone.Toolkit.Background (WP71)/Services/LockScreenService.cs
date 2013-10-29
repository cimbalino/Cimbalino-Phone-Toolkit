// ****************************************************************************
// <copyright file="LockScreenService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>15-08-2013</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILockScreenService"/>.
    /// </summary>
    public class LockScreenService : ILockScreenService
    {
        /// <summary>
        /// Sets the current app as the lock screen background provider.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
            throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
        }

        /// <summary>
        /// Gets a value indicating whether the app is the current lock screen background provider.
        /// </summary>
        /// <value>true if the app is the current lock screen background provider; otherwise, false.</value>
        public bool IsProvidedByCurrentApplication
        {
            get
            {
                throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
            }
        }

        /// <summary>
        /// Gets or sets the uniform resource identifier (URI) of the current lock screen background.
        /// </summary>
        /// <value>The Uniform Resource Identifier (URI) of the current lock screen background.</value>
        public Uri ImageUri
        {
            get
            {
                throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
            }
            set
            {
                throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
            }
        }
    }
}