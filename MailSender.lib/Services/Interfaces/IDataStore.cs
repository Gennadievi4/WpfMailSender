using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    public interface IDataStore<T>
    {
        IEnumerable<T> GetAll();
        void Edit(int Id, T recipient);
        void SaveChanges();
        T GetById(int Id);
        int Create(T T);
        T Remove(int Id);
    }
}
