using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var first_thread = new Thread(FirstThreadMethod);
            first_thread.Start();

            Console.WriteLine("Главный поток завершился!");
            Console.ReadLine();
        }
        public void SendEmails()
        {
            MailMessage ms = new MailMessage("gonzyck@gmail.com", "gonzy@yandex.ru");
            ms.Subject = "Письмо";
            ms.Body = "Получи письмо и отвали от меня.";
            ms.IsBodyHtml = false;
            //ms.Attachments.Add(new Attachment(@"E:\c#\SourceTreeSetup-3.1.3.exe"));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 58);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential();

            try
            {
                smtpClient.Send(ms);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void FirstThreadMethod()
        {
            while (true)
            {
                Console.Title = DateTime.Now.ToString();
                Thread.Sleep(100);
            }
        }
    }
}
