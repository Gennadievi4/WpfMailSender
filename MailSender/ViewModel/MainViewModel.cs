using GalaSoft.MvvmLight;

namespace MailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _Title = "���������� �����";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public MainViewModel()
        {

        }
    }
}