using MailSender.lib.Entities.Base;
using System;

namespace MailSender.lib.Entities
{
    public class ShedullerTask : BaseEntity
    {
        public DateTime Time { get; set; }
        public MailingList Recipients { get; set; }
        public Sender Sender { get; set; }
        public Server Server { get; set; }
        public Mail Mail { get; set; }
    }
}
