// ****************************************************************************
// <copyright file="ConnectionSettingsAction.cs" company="Pedro Lamas">
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
    /// Represents an attachable object capable of launching a Settings dialog that allows the user to change the device's network connection settings.
    /// </summary>
    public class ConnectionSettingsAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the type of network connection settings that will be displayed.
        /// </summary>
        /// <value>The type of network connection settings that will be displayed.</value>
        [Category("Common")]
        public ConnectionSettingsType ConnectionSettingsType
        {
            get { return (ConnectionSettingsType)GetValue(ConnectionSettingsTypeProperty); }
            set { SetValue(ConnectionSettingsTypeProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ConnectionSettingsType" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ConnectionSettingsTypeProperty =
            DependencyProperty.Register("ConnectionSettingsType", typeof(ConnectionSettingsType), typeof(ConnectionSettingsAction), new PropertyMetadata(ConnectionSettingsType.WiFi));

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new ConnectionSettingsTask()
            {
                ConnectionSettingsType = ConnectionSettingsType
            }.Show();
        }
    }
}