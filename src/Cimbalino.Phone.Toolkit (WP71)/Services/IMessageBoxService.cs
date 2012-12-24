// ****************************************************************************
// <copyright file="IMessageBoxService.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
#if WP8
using System.Threading.Tasks;
#endif
using System.Windows;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of showing message boxes.
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Displays a message box that contains the specified text and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        void Show(string text);

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        void Show(string text, string caption);

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and response buttons.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="button">A value that indicates the button or buttons to display.</param>
        /// <returns>A value that indicates the user's response to the message.</returns>
        MessageBoxResult Show(string text, string caption, MessageBoxButton button);

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and response buttons.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="buttons">The captions for message box buttons. The maximum number of buttons is two.</param>
        /// <param name="selectedButton">The <see cref="T:Action{int}"/> to be called once the operation is finished.</param>
        void Show(string text, string caption, IEnumerable<string> buttons, Action<int> selectedButton);

#if WP8
        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and response buttons.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="buttons">The captions for message box buttons. The maximum number of buttons is two.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<int> ShowAsync(string text, string caption, IEnumerable<string> buttons);
#endif
    }
}