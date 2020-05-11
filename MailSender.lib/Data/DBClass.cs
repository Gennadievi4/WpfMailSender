using System.Linq;

namespace MailSender.lib.Data
{
    public static class DBClass
    {
        private static readonly Emails emails = new Emails();
        public static IQueryable<Recipients> Emails => from c in emails.Recipients select c;

    }
}
