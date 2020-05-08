using MailSender.lib.Entities;
using System.Collections.Generic;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientManager
    {
        IEnumerable<Recipient> GetAll();
        void Add(Recipient recipient);
        void Edit(Recipient recipient);
        void SaveChanges();
    }
}
