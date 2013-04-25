// ****************************************************************************
// <copyright file="MultiBindingBehavior.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>25-04-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// The behavior that enables multiple binding.
    /// </summary>
    [System.Windows.Markup.ContentProperty("Items")]
    public class MultiBindingBehavior : SafeBehavior<FrameworkElement>
    {
        /// <summary>
        /// Gets the <see cref="MultiBindingItem"/> collection.
        /// </summary>
        /// <value>The <see cref="MultiBindingItem"/> collection.</value>
        public MultiBindingItemCollection Items
        {
            get { return (MultiBindingItemCollection)GetValue(ItemsProperty); }
            private set { SetValue(ItemsProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Items" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(MultiBindingItemCollection), typeof(MultiBindingBehavior), null);

        /// <summary>
        /// Gets or sets the path to the binding source property.
        /// </summary>
        /// <value>The path to the binding source property.</value>
        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="PropertyName" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(string), typeof(MultiBindingBehavior), new PropertyMetadata(null, OnPropertyNameChanged));

        private static void OnPropertyNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var multiBindingBehavior = (MultiBindingBehavior)d;

            multiBindingBehavior.UpdateAttach();
        }

        /// <summary>
        /// Gets or sets the converter to use.
        /// </summary>
        /// <value>The converter to use.</value>
        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(ConverterProperty); }
            set { SetValue(ConverterProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Converter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ConverterProperty =
            DependencyProperty.Register("Converter", typeof(IValueConverter), typeof(MultiBindingBehavior), new PropertyMetadata(null, OnConverterChanged));

        private static void OnConverterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var multiBindingBehavior = (MultiBindingBehavior)d;

            multiBindingBehavior.UpdateAttach();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiBindingBehavior"/> class.
        /// </summary>
        public MultiBindingBehavior()
        {
            Items = new MultiBindingItemCollection();
        }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();

            UpdateAttach();
        }

        private void UpdateAttach()
        {
            if (AssociatedObject == null)
            {
                return;
            }

            var targetProperty = PropertyName;
            Type targetType;

            if (targetProperty.Contains("."))
            {
                var propertyNameParts = targetProperty.Split('.');

                targetType = Type.GetType(string.Format("System.Windows.Controls.{0}, System.Windows",
                    propertyNameParts[0]));

                targetProperty = propertyNameParts[1];
            }
            else
            {
                targetType = AssociatedObject.GetType();
            }

            var targetDependencyPropertyField = targetType.GetField(targetProperty + "Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            var targetDependencyProperty = (DependencyProperty)targetDependencyPropertyField.GetValue(null);

            var binding = new Binding("Value")
            {
                Source = Items,
                Converter = Converter,
                Mode = BindingMode.TwoWay
            };

            BindingOperations.SetBinding(AssociatedObject, targetDependencyProperty, binding);
        }
    }
}