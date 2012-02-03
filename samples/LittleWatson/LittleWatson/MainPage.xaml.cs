using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace LittleWatson
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Cimbalino.Phone.Toolkit.Helpers.LittleWatson.CheckForPreviousException();
        }

        private void ThrowException_Click(object sender, RoutedEventArgs e)
        {
            //If you run this code from Visual Studio, it will stop here; just press "Continue" when that happens
            throw new Exception("My test exception");
        }
    }
}