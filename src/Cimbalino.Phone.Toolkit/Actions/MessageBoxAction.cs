// ****************************************************************************
// <copyright file="MessageBoxAction.cs" company="Pedro Lamas">
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

using System.Windows;
using System.Windows.Interactivity;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of showing message boxes.
    /// </summary>
    public class MessageBoxAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the message to display.
        /// </summary>
        /// <value>The message to display.</value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Text" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MessageBoxAction), null);

        /// <summary>
        /// Gets or sets the title of the message box.
        /// </summary>
        /// <value>The title of the message box.</value>
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Caption" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(MessageBoxAction), null);

        /// <summary>
        /// Gets or sets the value that indicates the button or buttons to display.
        /// </summary>
        /// <value>The value that indicates the button or buttons to display.</value>
        public MessageBoxButton Button
        {
            get { return (MessageBoxButton)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Button" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register("Button", typeof(MessageBoxButton), typeof(MessageBoxAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
        }
    }
}