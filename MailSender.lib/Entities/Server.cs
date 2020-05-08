namespace MailSender.lib.Entities
{
    /// <summary>Почтовый сервер </summary>
    public class Server
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; } = true;
        public string LogIn { get; set; }
        public string Password { get; set; }
    }
}
