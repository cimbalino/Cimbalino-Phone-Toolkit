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

        private PhoneApplicationFrame _mainFrame;
        private PhoneApplicationPage _currentPage;

        /// <summary>
        /// Gets a value indicating whether the progress indicator on the system tray on the current application page is visible.
        /// </summary>
        /// <value>true if the progress indicator is visible; otherwise, false.</value>
        public bool IsBusy
        {
            get
            {
                return _progressIndicator.IsVisible;
            }
        }

        /// <summary>
        /// Sets the progress indicator on the system tray on the current application page with the specified text.
        /// </summary>
        /// <param name="text">The text to use in the progress indicator.</param>
        public void SetProgressIndicator(string text)
        {
            if (EnsureCurrentPage())
            {
                _progressIndicator.IsVisible = true;
                _progressIndicator.IsIndeterminate = true;
                _progressIndicator.Text = text;

                SystemTray.SetProgressIndicator(_currentPage, _progressIndicator);
            }
        }

        /// <summary>
        /// Hides the progress indicator on the system tray on the current application page.
        /// </summary>
        public void HideProgressIndicator()
        {
            if (EnsureCurrentPage())
            {
                _progressIndicator.IsVisible = false;
                _progressIndicator.IsIndeterminate = false;

                SystemTray.SetProgressIndicator(_currentPage, null);
            }
        }

        private bool EnsureCurrentPage()
        {
            if (_mainFrame != null)
            {
                return _currentPage != null;
            }

            _mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

            if (_mainFrame != null)
            {
                _mainFrame.Navigated += (s, e) =>
                {
                    _currentPage = e.Content as PhoneApplicationPage;
                };

                _currentPage = _mainFrame.Content as PhoneApplicationPage;
            }

            return _currentPage != null;
        }
    }
}