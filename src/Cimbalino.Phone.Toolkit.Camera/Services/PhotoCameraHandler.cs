// ****************************************************************************
// <copyright file="PhotoCameraHandler.cs" company="Pedro Lamas">
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

using System;
using System.IO;
using System.Windows.Media;
using Microsoft.Devices;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IPhotoCameraHandler"/>
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
        Justification = "This class will be disposed in another matter")]
    public class PhotoCameraHandler : IPhotoCameraHandler
    {
        private readonly Action<bool, Exception> _onInitialized;
        private readonly Action<bool, Exception> _onCaptureCompleted;
        private readonly Action<Stream> _onCaptureImageAvailable;
        private readonly Action<bool, Exception> _onAutoFocusCompleted;

        private PhotoCamera _photoCamera;

        internal PhotoCameraHandler(Action<bool, Exception> onInitialized, Action<bool, Exception> onCaptureCompleted, Action<Stream> onCaptureImageAvailable, Action<bool, Exception> onAutoFocusCompleted)
        {
            _onInitialized = onInitialized;
            _onCaptureCompleted = onCaptureCompleted;
            _onCaptureImageAvailable = onCaptureImageAvailable;
            _onAutoFocusCompleted = onAutoFocusCompleted;
        }

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
        /// Starts the camera service.
        /// </summary>
        public void Start()
        {
            if (_photoCamera != null)
            {
                return;
            }

            _photoCamera = new PhotoCamera();

            _photoCamera.Initialized += PhotoCamera_Initialized;
            _photoCamera.CaptureCompleted += PhotoCamera_CaptureCompleted;
            _photoCamera.CaptureImageAvailable += PhotoCamera_CaptureImageAvailable;
            _photoCamera.AutoFocusCompleted += PhotoCamera_AutoFocusCompleted;
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

            _photoCamera.Initialized -= PhotoCamera_Initialized;
            _photoCamera.CaptureCompleted -= PhotoCamera_CaptureCompleted;
            _photoCamera.CaptureImageAvailable -= PhotoCamera_CaptureImageAvailable;
            _photoCamera.AutoFocusCompleted -= PhotoCamera_AutoFocusCompleted;

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

        private void PhotoCamera_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            if (_onInitialized != null)
            {
                _onInitialized(e.Succeeded, e.Exception);
            }
        }

        private void PhotoCamera_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            if (_onCaptureCompleted != null)
            {
                _onCaptureCompleted(e.Succeeded, e.Exception);
            }
        }

        private void PhotoCamera_CaptureImageAvailable(object sender, ContentReadyEventArgs e)
        {
            if (_onCaptureImageAvailable != null)
            {
                _onCaptureImageAvailable(e.ImageStream);
            }
        }

        private void PhotoCamera_AutoFocusCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            if (_onAutoFocusCompleted != null)
            {
                _onAutoFocusCompleted(e.Succeeded, e.Exception);
            }
        }
    }
}