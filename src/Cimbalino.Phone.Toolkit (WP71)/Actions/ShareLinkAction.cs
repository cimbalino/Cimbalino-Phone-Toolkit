// ****************************************************************************
// <copyright file="ShareLinkAction.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>06-06-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of sharing links over the social networks configured on the device.
    /// </summary>
    public class ShareLinkAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the title of the shared link.
        /// </summary>
        /// <value>The title of the shared link.</value>
        [Category("Common")]
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Title" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ShareLinkAction), null);

        /// <summary>
        /// Gets or sets the message that will accompany the shared link.
        /// </summary>
        /// <value>The message that will accompany the shared link.</value>
        [Category("Common")]
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Message" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ShareLinkAction), null);

        /// <summary>
        /// Gets or sets the URI of the link to be shared.
        /// </summary>
        /// <value>The URI of the link to be shared.</value>
        [Category("Common")]
        public Uri LinkUri
        {
            get { return (Uri)GetValue(LinkUriProperty); }
            set { SetValue(LinkUriProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="LinkUri" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty LinkUriProperty =
            DependencyProperty.Register("LinkUri", typeof(Uri), typeof(ShareLinkAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new ShareLinkTask()
            {
                Title = Title,
                Message = Message,
                LinkUri = LinkUri
            }.Show();
        }
    }
}