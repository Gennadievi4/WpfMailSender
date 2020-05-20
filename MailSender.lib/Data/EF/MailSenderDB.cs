using MailSender.lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailSender.lib.Data.EF
{
    public class MailSenderDB : DbContext
    {
        public DbSet<Mail> Mailss { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<ShedullerTask> shedullerTasks { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<MailingList> mailingLists { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public MailSenderDB(DbContextOptions<MailSenderDB> opt) : base(opt) { }
    }
}
