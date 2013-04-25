// ****************************************************************************
// <copyright file="MultiBindingItemCollection.cs" company="Pedro Lamas">
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

using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// Represents a collection of <see cref="MultiBindingBehavior" />.
    /// </summary>
    public class MultiBindingItemCollection : DependencyObjectCollection<MultiBindingItem>
    {
        private bool _updating;

        /// <summary>
        /// Gets or sets the multiple binding value.
        /// </summary>
        /// <value>The multiple binding value.</value>
        public object[] Value
        {
            get { return (object[])GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Value" /> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object[]), typeof(MultiBindingItemCollection), new PropertyMetadata(null, OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var multiBindingItemCollection = (MultiBindingItemCollection)d;

            multiBindingItemCollection.UpdateSource();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiBindingItemCollection"/> class.
        /// </summary>
        public MultiBindingItemCollection()
        {
            CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (MultiBindingItem item in e.OldItems)
                {
                    item.Parent = null;
                }
            }

            if (e.NewItems != null)
            {
                foreach (MultiBindingItem item in e.NewItems)
                {
                    item.Parent = this;
                }
            }

            Update();
        }

        internal void Update()
        {
            if (_updating)
            {
                return;
            }

            try
            {
                _updating = true;

                Value = this
                    .Select(x => x.Value)
                    .ToArray();
            }
            finally
            {
                _updating = false;
            }
        }

        private void UpdateSource()
        {
            if (_updating)
            {
                return;
            }

            try
            {
                _updating = true;

                for (var index = 0; index < Count; index++)
                {
                    this[index].Value = Value[index];
                }
            }
            finally
            {
                _updating = false;
            }
        }
    }
}