using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.Infrastructure.Services.Interfaces;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IRecipientManager _RecipientsManager;
        private readonly IMaleStore _MailStore;
        private readonly IServerStore _ServerStore;
        private readonly ISenderStore _SenderStore;
        private ISenderEditor _SenderEditor;
        private Recipient _Recipient;

        private Server _SelectedServer;
        private Sender _SelectedSender;
        private Mail _SelectedMail;
        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }
        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }
        public Mail SelectedMail
        {
            get => _SelectedMail;
            set => Set(ref _SelectedMail, value);
        }

        private ObservableCollection<Recipient> _Recipients;
        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }
        private ObservableCollection<Sender> _Senders;
        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            private set => Set(ref _Senders, value);
        }
        private ObservableCollection<Server> _Servers;
        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            private set => Set(ref _Servers, value);
        }

        private ObservableCollection<Mail> _Mails;
        public ObservableCollection<Mail> Mails
        {
            get => _Mails;
            private set => Set(ref _Mails, value);
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
        public ICommand SenderEditCommand { get; }
        private bool CanSenderEditCommandExecute(Sender sender) => sender != null;
        private void OnSenderEditCommandExecute(Sender sender)
        {
            _SenderEditor.Edit(sender);
        }
        private bool CanLoadRecipientsDataCommand() => true;
        private void OnLoadRecipientsDataCommand()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
            Mails = new ObservableCollection<Mail>(_MailStore.GetAll());
            Servers = new ObservableCollection<Server>(_ServerStore.GetAll());
            Senders = new ObservableCollection<Sender>(_SenderStore.GetAll());

        }

        private bool CanSavedRecipientChamgesCommandCanExecute(Recipient recipient) => recipient != null;
        private void OnSavedRecipientChangesCommandExecuted(Recipient recipient)
        {
            _RecipientsManager.Edit(recipient);
            _RecipientsManager.SaveChanges();
        }
        #endregion

        public MainViewModel(IRecipientManager recipientManager,
            IServerStore serverStore,
            ISenderStore senderStore,
            IMaleStore maleStore,
            ISenderEditor senderEditor)
        {
            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientsDataCommand, CanLoadRecipientsDataCommand);
            CanRecipientChangesCommand = new RelayCommand<Recipient>(OnSavedRecipientChangesCommandExecuted, CanSavedRecipientChamgesCommandCanExecute);
            SenderEditCommand = new RelayCommand<Sender>(OnSenderEditCommandExecute ,CanSenderEditCommandExecute);

            _RecipientsManager = recipientManager;
            _MailStore = maleStore;
            _SenderStore = senderStore;
            _ServerStore = serverStore;
            _SenderEditor = senderEditor;
        }
    }
}