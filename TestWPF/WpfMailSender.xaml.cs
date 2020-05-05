using System;
using System.Windows;

namespace TestWPF
{
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            var message_subject = msgSubj.Text;
            var message_body = msgBody.Text;
            var password = Password.SecurePassword;
            var user_name = txtBoxOfName.Text;

            EmailSendServicesClass emailSend = new EmailSendServicesClass();
            emailSend.SendEMale(message_subject, message_body, user_name, password);
        }
    }
}