// ****************************************************************************
// <copyright file="IPhotoCameraHandler.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>21-11-2011</date>
// <project>Cimbalino.Phone.Toolkit.Camera</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Windows.Media;
using Microsoft.Devices;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the device camera
    /// </summary>
    public interface IPhotoCameraHandler
    {
        /// <summary>
        /// Gets or sets the flash mode.
        /// </summary>
        /// <value>The flash mode.</value>
        FlashMode FlashMode { get; set; }

        /// <summary>
        /// Starts the camera service.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the camera service.
        /// </summary>
        void Stop();

        /// <summary>
        /// Starts a camera auto focus operation.
        /// </summary>
        void Focus();

        /// <summary>
        /// Initiates a full-resolution capture of the current image displayed in the viewfinder.
        /// </summary>
        void CaptureImage();

        /// <summary>
        /// Copies the luminance data for the current viewfinder frame into a buffer for further manipulation.
        /// </summary>
        /// <param name="pixelData">The YUV pixel data.</param>
        void GetPreviewBufferY(byte[] pixelData);

        /// <summary>
        /// Copies the current viewfinder frame into a buffer for further manipulation.
        /// </summary>
        /// <param name="pixelData">The pixel data.</param>
        void GetPreviewBufferYCbCr(byte[] pixelData);

        /// <summary>
        /// Creates a <see cref="VideoBrush"/> containing the current image.
        /// </summary>
        /// <returns>A <see cref="VideoBrush"/> containing the current image.</returns>
        VideoBrush CreateVideoBrush();
    }
}