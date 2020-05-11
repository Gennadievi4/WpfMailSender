using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;

namespace MailSender.lib.Services
{
    public class RecipientStoreInMemory : IRecipientStore
    {
        public IEnumerable<Recipient> Get() => TestData.recipients;

        public void Edit(int Id, Recipient recipient) { }
        public void SaveChanges() { }
    }
}