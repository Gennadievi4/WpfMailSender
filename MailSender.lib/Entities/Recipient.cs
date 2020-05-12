using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Recipient : PersonEntity
    {
        public override string Name { get; set; }
    }
}