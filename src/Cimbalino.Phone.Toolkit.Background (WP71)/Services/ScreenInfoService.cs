// ****************************************************************************
// <copyright file="ScreenInfoService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>30-11-2012</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WP8
using System;
#endif
using System.Windows;
#if WP8
using Microsoft.Phone.Info;
#endif

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IScreenInfoService"/>.
    /// </summary>
    public class ScreenInfoService : IScreenInfoService
    {
        /// <summary>
        /// Gets a value indicating the device scale factor.
        /// </summary>
        /// <value>The device scale factor.</value>
        public int ScaleFactor
        {
            get
            {
#if WP8
                object physicalScreenResolutionObject;

                if (DeviceExtendedProperties.TryGetValue("PhysicalScreenResolution", out physicalScreenResolutionObject))
                {
                    var physicalScreenResolution = (Size)physicalScreenResolutionObject;

                    return (int)(physicalScreenResolution.Width / 4.8);
                }

                return Application.Current.Host.Content.ScaleFactor;
#else
                return 100;
#endif
            }
        }

        /// <summary>
        /// Gets the device resolution.
        /// </summary>
        /// <value>The device resolution.</value>
        public ScreenInfoServiceResolution Resolution
        {
            get
            {
#if WP8
                var scaleFactor = ScaleFactor;

                if (Enum.IsDefined(typeof(ScreenInfoServiceResolution), scaleFactor))
                {
                    return (ScreenInfoServiceResolution)scaleFactor;
                }

                return ScreenInfoServiceResolution.Unknown;
#else
                return ScreenInfoServiceResolution.WVGA;
#endif
            }
        }

        /// <summary>
        /// Gets the device aspect ratio.
        /// </summary>
        /// <value>The device aspect ratio.</value>
        public ScreenInfoServiceAspectRatio AspectRatio
        {
            get
            {
#if WP8
                switch (Resolution)
                {
                    case ScreenInfoServiceResolution.WVGA:
                    case ScreenInfoServiceResolution.WXGA:
                        return ScreenInfoServiceAspectRatio.AspectRatio15By9;

                    case ScreenInfoServiceResolution.HD720p:
                    case ScreenInfoServiceResolution.HD1080p:
                        return ScreenInfoServiceAspectRatio.AspectRatio16By9;
                }

                return ScreenInfoServiceAspectRatio.Unknown;
#else
                return ScreenInfoServiceAspectRatio.AspectRatio15By9;
#endif
            }
        }

        /// <summary>
        /// Gets the device screen size.
        /// </summary>
        /// <value>The device screen size.</value>
        public Size Size
        {
            get
            {
#if WP8
                switch (Resolution)
                {
                    case ScreenInfoServiceResolution.WVGA:
                        return new Size(480, 800);

                    case ScreenInfoServiceResolution.HD720p:
                        return new Size(720, 1280);

                    case ScreenInfoServiceResolution.WXGA:
                        return new Size(800, 1280);

                    case ScreenInfoServiceResolution.HD1080p:
                        return new Size(1080, 1920);
                }

                return Size.Empty;
#else
                return new Size(480, 800);
#endif
            }
        }
    }
}