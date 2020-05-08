using MailSender.lib.Data;
using MailSender.lib.Entities;
using System.Collections.Generic;

namespace MailSender.lib.Services
{
    public class RecipientStoreInMemory
    {
        public IEnumerable<Recipient> Get() => TestData.recipients;
    }
}