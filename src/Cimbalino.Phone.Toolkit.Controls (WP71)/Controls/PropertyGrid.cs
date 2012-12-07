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
                sourceObject.PropertyChanged -= propertyGrid.SourceObject_PropertyChanged;
            }

            if ((sourceObject = e.NewValue as INotifyPropertyChanged) != null)
            {
                sourceObject.PropertyChanged += propertyGrid.SourceObject_PropertyChanged;
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

        /// <summary>
        /// Gets or sets a value indicating whether to show categories.
        /// </summary>
        /// <value>true if the categories are enabled; otherwise, false.</value>
        public bool ShowCategories
        {
            get { return (bool)GetValue(ShowCategoriesProperty); }
            set { SetValue(ShowCategoriesProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ShowCategories" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowCategoriesProperty =
            DependencyProperty.Register("ShowCategories", typeof(bool), typeof(PropertyGrid), new PropertyMetadata(true, OnShowCategoriesChanged));

        private static void OnShowCategoriesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var propertyGrid = (PropertyGrid)d;

            propertyGrid.Update();
        }

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

            _mainItemsControl.ItemsSource = null;

            if (SourceObject != null)
            {
                if (ShowCategories)
                {
#if !WP8
                    _mainItemsControl.IsFlatList = false;
#endif

                    _mainItemsControl.ItemsSource = GetProperties()
                        .GroupBy(x => x.Category)
                        .Select(x => new ItemsGroup<IPropertyGridItem>(x.Key, x.OrderBy(y => y.Name)))
                        .OrderBy(x => x.Name)
                        .ToArray();
                }
                else
                {
#if !WP8
                    _mainItemsControl.IsFlatList = true;
#endif

                    _mainItemsControl.ItemsSource = GetProperties()
                        .OrderBy(x => x.Name)
                        .ToArray();
                }
            }
        }

        private void SourceObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IPropertyGridItem propertyGridItem;

            if (ShowCategories)
            {
                propertyGridItem = _mainItemsControl.ItemsSource
                    .Cast<ItemsGroup<IPropertyGridItem>>()
                    .SelectMany(x => x.Items)
                    .FirstOrDefault(x => x.Name == e.PropertyName);
            }
            else
            {
                propertyGridItem = _mainItemsControl.ItemsSource
                    .Cast<IPropertyGridItem>()
                    .FirstOrDefault(x => x.Name == e.PropertyName);
            }

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

                yield return (IPropertyGridItem)Activator.CreateInstance(propertyGridItemType.MakeGenericType(propertyInfo.PropertyType), new[] { SourceObject, propertyInfo });
            }
        }
    }
}