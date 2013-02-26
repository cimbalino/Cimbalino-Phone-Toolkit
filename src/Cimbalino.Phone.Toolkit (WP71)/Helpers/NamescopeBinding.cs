// ****************************************************************************
// <copyright file="NamescopeBinding.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Windows;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Allows binding of objects in a different XAML namescope.
    /// </summary>
    public class NamescopeBinding : DependencyObject
    {
        /// <summary>
        /// Gets or sets the source <see cref="FrameworkElement"/> to bind.
        /// </summary>
        /// <value>The source <see cref="FrameworkElement"/> to bind.</value>
        public FrameworkElement Source
        {
            get { return (FrameworkElement)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Source" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(FrameworkElement), typeof(NamescopeBinding), null);
    }
}