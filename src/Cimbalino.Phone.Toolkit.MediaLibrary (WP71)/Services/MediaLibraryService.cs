// ****************************************************************************
// <copyright file="MediaLibraryService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>09-07-2013</date>
// <project>Cimbalino.Phone.Toolkit.MediaLibrary</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.IO;
using Microsoft.Xna.Framework.Media;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IMediaLibraryService"/>.
    /// </summary>
    public class MediaLibraryService : IMediaLibraryService
    {
        private readonly MediaLibrary _mediaLibrary = new MediaLibrary();

        /// <summary>
        /// Gets the <see cref="AlbumCollection"/> that contains all albums in the media library.
        /// </summary>
        /// <value>The <see cref="AlbumCollection"/> that contains all albums in the device's media library.</value>
        public AlbumCollection Albums
        {
            get
            {
                return _mediaLibrary.Albums;
            }
        }

        /// <summary>
        /// Gets the PictureCollection that contains all pictures in the media library.
        /// </summary>
        /// <value>The <see cref="PictureCollection"/> that contains all pictures in the device's media library.</value>
        public PictureCollection Pictures
        {
            get
            {
                return _mediaLibrary.Pictures;
            }
        }

        /// <summary>
        /// Gets the collection of all saved pictures in the device's media library.
        /// </summary>
        /// <value>The <see cref="PictureCollection"/> object that contains the collection of all saved pictures in the media library.</value>
        public PictureCollection SavedPictures
        {
            get
            {
                return _mediaLibrary.SavedPictures;
            }
        }

        /// <summary>
        /// Gets the root <see cref="PictureAlbum"/> for all pictures in the media library.
        /// </summary>
        /// <value>The root <see cref="PictureAlbum"/> for all pictures in the device's media library.</value>
        public PictureAlbum RootPictureAlbum
        {
            get
            {
                return _mediaLibrary.RootPictureAlbum;
            }
        }

        /// <summary>
        /// Retrieves a picture from the device's media library based on a picture token.
        /// </summary>
        /// <param name="token">The picture token.</param>
        /// <returns>The <see cref="Picture"/> object that matches the supplied picture token.</returns>
        public Picture GetPictureFromToken(string token)
        {
            return _mediaLibrary.GetPictureFromToken(token);
        }

        /// <summary>
        /// Saves an image to the media library.
        /// </summary>
        /// <param name="name">Name of the image file saved to the media library.</param>
        /// <param name="imageBuffer">Buffer that contains the image in the required JPEG file format.</param>
        public void SavePicture(string name, byte[] imageBuffer)
        {
            _mediaLibrary.SavePicture(name, imageBuffer);
        }

        /// <summary>
        /// Saves the image contained in the stream object to the media library.
        /// </summary>
        /// <param name="name">Name of the image file saved to the media library.</param>
        /// <param name="source">Stream object that contains the image information in the required JPEG file format.</param>
        public void SavePicture(string name, Stream source)
        {
            _mediaLibrary.SavePicture(name, source);
        }

        /// <summary>
        /// Saves the specified byte array as a picture in the Windows Phone camera roll.
        /// </summary>
        /// <param name="name">The name to use for the new picture.</param>
        /// <param name="imageBuffer">The picture to save, provided as a byte array.</param>
        public void SavePictureToCameraRoll(string name, byte[] imageBuffer)
        {
            _mediaLibrary.SavePictureToCameraRoll(name, imageBuffer);
        }

        /// <summary>
        /// Saves the specified image <see cref="Stream"/> as a picture in the Windows Phone camera roll.
        /// </summary>
        /// <param name="name">The name to use for the new picture.</param>
        /// <param name="source">The picture to save, provided as a <see cref="Stream"/>.</param>
        public void SavePictureToCameraRoll(string name, Stream source)
        {
            _mediaLibrary.SavePictureToCameraRoll(name, source);
        }
    }
}