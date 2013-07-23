// ****************************************************************************
// <copyright file="PhotoCameraService.cs" company="Pedro Lamas">
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
    /// Represents an implementation of the <see cref="IPhotoCameraService"/>
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
        Justification = "This class will be disposed in another matter")]
    public class PhotoCameraService : IPhotoCameraService
    {
        /// <summary>
        /// Occurs after the focus operation is complete.
        /// </summary>
        public event EventHandler<CameraOperationCompletedEventArgs> AutoFocusCompleted;

        /// <summary>
        /// Occurs when the capture sequence is complete.
        /// </summary>
        public event EventHandler<CameraOperationCompletedEventArgs> CaptureCompleted;

        /// <summary>
        /// Occurs when an image is available.
        /// </summary>
        public event EventHandler<ContentReadyEventArgs> CaptureImageAvailable;

        /// <summary>
        /// Occurs when the capture sequence has started.
        /// </summary>
        public event EventHandler CaptureStarted;

        /// <summary>
        /// Occurs when a thumbnail image is available.
        /// </summary>
        public event EventHandler<ContentReadyEventArgs> CaptureThumbnailAvailable;

        /// <summary>
        /// Occurs when the camera object has been initialized.
        /// </summary>
        public event EventHandler<CameraOperationCompletedEventArgs> Initialized;

        private PhotoCamera _photoCamera;

        /// <summary>
        /// Gets the state of the <see cref="IPhotoCameraService" />.
        /// </summary>
        /// <value>
        /// Returns a <see cref="PhotoCameraServiceState" /> enumeration indicating the state of the <see cref="IPhotoCameraService" />.
        /// </value>
        public PhotoCameraServiceState State { get; private set; }

        /// <summary>
        /// Gets or sets the flash mode.
        /// </summary>
        /// <value>The flash mode.</value>
        public FlashMode FlashMode
        {
            get
            {
                return _photoCamera.FlashMode;
            }
            set
            {
                if (_photoCamera.IsFlashModeSupported(value))
                {
                    try
                    {
                        _photoCamera.FlashMode = value;
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Gets the camera for the available resolutions.
        /// </summary>
        /// <value>The collection of available resolutions on the camera.</value>
        public IEnumerable<Size> AvailableResolutions
        {
            get
            {
                return _photoCamera.AvailableResolutions;
            }
        }

        /// <summary>
        /// Gets or sets the resolution of the image captured by the camera.
        /// </summary>
        /// <value>The resolution of the image captured by the camera.</value>
        public Size Resolution
        {
            get
            {
                return _photoCamera.Resolution;
            }
            set
            {
                try
                {
                    _photoCamera.Resolution = value;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Gets the number of degrees that the viewfinder brush needs to be rotated clockwise to align with the camera sensor.
        /// </summary>
        /// <value>The number of degrees that the viewfinder brush needs to be rotated clockwise to align with the camera sensor.</value>
        public double Orientation
        {
            get
            {
                return _photoCamera.Orientation;
            }
        }

        /// <summary>
        /// Starts the camera service.
        /// </summary>
        public void Start()
        {
            if (_photoCamera != null)
            {
                return;
            }

            _photoCamera = new PhotoCamera();

            _photoCamera.AutoFocusCompleted += PhotoCamera_AutoFocusCompleted;
            _photoCamera.CaptureCompleted += PhotoCamera_CaptureCompleted;
            _photoCamera.CaptureImageAvailable += PhotoCamera_CaptureImageAvailable;
            _photoCamera.CaptureStarted += PhotoCamera_CaptureStarted;
            _photoCamera.CaptureThumbnailAvailable += PhotoCamera_CaptureThumbnailAvailable;
            _photoCamera.Initialized += PhotoCamera_Initialized;

            State = PhotoCameraServiceState.Starting;
        }

        /// <summary>
        /// Stops the camera service.
        /// </summary>
        public void Stop()
        {
            if (_photoCamera == null)
            {
                return;
            }

            State = PhotoCameraServiceState.Stopped;

            _photoCamera.AutoFocusCompleted -= PhotoCamera_AutoFocusCompleted;
            _photoCamera.CaptureCompleted -= PhotoCamera_CaptureCompleted;
            _photoCamera.CaptureImageAvailable -= PhotoCamera_CaptureImageAvailable;
            _photoCamera.CaptureStarted -= PhotoCamera_CaptureStarted;
            _photoCamera.CaptureThumbnailAvailable -= PhotoCamera_CaptureThumbnailAvailable;
            _photoCamera.Initialized -= PhotoCamera_Initialized;

            _photoCamera.Dispose();
            _photoCamera = null;
        }

        /// <summary>
        /// Starts a camera auto focus operation.
        /// </summary>
        public void Focus()
        {
            if (_photoCamera.IsFocusSupported)
            {
                try
                {
                    _photoCamera.Focus();
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Cancels the current focus operation.
        /// </summary>
        public void CancelFocus()
        {
            _photoCamera.CancelFocus();
        }

        /// <summary>
        /// Starts a camera auto focus operation on a specific point in the viewfinder, for those devices that support it.
        /// </summary>
        /// <param name="x">The horizontal location in the viewfinder; a value between 0 (left) and 1.0 (right).</param>
        /// <param name="y">The vertical location in the viewfinder; a value between 0 (bottom) and 1.0 (top).</param>
        public void FocusAtPoint(double x, double y)
        {
            if (_photoCamera.IsFocusAtPointSupported)
            {
                try
                {
                    _photoCamera.FocusAtPoint(x, y);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Initiates a full-resolution capture of the current image displayed in the viewfinder.
        /// </summary>
        public void CaptureImage()
        {
            try
            {
                _photoCamera.CaptureImage();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Copies the luminance data for the current viewfinder frame into a buffer for further manipulation.
        /// </summary>
        /// <param name="pixelData">The YUV pixel data.</param>
        public void GetPreviewBufferY(byte[] pixelData)
        {
            _photoCamera.GetPreviewBufferY(pixelData);
        }

        /// <summary>
        /// Copies the current viewfinder frame into a buffer for further manipulation.
        /// </summary>
        /// <param name="pixelData">The pixel data.</param>
        public void GetPreviewBufferYCbCr(byte[] pixelData)
        {
            _photoCamera.GetPreviewBufferYCbCr(pixelData);
        }

        /// <summary>
        /// Creates a <see cref="VideoBrush" /> containing the current image.
        /// </summary>
        /// <returns>A <see cref="VideoBrush" /> containing the current image.</returns>
        public VideoBrush CreateVideoBrush()
        {
            var videoBrush = new VideoBrush();

            videoBrush.SetSource(_photoCamera);

            return videoBrush;
        }

        private void PhotoCamera_AutoFocusCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            var eventHandler = AutoFocusCompleted;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void PhotoCamera_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            var eventHandler = CaptureCompleted;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void PhotoCamera_CaptureImageAvailable(object sender, ContentReadyEventArgs e)
        {
            var eventHandler = CaptureImageAvailable;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void PhotoCamera_CaptureStarted(object sender, EventArgs e)
        {
            var eventHandler = CaptureStarted;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void PhotoCamera_CaptureThumbnailAvailable(object sender, ContentReadyEventArgs e)
        {
            var eventHandler = CaptureThumbnailAvailable;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void PhotoCamera_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            State = PhotoCameraServiceState.Started;

            var eventHandler = Initialized;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
}