using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MailSender.lib.Services
{
    public class RecipientStoreInMemory : IRecipientStore
    {
        public IEnumerable<Recipient> GetAll() => TestData.recipients;

        public void Edit(int Id, Recipient recipient) 
        {
            var db_recipient = GetById(Id);
            if (db_recipient is null) return;

            db_recipient.Name = recipient.Name;
            db_recipient.Adress = recipient.Adress;
        }
        public void SaveChanges()
        {
            Debug.WriteLine("Сохранение изменений в хранилище получателей писем.");
        }

        public Recipient GetById(int Id) => TestData.recipients.FirstOrDefault(x => x.ID == Id);

        public int Create(Recipient recipient)
        {
            if (TestData.recipients.Contains(recipient)) return recipient.ID;
            recipient.ID = TestData.recipients.Count == 0 ? 1 : TestData.recipients.Max(x => x.ID) + 1;
            TestData.recipients.Add(recipient);
            return recipient.ID;
        }

        public Recipient Remove(int Id)
        {
            var db_recipient = GetById(Id);
            if (db_recipient != null)
                TestData.recipients.Remove(db_recipient);
            return db_recipient;
        }
    }
}