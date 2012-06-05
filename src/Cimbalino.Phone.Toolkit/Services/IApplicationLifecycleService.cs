// ****************************************************************************
// <copyright file="IApplicationLifecycleService.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of managing the application lifecycle.
    /// </summary>
    public interface IApplicationLifecycleService
    {
        /// <summary>
        /// Occurs when the application is being made active after previously being put into a dormant state or tombstoned.
        /// </summary>
        event EventHandler<ActivatedEventArgs> Activated;

        /// <summary>
        /// Occurs when the application is exiting.
        /// </summary>
        event EventHandler<ClosingEventArgs> Closing;

        /// <summary>
        /// Occurs when the application is being deactivated.
        /// </summary>
        event EventHandler<DeactivatedEventArgs> Deactivated;

        /// <summary>
        /// Occurs when the application is being launched.
        /// </summary>
        event EventHandler<LaunchingEventArgs> Launching;

        /// <summary>
        /// Occurs when an exception that is raised by Silverlight is not handled.
        /// </summary>
        event EventHandler<ApplicationUnhandledExceptionEventArgs> UnhandledException;

        /// <summary>
        /// This event is raised when the hardware Back button is pressed.
        /// </summary>
        event EventHandler<CancelEventArgs> BackKeyPress;

        /// <summary>
        /// Occurs when the content that is being navigated to has been found and is available.
        /// </summary>
        event NavigatedEventHandler Navigated;

        /// <summary>
        /// Occurs when a new navigation is requested.
        /// </summary>
        event NavigatingCancelEventHandler Navigating;

        /// <summary>
        /// Occurs when an error is encountered while navigating to the requested content.
        /// </summary>
        event NavigationFailedEventHandler NavigationFailed;

        /// <summary>
        /// Occurs when a navigation is terminated by either calling the StopLoading method, or when a new navigation is requested while the current navigation is in progress.
        /// </summary>
        event NavigationStoppedEventHandler NavigationStopped;

        /// <summary>
        /// This event is raised when the shell chrome is covering the frame.
        /// </summary>
        event EventHandler Obscured;

        /// <summary>
        /// This event is raised when the shell chrome is no longer covering the frame.
        /// </summary>
        event EventHandler Unobscured;

        /// <summary>
        /// Gets the mode in which the application was started.
        /// </summary>
        /// <value>The mode in which the application was started.</value>
        StartupMode StartupMode { get; }

        /// <summary>
        /// Gets the dictionary used for passing an application's state between invocations.
        /// </summary>
        /// <value>The dictionary used for passing an application's state between invocations.</value>
        IDictionary<string, object> State { get; }

        /// <summary>
        /// Gets or sets a value indicating the application idle detection is enabled.
        /// </summary>
        /// <value>The application idle detection mode.</value>
        IdleDetectionMode ApplicationIdleDetectionMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the user idle detection mode.
        /// </summary>
        /// <value>The user idle detection mode.</value>
        IdleDetectionMode UserIdleDetectionMode { get; set; }
    }
}