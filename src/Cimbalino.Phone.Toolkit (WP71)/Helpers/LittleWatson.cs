// ****************************************************************************
// <copyright file="LittleWatson.cs" company="Pedro Lamas">
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
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// This object registers a raised exception information and allows the user to send the information thru e-mail.
    /// </summary>
    public class LittleWatson
    {
        private const string Filename = "LittleWatson.txt";

        #region Properties

        /// <summary>
        /// Gets or sets the caption of the message box requesting the user to send the information.
        /// </summary>
        /// <value>The caption of the message box requesting the user to send the information.</value>
        public static string SendRequestMessageBoxCaption { get; set; }

        /// <summary>
        /// Gets or sets the text of the message box requesting the user to send the information.
        /// </summary>
        /// <value>The text of the message box requesting the user to send the information.</value>
        public static string SendRequestMessageBoxText { get; set; }

        /// <summary>
        /// Gets or sets the recipient e-mail address.
        /// </summary>
        /// <value>The recipient e-mail address.</value>
        public static string EmailTo { get; set; }

        /// <summary>
        /// Gets or sets the e-mail subject.
        /// </summary>
        /// <value>The e-mail subject.</value>
        public static string EmailSubject { get; set; }

        #endregion

        /// <summary>
        /// Initializes the <see cref="LittleWatson"/>.
        /// </summary>
        /// <param name="emailTo">The recipient e-mail address.</param>
        /// <param name="emailSubject">The e-mail subject.</param>
        public static void Initialize(string emailTo, string emailSubject)
        {
            Initialize(emailTo, emailSubject, "Problem Report", "A problem occurred the last time you ran this application. Would you like to send an email to report it?");
        }

        /// <summary>
        /// Initializes the <see cref="LittleWatson"/>.
        /// </summary>
        /// <param name="emailTo">The recipient e-mail address.</param>
        /// <param name="emailSubject">The e-mail subject.</param>
        /// <param name="sendRequestMessageBoxCaption">The caption of the message box requesting the user to send the information.</param>
        /// <param name="sendRequestMessageBoxText">The text of the message box requesting the user to send the information.</param>
        public static void Initialize(string emailTo, string emailSubject, string sendRequestMessageBoxCaption, string sendRequestMessageBoxText)
        {
            EmailTo = emailTo;
            EmailSubject = emailSubject;
            SendRequestMessageBoxCaption = sendRequestMessageBoxCaption;
            SendRequestMessageBoxText = sendRequestMessageBoxText;
        }

        /// <summary>
        /// Saves information regarding an exception to the isolated storage.
        /// </summary>
        /// <param name="ex">The exception that occured.</param>
        /// <param name="extra">Extra data to save along with the exception information.</param>
        public static void ReportException(Exception ex, string extra)
        {
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    SafeDeleteFile(store);

                    using (var outputStreamWriter = new StreamWriter(store.CreateFile(Filename)))
                    {
                        outputStreamWriter.WriteLine(extra);
                        outputStreamWriter.WriteLine(ex.Message);
                        outputStreamWriter.WriteLine(ex.StackTrace);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Checks if a previous exception information was saved to isolated storage and if so, requests the user to send it by email.
        /// </summary>
        public static void CheckForPreviousException()
        {
            try
            {
                string contents = null;

                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (store.FileExists(Filename))
                    {
                        contents = store.ReadAllText(Filename);

                        SafeDeleteFile(store);
                    }
                }

                if (contents != null)
                {
                    if (MessageBox.Show(SendRequestMessageBoxText, SendRequestMessageBoxCaption, MessageBoxButton.OKCancel) != MessageBoxResult.OK)
                    {
                        return;
                    }

                    new EmailComposeTask()
                    {
                        To = EmailTo,
                        Subject = EmailSubject,
                        Body = contents
                    }.Show();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    SafeDeleteFile(store);
                }
            }
        }

        private static void SafeDeleteFile(IsolatedStorageFile store)
        {
            try
            {
                store.DeleteFile(Filename);
            }
            catch (Exception)
            {
            }
        }
    }
}