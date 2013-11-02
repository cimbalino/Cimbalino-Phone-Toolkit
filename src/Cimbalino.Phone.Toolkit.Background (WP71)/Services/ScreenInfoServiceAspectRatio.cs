// ****************************************************************************
// <copyright file="ScreenInfoServiceAspectRatio.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Describes the device aspect ratio.
    /// </summary>
    public enum ScreenInfoServiceAspectRatio
    {
        /// <summary>
        /// The device has an unknown aspect ratio.
        /// </summary>
        Unknown,

        /// <summary>
        /// The device has a 15:9 aspect ratio.
        /// </summary>
        AspectRatio15By9,

        /// <summary>
        /// The device has a 16:9 aspect ratio.
        /// </summary>
        AspectRatio16By9
    }
}