// ****************************************************************************
// <copyright file="SystemTrayService.cs" company="Pedro Lamas">
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
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ISystemTrayService"/>.
    /// </summary>
    public class SystemTrayService : ISystemTrayService
    {
        private readonly ProgressIndicator _progressIndicator = new ProgressIndicator();

        private bool _initialized;

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the progress indicator is visible on the system tray on the current application.
        /// </summary>
        /// <value>true if the progress indicator is visible; otherwise, false.</value>
        public bool IsVisible
        {
            get
            {
                return _progressIndicator.IsVisible;
            }
            set
            {
                EnsureInitialization();

                _progressIndicator.IsVisible = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the progress indicator on the system tray on the current application page is determinate or indeterminate.
        /// </summary>
        /// <value>true if the progress indicator is indeterminate; false if the progress bar is determinate.</value>
        public bool IsIndeterminate
        {
            get
            {
                return _progressIndicator.IsIndeterminate;
            }
            set
            {
                EnsureInitialization();

                _progressIndicator.IsIndeterminate = value;
            }
        }

        /// <summary>
        /// Gets or sets the text to show in the system tray.
        /// </summary>
        /// <value>The text to show in the system tray.</value>
        public string Text
        {
            get
            {
                return _progressIndicator.Text;
            }
            set
            {
                EnsureInitialization();

                _progressIndicator.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the progress indicator on the system tray on the current application page.
        /// </summary>
        /// <value>The value of the progress indicator on the system tray.</value>
        public double Value
        {
            get
            {
                return _progressIndicator.Value;
            }
            set
            {
                EnsureInitialization();

                _progressIndicator.Value = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTrayService" /> class.
        /// </summary>
        public SystemTrayService()
        {
            Deployment.Current.Dispatcher.BeginInvoke(EnsureInitialization);
        }

        private void EnsureInitialization()
        {
            if (_initialized)
            {
                return;
            }

            var mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

            if (mainFrame != null)
            {
                mainFrame.Navigated += (s, e) =>
                {
                    SetPageProgressIndicator(e.Content as PhoneApplicationPage);
                };

                SetPageProgressIndicator(mainFrame.Content as PhoneApplicationPage);

                _initialized = true;
            }
        }

        private void SetPageProgressIndicator(PhoneApplicationPage page)
        {
            if (page != null)
            {
                SystemTray.SetProgressIndicator(page, _progressIndicator);
            }
        }

        #region Obsolete

        /// <summary>
        /// Gets a value indicating whether the progress indicator on the system tray on the current application page is visible.
        /// </summary>
        /// <value>true if the progress indicator is visible; otherwise, false.</value>
        [Obsolete("Please use the IsVisible property instead.")]
        public bool IsBusy
        {
            get
            {
                return IsVisible;
            }
        }

        /// <summary>
        /// Sets the progress indicator on the system tray on the current application page with the specified text.
        /// </summary>
        /// <param name="text">The text to use in the progress indicator.</param>
        [Obsolete("Please use the Text, IsVisible and IsIndeterminate properties instead.")]
        public void SetProgressIndicator(string text)
        {
            EnsureInitialization();

            _progressIndicator.Text = text;
            _progressIndicator.IsIndeterminate = true;
            _progressIndicator.IsVisible = true;
        }

        /// <summary>
        /// Hides the progress indicator on the system tray on the current application page.
        /// </summary>
        [Obsolete("Please use the IsVisible property instead.")]
        public void HideProgressIndicator()
        {
            _progressIndicator.IsIndeterminate = false;
            _progressIndicator.IsVisible = false;
        }

        #endregion
    }
}