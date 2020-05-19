using MailSender.lib.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private readonly Server _Server;
        public MailSender(Server server) => _Server = server;
        public void Send(Mail mail, Sender From, Recipient To)
        {
            using (var message = new MailMessage(new MailAddress(From.Adress, From.Name), new MailAddress(To.Adress, To.Name)))
            {
                message.Subject = mail.Subject;
                message.Body = mail.Body;

                var login = new NetworkCredential(_Server.LogIn, _Server.Password);
                using (var smtpClient = new SmtpClient(_Server.Adress, _Server.Port))
                {
                    smtpClient.EnableSsl = _Server.UseSSL;
                    smtpClient.Credentials = login;
                    smtpClient.Send(message);
                }
            }
        }

        public void Send(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                Send(Message, From, To);
        }

        public void SendParallel(Mail message, Sender From, IEnumerable<Recipient> To)
        {
            foreach(var recipient in To)
            {
                ThreadPool.QueueUserWorkItem(_ => Send(message, From, recipient));
            }
        }
        public async Task SendAsync(Mail mail, Sender From, Recipient To)
        {
            using (var message = new MailMessage(new MailAddress(From.Adress, From.Name), new MailAddress(To.Adress, To.Name)))
            {
                message.Subject = mail.Subject;
                message.Body = mail.Body;

                var login = new NetworkCredential(_Server.LogIn, _Server.Password);
                using (var smtpClient = new SmtpClient(_Server.Adress, _Server.Port))
                {
                    smtpClient.EnableSsl = _Server.UseSSL;
                    smtpClient.Credentials = login;
                    //smtpClient.Send(message);
                    await smtpClient.SendMailAsync(message);
                }
            }
        }
        //public async Task SendAsync(Mail mail, Sender From, IEnumerable<Recipient> To)
        //{
        //    await Task.WhenAll(To.Select(to => SendAsync(mail, From, to))).ConfigureAwait(false);
        //}

        public async Task SendAsync(Mail mail, Sender From, IEnumerable<Recipient> To, CancellationToken Cancel = default)
        {
            foreach (var recipient in To)
            {
                Cancel.ThrowIfCancellationRequested();
                await SendAsync(mail, From, recipient).ConfigureAwait(false);
            }
        }
    }
}