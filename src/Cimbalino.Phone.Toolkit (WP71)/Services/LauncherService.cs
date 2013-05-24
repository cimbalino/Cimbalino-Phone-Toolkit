// ****************************************************************************
// <copyright file="LauncherService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>24-05-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading.Tasks;
#if WP8
using Windows.Storage;
using Windows.System;
#endif

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILauncherService"/>.
    /// </summary>
    public class LauncherService : ILauncherService
    {
        /// <summary>
        /// Starts the default app associated with the URI scheme name for the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task LaunchUriAsync(Uri uri)
        {
#if WP8
            return Launcher.LaunchUriAsync(uri)
                .AsTask();
#else
            throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
#endif
        }

        /// <summary>
        /// Starts the default app associated with the specified file.
        /// </summary>
        /// <param name="file">The file to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
#if WP8
        public async Task LaunchFileAsync(string file)
        {
            var storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(file);

            await Launcher.LaunchFileAsync(storageFile);
        }
#else
        public Task LaunchFileAsync(string file)
        {
            throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
        }
#endif
    }
}