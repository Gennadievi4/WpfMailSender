using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;

namespace MailSender.lib.Services
{
    public class RecipientsManager : IRecipientManager
    {
        private IRecipientStore _Store;

        public RecipientsManager(IRecipientStore Store) { _Store = Store; }
        public IEnumerable<Recipient> GetAll() => _Store.Get();
        public void Add(Recipient recipient)
        {

        }
        public void Edit(Recipient recipient)
        {
            _Store.Edit(recipient.ID, recipient);
        }

        public void SaveChanges()
        {
            _Store.SaveChanges();
        }
    }
}
