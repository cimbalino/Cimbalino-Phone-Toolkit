// ****************************************************************************
// <copyright file="PhoneCallAction.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>06-06-2012</date>
// <project>Cimbalino.Phone.Toolkit.PhoneDialer</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of launching the Phone application.
    /// </summary>
    public class PhoneCallAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="PhoneNumber" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumber", typeof(string), typeof(PhoneCallAction), null);

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName
        {
            get { return (string)GetValue(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="DisplayName" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register("DisplayName", typeof(string), typeof(PhoneCallAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new PhoneCallTask()
            {
                PhoneNumber = PhoneNumber,
                DisplayName = DisplayName
            }.Show();
        }
    }
}