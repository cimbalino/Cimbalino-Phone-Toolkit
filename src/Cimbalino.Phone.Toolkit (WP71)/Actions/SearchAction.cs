// ****************************************************************************
// <copyright file="SearchAction.cs" company="Pedro Lamas">
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
    /// Represents an attachable object capable of launching the Web Search application.
    /// </summary>
    public class SearchAction : TriggerAction<FrameworkElement>
    {
        /// <summary>
        /// Gets or sets the search query that the Web Search application will use when it is launched.
        /// </summary>
        /// <value>The search query that the Web Search application will use when it is launched.</value>
        [Category("Common")]
        public string SearchQuery
        {
            get { return (string)GetValue(SearchQueryProperty); }
            set { SetValue(SearchQueryProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="SearchQuery" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchQueryProperty =
            DependencyProperty.Register("SearchQuery", typeof(string), typeof(SearchAction), null);

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            new SearchTask()
            {
                SearchQuery = SearchQuery
            }.Show();
        }
    }
}