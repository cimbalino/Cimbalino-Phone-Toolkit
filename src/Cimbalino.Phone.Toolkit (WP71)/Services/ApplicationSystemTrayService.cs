// ****************************************************************************
// <copyright file="ApplicationSystemTrayService.cs" company="Pedro Lamas">
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

using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationSystemTrayService"/>.
    /// </summary>
    public class ApplicationSystemTrayService : IApplicationSystemTrayService
    {
        private readonly ProgressIndicator _progressIndicator = new ProgressIndicator();
        private readonly object _progressIndicatorLock = new object();

        private bool _initialized;
        private int _showCount;

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the progress indicator is visible on the system tray.
        /// </summary>
        /// <value>true if the progress indicator is visible on the system tray; otherwise false.</value>
        public bool IsVisible
        {
            get
            {
                return _progressIndicator.IsVisible;
            }
        }

        /// <summary>
        /// Gets or sets the text of the progress indicator on the system tray.
        /// </summary>
        /// <value>The text of the progress indicator on the system tray.</value>
        public string Text
        {
            get
            {
                return _progressIndicator.Text;
            }
            set
            {
                _progressIndicator.Text = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSystemTrayService" /> class.
        /// </summary>
        public ApplicationSystemTrayService()
        {
            Deployment.Current.Dispatcher.BeginInvoke(EnsureInitialization);
        }

        /// <summary>
        /// Show the progress indicator on the system tray.
        /// </summary>
        public void Show()
        {
            EnsureInitialization();

            lock (_progressIndicatorLock)
            {
                _showCount++;

                _progressIndicator.IsIndeterminate = true;
                _progressIndicator.IsVisible = true;
            }
        }

        /// <summary>
        /// Hide the progress indicator on the system tray.
        /// </summary>
        public void Hide()
        {
            lock (_progressIndicatorLock)
            {
                if (_showCount-- == 0)
                {
                    _progressIndicator.IsIndeterminate = false;
                    _progressIndicator.IsVisible = false;
                }
            }
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
    }
}