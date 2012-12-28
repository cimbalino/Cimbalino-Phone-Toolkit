// ****************************************************************************
// <copyright file="SafeBehavior.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>29-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Windows;
using System.Windows.Interactivity;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// A BaseBehavior that ensures all resources are released when the <see cref="Behavior.AssociatedObject"/> is unloaded or detached.
    /// </summary>
    /// <typeparam name="T">The <see cref="Behavior.AssociatedObject"/> type.</typeparam>
    public abstract class SafeBehavior<T> : Behavior<T>
        where T : FrameworkElement
    {
        private bool _isCleanedUp;

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Unloaded += AssociatedObjectUnloaded;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            InternalCleanUp();

            base.OnDetaching();
        }

        /// <summary>
        /// Releases all resources used by this instance.
        /// </summary>
        protected virtual void CleanUp()
        {
        }

        private void InternalCleanUp()
        {
            if (!_isCleanedUp)
            {
                _isCleanedUp = true;

                AssociatedObject.Unloaded -= AssociatedObjectUnloaded;

                CleanUp();
            }
        }

        private void AssociatedObjectUnloaded(object sender, RoutedEventArgs e)
        {
            InternalCleanUp();
        }
    }
}