using MailSender.lib.Entities;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;
using System.Linq;

namespace MailSender.lib.Services
{
    public class MailstStoreInMemory : DataStoreInMemory<Mail>, IMaleStore
    {
        public MailstStoreInMemory() : base(Enumerable.Range(1, 10).Select(x => new Mail { ID = x, Subject = $"Тема письма {x}", Body = $"Тело письма {x}" }).ToList())
        {

        }

        public override void Edit(int Id, Mail mail)
        {
            var db_Mail = GetById(Id);
            if (db_Mail is null) return;

            db_Mail.Body = mail.Body;
            db_Mail.Subject = mail.Subject;
        }
    }
}