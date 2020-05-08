using MailSender.lib.Entities;
using System.Collections.Generic;

namespace MailSender.lib.Services
{
    public class RecipientsManager
    {
        private RecipientStoreInMemory _Store;

        public RecipientsManager(RecipientStoreInMemory Store) { _Store = Store; }
        public IEnumerable<Recipient> GetAll() => _Store.Get();
        public void Add(Recipient recipient)
        {

        }
    }
}
