// ****************************************************************************
// <copyright file="ScreenInfoService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>30-11-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WP8
using System;
using System.Windows;
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
                return Application.Current.Host.Content.ScaleFactor;
#else
                return 100;
#endif
            }
        }

        /// <summary>
        /// Gets a value indicating whether the device has a WVGA resolution.
        /// </summary>
        /// <value>true if the device has a WVGA resolution; otherwise, false.</value>
        public bool IsWVGA
        {
            get
            {
#if WP8
                return Application.Current.Host.Content.ScaleFactor == 100;
#else
                return true;
#endif
            }
        }

        /// <summary>
        /// Gets a value indicating whether the device has a WXGA resolution.
        /// </summary>
        /// <value>true if the device has a WXGA resolution; otherwise, false.</value>
        public bool IsWXGA
        {
            get
            {
#if WP8
                return Application.Current.Host.Content.ScaleFactor == 160;
#else
                return false;
#endif
            }
        }

        /// <summary>
        /// Gets a value indicating whether the device has a 720p resolution.
        /// </summary>
        /// <value>true if the device has a 720p resolution; otherwise, false.</value>
        public bool Is720p
        {
            get
            {
#if WP8
                return Application.Current.Host.Content.ScaleFactor == 150;
#else
                return false;
#endif
            }
        }

        /// <summary>
        /// Gets the device resolution.
        /// </summary>
        /// <value>Returns a <see cref="ScreenInfoResolution"/> enumeration indicating the device resolution.</value>
        public ScreenInfoResolution Resolution
        {
            get
            {
#if WP8
                if (IsWVGA)
                {
                    return ScreenInfoResolution.WVGA;
                }
                else if (IsWXGA)
                {
                    return ScreenInfoResolution.WXGA;
                }
                else if (Is720p)
                {
                    return ScreenInfoResolution.HD720p;
                }
                else
                {
                    throw new InvalidOperationException("Unknown resolution");
                }
#else
                return ScreenInfoResolution.WVGA;
#endif
            }
        }
    }
}