using System.Linq;

namespace MailSender.lib.Data
{
    public static class DBClass
    {
        private static readonly Emails emails = new Emails();
        public static IQueryable<Recipient> Emails => from c in emails.Recipient select c;

    }
}
