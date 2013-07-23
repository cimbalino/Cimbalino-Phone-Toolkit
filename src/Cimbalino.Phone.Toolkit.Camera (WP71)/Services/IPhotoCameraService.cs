// ****************************************************************************
// <copyright file="IPhotoCameraService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>26-12-2011</date>
// <project>Cimbalino.Phone.Toolkit.Camera</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Microsoft.Devices;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the device camera.
    /// </summary>
    public interface IPhotoCameraService
    {
        /// <summary>
        /// Occurs when the camera object has been initialized.
        /// </summary>
        event EventHandler<CameraOperationCompletedEventArgs> Initialized;

        /// <summary>
        /// Occurs when the capture sequence is complete.
        /// </summary>
        event EventHandler<CameraOperationCompletedEventArgs> CaptureCompleted;

        /// <summary>
        /// Occurs when an image is available.
        /// </summary>
        event EventHandler<ContentReadyEventArgs> CaptureImageAvailable;

        /// <summary>
        /// Occurs when the capture sequence has started.
        /// </summary>
        event EventHandler CaptureStarted;

        /// <summary>
        /// Occurs when a thumbnail image is available.
        /// </summary>
        event EventHandler<ContentReadyEventArgs> CaptureThumbnailAvailable;

        /// <summary>
        /// Occurs after the focus operation is complete.
        /// </summary>
        event EventHandler<CameraOperationCompletedEventArgs> AutoFocusCompleted;

        /// <summary>
        /// Gets the state of the <see cref="IPhotoCameraService"/>.
        /// </summary>
        /// <value>Returns a <see cref="PhotoCameraServiceState"/> enumeration indicating the state of the <see cref="IPhotoCameraService"/>.</value>
        PhotoCameraServiceState State { get; }

        /// <summary>
        /// Gets or sets the flash mode.
        /// </summary>
        /// <value>The flash mode.</value>
        FlashMode FlashMode { get; set; }

        /// <summary>
        /// Gets the camera for the available resolutions.
        /// </summary>
        /// <value>The collection of available resolutions on the camera.</value>
        IEnumerable<Size> AvailableResolutions { get; }

        /// <summary>
        /// Gets or sets the resolution of the image captured by the camera.
        /// </summary>
        /// <value>The resolution of the image captured by the camera.</value>
        Size Resolution { get; set; }

        /// <summary>
        /// Gets the number of degrees that the viewfinder brush needs to be rotated clockwise to align with the camera sensor.
        /// </summary>
        /// <value>The number of degrees that the viewfinder brush needs to be rotated clockwise to align with the camera sensor.</value>
        double Orientation { get; }

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
        /// Cancels the current focus operation.
        /// </summary>
        void CancelFocus();

        /// <summary>
        /// Starts a camera auto focus operation on a specific point in the viewfinder, for those devices that support it.
        /// </summary>
        /// <param name="x">The horizontal location in the viewfinder; a value between 0 (left) and 1.0 (right).</param>
        /// <param name="y">The vertical location in the viewfinder; a value between 0 (bottom) and 1.0 (top).</param>
        void FocusAtPoint(double x, double y);

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