// ****************************************************************************
// <copyright file="AutoFocusBehavior.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>09-08-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Cimbalino.Phone.Toolkit.Extensions;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// The behavior that enables automatic control focus.
    /// </summary>
    public class AutoFocusBehavior : SafeBehavior<FrameworkElement>
    {
        /// <summary>
        /// Occurs when the focus automatically moves from one control to the next.
        /// </summary>
        public event EventHandler<AfterAutoFocusEventArgs> AfterAutoFocus;

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            AssociatedObject.KeyUp += AssociatedObjectKeyUp;

            base.OnAttached();
        }

        /// <summary>
        /// Releases all resources used by this instance.
        /// </summary>
        protected override void CleanUp()
        {
            AssociatedObject.KeyUp -= AssociatedObjectKeyUp;

            base.CleanUp();
        }

        /// <summary>
        /// Gets or sets the command to invoke when the focus automatically moves from one control to the next. This is a DependencyProperty.
        /// </summary>
        /// <value>The command to invoke when the focus automatically moves from one control to the next.</value>
        public ICommand AfterAutoFocusCommand
        {
            get { return (ICommand)GetValue(AfterAutoFocusCommandProperty); }
            set { SetValue(AfterAutoFocusCommandProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="AfterAutoFocusCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AfterAutoFocusCommandProperty =
            DependencyProperty.Register("AfterAutoFocusCommand", typeof(ICommand), typeof(AutoFocusBehavior), null);

        private void AssociatedObjectKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var originalSource = e.OriginalSource as Control;
                var originalSourceAsTextBox = originalSource as TextBox;

                if (originalSource != null && (originalSourceAsTextBox == null || !originalSourceAsTextBox.AcceptsReturn))
                {
                    FocusNextControl(originalSource);
                }
            }
        }

        private void FocusNextControl(Control fromControl)
        {
            var toControl = GetControlChilds(AssociatedObject)
                .OrderBy(x => x.TabIndex)
                .SkipWhile(x => x != fromControl)
                .Skip(1)
                .FirstOrDefault();

            if (toControl == null)
            {
                var page = fromControl.GetVisualAncestor<Page>();

                if (page != null)
                {
                    page.Focus();
                }
            }
            else
            {
                toControl.Focus();
            }

            var eventArgs = new AfterAutoFocusEventArgs(fromControl, toControl);

            var eventHandler = AfterAutoFocus;

            if (eventHandler != null)
            {
                eventHandler(this, eventArgs);
            }

            var command = AfterAutoFocusCommand;

            if (command != null)
            {
                command.Execute(eventArgs);
            }
        }

        private IEnumerable<Control> GetControlChilds(FrameworkElement control)
        {
            return GetVisibleVisualChilds(control)
                .Descendants(x => x is TextBox || x is PasswordBox ? new FrameworkElement[] { } : GetVisibleVisualChilds(x))
                .OfType<Control>()
                .Where(x => x.IsEnabled && x.IsTabStop && (x is TextBox || x is PasswordBox));
        }

        private IEnumerable<FrameworkElement> GetVisibleVisualChilds(FrameworkElement frameworkElement)
        {
            return frameworkElement.GetVisualChilds<FrameworkElement>()
                .Where(x => x.Visibility == Visibility.Visible);
        }
    }
}