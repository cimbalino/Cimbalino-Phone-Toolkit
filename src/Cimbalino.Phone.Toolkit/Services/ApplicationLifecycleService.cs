// ****************************************************************************
// <copyright file="ApplicationLifecycleService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>01-03-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationLifecycleService"/>.
    /// </summary>
    public class ApplicationLifecycleService : IApplicationLifecycleService
    {
        private PhoneApplicationFrame _mainFrame;

        /// <summary>
        /// Occurs when the application is being made active after previously being put into a dormant state or tombstoned.
        /// </summary>
        public event EventHandler<ActivatedEventArgs> Activated;

        /// <summary>
        /// Occurs when the application is exiting.
        /// </summary>
        public event EventHandler<ClosingEventArgs> Closing;

        /// <summary>
        /// Occurs when the application is being deactivated.
        /// </summary>
        public event EventHandler<DeactivatedEventArgs> Deactivated;

        /// <summary>
        /// Occurs when the application is being launched.
        /// </summary>
        public event EventHandler<LaunchingEventArgs> Launching;

        /// <summary>
        /// Occurs when an exception that is raised by Silverlight is not handled.
        /// </summary>
        public event EventHandler<ApplicationUnhandledExceptionEventArgs> UnhandledException;

        /// <summary>
        /// This event is raised when the hardware Back button is pressed.
        /// </summary>
        public event EventHandler<CancelEventArgs> BackKeyPress;

        /// <summary>
        /// Occurs when the content that is being navigated to has been found and is available.
        /// </summary>
        public event NavigatedEventHandler Navigated;

        /// <summary>
        /// Occurs when a new navigation is requested.
        /// </summary>
        public event NavigatingCancelEventHandler Navigating;

        /// <summary>
        /// Occurs when an error is encountered while navigating to the requested content.
        /// </summary>
        public event NavigationFailedEventHandler NavigationFailed;

        /// <summary>
        /// Occurs when a navigation is terminated by either calling the StopLoading method, or when a new navigation is requested while the current navigation is in progress.
        /// </summary>
        public event NavigationStoppedEventHandler NavigationStopped;

        /// <summary>
        /// This event is raised when the shell chrome is covering the frame.
        /// </summary>
        public event EventHandler Obscured;

        /// <summary>
        /// This event is raised when the shell chrome is no longer covering the frame.
        /// </summary>
        public event EventHandler Unobscured;

        /// <summary>
        /// Gets or sets a value indicating whether the application can run under the lock screen.
        /// </summary>
        /// <value>
        /// true if the application can run under the lock screen; otherwise, false.
        /// </value>
        public bool AllowRunningUnderLockScreen
        {
            get
            {
                return PhoneApplicationService.Current.ApplicationIdleDetectionMode == IdleDetectionMode.Disabled;
            }
            set
            {
                PhoneApplicationService.Current.ApplicationIdleDetectionMode = value ? IdleDetectionMode.Disabled : IdleDetectionMode.Enabled;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLifecycleService" /> class.
        /// </summary>
        public ApplicationLifecycleService()
        {
            var phoneApplicationService = PhoneApplicationService.Current;

            phoneApplicationService.Activated += (s, e) =>
            {
                var eventHandler = Activated;

                if (eventHandler != null)
                {
                    eventHandler(s, e);
                }
            };

            phoneApplicationService.Closing += (s, e) =>
            {
                var eventHandler = Closing;

                if (eventHandler != null)
                {
                    eventHandler(s, e);
                }
            };

            phoneApplicationService.Deactivated += (s, e) =>
            {
                var eventHandler = Deactivated;

                if (eventHandler != null)
                {
                    eventHandler(s, e);
                }
            };

            phoneApplicationService.Launching += (s, e) =>
            {
                var eventHandler = Launching;

                if (eventHandler != null)
                {
                    eventHandler(s, e);
                }
            };

            var application = Application.Current;

            application.UnhandledException += (s, e) =>
            {
                var eventHandler = UnhandledException;

                if (eventHandler != null)
                {
                    eventHandler(s, e);
                }
            };

            application.Host.Content.Resized += (s, e) =>
            {
                EnsureMainFrame();
            };
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
                _mainFrame.BackKeyPress += (s, e) =>
                {
                    var eventHandler = BackKeyPress;

                    if (eventHandler != null)
                    {
                        eventHandler(s, e);
                    }
                };

                _mainFrame.Navigated += (s, e) =>
                {
                    var eventHandler = Navigated;

                    if (eventHandler != null)
                    {
                        eventHandler(s, e);
                    }
                };

                _mainFrame.Navigating += (s, e) =>
                {
                    var eventHandler = Navigating;

                    if (eventHandler != null)
                    {
                        eventHandler(s, e);
                    }
                };

                _mainFrame.NavigationFailed += (s, e) =>
                {
                    var eventHandler = NavigationFailed;

                    if (eventHandler != null)
                    {
                        eventHandler(s, e);
                    }
                };

                _mainFrame.NavigationStopped += (s, e) =>
                {
                    var eventHandler = NavigationStopped;

                    if (eventHandler != null)
                    {
                        eventHandler(s, e);
                    }
                };

                _mainFrame.Obscured += (s, e) =>
                {
                    var eventHandler = Obscured;

                    if (eventHandler != null)
                    {
                        eventHandler(s, e);
                    }
                };

                _mainFrame.Unobscured += (s, e) =>
                {
                    var eventHandler = Unobscured;

                    if (eventHandler != null)
                    {
                        eventHandler(s, e);
                    }
                };

                return true;
            }

            return false;
        }
    }
}