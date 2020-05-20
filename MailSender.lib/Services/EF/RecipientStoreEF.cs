using MailSender.lib.Data.EF;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services.EF
{
    public class RecipientStoreEF : IRecipientStore
    {
        private readonly MailSenderDB _db;
        public RecipientStoreEF(MailSenderDB dB) => _db = dB;
        public int Create(Recipient item)
        {
            _db.Recipients.Add(item);
            SaveChanges();
            return item.ID;
        }

        public void Edit(int Id, Recipient item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(Id);
            db_item.Name = item.Name;
            db_item.Adress = item.Adress;
            SaveChanges();
        }

        public IEnumerable<Recipient> GetAll() => _db.Recipients.AsEnumerable();
        public Recipient GetById(int Id) => _db.Recipients.FirstOrDefault(x => x.ID == Id);

        public Recipient Remove(int Id)
        {
            var db_item = GetById(Id);
            if (db_item is null) return null;
            //_db.Recipients.Remove(db_item);
            _db.Entry(db_item).State = EntityState.Deleted;
            return db_item;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
