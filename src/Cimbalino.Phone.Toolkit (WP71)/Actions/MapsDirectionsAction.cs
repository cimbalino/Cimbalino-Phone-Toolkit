// ****************************************************************************
// <copyright file="MapsDirectionsAction.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-12-2012</date>
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
    /// Represents an attachable object capable of launching the Maps application, specifying a starting location or an ending location, or both, for which driving directions are displayed.
    /// </summary>
    public class MapsDirectionsAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the starting location for which driving directions are displayed.
        /// </summary>
        /// <value>The starting location for which driving directions are displayed.</value>
        [Category("Common")]
        public LabeledMapLocation StartingLocation
        {
            get { return (LabeledMapLocation)GetValue(StartingLocationProperty); }
            set { SetValue(StartingLocationProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="StartingLocation" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StartingLocationProperty =
            DependencyProperty.Register("StartingLocation", typeof(LabeledMapLocation), typeof(MapsDirectionsAction), null);

        /// <summary>
        /// Gets or sets the ending location for which driving directions are displayed.
        /// </summary>
        /// <value>The ending location for which driving directions are displayed.</value>
        [Category("Common")]
        public LabeledMapLocation EndingLocation
        {
            get { return (LabeledMapLocation)GetValue(EndingLocationProperty); }
            set { SetValue(EndingLocationProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="EndingLocation" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty EndingLocationProperty =
            DependencyProperty.Register("EndingLocation", typeof(LabeledMapLocation), typeof(MapsDirectionsAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
#if WP8
            new MapsDirectionsTask()
#else
            new BingMapsDirectionsTask()
#endif
            {
                Start = StartingLocation,
                End = EndingLocation
            }.Show();
        }
    }
}