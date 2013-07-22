// ****************************************************************************
// <copyright file="SavePhoneNumberAction.cs" company="Pedro Lamas">
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
    /// Represents an attachable object capable of launching the contacts application. Use this to allow users to save a phone number from your application to a new or existing contact.
    /// </summary>
    public class SavePhoneNumberAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the phone number that can be saved to a contact.
        /// </summary>
        /// <value>The phone number that can be saved to a contact.</value>
        [Category("Common")]
        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="PhoneNumber" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumber", typeof(string), typeof(SavePhoneNumberAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new SavePhoneNumberTask()
            {
                PhoneNumber = PhoneNumber
            }.Show();
        }
    }
}