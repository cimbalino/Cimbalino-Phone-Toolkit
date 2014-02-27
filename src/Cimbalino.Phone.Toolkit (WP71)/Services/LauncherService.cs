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
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.Phone.Tasks;
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
            if (uri.Scheme == "http")
            {
                return ShowWebBrowserAsync(uri);
            }

            if (uri.Scheme == "mailto")
            {
                return ShowEmailComposeAsync(uri);
            }

            if (uri.Scheme == "zune")
            {
                switch (uri.LocalPath)
                {
                    case "navigate":
                        return ShowMarketplaceDetailAsync(uri);

                    case "reviewapp":
                        return ShowMarketplaceReviewAsync(uri);

                    case "search":
                        return ShowMarketplaceSearchAsync(uri);
                }
            }

            switch (uri.Scheme)
            {
                case "ms-settings-airplanemode":
                    return ShowConnectionSettingsAsync(ConnectionSettingsType.AirplaneMode);

                case "ms-settings-bluetooth":
                    return ShowConnectionSettingsAsync(ConnectionSettingsType.Bluetooth);

                case "ms-settings-cellular":
                    return ShowConnectionSettingsAsync(ConnectionSettingsType.Cellular);

                case "ms-settings-wifi":
                    return ShowConnectionSettingsAsync(ConnectionSettingsType.WiFi);
            }

            throw new NotSupportedException("The specified uri is not supported in Windows Phone 7.x");
#endif
        }

#if !WP8
        private Task ShowWebBrowserAsync(Uri uri)
        {
            return Task.Factory.StartNew(() =>
            {
                new WebBrowserTask()
                {
                    Uri = uri
                }.Show();
            });
        }

        private Task ShowEmailComposeAsync(Uri uri)
        {
            return Task.Factory.StartNew(() =>
            {
                var queryString = uri.QueryString();

                new EmailComposeTask()
                {
                    To = string.IsNullOrEmpty(uri.UserInfo) ? queryString.GetValue("to") : uri.UserInfo + "@" + uri.Host,
                    Subject = queryString.GetValue("subject"),
                    Body = queryString.GetValue("body"),
                    Cc = queryString.GetValue("cc"),
                    Bcc = queryString.GetValue("bcc")
                }.Show();
            });
        }

        private Task ShowMarketplaceDetailAsync(Uri uri)
        {
            return Task.Factory.StartNew(() =>
            {
                new MarketplaceDetailTask()
                {
                    ContentIdentifier = uri.QueryString().GetValue("appid")
                }.Show();
            });
        }

        private Task ShowMarketplaceReviewAsync(Uri uri)
        {
            if (!string.IsNullOrEmpty(uri.Query))
            {
                throw new NotSupportedException("The specified uri is not supported in Windows Phone 7.x");
            }

            return Task.Factory.StartNew(() => new MarketplaceReviewTask().Show());
        }

        private Task ShowMarketplaceSearchAsync(Uri uri)
        {
            var queryString = uri.QueryString();

            if (!queryString.ContainsKey("keyword"))
            {
                throw new NotSupportedException("The specified uri is not supported in Windows Phone 7.x");
            }

            return Task.Factory.StartNew(() =>
            {
                new MarketplaceSearchTask()
                {
                    SearchTerms = queryString["keyword"]
                }.Show();
            });
        }

        private Task ShowConnectionSettingsAsync(ConnectionSettingsType connectionSettingsType)
        {
            return Task.Factory.StartNew(() =>
            {
                new ConnectionSettingsTask()
                {
                    ConnectionSettingsType = connectionSettingsType
                }.Show();
            });
        }
#endif

        /// <summary>
        /// Starts the default app associated with the specified file.
        /// </summary>
        /// <param name="file">The file to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
#if WP8
        public async Task LaunchFileAsync(string file)
        {
            var storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(file).AsTask().ConfigureAwait(false);

            await Launcher.LaunchFileAsync(storageFile).AsTask().ConfigureAwait(false);
        }
#else
        public Task LaunchFileAsync(string file)
        {
            throw new NotSupportedException("This service is not supported in Windows Phone 7.x");
        }
#endif
    }
}