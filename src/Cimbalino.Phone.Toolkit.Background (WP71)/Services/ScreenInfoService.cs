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
        /// Gets the device resolution.
        /// </summary>
        /// <value>Returns a <see cref="ScreenInfoServiceResolution"/> enumeration indicating the device resolution.</value>
        public ScreenInfoServiceResolution Resolution
        {
            get
            {
#if WP8
                var scaleFactor = Application.Current.Host.Content.ScaleFactor;

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
    }
}