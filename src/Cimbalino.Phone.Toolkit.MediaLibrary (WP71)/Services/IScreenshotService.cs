// ****************************************************************************
// <copyright file="IScreenshotService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>23-12-2012</date>
// <project>Cimbalino.Phone.Toolkit.MediaLibrary</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of taking screenshots.
    /// </summary>
    public interface IScreenshotService
    {
        /// <summary>
        /// Creates a screenshot image from the current screen.
        /// </summary>
        void TakeScreenshot();

        /// <summary>
        /// Creates a screenshot image from the current screen and saves it with the specified filename.
        /// </summary>
        /// <param name="destinationFilename">The destination filename.</param>
        void TakeScreenshot(string destinationFilename);
    }
}