using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class ServerstStoreInMemory : DataStoreInMemory<Server>, IServerStore
    {
        public ServerstStoreInMemory() : base(TestData.servers) { }
        public override void Edit(int Id, Server server)
        {
            var db_server = GetById(Id);
            if (db_server is null) return;

            db_server.Name = server.Name;
            db_server.Adress = server.Adress;
            db_server.LogIn = server.LogIn;
            db_server.Port = server.Port;
            db_server.UseSSL = db_server.UseSSL;
            db_server.Password = server.Password;
        }
    }
}