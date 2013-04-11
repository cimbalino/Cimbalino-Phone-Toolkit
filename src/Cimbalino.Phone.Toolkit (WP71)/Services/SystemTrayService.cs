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

        /// <summary>
        /// Gets a value indicating whether the progress indicator on the system tray on the current application page is visible.
        /// </summary>
        /// <value>true if the progress indicator is visible; otherwise, false.</value>
        public bool IsVisible
        {
            get
            {
                return _progressIndicator.IsVisible;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTrayService" /> class.
        /// </summary>
        public SystemTrayService()
        {
            Deployment.Current.Dispatcher.BeginInvoke(EnsureInitialization);
        }

        /// <summary>
        /// Sets the progress indicator on the system tray on the current application page with the specified text.
        /// </summary>
        /// <param name="text">The text to use in the progress indicator.</param>
        public void SetProgressIndicator(string text)
        {
            EnsureInitialization();

            _progressIndicator.IsIndeterminate = true;
            _progressIndicator.IsVisible = true;
        }

        /// <summary>
        /// Hides the progress indicator on the system tray on the current application page.
        /// </summary>
        public void HideProgressIndicator()
        {
            _progressIndicator.IsIndeterminate = false;
            _progressIndicator.IsVisible = false;
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