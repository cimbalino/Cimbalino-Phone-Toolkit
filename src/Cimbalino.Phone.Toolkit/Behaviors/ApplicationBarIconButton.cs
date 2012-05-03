// ****************************************************************************
// <copyright file="ApplicationBarIconButton.cs" company="Pedro Lamas">
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
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// An Application Bar button with an icon.
    /// </summary>
    public class ApplicationBarIconButton : ApplicationBarItemBase<IApplicationBarIconButton>, IApplicationBarIconButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarIconButton" /> class.
        /// </summary>
        public ApplicationBarIconButton()
            : base(new Microsoft.Phone.Shell.ApplicationBarIconButton() { IconUri = new Uri(string.Empty, UriKind.Relative) })
        {
        }

        /// <summary>
        /// Occurs when a <see cref="ApplicationBarIconButton"/> is clicked.
        /// </summary>
        public override event EventHandler Click
        {
            add
            {
                base.Click += value;
            }
            remove
            {
                base.Click -= value;
            }
        }

        /// <summary>
        /// Gets or sets the URI of the icon to use for the button.
        /// </summary>
        /// <returns>The URI of the icon to use for the button.</returns>
        public Uri IconUri
        {
            get
            {
                return (Uri)GetValue(IconUriProperty);
            }
            set
            {
                SetValue(IconUriProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="ApplicationBarIconButton.IconUri" /> dependency property
        /// </summary>
        public static readonly DependencyProperty IconUriProperty =
            DependencyProperty.Register("IconUri", typeof(Uri), typeof(ApplicationBarIconButton), new PropertyMetadata(new Uri(string.Empty, UriKind.Relative), OnIconUriChanged));

        /// <summary>
        /// Called after the URI of the icon to use for the button is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        protected static void OnIconUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is Uri)
            {
                var element = (ApplicationBarIconButton)d;

                element.Item.IconUri = (Uri)e.NewValue;
            }
        }
    }
}