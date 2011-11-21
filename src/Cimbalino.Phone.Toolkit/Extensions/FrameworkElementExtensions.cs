// ****************************************************************************
// <copyright file="FrameworkElementExtensions.cs" company="Pedro Lamas">
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

using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="System.Windows.FrameworkElement"/> instances
    /// </summary>
    public static class FrameworkElementExtensions
    {
        /// <summary>
        /// Resets the <see cref="System.Windows.FrameworkElement"/> language information with a <see cref="System.Windows.Markup.XmlLanguage"/> matching the <see cref="System.Threading.Thread.CurrentThread.CurrentCulture"/>.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        public static void ResetLanguageWithCurrentCulture(this FrameworkElement frameworkElement)
        {
            frameworkElement.Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);
        }
    }
}