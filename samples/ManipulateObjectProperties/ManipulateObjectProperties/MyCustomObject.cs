using System;
using System.ComponentModel;

namespace ManipulateObjectProperties
{
    public enum TestEnum
    {
        Item1,
        Item2,
        Item3
    }

    public class MyCustomObject : INotifyPropertyChanged
    {
        private bool _observableBoolProperty;

        public event PropertyChangedEventHandler PropertyChanged;

        public MyCustomObject()
        {
            DateTimeProperty = DateTime.Now;
        }

        [Browsable(false)]
        public string HiddenProperty { get; set; }

        public string StringProperty { get; set; }

        public string IntProperty { get; set; }

        public bool BoolProperty { get; set; }

        public TestEnum EnumProperty { get; set; }

        public DateTime DateTimeProperty { get; set; }

        [Category("Read Only Properties")]
        public string ReadOnlyStringProperty { get; private set; }

        [Category("Read Only Properties")]
        [ReadOnly(true)]
        public bool ReadOnlyBoolProperty { get; set; }

        [Category("Observable Properties")]
        public bool ObservableBoolProperty
        {
            get
            {
                return _observableBoolProperty;
            }
            set
            {
                if (_observableBoolProperty == value)
                {
                    return;
                }

                _observableBoolProperty = value;

                RaisePropertyChanged("ObservableBoolProperty");
                RaisePropertyChanged("ObservableReadOnlyStringProperty");
            }
        }

        [Category("Observable Properties")]
        public string ObservableReadOnlyStringProperty
        {
            get
            {
                return _observableBoolProperty.ToString();
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;

            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}