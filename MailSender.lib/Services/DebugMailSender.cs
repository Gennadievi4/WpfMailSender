using MailSender.lib.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MailSender.lib.Services
{
    public class DebugMailSender
    {
        private readonly Server _Server;
        public DebugMailSender(Server server) => _Server = server;
        public void Send(Mail mail, Sender From, Recipient To)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]\r\n{5}:{6}", From.Adress, To.Adress, _Server.Adress, _Server.Port, 
                _Server.UseSSL ? "SSL" : "NoSSL", mail.Subject, mail.Body);
        }

        public void Send(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                Send(Message, From, To);
        }

        public void SendParallel(Mail message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
            {
                ThreadPool.QueueUserWorkItem(_ => Send(message, From, recipient));
            }
        }
    }
}