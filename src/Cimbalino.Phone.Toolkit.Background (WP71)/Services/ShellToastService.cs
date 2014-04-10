// ****************************************************************************
// <copyright file="ShellToastService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IShellToastService"/>.
    /// </summary>
    public class ShellToastService : IShellToastService
    {
#if WP8
        internal static readonly bool CustomSoundsSupportedStatic = Environment.OSVersion.Version >= new Version(8, 0, 10492);
#endif

        /// <summary>
        /// Display a toast message with the specified title and content.
        /// </summary>
        /// <param name="title">The title of the toast message.</param>
        /// <param name="content">The contents of the toast message.</param>
        public void Show(string title, string content)
        {
            Show(title, content, null);
        }

        /// <summary>
        /// Display a toast message with the specified title and content.
        /// </summary>
        /// <param name="title">The title of the toast message.</param>
        /// <param name="content">The contents of the toast message.</param>
        /// <param name="navigationUri">Uri to navigate to if the user taps the toast message.</param>
        public void Show(string title, string content, Uri navigationUri)
        {
            Show(title, content, null, null);
        }

        /// <summary>
        /// Display a toast message with the specified title and content.
        /// </summary>
        /// <param name="title">The title of the toast message.</param>
        /// <param name="content">The contents of the toast message.</param>
        /// <param name="navigationUri">Uri to navigate to if the user taps the toast message.</param>
        /// <param name="soundUri">The sound URI of the toast message.</param>
        public void Show(string title, string content, Uri navigationUri, Uri soundUri)
        {
            var toast = new ShellToast()
            {
                Title = title,
                Content = content,
                NavigationUri = navigationUri
            };

#if WP8
            if (CustomSoundsSupportedStatic && soundUri != null)
            {
                toast.SetPropertyValue("Sound", soundUri);
            }
#endif

            toast.Show();
        }

        /// <summary>
        /// Display a toast message with the specified title and content.
        /// </summary>
        /// <param name="title">The title of the toast message.</param>
        /// <param name="content">The contents of the toast message.</param>
        /// <param name="navigationUri">Uri to navigate to if the user taps the toast message.</param>
        /// <param name="silent">true if the toast should not use the default sound; otherwise, false.</param>
        public void Show(string title, string content, Uri navigationUri, bool silent)
        {
            Show(title, content, navigationUri, silent ? new Uri(string.Empty, UriKind.RelativeOrAbsolute) : null);
        }
    }
}