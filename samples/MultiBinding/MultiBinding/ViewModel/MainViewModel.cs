using GalaSoft.MvvmLight;

namespace MultiBinding.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _text1;
        private string _text2;

        public string Text1
        {
            get
            {
                return _text1;
            }
            set
            {
                if (_text1 != value)
                {
                    _text1 = value;

                    RaisePropertyChanged(() => Text1);
                }
            }
        }

        public string Text2
        {
            get
            {
                return _text2;
            }
            set
            {
                if (_text2 != value)
                {
                    _text2 = value;

                    RaisePropertyChanged(() => Text2);
                }
            }
        }

        public string[] Items
        {
            get
            {
                return new[]
                {
                    "Both are empty",
                    "Text 1 is empty",
                    "Text 2 is empty",
                    "None are empty",
                };

            }
        }
    }
}