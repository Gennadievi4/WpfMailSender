using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Mail : BaseEntity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
