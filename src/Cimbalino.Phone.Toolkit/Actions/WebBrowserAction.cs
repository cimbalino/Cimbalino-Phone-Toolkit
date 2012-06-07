// ****************************************************************************
// <copyright file="WebBrowserAction.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>05-06-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of using the webbrowser.
    /// </summary>
    public class WebBrowserAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the <see cref="Uri" /> to which the web browser application will navigate when it is launched.
        /// </summary>
        /// <value>The <see cref="Uri" /> to which the web browser application will navigate when it is launched.</value>
        public Uri Uri
        {
            get { return (Uri)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Uri" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty UriProperty =
            DependencyProperty.Register("Uri", typeof(Uri), typeof(WebBrowserAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new WebBrowserTask()
            {
                Uri = Uri
            }.Show();
        }
    }
}