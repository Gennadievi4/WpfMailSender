using MailSender.lib.Entities;
using MailSender.lib.Services;
using System.Windows;

namespace MailSender
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            //var recipient = RecipientsList.SelectedItem as Recipient;
            //var server = ServersList.SelectedItem as Server;
            //var senders = SendersList.SelectedItem as Sender;

            //if (recipient is null || server is null || senders is null) return;

            //var mail_sender = new DebugMailSender(server.Adress, server.Port, server.UseSSL, server.LogIn, server.Password.DeCode());
            //mail_sender.Send(MailHeader.Text, MailText.Text, senders.Adress, recipient.Adress);
        }

        private void OnAddBtnClick(object sender, RoutedEventArgs e)
        {
            var senders = SendersList.SelectedItem as Sender;
            if (senders is null) return;

            var dialog = new SenderEditor(senders);

            if (dialog.ShowDialog() != true) return;

            senders.Name = dialog.NameValue;
            senders.Adress = dialog.AdressValue;
        }
    }
}
