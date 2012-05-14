// ****************************************************************************
// <copyright file="PropertyGridItem.cs" company="Pedro Lamas">
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
using System.ComponentModel;
using System.Reflection;

namespace Cimbalino.Phone.Toolkit.Controls
{
    /// <summary>
    /// A <see cref="PropertyGrid"/> item.
    /// </summary>
    /// <typeparam name="T">The property type.</typeparam>
    public class PropertyGridItem<T> : IPropertyGridItem, INotifyPropertyChanged
    {
        private const string DefaultCategory = "Misc";

        /// <summary>
        /// Occurs after a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly object _sourceObject;
        private readonly PropertyInfo _propertyInfo;
        private T _value;

        #region Properties

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        public string Name
        {
            get
            {
                return _propertyInfo.Name;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the item is writable.
        /// </summary>
        /// <value>A value indicating whether the item is writable.</value>
        public bool IsWritable { get; private set; }

        /// <summary>
        /// Gets the category of the item.
        /// </summary>
        /// <value>The category of the item.</value>
        public string Category { get; private set; }

        /// <summary>
        /// Gets or sets the value of the item.
        /// </summary>
        /// <value>The value of the item.</value>
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!object.Equals(_value, value))
                {
                    _value = value;

                    WriteValue();
                }

                RaisePropertyChanged("Value");
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGridItem{T}" /> class.
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="propertyInfo">The <see cref="PropertyInfo"/>.</param>
        public PropertyGridItem(object sourceObject, PropertyInfo propertyInfo)
        {
            _sourceObject = sourceObject;
            _propertyInfo = propertyInfo;

            var readOnlyAttribute = GetPropertyCustomAttribute<ReadOnlyAttribute>();

            IsWritable = (readOnlyAttribute == null || !readOnlyAttribute.IsReadOnly) && _propertyInfo.GetSetMethod() != null;

            var categoryAttribute = GetPropertyCustomAttribute<CategoryAttribute>();

            Category = categoryAttribute == null ? DefaultCategory : categoryAttribute.Category;

            ReadValue();
        }

        /// <summary>
        /// Updates the item.
        /// </summary>
        public void Update()
        {
            ReadValue();
        }

        private void ReadValue()
        {
            var value = _propertyInfo.GetValue(_sourceObject, null);

            if (object.Equals(_value, value))
            {
                return;
            }

            _value = (T)value;

            RaisePropertyChanged("Value");
        }

        private void WriteValue()
        {
            _propertyInfo.SetValue(_sourceObject, _value, null);
        }

        /// <summary>
        /// Gets a custom <see cref="Attribute"/> from the <see cref="PropertyInfo"/>.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <returns>A custom <see cref="Attribute"/> from the <see cref="PropertyInfo"/>.</returns>
        protected TAttribute GetPropertyCustomAttribute<TAttribute>()
            where TAttribute : Attribute
        {
            return (TAttribute)Attribute.GetCustomAttribute(_propertyInfo, typeof(TAttribute));
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            var eventhandler = PropertyChanged;

            if (eventhandler != null)
            {
                eventhandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}