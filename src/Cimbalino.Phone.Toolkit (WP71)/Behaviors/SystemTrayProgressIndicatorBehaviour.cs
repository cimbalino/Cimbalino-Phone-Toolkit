using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// Behaviour that lets you set a custom colour for the system tray's progress indicator
    /// </summary>
    public class SystemTrayProgressIndicatorBehaviour : SafeBehavior<PhoneApplicationPage>
    {
        /// <summary>
        /// The page
        /// </summary>
        private PhoneApplicationPage _page;

        /// <summary>
        /// The indicator
        /// </summary>
        private ProgressIndicator _indicator;

        /// <summary>
        /// The progress bar
        /// </summary>
        private ProgressBar _progressBar;

        /// <summary>
        /// The root panel
        /// </summary>
        private Panel _rootPanel;

        /// <summary>
        /// The is visible property
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible", typeof (bool), typeof (SystemTrayProgressIndicatorBehaviour), new PropertyMetadata(true, OnIsVisibleChanged));

        /// <summary>
        /// The dot color property
        /// </summary>
       public static readonly DependencyProperty DotColorProperty =
            DependencyProperty.Register("DotColor", typeof (Color), typeof (SystemTrayProgressIndicatorBehaviour), new PropertyMetadata(Application.Current.Resources["PhoneAccentColor"], OnDotColourChanged));

       /// <summary>
       /// The dot matches foreground property
       /// </summary>
        public static readonly DependencyProperty DotMatchesForegroundProperty =
            DependencyProperty.Register("DotMatchesForeground", typeof (bool), typeof (SystemTrayProgressIndicatorBehaviour), new PropertyMetadata(default(bool), OnDotMatchesForegroundChanged));

        /// <summary>
        /// The value property
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof (double), typeof (SystemTrayProgressIndicatorBehaviour), new PropertyMetadata(default(double), OnValueChanged));

        /// <summary>
        /// The is indeterminate property
        /// </summary>
        public static readonly DependencyProperty IsIndeterminateProperty =
            DependencyProperty.Register("IsIndeterminate", typeof (bool), typeof (SystemTrayProgressIndicatorBehaviour), new PropertyMetadata(default(bool), OnIsIndeterminateChanged));

        /// <summary>
        /// The text property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof (string), typeof (SystemTrayProgressIndicatorBehaviour), new PropertyMetadata(default(string), OnTextChanged));

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is indeterminate.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is indeterminate; otherwise, <c>false</c>.
        /// </value>
        public bool IsIndeterminate
        {
            get { return (bool) GetValue(IsIndeterminateProperty); }
            set { SetValue(IsIndeterminateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value
        {
            get { return (double) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible
        {
            get { return (bool) GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the dot.
        /// </summary>
        /// <value>
        /// The color of the dot.
        /// </value>
        public Color DotColor
        {
            get { return (Color) GetValue(DotColorProperty); }
            set { SetValue(DotColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [dot matches foreground].
        /// </summary>
        /// <value>
        /// <c>true</c> if [dot matches foreground]; otherwise, <c>false</c>.
        /// </value>
        public bool DotMatchesForeground
        {
            get { return (bool) GetValue(DotMatchesForegroundProperty); }
            set { SetValue(DotMatchesForegroundProperty, value); }
        }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            AssociatedObject.LayoutUpdated += AssociatedObjectOnLayoutUpdated;
            
            base.OnAttached();
        }

        /// <summary>
        /// Called when [is visible changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnIsVisibleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var b = sender as SystemTrayProgressIndicatorBehaviour;
            if (b == null)
            {
                return;
            }

            var isVisible = (bool) e.NewValue;
            if (b._indicator == null || b._progressBar == null)
            {
                return;
            }

            b._indicator.IsVisible = isVisible;
            b._progressBar.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var b = sender as SystemTrayProgressIndicatorBehaviour;
            if (b == null)
            {
                return;
            }

            var text = (string) e.NewValue;
            if (b._indicator == null || b._progressBar == null)
            {
                return;
            }

            b._indicator.Text = text;
        }

        /// <summary>
        /// Called when [is indeterminate changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnIsIndeterminateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var b = sender as SystemTrayProgressIndicatorBehaviour;
            if (b == null)
            {
                return;
            }

            var isIndeterminate = (bool) e.NewValue;
            if (b._indicator == null || b._progressBar == null)
            {
                return;
            }

            b._progressBar.IsIndeterminate = isIndeterminate;
        }

        /// <summary>
        /// Called when [dot colour changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnDotColourChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var b = sender as SystemTrayProgressIndicatorBehaviour;
            if (b == null)
            {
                return;
            }

            var dotColour = (Color) e.NewValue;
            if (b._indicator == null || b._progressBar == null)
            {
                return;
            }

            b._progressBar.Foreground = new SolidColorBrush(dotColour);
        }

        /// <summary>
        /// Called when [dot matches foreground changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnDotMatchesForegroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var b = sender as SystemTrayProgressIndicatorBehaviour;
            if (b == null)
            {
                return;
            }

            var dotMatchesForeground = (bool) e.NewValue;
            if (b._indicator == null || b._progressBar == null)
            {
                return;
            }

            b._progressBar.Foreground = dotMatchesForeground ? new SolidColorBrush(SystemTray.GetForegroundColor(b._page)) : new SolidColorBrush(b.DotColor);
        }

        /// <summary>
        /// Called when [value changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var b = sender as SystemTrayProgressIndicatorBehaviour;
            if (b == null)
            {
                return;
            }

            var value = (double) e.NewValue;
            if (b._indicator == null || b._progressBar == null)
            {
                return;
            }
            b._progressBar.Value = value;
        }

        /// <summary>
        /// Associateds the object on layout updated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">
        /// This CustomColourSystemTrayBehaviour can only be attached to the main page
        /// or
        /// This CustomColourSystemTrayBehaviour requires a root element in the page called 'LayoutRoot'
        /// </exception>
        private void AssociatedObjectOnLayoutUpdated(object sender, EventArgs eventArgs)
        {
            AssociatedObject.LayoutUpdated -= AssociatedObjectOnLayoutUpdated;

            _page = AssociatedObject;
            _indicator = new ProgressIndicator();
            _progressBar = new ProgressBar {VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(-12, 0, -12, 0)};
            _rootPanel = FindChild<Panel>(_page, "LayoutRoot");

            if (_page == null)
            {
                throw new Exception("This CustomColourSystemTrayBehaviour can only be attached to the main page");
            }

            if (_rootPanel == null)
            {
                throw new Exception("This CustomColourSystemTrayBehaviour requires a root element in the page called 'LayoutRoot'");
            }

            SetSystemTray();
        }

        /// <summary>
        /// Sets the system tray.
        /// </summary>
        private void SetSystemTray()
        {
            if (DesignerProperties.IsInDesignTool || AssociatedObject == null)
            {
                return;
            }

            _indicator.IsVisible = IsVisible;

            var currentOpacity = SystemTray.GetOpacity(_page);
            var border = new Border
            {
                Background = new SolidColorBrush(SystemTray.GetBackgroundColor(_page)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Opacity = SystemTray.GetOpacity(_page),
                Height = 32
            };

            var grid = new Grid
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Height = 32
            };
            
            if (currentOpacity == 1)
            {
                SystemTray.SetOpacity(_page, 0);
                grid.Margin = new Thickness(0, -32, 0, 0);

                if (_rootPanel != null)
                {
                    _rootPanel.Margin = new Thickness(_rootPanel.Margin.Left, _rootPanel.Margin.Top + 32, _rootPanel.Margin.Right, _rootPanel.Margin.Bottom);                    
                }
            }

            _indicator.Text = Text;
            _progressBar.IsIndeterminate = IsIndeterminate;
            _progressBar.Value = Value;
            _progressBar.Visibility = IsVisible ? Visibility.Visible : Visibility.Collapsed;
            _progressBar.Foreground = DotMatchesForeground ? new SolidColorBrush(SystemTray.GetForegroundColor(_page)) : new SolidColorBrush(DotColor);
            
            grid.Children.Add(border);
            grid.Children.Add(_progressBar);

            if (_rootPanel != null)
            {
                Grid.SetRowSpan(grid, 1000);
                Grid.SetColumnSpan(grid, 1000);
                _rootPanel.Children.Add(grid);
            }

            SystemTray.SetProgressIndicator(_page, _indicator);
        }

        /// <summary>
        /// Finds the child.
        /// </summary>
        /// <typeparam name="T">The return type</typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="childName">Name of the child.</param>
        /// <returns>The child element if found</returns>
        public static T FindChild<T>(DependencyObject parent, string childName)
            where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null)
            {
                return null;
            }

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                var childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null)
                    {
                        break;
                    }
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T) child;
                        break;
                    }

                    // Need this in case the element we want is nested
                    // in another element of the same type
                    foundChild = FindChild<T>(child, childName);
                }
                else
                {
                    // child element found.
                    foundChild = (T) child;
                    break;
                }
            }

            return foundChild;
        }

    }
}