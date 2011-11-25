using Microsoft.Phone.Controls;

namespace BindableApplicationBar
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = new MainPageViewModel();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            var model = DataContext as MainPageViewModel;

            if (model == null)
                return;

            model.BackKeyPressCommand.Execute(e);
        }
    }
}