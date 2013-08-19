// ****************************************************************************
// <copyright file="LockScreenService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>15-08-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Windows.Phone.System.UserProfile;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILockScreenService"/>.
    /// </summary>
    public class LockScreenService : ILockScreenService
    {
        /// <summary>
        /// The default lock screen image Uri
        /// </summary>
        private const string DefaultLockScreenImageUri = "ms-appx:///DefaultLockScreen.jpg";
        
        /// <summary>
        /// The lock screen image URL normal
        /// </summary>
        private const string LockScreenImageUrlNormal = "ms-appdata:///Local/shared/shellcontent/Wallpaper.jpg";
        
        /// <summary>
        /// The lock screen image URL alternative
        /// </summary>
        private const string LockScreenImageUrlAlternative = "ms-appdata:///Local/shared/shellcontent/Wallpaper2.jpg";
        
        /// <summary>
        /// The lock screen file normal
        /// </summary>
        private const string LockScreenFileNormal = "shared\\shellcontent\\Wallpaper.jpg";
        
        /// <summary>
        /// The lock screen file alternative
        /// </summary>
        private const string LockScreenFileAlternative = "shared\\shellcontent\\Wallpaper2.jpg";

        /// <summary>
        /// The storage service
        /// </summary>
        private readonly IAsyncStorageService _storageService = new AsyncStorageService();

        private string LockScreenImageUrl
        {
            get
            {
                return ImageUri.ToString().EndsWith("2.jpg") ? LockScreenImageUrlNormal : LockScreenImageUrlAlternative;
            }
        }

        private string LockScreenFile
        {
            get
            {
                return ImageUri.ToString().EndsWith("2.jpg") ? LockScreenFileNormal : LockScreenFileAlternative;
            }
        }

        /// <summary>
        /// Sets the current app as the lock screen background provider.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
            var result = await LockScreenManager.RequestAccessAsync();

            switch (result)
            {
                case LockScreenRequestResult.Denied:
                    return LockScreenServiceRequestResult.Denied;

                case LockScreenRequestResult.Granted:
                    return LockScreenServiceRequestResult.Granted;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the app is the current lock screen background provider.
        /// </summary>
        /// <value>true if the app is the current lock screen background provider; otherwise, false.</value>
        public bool IsProvidedByCurrentApplication
        {
            get
            {
                return LockScreenManager.IsProvidedByCurrentApplication;
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
                return LockScreen.GetImageUri();
            }
            set
            {
                LockScreen.SetImageUri(value);
            }
        }

        public async Task SetDefaultLockScreenAsync()
        {
            await SetLockScreenAsync(DefaultLockScreenImageUri);
        }

        public async Task SetLockScreenAsync(string uri)
        {
            if (uri.StartsWith("http"))
            {
                await DownloadImage(uri);
                ImageUri = new Uri(LockScreenImageUrl, UriKind.RelativeOrAbsolute);
            }
            else
            {
                ImageUri = new Uri(uri, UriKind.RelativeOrAbsolute);
            }
        }

        private async Task DownloadImage(string uri)
        {
            try
            {
                var bitmap = new BitmapImage();
                var client = new WebClient();
                var stream = await client.OpenReadTaskAsync(new Uri(uri, UriKind.Absolute));
                bitmap.SetSource(stream);
                var writeableBitmap = new WriteableBitmap(bitmap);

                await SaveTheImage(writeableBitmap);

                await SetLockScreenAsync(LockScreenImageUrl);
            }
            catch (Exception ex)
            {
            }
        }

        private async Task SaveTheImage(WriteableBitmap bitmap)
        {
            if (await _storageService.FileExistsAsync(LockScreenFile))
            {
                await _storageService.DeleteFileAsync(LockScreenFile);
            }

            using (var fileStream = await _storageService.CreateFileAsync(LockScreenFile))
            {
                bitmap.SaveJpeg(fileStream, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
            }
        }
    }
}