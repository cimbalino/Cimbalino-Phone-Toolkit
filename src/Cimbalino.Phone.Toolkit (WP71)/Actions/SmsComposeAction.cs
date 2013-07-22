// ****************************************************************************
// <copyright file="SmsComposeAction.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of launching the Messaging application with a new SMS message displayed.
    /// </summary>
    public class SmsComposeAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the recipient list for the new SMS message.
        /// </summary>
        /// <value>The recipient list for the new SMS message.</value>
        [Category("Common")]
        public string Recipient
        {
            get { return (string)GetValue(RecipientProperty); }
            set { SetValue(RecipientProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Recipient" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty RecipientProperty =
            DependencyProperty.Register("Recipient", typeof(string), typeof(SmsComposeAction), null);

        /// <summary>
        /// Gets or sets the body text of the new SMS message.
        /// </summary>
        /// <value>The body text of the new SMS message.</value>
        [Category("Common")]
        public string Body
        {
            get { return (string)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Body" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BodyProperty =
            DependencyProperty.Register("Body", typeof(string), typeof(SmsComposeAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new SmsComposeTask()
            {
                To = Recipient,
                Body = Body
            }.Show();
        }
    }
}