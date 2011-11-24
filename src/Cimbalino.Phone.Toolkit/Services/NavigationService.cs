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

        /// <summary>
        /// Occurs when a new navigation is requested.
        /// </summary>
        public event NavigatingCancelEventHandler Navigating;

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
                if (EnsureMainFrame())
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
        /// <param name="source">A Uri object initialized with the URI for the desired content.</param>
        public void NavigateTo(Uri source)
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(source);
            }
        }

        /// <summary>
        /// Navigates to the most recent available entry in the back navigation history.
        /// </summary>
        public void GoBack()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        public void RemoveBackEntry()
        {
            if (EnsureMainFrame())
            {
                _mainFrame.RemoveBackEntry();
            }
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            _mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

            if (_mainFrame != null)
            {
                // Could be null if the app runs inside a design tool
                _mainFrame.Navigating += (s, e) =>
                {
                    if (Navigating != null)
                    {
                        Navigating(s, e);
                    }
                };

                return true;
            }

            return false;
        }
    }
}