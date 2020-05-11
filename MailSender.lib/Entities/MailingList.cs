using MailSender.lib.Entities.Base;
using System.Collections.Generic;

namespace MailSender.lib.Entities
{
    public class MailingList : NamedEntity
    {
        public ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();
    }
}
