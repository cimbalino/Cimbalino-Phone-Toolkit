using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BindableApplicationBar
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool _isSelectionViewEnabled = false;

        #region Properties

        public ObservableCollection<string> Items { get; private set; }

        public CustomCommand AddItemCommand { get; private set; }

        public CustomCommand EnableSelectionCommand { get; private set; }

        public CustomCommand<System.Collections.IList> DeleteItemsCommand { get; private set; }

        public CustomCommand<CancelEventArgs> BackKeyPressCommand { get; private set; }

        public CustomCommand AboutCommand { get; private set; }

        public bool IsSelectionEnabled
        {
            get
            {
                return _isSelectionViewEnabled;
            }
            set
            {
                if (_isSelectionViewEnabled == value)
                    return;

                _isSelectionViewEnabled = value;

                NotifyPropertyChanged("IsSelectionEnabled");
                NotifyPropertyChanged("IsSelectionDisabled");
            }
        }

        public bool IsSelectionDisabled
        {
            get
            {
                return !_isSelectionViewEnabled;
            }
        }

        #endregion

        public MainPageViewModel()
        {
            AddItemCommand = new CustomCommand(() =>
            {
                Items.Add(DateTime.Now.ToString());

                EnableSelectionCommand.RaiseCanExecuteChanged();
            });

            EnableSelectionCommand = new CustomCommand(() =>
            {
                IsSelectionEnabled = true;
            }, () => Items.Count > 0);

            DeleteItemsCommand = new CustomCommand<System.Collections.IList>(items =>
            {
                var itemsToRemove = items
                    .Cast<string>()
                    .ToArray();

                foreach (var itemToRemove in itemsToRemove)
                {
                    Items.Remove(itemToRemove);
                }

                EnableSelectionCommand.RaiseCanExecuteChanged();

                IsSelectionEnabled = false;
            });

            BackKeyPressCommand = new CustomCommand<CancelEventArgs>(e =>
            {
                if (IsSelectionEnabled)
                {
                    IsSelectionEnabled = false;

                    e.Cancel = true;
                }
            });

            AboutCommand = new CustomCommand(() =>
            {
                System.Windows.MessageBox.Show("Cimbalino Windows Phone Toolkit Bindable Application Bar Sample", "About", System.Windows.MessageBoxButton.OK);
            });

            Items = new ObservableCollection<string>();
        }

        #region INotifyPropertyChanged Interface

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}