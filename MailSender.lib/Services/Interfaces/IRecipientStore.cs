using MailSender.lib.Entities;
using System.Collections.Generic;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientStore
    {
        IEnumerable<Recipient> Get();
        void Edit(int Id, Recipient recipient);
        void SaveChanges();
    }
}
