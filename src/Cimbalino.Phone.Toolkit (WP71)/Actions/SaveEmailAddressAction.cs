// ****************************************************************************
// <copyright file="SaveEmailAddressAction.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of launching the contacts application. Use this to allow users to save an email address from your application to a new or existing contact.
    /// </summary>
    public class SaveEmailAddressAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the email address that can be saved to a contact.
        /// </summary>
        /// <value>The email address that can be saved to a contact.</value>
        [Category("Common")]
        public string EmailAddress
        {
            get { return (string)GetValue(EmailAddressProperty); }
            set { SetValue(EmailAddressProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="EmailAddress" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty EmailAddressProperty =
            DependencyProperty.Register("EmailAddress", typeof(string), typeof(SaveEmailAddressAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new SaveEmailAddressTask()
            {
                Email = EmailAddress
            }.Show();
        }
    }
}