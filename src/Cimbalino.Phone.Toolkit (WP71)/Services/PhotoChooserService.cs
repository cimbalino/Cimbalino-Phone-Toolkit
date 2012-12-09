// ****************************************************************************
// <copyright file="PhotoChooserService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>25-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
#if WP8
using System.Threading.Tasks;
#endif
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IPhotoChooserService"/>.
    /// </summary>
    public class PhotoChooserService : IPhotoChooserService
    {
        /// <summary>
        /// Shows the Photo Chooser application.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{PhotoResult}" /> to be called once the operation is finished.</param>
        public void Show(Action<PhotoResult> resultAction)
        {
            new ChooserHandler<PhotoResult>(new PhotoChooserTask(), resultAction)
                .Show();
        }

        /// <summary>
        /// Shows the Photo Chooser application, optionally presenting a button for launching the camera.
        /// </summary>
        /// <param name="showCamera">true if the user is presented with a button for launching the camera during the photo choosing process; otherwise, false.</param>
        /// <param name="resultAction">The <see cref="Action{PhotoResult}" /> to be called once the operation is finished.</param>
        public virtual void Show(bool showCamera, Action<PhotoResult> resultAction)
        {
            throw new NotImplementedException("To use this method, add Cimbalino.Phone.Toolkit.Camera assembly to the project and use the PhotoChooserWithCameraService instead.");
        }

#if WP8
        /// <summary>
        /// Shows the Photo Chooser application.
        /// </summary>
        /// <returns>The <see cref="Task{PhotoResult}"/> object representing the asynchronous operation.</returns>
        public Task<PhotoResult> ShowAsync()
        {
            return new ChooserHandler<PhotoResult>(new PhotoChooserTask())
               .ShowAsync();
        }

        /// <summary>
        /// Shows the Photo Chooser application, optionally presenting a button for launching the camera.
        /// </summary>
        /// <param name="showCamera">true if the user is presented with a button for launching the camera during the photo choosing process; otherwise, false.</param>
        /// <returns>The <see cref="Task{PhotoResult}"/> object representing the asynchronous operation.</returns>
        public virtual Task<PhotoResult> ShowAsync(bool showCamera)
        {
            throw new NotImplementedException("To use this method, add Cimbalino.Phone.Toolkit.Camera assembly to the project and use the PhotoChooserWithCameraService instead.");
        }
#endif
    }
}