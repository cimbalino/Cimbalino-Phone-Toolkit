// ****************************************************************************
// <copyright file="PropertyGridItemContainer.cs" company="Pedro Lamas">
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
using System.Windows;
using System.Windows.Controls;

namespace Cimbalino.Phone.Toolkit.Controls
{
    /// <summary>
    /// A <see cref="IPropertyGridItem"/> container.
    /// </summary>
    public class PropertyGridItemContainer : ContentControl
    {
        private ContentPresenter _contentPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGridItemContainer"/> class.
        /// </summary>
        public PropertyGridItemContainer()
        {
            DefaultStyleKey = typeof(PropertyGridItemContainer);
        }

        /// <summary>
        /// Called just before a UI element displays in an application.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _contentPresenter = (ContentPresenter)GetTemplateChild("ContentPresenter");

            Update();
        }

        /// <summary>
        /// Called when the value of the <see cref="Content"/> property changes.
        /// </summary>
        /// <param name="oldContent">The old value of the <see cref="Content"/> property.</param>
        /// <param name="newContent">The new value of the <see cref="Content"/> property.</param>
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            Update();
        }

        /// <summary>
        /// Updates the <see cref="PropertyGridItemContainer"/>.
        /// </summary>
        protected virtual void Update()
        {
            if (_contentPresenter == null)
            {
                return;
            }

            _contentPresenter.ContentTemplate = null;
            _contentPresenter.ContentTemplate = SelectTemplate(Content as IPropertyGridItem);
        }

        /// <summary>
        /// Retrieved a <see cref="DataTemplate"/> instance for the specified <see cref="IPropertyGridItem"/>.
        /// </summary>
        /// <param name="item">The <see cref="IPropertyGridItem"/>.</param>
        /// <returns>A <see cref="DataTemplate"/> instace for the specified <see cref="IPropertyGridItem"/>.</returns>
        protected virtual DataTemplate SelectTemplate(IPropertyGridItem item)
        {
            if (item == null)
            {
                return null;
            }

            var propertyType = item.GetType().GetGenericArguments()[0];

            if (propertyType.IsEnum)
            {
                return (DataTemplate)_contentPresenter.Resources["EnumPropertyDataTemplate"];
            }

            if (propertyType == typeof(DateTime))
            {
                return (DataTemplate)_contentPresenter.Resources["DateTimePropertyDataTemplate"];
            }

            if (propertyType == typeof(bool))
            {
                return (DataTemplate)_contentPresenter.Resources["BoolPropertyDataTemplate"];
            }

            if (propertyType.IsPrimitive || propertyType == typeof(string))
            {
                return (DataTemplate)_contentPresenter.Resources["PrimitivePropertyDataTemplate"];
            }

            return (DataTemplate)_contentPresenter.Resources["ObjectPropertyDataTemplate"];
        }
    }
}