// ****************************************************************************
// <copyright file="IPhotoCameraService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the device camera
    /// </summary>
    public interface IPhotoCameraService
    {
        /// <summary>
        /// Creates a new photo camera handler.
        /// </summary>
        /// <param name="onInitialized">The action to execute after initializing the camera.</param>
        /// <returns>A <see cref="IPhotoCameraHandler"/> instance.</returns>
        IPhotoCameraHandler CreatePhotoCameraHandler(Action<bool, Exception> onInitialized);

        /// <summary>
        /// Creates a new photo camera handler.
        /// </summary>
        /// <param name="onInitialized">The action to execute after initializing the camera.</param>
        /// <param name="onCaptureCompleted">The action to execute after an image capture operation.</param>
        /// <param name="onCaptureImageAvailable">The action to execute after an image is available.</param>
        /// <returns>A <see cref="IPhotoCameraHandler"/> instance.</returns>
        IPhotoCameraHandler CreatePhotoCameraHandler(Action<bool, Exception> onInitialized, Action<bool, Exception> onCaptureCompleted, Action<Stream> onCaptureImageAvailable);

        /// <summary>
        /// Creates a new photo camera handler.
        /// </summary>
        /// <param name="onInitialized">The action to execute after initializing the camera.</param>
        /// <param name="onCaptureCompleted">The action to execute after an image capture operation.</param>
        /// <param name="onCaptureImageAvailable">The action to execute after an image is available.</param>
        /// <param name="onAutoFocusCompleted">The action to execute after an auto focus operation.</param>
        /// <returns>A <see cref="IPhotoCameraHandler"/> instance.</returns>
        IPhotoCameraHandler CreatePhotoCameraHandler(Action<bool, Exception> onInitialized, Action<bool, Exception> onCaptureCompleted, Action<Stream> onCaptureImageAvailable, Action<bool, Exception> onAutoFocusCompleted);
    }
}