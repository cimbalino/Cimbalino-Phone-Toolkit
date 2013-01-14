// ****************************************************************************
// <copyright file="MarketplaceDetailAction.cs" company="Pedro Lamas">
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
    /// Represents an attachable object capable of showing marketplace information about an application.
    /// </summary>
    public class MarketplaceDetailAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the application content identifier.
        /// </summary>
        /// <value>The application content identifier.</value>
        [Category("Common")]
        public string ContentIdentifier
        {
            get { return (string)GetValue(ContentIdentifierProperty); }
            set { SetValue(ContentIdentifierProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ContentIdentifier" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentIdentifierProperty =
            DependencyProperty.Register("ContentIdentifier", typeof(string), typeof(MarketplaceDetailAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new MarketplaceDetailTask()
            {
                ContentIdentifier = ContentIdentifier
            }.Show();
        }
    }
}