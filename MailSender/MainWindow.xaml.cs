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
            var recipient = RecipientsList.SelectedItem as Recipient;
            var server = ServersList.SelectedItem as Server;
            var senders = SendersList.SelectedItem as Sender;

            if (recipient is null || server is null || senders is null) return;

            var mail_sender = new lib.Services.DebugMailSender(server.Adress, server.Port, server.UseSSL, server.LogIn, server.Password.DeCode());
            mail_sender.Send(MailHeader.Text, MailText.Text, senders.Adress, recipient.Adress);
        }
    }
}
