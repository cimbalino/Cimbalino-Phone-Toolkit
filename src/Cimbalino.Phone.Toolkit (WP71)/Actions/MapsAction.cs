// ****************************************************************************
// <copyright file="MapsAction.cs" company="Pedro Lamas">
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

using System.ComponentModel;
using System.Device.Location;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Actions
{
    /// <summary>
    /// Represents an attachable object capable of launching the Maps application, specifying optional center location, search term, and initial zoom values.
    /// </summary>
    public class MapsAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the location that will be used as the center point for the map.
        /// </summary>
        /// <value>The location that will be used as the center point for the map.</value>
        [Category("Common")]
        public GeoCoordinate Center
        {
            get { return (GeoCoordinate)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Center" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.Register("Center", typeof(GeoCoordinate), typeof(MapsAction), null);

        /// <summary>
        /// Gets or sets the search term that is used to find and tag locations on the map.
        /// </summary>
        /// <value>The search term that is used to find and tag locations on the map.</value>
        [Category("Common")]
        public string SearchTerm
        {
            get { return (string)GetValue(SearchTermProperty); }
            set { SetValue(SearchTermProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="SearchTerm" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchTermProperty =
            DependencyProperty.Register("SearchTerm", typeof(string), typeof(MapsAction), null);

        /// <summary>
        /// Gets or sets the initial zoom level of the map.
        /// </summary>
        /// <value>The initial zoom level of the map.</value>
        [Category("Common")]
        public double ZoomLevel
        {
            get { return (double)GetValue(ZoomLevelProperty); }
            set { SetValue(ZoomLevelProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ZoomLevel" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ZoomLevelProperty =
            DependencyProperty.Register("ZoomLevel", typeof(double), typeof(MapsAction), new PropertyMetadata(1));

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
#if WP8
            new MapsTask()
#else
            new BingMapsTask()
#endif
            {
                Center = Center,
                SearchTerm = SearchTerm,
                ZoomLevel = ZoomLevel
            }.Show();
        }
    }
}