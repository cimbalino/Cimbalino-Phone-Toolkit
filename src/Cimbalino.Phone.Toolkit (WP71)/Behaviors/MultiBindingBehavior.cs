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
using System.Globalization;
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
        /// Gets the <see cref="MultiBindingItem"/> collection within this <see cref="MultiBindingBehavior"/> instance.
        /// </summary>
        /// <value>One or more <see cref="MultiBindingItem"/> objects.</value>
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
            DependencyProperty.Register("PropertyName", typeof(string), typeof(MultiBindingBehavior), new PropertyMetadata(null, OnPropertyChanged));

        /// <summary>
        /// Gets or sets the converter to use to convert the source values to or from the target value.
        /// </summary>
        /// <value>A resource reference to a class that implements the <see cref="IValueConverter"/> interface, which includes implementations of the <see cref="IValueConverter.Convert"/> and <see cref="IValueConverter.ConvertBack"/> methods.</value>
        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(ConverterProperty); }
            set { SetValue(ConverterProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Converter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ConverterProperty =
            DependencyProperty.Register("Converter", typeof(IValueConverter), typeof(MultiBindingBehavior), new PropertyMetadata(null, OnPropertyChanged));

        /// <summary>
        /// Gets or sets the <see cref="CultureInfo"/> object that applies to the converter.
        /// </summary>
        /// <value>The <see cref="CultureInfo"/> object that applies to the converter.</value>
        public CultureInfo ConverterCulture
        {
            get { return (CultureInfo)GetValue(ConverterCultureProperty); }
            set { SetValue(ConverterCultureProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ConverterCulture" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ConverterCultureProperty =
            DependencyProperty.Register("ConverterCulture", typeof(CultureInfo), typeof(MultiBindingBehavior), new PropertyMetadata(null, OnPropertyChanged));

        /// <summary>
        /// Gets or sets an optional parameter to pass to the converter as additional information.
        /// </summary>
        /// <value>A value of the type expected by the converter, which might be an object element or a string depending on the definition and XAML capabilities both of the property type being used and of the implementation of the converter.</value>
        public object ConverterParameter
        {
            get { return GetValue(ConverterParameterProperty); }
            set { SetValue(ConverterParameterProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ConverterParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ConverterParameterProperty =
            DependencyProperty.Register("ConverterParameter", typeof(object), typeof(MultiBindingBehavior), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var multiBindingBehavior = (MultiBindingBehavior)d;

            multiBindingBehavior.Update();
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

            Update();
        }

        private void Update()
        {
            if (AssociatedObject == null || string.IsNullOrEmpty(PropertyName))
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
                ConverterCulture = ConverterCulture,
                ConverterParameter = ConverterParameter,
                Mode = BindingMode.TwoWay
            };

            BindingOperations.SetBinding(AssociatedObject, targetDependencyProperty, binding);
        }
    }
}