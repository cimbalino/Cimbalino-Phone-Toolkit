using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace ManipulateObjectProperties
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void ShowButtonPropertiesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ButtonPage.xaml", UriKind.Relative));
        }

        private void ShowCustomObjectPropertiesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CustomObjectPage.xaml", UriKind.Relative));
        }
    }
}