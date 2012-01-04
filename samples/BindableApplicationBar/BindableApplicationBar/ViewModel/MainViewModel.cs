using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BindableApplicationBar.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessageBoxService _messageBoxService;

        private bool _isSelectionViewEnabled = false;

        #region Properties

        public ObservableCollection<string> Items { get; private set; }

        public RelayCommand AddItemCommand { get; private set; }

        public RelayCommand EnableSelectionCommand { get; private set; }

        public RelayCommand<System.Collections.IList> DeleteItemsCommand { get; private set; }

        public RelayCommand<CancelEventArgs> BackKeyPressCommand { get; private set; }

        public RelayCommand AboutCommand { get; private set; }

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

                RaisePropertyChanged(() => IsSelectionEnabled);
                RaisePropertyChanged(() => IsSelectionDisabled);
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

        public MainViewModel(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;

            AddItemCommand = new RelayCommand(() =>
            {
                Items.Add(DateTime.Now.ToString());

                EnableSelectionCommand.RaiseCanExecuteChanged();
            });

            EnableSelectionCommand = new RelayCommand(() =>
            {
                IsSelectionEnabled = true;
            }, () => Items.Count > 0);

            DeleteItemsCommand = new RelayCommand<System.Collections.IList>(items =>
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

            BackKeyPressCommand = new RelayCommand<CancelEventArgs>(e =>
            {
                if (IsSelectionEnabled)
                {
                    IsSelectionEnabled = false;

                    e.Cancel = true;
                }
            });

            AboutCommand = new RelayCommand(() =>
            {
                _messageBoxService.Show("Cimbalino Windows Phone Toolkit Bindable Application Bar Sample", "About");
            });

            Items = new ObservableCollection<string>();
        }
    }
}