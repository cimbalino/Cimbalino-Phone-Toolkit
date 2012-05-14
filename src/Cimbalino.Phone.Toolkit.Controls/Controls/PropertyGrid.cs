// ****************************************************************************
// <copyright file="PropertyGrid.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>09-05-2012</date>
// <project>Cimbalino.Phone.Toolkit.Controls</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace Cimbalino.Phone.Toolkit.Controls
{
    /// <summary>
    /// Represents a PropertyGrid control capable of managing an object properties.
    /// </summary>
    public class PropertyGrid : ContentControl
    {
        private LongListSelector _mainItemsControl;

        #region Properties

        /// <summary>
        /// Gets or sets the object for which the grid displays properties.
        /// </summary>
        /// <value>The object for which the grid displays properties.</value>
        public object SourceObject
        {
            get { return GetValue(SourceObjectProperty); }
            set { SetValue(SourceObjectProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="SourceObject" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SourceObjectProperty =
            DependencyProperty.Register("SourceObject", typeof(object), typeof(PropertyGrid), new PropertyMetadata(null, OnSourceObjectChanged));

        private static void OnSourceObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var propertyGrid = (PropertyGrid)d;

            INotifyPropertyChanged sourceObject;

            if ((sourceObject = e.OldValue as INotifyPropertyChanged) != null)
            {
                sourceObject.PropertyChanged -= propertyGrid.SelectedObject_PropertyChanged;
            }

            if ((sourceObject = e.NewValue as INotifyPropertyChanged) != null)
            {
                sourceObject.PropertyChanged += propertyGrid.SelectedObject_PropertyChanged;
            }

            propertyGrid.Update();
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> used to display each item.
        /// </summary>
        /// <value>A <see cref="DataTemplate"/> that specifies the visualization of the data objects.</value>
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ItemTemplate" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(PropertyGrid), null);

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGrid"/> class.
        /// </summary>
        public PropertyGrid()
        {
            DefaultStyleKey = typeof(PropertyGrid);
        }

        /// <summary>
        /// Called just before a UI element displays in an application.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _mainItemsControl = (LongListSelector)GetTemplateChild("MainItemsControl");

            Update();
        }

        private void Update()
        {
            if (_mainItemsControl == null)
            {
                return;
            }

            if (SourceObject == null)
            {
                _mainItemsControl.ItemsSource = null;
            }
            else
            {
                _mainItemsControl.ItemsSource = GetProperties()
                    .GroupBy(x => x.Category)
                    .Select(x => new ItemsGroup<IPropertyGridItem>(x.Key, x.OrderBy(y => y.Name)))
                    .OrderBy(x => x.Name)
                    .ToArray();
            }
        }

        private void SelectedObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var propertyGridItem = _mainItemsControl.ItemsSource
                .OfType<IPropertyGridItem>()
                .FirstOrDefault(x => x.Name == e.PropertyName);

            if (propertyGridItem != null)
            {
                propertyGridItem.Update();
            }
        }

        private IEnumerable<IPropertyGridItem> GetProperties()
        {
            var propertyGridItemType = typeof(PropertyGridItem<>);

            var propertyInfos = SourceObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

            foreach (var propertyInfo in propertyInfos)
            {
                var browsableAttribute = (BrowsableAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(BrowsableAttribute));

                if (browsableAttribute != null && !browsableAttribute.Browsable)
                {
                    continue;
                }

                yield return (IPropertyGridItem)Activator.CreateInstance(propertyGridItemType.MakeGenericType(propertyInfo.PropertyType), new object[] { SourceObject, propertyInfo });
            }
        }
    }
}