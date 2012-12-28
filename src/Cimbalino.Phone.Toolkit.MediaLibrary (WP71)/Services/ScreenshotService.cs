// ****************************************************************************
// <copyright file="ScreenshotService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>23-12-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IScreenshotService"/>.
    /// </summary>
    public class ScreenshotService : IScreenshotService
    {
        /// <summary>
        /// Creates a screenshot image from the current screen.
        /// </summary>
        public void TakeScreenshot()
        {
            var frame = Application.Current.RootVisual as PhoneApplicationFrame;

            if (frame != null)
            {
                var screenshotBitmap = new WriteableBitmap((int)frame.ActualWidth, (int)frame.ActualHeight);

                screenshotBitmap.Render(frame, null);
                screenshotBitmap.Invalidate();

                using (var screenshotStream = new MemoryStream())
                {
                    screenshotBitmap.SaveJpeg(screenshotStream, screenshotBitmap.PixelWidth, screenshotBitmap.PixelHeight, 0, 100);

                    var destinationFilename = new Guid().ToString() + ".jpg";

                    using (var mediaLibrary = new MediaLibrary())
                    {
                        mediaLibrary.SavePicture(destinationFilename, screenshotStream.ToArray());
                    }
                }
            }
        }
    }
}