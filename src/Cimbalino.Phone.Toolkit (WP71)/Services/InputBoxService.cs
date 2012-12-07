// ****************************************************************************
// <copyright file="InputBoxService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-02-2012</date>
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
using System.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IInputBoxService"/>.
    /// </summary>
    public class InputBoxService : IInputBoxService
    {
        /// <summary>
        /// Shows the specified text and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="textInputed">The <see cref="T:Action{string}" /> to be called once the operation is finished.</param>
        public void Show(string text, Action<string> textInputed)
        {
            Show(text, null, null, false, textInputed);
        }

        /// <summary>
        /// Shows the specified text and caption and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="textInputed">The <see cref="T:Action{string}" /> to be called once the operation is finished.</param>
        public void Show(string text, string caption, Action<string> textInputed)
        {
            Show(text, caption, null, false, textInputed);
        }

        /// <summary>
        /// Shows the specified text and caption and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="usePasswordMode">true if password mode is enabled; otherwise, false.</param>
        /// <param name="textInputed">The <see cref="T:Action{string}" /> to be called once the operation is finished.</param>
        public void Show(string text, string caption, bool usePasswordMode, Action<string> textInputed)
        {
            Show(text, caption, null, usePasswordMode, textInputed);
        }

        /// <summary>
        /// Shows the specified text, caption and default input text, and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="defaultText">The default text displayed in the input area when the interface dialog box is first shown.</param>
        /// <param name="textInputed">The <see cref="T:Action{string}" /> to be called once the operation is finished.</param>
        public void Show(string text, string caption, string defaultText, Action<string> textInputed)
        {
            Show(text, caption, defaultText, false, textInputed);
        }

        /// <summary>
        /// Shows the specified text, caption and default input text, and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="defaultText">The default text displayed in the input area when the interface dialog box is first shown.</param>
        /// <param name="usePasswordMode">true if password mode is enabled; otherwise, false.</param>
        /// <param name="textInputed">The <see cref="T:Action{string}" /> to be called once the operation is finished.</param>
        public void Show(string text, string caption, string defaultText, bool usePasswordMode, Action<string> textInputed)
        {
            Guide.BeginShowKeyboardInput(PlayerIndex.One, caption, text, defaultText, ar =>
            {
                text = Guide.EndShowKeyboardInput(ar);

                Deployment.Current.Dispatcher.BeginInvoke(() => textInputed(text));
            }, null, usePasswordMode);
        }

#if WP8
        /// <summary>
        /// Shows the specified text and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <returns>The <see cref="Task{EmailResult}"/> object representing the asynchronous operation.</returns>
        public Task<string> ShowTaskAsync(string text)
        {
            return ShowTaskAsync(text, null, null, false);
        }

        /// <summary>
        /// Shows the specified text and caption and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <returns>The <see cref="Task{EmailResult}"/> object representing the asynchronous operation.</returns>
        public Task<string> ShowTaskAsync(string text, string caption)
        {
            return ShowTaskAsync(text, caption, null, false);
        }

        /// <summary>
        /// Shows the specified text and caption and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="usePasswordMode">true if password mode is enabled; otherwise, false.</param>
        /// <returns>The <see cref="Task{EmailResult}"/> object representing the asynchronous operation.</returns>
        public Task<string> ShowTaskAsync(string text, string caption, bool usePasswordMode)
        {
            return ShowTaskAsync(text, caption, null, usePasswordMode);
        }

        /// <summary>
        /// Shows the specified text, caption and default input text, and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="defaultText">The default text displayed in the input area when the interface dialog box is first shown.</param>
        /// <returns>The <see cref="Task{EmailResult}"/> object representing the asynchronous operation.</returns>
        public Task<string> ShowTaskAsync(string text, string caption, string defaultText)
        {
            return ShowTaskAsync(text, caption, defaultText, false);
        }

        /// <summary>
        /// Shows the specified text, caption and default input text, and awaits for the user to reply.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the input box.</param>
        /// <param name="defaultText">The default text displayed in the input area when the interface dialog box is first shown.</param>
        /// <param name="usePasswordMode">true if password mode is enabled; otherwise, false.</param>
        /// <returns>The <see cref="Task{EmailResult}"/> object representing the asynchronous operation.</returns>
        public Task<string> ShowTaskAsync(string text, string caption, string defaultText, bool usePasswordMode)
        {
            var taskCompletionSource = new TaskCompletionSource<string>();

            Guide.BeginShowKeyboardInput(PlayerIndex.One, caption, text, defaultText, ar =>
            {
                text = Guide.EndShowKeyboardInput(ar);

                Deployment.Current.Dispatcher.BeginInvoke(() => taskCompletionSource.SetResult(text));
            }, null, usePasswordMode);

            return taskCompletionSource.Task;
        }
#endif
    }
}