// ****************************************************************************
// <copyright file="NavigationService.cs" company="Pedro Lamas">
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
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="INavigationService"/>.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private PhoneApplicationFrame _mainFrame;
        private System.Windows.Navigation.NavigationService _navigationService;

        /// <summary>
        /// Occurs when a new navigation is requested.
        /// </summary>
        public event NavigatingCancelEventHandler Navigating;

        /// <summary>
        /// Gets the uniform resource identifier (URI) of the content that is currently displayed.
        /// </summary>
        /// <value>
        /// Returns a value that represents the <see cref="Uri" /> of content that is currently displayed.
        /// </value>
        public Uri CurrentSource
        {
            get
            {
                if (EnsureNavigationService())
                {
                    return _mainFrame.CurrentSource;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets a collection of query string values.
        /// </summary>
        /// <value>
        /// Returns a <see cref="T:IDictionary{string,string}" /> collection that contains the query string values.
        /// </value>
        public IDictionary<string, string> QueryString
        {
            get
            {
                if (EnsureNavigationService())
                {
                    var page = _mainFrame.Content as PhoneApplicationPage;

                    if (page != null && page.NavigationContext != null)
                    {
                        return page.NavigationContext.QueryString;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">The URI for the desired content.</param>
        public void NavigateTo(string source)
        {
            NavigateTo(new Uri(source, UriKind.Relative));
        }

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">A <see cref="Uri" /> initialized with the URI for the desired content.</param>
        public void NavigateTo(Uri source)
        {
            if (EnsureNavigationService())
            {
                _navigationService.Navigate(source);
            }
        }

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in the back navigation history.
        /// </summary>
        /// <value>
        /// true if there is at least one entry in the back navigation history; otherwise, false.
        /// </value>
        public bool CanGoBack
        {
            get
            {
                return EnsureNavigationService() && _navigationService.CanGoBack;
            }
        }

        /// <summary>
        /// Navigates to the most recent available entry in the back navigation history.
        /// </summary>
        public void GoBack()
        {
            if (EnsureNavigationService() && _navigationService.CanGoBack)
            {
                _navigationService.GoBack();
            }
        }

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        public void RemoveBackEntry()
        {
            if (EnsureNavigationService() && _navigationService.CanGoBack)
            {
                _navigationService.RemoveBackEntry();
            }
        }

        private bool EnsureNavigationService()
        {
            if (_navigationService != null)
            {
                return true;
            }

            if (_mainFrame == null)
            {
                _mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

                if (_mainFrame != null)
                {
                    _mainFrame.Navigating += (s, e) =>
                    {
                        var eventHandler = Navigating;

                        if (eventHandler != null)
                        {
                            eventHandler(s, e);
                        }
                    };

                    if (GetNavigationServiceFromPage(_mainFrame.Content as PhoneApplicationPage))
                    {
                        return true;
                    }
                    else
                    {
                        _mainFrame.Navigated += MainFrameNavigated;
                    }
                }
            }

            return false;
        }

        private void MainFrameNavigated(object s, NavigationEventArgs e)
        {
            if (GetNavigationServiceFromPage(e.Content as PhoneApplicationPage))
            {
                _mainFrame.Navigated -= MainFrameNavigated;
            }
        }

        private bool GetNavigationServiceFromPage(PhoneApplicationPage page)
        {
            return page != null && (_navigationService = page.NavigationService) != null;
        }
    }
}