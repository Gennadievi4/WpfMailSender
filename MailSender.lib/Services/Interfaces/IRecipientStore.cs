using MailSender.lib.Entities;
using System.Collections.Generic;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientStore
    {
        IEnumerable<Recipient> GetAll();
        Recipient GetById(int Id);
        int Create(Recipient recipient);
        void Edit(int Id, Recipient recipient);
        Recipient Remove(int Id);
        void SaveChanges();
    }
}
