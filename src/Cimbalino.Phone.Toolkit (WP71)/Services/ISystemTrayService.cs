// ****************************************************************************
// <copyright file="ISystemTrayService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application system tray.
    /// </summary>
    public interface ISystemTrayService
    {
        /// <summary>
        /// Gets a value indicating whether the progress indicator on the system tray on the current application page is visible.
        /// </summary>
        /// <value>true if the progress indicator is visible; otherwise, false.</value>
        bool IsVisible { get; }

        /// <summary>
        /// Sets the progress indicator on the system tray on the current application page with the specified text.
        /// </summary>
        /// <param name="text">The text to use in the progress indicator.</param>
        void Show(string text);

        /// <summary>
        /// Hides the progress indicator on the system tray on the current application page.
        /// </summary>
        void Hide();

        /// <summary>
        /// Gets a value indicating whether the progress indicator on the system tray on the current application page is visible.
        /// </summary>
        /// <value>true if the progress indicator is visible; otherwise, false.</value>
        [Obsolete("Please use the IsVisible property instead.")]
        bool IsBusy { get; }

        /// <summary>
        /// Sets the progress indicator on the system tray on the current application page with the specified text.
        /// </summary>
        /// <param name="text">The text to use in the progress indicator.</param>
        [Obsolete("Please use the Show method instead.")]
        void SetProgressIndicator(string text);

        /// <summary>
        /// Hides the progress indicator on the system tray on the current application page.
        /// </summary>
        [Obsolete("Please use the Hide method instead.")]
        void HideProgressIndicator();
    }
}