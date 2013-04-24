using System;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Location.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ILocationService _locationService;
        private readonly IMessageBoxService _messageBoxService;

        private string _status;
        private string _currentLocation;

        #region Properties

        public RelayCommand GetCurrentLocationCommand { get; private set; }

        public RelayCommand StartMonitoringLocationCommand { get; private set; }

        public RelayCommand StopMonitoringLocationCommand { get; private set; }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (_status == value)
                    return;

                _status = value;

                RaisePropertyChanged(() => Status);
            }
        }

        public string CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                if (_currentLocation == value)
                    return;

                _currentLocation = value;

                RaisePropertyChanged(() => CurrentLocation);
            }
        }

        #endregion

        public MainViewModel(ILocationService locationService, IMessageBoxService messageBoxService)
        {
            _locationService = locationService;
            _messageBoxService = messageBoxService;

            _locationService.PositionChanged += LocationService_PositionChanged;
            _locationService.StatusChanged += LocationService_StatusChanged;

            GetCurrentLocationCommand = new RelayCommand(() =>
            {
                _locationService.GetPosition(TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(10), (location, ex) =>
                {
                    if (ex != null)
                    {
                        _messageBoxService.Show(ex.ToString(), "Error");
                    }
                    else
                    {
                        CurrentLocation = location.ToString();
                    }
                });
            });

            StartMonitoringLocationCommand = new RelayCommand(() =>
            {
                _locationService.Start(LocationServiceAccuracy.High);

                Status = "Starting";
            });

            StopMonitoringLocationCommand = new RelayCommand(() =>
            {
                _locationService.Stop();

                Status = "Stopped";
            });

            CurrentLocation = "(Unknown)";
            Status = "Stopped";
        }

        private void LocationService_StatusChanged(object sender, LocationServiceStatusChangedEventArgs e)
        {
            Status = e.Status.ToString();
        }

        private void LocationService_PositionChanged(object sender, LocationServicePositionChangedEventArgs e)
        {
            CurrentLocation = e.Position.ToString();
        }
    }
}