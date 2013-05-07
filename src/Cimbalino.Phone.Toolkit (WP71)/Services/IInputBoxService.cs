// ****************************************************************************
// <copyright file="IInputBoxService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>10-02-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of showing a prompt in a dialog box.
    /// </summary>
    public interface IInputBoxService
    {
        /// <summary>
        /// Shows the specified text and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="textInputed">The <see cref="Action{String}"/> to be called once the operation is finished.</param>
        void Show(string text, Action<string> textInputed);

        /// <summary>
        /// Shows the specified text and caption and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="textInputed">The <see cref="Action{String}"/> to be called once the operation is finished.</param>
        void Show(string text, string caption, Action<string> textInputed);

        /// <summary>
        /// Shows the specified text and caption and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="usePasswordMode">true if password mode is enabled; otherwise, false.</param>
        /// <param name="textInputed">The <see cref="Action{String}"/> to be called once the operation is finished.</param>
        void Show(string text, string caption, bool usePasswordMode, Action<string> textInputed);

        /// <summary>
        /// Shows the specified text, caption and default input text, and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="defaultText">The default text displayed in the input area when the interface dialog box is first shown.</param>
        /// <param name="textInputed">The <see cref="Action{String}"/> to be called once the operation is finished.</param>
        void Show(string text, string caption, string defaultText, Action<string> textInputed);

        /// <summary>
        /// Shows the specified text, caption and default input text, and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="defaultText">The default text displayed in the input area when the interface dialog box is first shown.</param>
        /// <param name="usePasswordMode">true if password mode is enabled; otherwise, false.</param>
        /// <param name="textInputed">The <see cref="Action{String}"/> to be called once the operation is finished.</param>
        void Show(string text, string caption, string defaultText, bool usePasswordMode, Action<string> textInputed);

        /// <summary>
        /// Shows the specified text and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> ShowAsync(string text);

        /// <summary>
        /// Shows the specified text and caption and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> ShowAsync(string text, string caption);

        /// <summary>
        /// Shows the specified text and caption and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="usePasswordMode">true if password mode is enabled; otherwise, false.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> ShowAsync(string text, string caption, bool usePasswordMode);

        /// <summary>
        /// Shows the specified text, caption and default input text, and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="defaultText">The default text displayed in the input area when the interface dialog box is first shown.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> ShowAsync(string text, string caption, string defaultText);

        /// <summary>
        /// Shows the specified text, caption and default input text, and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="defaultText">The default text displayed in the input area when the interface dialog box is first shown.</param>
        /// <param name="usePasswordMode">true if password mode is enabled; otherwise, false.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> ShowAsync(string text, string caption, string defaultText, bool usePasswordMode);
    }
}