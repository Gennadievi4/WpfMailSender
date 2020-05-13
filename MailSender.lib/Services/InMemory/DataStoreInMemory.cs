using MailSender.lib.Entities.Base;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MailSender.lib.Services.InMemory
{
    public abstract class DataStoreInMemory<T> : IDataStore<T> where T : BaseEntity
    {
        private readonly List<T> _items;
        protected DataStoreInMemory(List<T> Item = null) => _items = Item ?? new List<T>();
        public int Create(T T)
        {
            if (T is null) throw new ArgumentNullException(nameof(T));
            if (_items.Contains(T)) return T.ID;
            T.ID = _items.Count == 0 ? 1 : _items.Max(x => x.ID) + 1;
            _items.Add(T);
            return T.ID;
        }

        public abstract void Edit(int Id, T recipient);

        public IEnumerable<T> GetAll() => _items;

        public T GetById(int Id) => _items.FirstOrDefault(x => x.ID == Id);

        public T Remove(int Id)
        {
            var item = GetById(Id);
            if (item != null)
                _items.Remove(item);
            return item;
        }
        public void SaveChanges() => Debug.WriteLine("Сохранение изменений в хранилище {0}.", typeof(T));
    }
}
