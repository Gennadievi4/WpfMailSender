using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTest.Start();
            //ThreadPooltest.Start();
            //SynchronizationTest.Start();
            //TPLtests.Start2();
            //TaskTest.Start();
            //TaskTest.StartAsync();
            TaskTest.StartDataProcessAsync();
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
    }
}
