using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class RecipientStoreInMemory : DataStoreInMemory<Recipient>, IRecipientStore
    {
        public RecipientStoreInMemory() : base(TestData.recipients) { }
        public override void Edit(int Id, Recipient recipient) 
        {
            var db_recipient = GetById(Id);
            if (db_recipient is null) return;

            db_recipient.Name = recipient.Name;
            db_recipient.Adress = recipient.Adress;
        }
    }
}