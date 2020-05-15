using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class SenderstStoreInMemory : DataStoreInMemory<Sender>, ISenderStore
    {
        public SenderstStoreInMemory() : base(TestData.senders) { }
        public override void Edit(int Id, Sender Sender)
        {
            var db_sender = GetById(Id);
            if (db_sender is null) return;

            db_sender.Name = Sender.Name;
            db_sender.Adress = Sender.Adress;
        }
    }
}