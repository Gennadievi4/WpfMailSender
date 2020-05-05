using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Windows;

namespace TestWPF
{
    public class EmailSendServicesClass
    {
        public void SendEMale(string message_subject, string message_body, string user_name, SecureString secure)
        {
            try
            {
                using (MailMessage ms = new MailMessage(WpfMailSenderVariables.from, WpfMailSenderVariables.to))
                {
                    ms.Subject = message_subject;
                    ms.IsBodyHtml = false;
                    ms.Body = message_body;

                    using (SmtpClient smtpClient = new SmtpClient(WpfMailSenderVariables.server_adress, WpfMailSenderVariables.server_port))
                    {
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new NetworkCredential(user_name, secure);
                        smtpClient.Send(ms);
                        SendEndWindow sw = new SendEndWindow();
                        sw.ShowDialog();
                    }
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.InnerException);
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Message = error.Message;
                errorWindow.ShowDialog();
                //MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void SendsEmales()
        {

        }
    }
}
