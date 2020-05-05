using MailSender.lib.Entities;
using MailSender.lib.Services;
using System.Collections.Generic;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static List<Server> servers { get; } = new List<Server>
        {
            new Server {Name = "Яндекс", Adress = "smtp.yandex.ru", LogIn = "login yandex", Password = "passwordYandex".Encode(3), Port = 587},
            new Server {Name = "Гугл", Adress = "smtp.gmail.com", LogIn = "login gmail", Password = "passwordGmail".Encode(3), Port = 25},
            new Server {Name = "Mail.ru", Adress = "smtp.mail.ru", LogIn = "login mail", Password = "passwordMail".Encode(3), Port = 587}
        };

        public static List<Sender> senders { get; } = new List<Sender>
        {
            new Sender {Name = "Иванов", Adress = "ivanov@server.ru"},
            new Sender {Name = "Петров", Adress = "petrov@server.ru"},
            new Sender {Name = "Сидоров", Adress = "sidorov@server.ru"}
        };

        public static List<Recipient> recipients { get; } = new List<Recipient>
        {
            new Recipient{Name = "Иванов", Adress = "ivanov@server.ru"},
            new Recipient{Name = "Петров", Adress = "petrov@server.ru"},
            new Recipient{Name = "Сидоров", Adress = "sidorov@server.ru"}
        };
    }
}
