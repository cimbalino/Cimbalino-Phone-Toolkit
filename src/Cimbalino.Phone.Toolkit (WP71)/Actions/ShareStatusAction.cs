// ****************************************************************************
// <copyright file="ShareStatusAction.cs" company="Pedro Lamas">
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

using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of launching a dialog that enables the user to share a status message on the social networks of their choice.
    /// </summary>
    public class ShareStatusAction : TriggerAction<FrameworkTemplate>
    {
        /// <summary>
        /// Gets or sets the status message to be shared.
        /// </summary>
        /// <value>The status message to be shared.</value>
        [Category("Common")]
        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Status" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(string), typeof(ShareStatusAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new ShareStatusTask()
            {
                Status = Status
            }.Show();
        }
    }
}