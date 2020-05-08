using GalaSoft.MvvmLight;
using MailSender.lib.Entities;
using MailSender.lib.Services;
using System.Collections.ObjectModel;

namespace MailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly RecipientsManager _RecipientsManager;
        private ObservableCollection<Recipient> _Recipients;
        public ObservableCollection<Recipient> Recipints
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        private string _Title = "Рассыльщик почты";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public MainViewModel(RecipientsManager recipientManager)
        {
            _RecipientsManager = recipientManager;
            _Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
        }
    }
}