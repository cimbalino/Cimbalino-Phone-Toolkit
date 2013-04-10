// ****************************************************************************
// <copyright file="IApplicationSystemTrayService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>09-04-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application system tray across the whole application.
    /// </summary>
    public interface IApplicationSystemTrayService
    {
        /// <summary>
        /// Gets a value indicating whether the progress indicator is visible on the system tray.
        /// </summary>
        /// <value>true if the progress indicator is visible on the system tray; otherwise false.</value>
        bool IsVisible { get; }

        /// <summary>
        /// Gets or sets the text of the progress indicator on the system tray.
        /// </summary>
        /// <value>The text of the progress indicator on the system tray.</value>
        string Text { get; set; }

        /// <summary>
        /// Show the progress indicator on the system tray.
        /// </summary>
        void Show();

        /// <summary>
        /// Hide the progress indicator on the system tray.
        /// </summary>
        void Hide();
    }
}