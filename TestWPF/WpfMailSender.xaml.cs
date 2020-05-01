using System.Windows;
using System.Net;
using System.Net.Mail;
using System;
using System.Diagnostics;

namespace TestWPF
{
    public partial class WpfMailSender : Window
    {
        public WpfMailSender() => InitializeComponent();

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            const string from = "gonzy@yandex.ru";
            const string to = "9lilys@mail.ru";

            const string server_adress = "smtp.yandex.ru";
            const int server_port = 587;

            var message_subject = $"Тестовое письмо от {DateTime.Now}";
            var message_body = $"Тестовое тело письма от {DateTime.Now}";
            var password = Password.SecurePassword;
            var user_name = txtBoxOfName.Text;

            try
            {
                using (MailMessage ms = new MailMessage(from, to))
                {
                    ms.Subject = message_subject;
                    ms.IsBodyHtml = false;
                    ms.Body = message_body;

                    using (SmtpClient smtpClient = new SmtpClient(server_adress, server_port))
                    {
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new NetworkCredential(user_name, password);
                        smtpClient.Send(ms);
                        SendEndWindow sw = new SendEndWindow();
                        sw.ShowDialog();
                    }
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.InnerException);
                MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
