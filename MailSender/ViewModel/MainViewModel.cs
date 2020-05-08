using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IRecipientManager _RecipientsManager;
        private ObservableCollection<Recipient> _Recipients;
        private Recipient _Recipient;
        public ObservableCollection<Recipient> Recipients
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
        public Recipient SelectedRecipient
        {
            get => _Recipient;
            set => Set(ref _Recipient, value);
        }

        #region Команды
        public ICommand LoadRecipientsDataCommand { get; }
        public ICommand CanRecipientChangesCommand { get; }
        #endregion
        public MainViewModel(IRecipientManager recipientManager)
        {
            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientsDataCommand, CanLoadRecipientsDataCommand);
            CanRecipientChangesCommand = new RelayCommand<Recipient>(OnSavedRecipientChangesCommandExecuted, CanSavedRecipientChamgesCommandCanExecute);
            _RecipientsManager = recipientManager;
        }

        private bool CanLoadRecipientsDataCommand() => true;
        private void OnLoadRecipientsDataCommand() 
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
        }

        private bool CanSavedRecipientChamgesCommandCanExecute(Recipient recipient) => recipient != null;
        private void OnSavedRecipientChangesCommandExecuted(Recipient recipient)
        {
            _RecipientsManager.Edit(recipient);
            _RecipientsManager.SaveChanges();
        }
    }
}